using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Lab.FileIO
{
    // Created by: G. Futia
    // Description: Wraps MatlabIO written by P.Schlup
    // provides c# .MAT file writting functionality
    public class MATLABIO : IDisposable
    {
        public IntPtr fileHandle = IntPtr.Zero;

        public MATLABIO(string fileName)
        {
            fileHandle = WriteMatlabOpen(fileName);
        }

        #region IDisposable Members
        void IDisposable.Dispose()
        {
            WriteClose();
        }
        #endregion

        public void Write1DReal(string variableName, double[] realArr)
        {
            if (realArr == null || variableName == null || fileHandle == IntPtr.Zero)
                return;

            WriteMatlabReal2d(fileHandle, variableName, 1, realArr.Length, realArr);
        }

        public void Write1DComplex(string variableName, double[] realArr, double [] imagArr)
        {
            if (variableName == null || realArr == null || imagArr == null || fileHandle == IntPtr.Zero)
                return;

            // lengths should be equal
            if (realArr.Length != imagArr.Length)
                return;

            // WriteMatlabComplex2D requires a flat array,
            double[] flatArr = new double[realArr.Length * 2];
            int flatIndex = 0;

            for (int i = 0; i < realArr.Length; i++)
            {
                flatArr[flatIndex] = realArr[i];
                flatIndex++;
                flatArr[flatIndex] = imagArr[i];
                flatIndex++;
            }
            
            // write to the file
            WriteMatlabComplex2d(fileHandle, variableName, 1, realArr.Length, flatArr);
        }

        public void Write2DReal(string variableName, double[,] array)
        {
            // convention is [rows,columns]
            if (variableName == null || array == null || fileHandle == IntPtr.Zero)
                return;

            // the static function WriteMatlabReal2d takes linear single array
            double [] flatArray = new double[array.GetLength(0)*array.GetLength(1)];
            int flatIndex = 0;
            
            
            for (int j = 0; j < array.GetLength(1); j++)
            {
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    flatArray[flatIndex] = array[i, j];
                    flatIndex++;
                }
            }
            
            WriteMatlabReal2d(fileHandle, variableName, array.GetLength(0), array.GetLength(1), flatArray);
        }

        public void Write2dComplex(string variableName, double[,] realArr, double[,] imagArr)
        {
            if (realArr == null || imagArr == null || fileHandle == IntPtr.Zero)
            {
                return;
            }

            // the complex array must be equal in size to the real array
            if (realArr.GetLength(0) != imagArr.GetLength(0) ||
                realArr.GetLength(1) != imagArr.GetLength(1))
            {
                return;
            }

            // WriteMatlabComplex2D takes a flat double array
            // *2 because it's complex
            double[] flatArr = new double[realArr.GetLength(0) * realArr.GetLength(1) * 2];
            int flatIndex = 0;
            // copy into the flatArr
            for(int j = 0; j < realArr.GetLength(1); j++)
            {
                for (int i = 0; i < realArr.GetLength(0); i++)
                {
        
                flatArr[flatIndex] = realArr[i,j];
                flatIndex++;
                flatArr[flatIndex] = imagArr[i,j];
                flatIndex++;
                }
            }
          

            // call the dll write function
            WriteMatlabComplex2d(fileHandle, variableName,
                realArr.GetLength(0), realArr.GetLength(1),
                flatArr);
        }

        public void WriteString(string variableName, string data)
        {
            if (variableName == null || data == null || fileHandle == IntPtr.Zero)
                return;

            WriteMatlabString(fileHandle, variableName, data);
        }

        public void WriteClose()
        {
            if (fileHandle == IntPtr.Zero)
                return;

            WriteMatlabClose(fileHandle);
            fileHandle = IntPtr.Zero;
        }

        [DllImport("Lab.FileIO.MATLABIO.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr WriteMatlabOpen(string fileName); // open a MATLAB file
        
        [DllImport("Lab.FileIO.MATLABIO.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void WriteMatlabComplex2d(IntPtr fileHandle, string variableName, int row, int column, double[] data);

        [DllImport("Lab.FileIO.MATLABIO.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void WriteMatlabReal2d(IntPtr fileHandle, string variableName, int numRows, int numColumns, double[] data);
        
        [DllImport("Lab.FileIO.MATLABIO.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void WriteMatlabString(IntPtr fileHandle, string variableName,  string data);

        [DllImport("Lab.FileIO.MATLABIO.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void WriteMatlabClose(IntPtr fileHandle); // close the file   

}
}
