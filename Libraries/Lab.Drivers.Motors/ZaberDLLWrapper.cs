using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Text;

namespace Lab.Drivers.Motors
{
    public class ZaberDLLWrapper
    {
        // ZaberDLL.dll must be in the executable directory
    
        // DLL Main is called by the DLL loader
        [DllImport("ZaberDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int DLLMain(IntPtr hinstance, long a, IntPtr b);

        // Comments imported from ZaberDLL.cpp, Created By: P. Schlup
        /*********************************************************
        * Motor_Init
        * Initialize the  motor on port pszPort. The  hWnd handle
        * is used as parent window for any error messages and may
        * be NULL.
        * Return value: The function returns  zero on success, or
        * an error code on failure. This is DIFFERENT to the New-
        * port and Zaber motor functions that return a handle. It
        * is hoped that the calling  application does not need to
        * manage handles, although it's  not clear to me how mul-
        * tiple motors will be distinguished.
        *********************************************************/
        [DllImport("ZaberDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Motor_Init(IntPtr hWnd, string pszPort);

        /*********************************************************
        * Motor_Exit
        * Closes the motor port
        *********************************************************/
        [DllImport("ZaberDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Motor_Exit();

        /*********************************************************
        * Motor_Options
        * Displays a dialog box for the given motor type. The di-
        * alog is created as a child window to hWnd, which may be
        * NULL.
        * We'll release the motor during the dialog box in case a
        * different motor is selected.
        *********************************************************/
        [DllImport("ZaberDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Motor_Options(IntPtr hWnd);

        /*********************************************************
        * Motor_About
        * Displays a dialog with information about this DLL.
        *********************************************************/
        [DllImport("ZaberDLL.dll", CallingConvention = CallingConvention.Cdecl)]                      
        public static extern void Motor_About(IntPtr hWnd);

        /*********************************************************
        * Motor_SetVelocity
        *********************************************************/
        [DllImport("ZaberDLL.dll", CallingConvention = CallingConvention.Cdecl)]    
        public static extern void Motor_SetVelocity(double dVel);

        /*********************************************************
        * Motor_SetZero
        *********************************************************/
        [DllImport("ZaberDLL.dll", CallingConvention = CallingConvention.Cdecl)]            
        public static extern void Motor_SetZero();

        /*********************************************************
        * Motor_Goto
        * The position dPos is in units of mm.
        *********************************************************/
        [DllImport("ZaberDLL.dll", CallingConvention = CallingConvention.Cdecl)] 
        public static extern void Motor_Goto(double dPos);
        /*********************************************************
        * Motor_Goto
        * Same as Motor_Goto but doesn't return until the motor is it at the final
        * position. The position dPos is in units of mm.
        *********************************************************/
        [DllImport("ZaberDLL.dll", CallingConvention = CallingConvention.Cdecl)] 
        public static extern void Motor_GotoWait(double dPos);

        /*********************************************************
        * Motor_GetPosition
        *********************************************************/
        [DllImport("ZaberDLL.dll", CallingConvention = CallingConvention.Cdecl)] 
        public static extern double Motor_GetPosition();

        /*********************************************************
        * Motor_GoHome
        * Unlike Goto,  this function  waits until  the motor has
        * finished moving.
        *********************************************************/
        [DllImport("ZaberDLL.dll", CallingConvention = CallingConvention.Cdecl)] 
        public static extern void Motor_GoHome();

        /*********************************************************
        * Motor_GoHardwareLimit
        *********************************************************/
        [DllImport("ZaberDLL.dll", CallingConvention = CallingConvention.Cdecl)] 
        public static extern void Motor_GoHardwareLimit();

        /*********************************************************
        * Motor_NumAxes
        * Returns the number of axes connected
        *********************************************************/
        [DllImport("ZaberDLL.dll", CallingConvention = CallingConvention.Cdecl)] 
        public static extern int Motor_NumAxes();

        /*********************************************************
        * Motor_SetAxis
        * Returns the previously selected axis, or -1 on error.
        * Zaber: The numbering starts at 1, so add unit offset to
        * maintain C/C++-style first index of 0.
        *********************************************************/
        [DllImport("ZaberDLL.dll", CallingConvention = CallingConvention.Cdecl)]         
        public static extern int Motor_SetAxis(int iAxisIn);
        
        // stub this out
        public static double Motor_GetVelocity()
        {
            return (5);
        }

    }
}
