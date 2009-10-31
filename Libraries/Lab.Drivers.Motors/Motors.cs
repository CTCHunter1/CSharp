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

        IAxis []axes = null;


        public Motors()
        {
            // donno if this should be in the constructor
            FindAxes();
        }

        public void FindAxes()
        {
            zaberAxes = FindZaberMotors();
            newportAxes = FindNewportMotors();

            // figure out if both are attached
            if (zaberAxes == null && newportAxes == null)
            {
               // no motors found
                axes = null;
                return;
            }

            if (zaberAxes == null)
            {
                axes = newportAxes;
                return;
            }

            if (newportAxes == null)
            {
                axes = zaberAxes;
                return;
            }
            
            // both are attached, put them together in the axes list
            int numAxis = newportAxes.Length + zaberAxes.Length;
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
        }

        public NewportESP100Axis[] FindNewportMotors()
        {
            int newportMotorCount = 0;

            try
            {
                if(newportObj == null)
                    newportObj = new NewportESP100();
                
                newportMotorCount = newportObj.Axes.Length;
            }
            catch (Exception ex)
            {

                newportObj = null;
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
            newportObj.Dispose();
            ZaberDLLWrapper.Motor_Exit();
        }

        #endregion
    }
}
