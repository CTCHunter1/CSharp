using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Text;

namespace MultiOOIDLL_Wrapper
{
    class MultiOOIDLL_Wrapper
    {
        [DllImport("MultiOOIDLL.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int DllMain(IntPtr hinstance, long a, IntPtr b);

        /* int Hardware_Init(HWND hWnd, void *pVoid)
        * -----------------------------------------
        *   hWnd    Parent window handle  for error  messages. If
        *           hWnd is NULL,  the error messages have no pa-
        *           rent.
        *   pVoid   Library-specific parameter, not used here.
        *   Return  Zero if successful, otherwise error code.
        *
        *   Initializes the  spectrometers.  The OOIDRV32.dll  is
        *   loaded, and child processes  are launched to communi-
        *   cate with the enumerated spectrometers.
        *
        *   Error codes returned:
        *     0  Initialization ok.
        *    -1  Failed to load the OOIDRV32.dll library.
        *    -2  The OOIDRV32.dll library  does not export all of
        *        the required  functions. Check the  library ver-
        *        sion.
        *    -3  Failed to find any spectrometers.
        *    99  Failed to  create one  or more  child processes.
        *        Check the version of the MultiOOIDLLModule.
        *   101  Timeout waiting for child module to start up.
        *   102  Timeout waiting  for child module  to read spec-
*        trometer parameters. */
        // Bug: IF called with miss initalized dll doesn't paint correct.        
        [DllImport("MultiOOIDLL.dll", CallingConvention = CallingConvention.Winapi)]
        public static extern int Hardware_Init(IntPtr hWnd, IntPtr pVoid);

        [DllImport("MultiOOIDLL.dll")]
        public static extern bool Hardware_GetCaps(string lpszTitle, int len, int[] pPixel1, int[] pPixel2);

        /*int Hardware_GetAxis(double *pBuf1, int iNum1,
        *      double *pBuf2, int iNum2);
        * int Hardware_GetSpectrum(double *pBuf1, int iNum1,
        *      double *pBuf2, int iNum2);
        * --------------------------------------------------
        *   pBuf1   Buffer to receive  the axis or  spectrum from
        *           the first spectrometer. Can be NULL.
        *   iNum1   Length of buffer pBuf1.
        *   pBuf2   Buffer to receive  the axis or  spectrum from
        *           the second spectrometer. Can be NULL.
        *   iNum2   Length of buffer pBuf2
        *   Return  Hardware_GetAxis: Zero on success
        *           Hardware_GetSpectrum: Number of pixels filled
        *           The return value is not significant. */
        [DllImport("MultiOOIDLL.dll")]
        public static extern int Hardware_GetAxis(double[] ddAx1, int n1, double[] ddAx2, int n2);

        [DllImport("MultiOOIDLL.dll")]
        public static extern int Hardware_GetSpectrum(double[] ddInt1, int n1, double[] ddInt2, int n2);

        [DllImport("MultiOOIDLL.dll")]
        //public static extern int Hardware_GetSpectrumRaw(double **pddSpec, int *piPixel, int iNumBuf);
        public static extern int Hardware_GetSpectrumRaw([In, Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(NestArray_CustomMarshaler))] List<double[]> pddSpec, int[] piPixel, int iNumBuf);

        [DllImport("MultiOOIDLL.dll")]
        public static extern void Hardware_Exit();

        [DllImport("MultiOOIDLL.dll")]
        public static extern void Hardware_About(IntPtr hWnd);

        [DllImport("MultiOOIDLL.dll")]
        public static extern void Hardware_Options(IntPtr hWnd);


        //integration time for every spectrometer connect to pc
        [DllImport("MultiOOIDLL.dll")]
        //public static extern void Hardware_GetIntTime(double *pddIntTime, int iNum);
        public static extern void Hardware_GetIntTime(double[] pddIntTime, int iNum);

        [DllImport("MultiOOIDLL.dll")]
        public static extern void Hardware_SetIntTime(double[] ddIntTime, int iNum);


        // tells how manyt spectrometers are connected
        [DllImport("MultiOOIDLL.dll")]
        //public static extern int Hardware_GetCapsEx(string lpszTitle, size_t len, int *pPixel, int iMaxSpec);
        // string buffer, string length, array of pixel numbers, size of array

        public static extern int Hardware_GetCapsEx(string lpszTitle, int len, int[] pPixel, int iMaxSpec);


        [DllImport("MultiOOIDLL.dll")]
        // public static extern int Hardware_GetAxisEx(double **pddAx, int *pPixel, int iNumBuf);
        // array of arrays, arraries 
        public static extern int Hardware_GetAxisEx([In, Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(NestArray_CustomMarshaler))] List<double[]> pddAx, int[] pPixel, int iNumBuf);


        [DllImport("MultiOOIDLL.dll")]
        //public static extern int Hardware_GetSpectrumEx(double **pddSpec, int *pPixel, int iNumBuf);
        public static extern int Hardware_GetSpectrumEx([In, Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(NestArray_CustomMarshaler))] List<double[]> pddSpec, int[] pPixel, int iNumBuf);


        [DllImport("MultiOOIDLL.dll")]
        public static extern void Hardware_ErrorMessage(IntPtr hWnd, int iErr);
    }
    
    // Compile Note:
    // Unsafe required top use sizeof operator
    // .net framework Marshel.SizeOf does not work 
    unsafe public class NestArray_CustomMarshaler :
        ICustomMarshaler
    {
        public IntPtr MarshalManagedToNative(Object ManagedObj)
        {
            list_arr = (List<double[]>)ManagedObj;
            // allocate the pointer to the pointers for the sub arrays
            IntPtr ptrHead = Marshal.AllocCoTaskMem(sizeof(IntPtr) * list_arr.Count);
            // create a areay of pointers for the jagged array
            ptrArr = new IntPtr[list_arr.Count];

            len = list_arr.Count;
            for (int i = 0; i < len; i++)
            {
                ptrArr[i] = Marshal.AllocCoTaskMem(sizeof(double) * list_arr[i].Length);
                Marshal.Copy(list_arr[i], 0, ptrArr[i], list_arr[i].Length);
            }

            // copy the pointers for each subarray 
            Marshal.Copy(ptrArr, 0, ptrHead, len);

            return (ptrHead);
        }


        public void CleanUpNativeData(IntPtr pNativeData)
        {
            // cleanup the allocated memory
            for (int i = 0; i < len; i++)
            {
                Marshal.FreeCoTaskMem(ptrArr[i]);
            }
        }


        public Object MarshalNativeToManaged(IntPtr pNativeData)
        {
            // cleanup the allocated memory
            for (int i = 0; i < len; i++)
            {
                Marshal.Copy(ptrArr[i], list_arr[i], 0, list_arr[i].Length);
            }

            return (list_arr);
        }

        public void CleanUpManagedData(Object ManagedObj)
        {
            // nothing to do here
            list_arr = null;
            ptrArr = null;
            len = 0;
        }

        public int GetNativeDataSize()
        {
            // some code
            return 0;
        }

        public static ICustomMarshaler GetInstance(string str)
        {
            if (ICustomMarshalerObj == null)
                ICustomMarshalerObj = new NestArray_CustomMarshaler();

            return (ICustomMarshalerObj);
        }

        private static ICustomMarshaler ICustomMarshalerObj = (ICustomMarshaler)null;
        private List<double[]> list_arr = (List<double[]>)null;
        private IntPtr[] ptrArr = (IntPtr[])null;
        private int len = 0;
    };
}
