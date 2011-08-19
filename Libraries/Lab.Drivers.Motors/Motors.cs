using System;
using System.Collections.Generic;
using System.Text;

namespace Lab.Drivers.Motors
{
    // this class holds all the axis interfaces present
    public class Motors : IDisposable
    {
        NewportESP100 newportObj = null;
        ZaberTLAAxis [] zaberAxes = null;
        NewportESP100Axis[] newportAxes = null;
        ASILV4000 asilv4000_obj = null;
        ASILV4000Axis[] asilv4000_axes = null;

        IAxis []axes = null;


        public Motors()
        {
            // donno if this should be in the constructor
            FindAxes();           
            
            if (axes == null)
            {
                Exception motorEx = new Exception("No Motors Found");
                throw (motorEx);
            }
        }

        public void FindAxes()
        {
            newportAxes = FindNewportMotors();
            zaberAxes = FindZaberMotors();

            try
            {
                asilv4000_obj = new ASILV4000();
                // found a controller
                asilv4000_axes = asilv4000_obj.GetAxes();

            }
            catch { }

            // figure out if both are attached
            if (zaberAxes == null && newportAxes == null && asilv4000_axes == null)
            {
               // no motors found
                axes = null;
                return;
            }

            if (zaberAxes == null && newportAxes == null && asilv4000_axes != null)
            {
                axes = asilv4000_axes;
                return;
            }

            if (zaberAxes == null && asilv4000_axes == null)
            {
                axes = newportAxes;
                return;
            }

            if (newportAxes == null && asilv4000_axes == null)
            {
                axes = zaberAxes;
                return;
            }            

            // both are attached, put them together in the axes list
            int numAxis = newportAxes.Length + zaberAxes.Length + asilv4000_axes.Length;
            axes = new IAxis[numAxis];

            int axesIndex = 0;
            // copy the newport axes then the zaber axes
            for (int i = 0; i < newportAxes.Length; i++)
            {
                axes[axesIndex] = newportAxes[i];
                axesIndex++;
            } 

            // copy the zaber axes
            for (int i = 0; i < zaberAxes.Length; i++)
            {
                axes[axesIndex] = zaberAxes[i];
                axesIndex++;
            }

            // copy the ASILV4000 axes
            for (int i = 0; i < asilv4000_axes.Length; i++)
            {
                axes[axesIndex] = asilv4000_axes[i];
                axesIndex++;
            }
        }

        public NewportESP100Axis[] FindNewportMotors()
        {
            int newportMotorCount = 0;

            try
            {
                if(newportObj == null)
                    newportObj = new NewportESP100();

                if (newportObj.Axes != null)
                {
                    newportMotorCount = newportObj.Axes.Length;
                }
                else
                {
                    newportMotorCount = 0;
                }
            }
            catch (Exception ex)
            {

                newportObj = null;
                newportMotorCount = 0;
                return (null);
            }

            if (newportMotorCount > 0)
            {
                return (newportObj.Axes);
            }
            
            return (null);                       
        }


        public ZaberTLAAxis[] FindZaberMotors()
        {
            try
            {

                ZaberDLLWrapper.Motor_Init((IntPtr)null, (string)null);
                int numAxis = ZaberDLLWrapper.Motor_NumAxes();

                ZaberTLAAxis[] zaberAxisArr = new ZaberTLAAxis[numAxis];

                // initalize the zaber axes
                for (int i = 0; i < numAxis; i++)
                {
                    zaberAxisArr[i] = new ZaberTLAAxis(i);
                }

                if (numAxis > 0)
                {
                    return (zaberAxisArr);
                }
            }
            catch { };

            // no motors found
            return (null);
        }

        public IAxis[] Axes
        {
            get
            {
                return (axes);
            }
        }



        #region IDisposable Members

        public void Dispose()
        {
            if (newportObj != null)
            {
                newportObj.Dispose();
            }

            try
            {

                ZaberDLLWrapper.Motor_Exit();
            }
                // will throw error if ZaberDLL not found
            catch { }

        }

        #endregion
    }
}
