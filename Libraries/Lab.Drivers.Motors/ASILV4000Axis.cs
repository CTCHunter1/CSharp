using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab.Drivers.Motors
{

    // AXIS 1 = X axis of XY
    // AXIS 2 = Y axis of XY
    // AXIS 3 = Z Axis on LV4000 Controller
    public class ASILV4000Axis : IAxis
    {
        ASILV4000 asilv4000_obj = null;
        int axisIndex = 0;  // sets how the axis moves  

        // Axis num must be between 1 & 3
        public ASILV4000Axis(int axisNum, ASILV4000 asilv4000_obj)
        {
            this.asilv4000_obj = asilv4000_obj;
            Exception ex = null;
            double[] pos = null;

            switch (axisNum)
            {
                case 1:
                    pos = asilv4000_obj.ReadPositionXY();
                    if (pos[0] == 0)
                    {
                        asilv4000_obj.MoveXY(10, 0);
                        pos = asilv4000_obj.ReadPositionXY();
                    }                        
                    if (pos[0] == 0)
                    {
                        ex = new Exception(string.Format("Stage: {0} Not connected to controller", axisNum));
                        throw (ex);
                    }
                    else
                    {
                        axisIndex = axisNum;
                    }
                    break;
                case 2:
                    pos = asilv4000_obj.ReadPositionXY();
                    if (pos[1] == 0)
                    {
                        asilv4000_obj.MoveXY(0, 10);
                        pos = asilv4000_obj.ReadPositionXY();
                    }

                    if (pos[1] == 0)
                    {
                        ex = new Exception(string.Format("Stage: {0} Not connected to controller", axisNum));
                        throw (ex);
                    }
                    else
                    {
                        axisIndex = axisNum;
                    }
                    break;
                case 3:
                    double posZ = asilv4000_obj.ReadPositionZ();
                    if (posZ == 0)
                    {
                        asilv4000_obj.MoveZ(11);
                        posZ = asilv4000_obj.ReadPositionZ();
                    }
                    if (posZ == 0)
                    {
                        ex = new Exception(string.Format("Stage: {0} Does not connected to controller", axisNum));
                        throw (ex);
                    }
                    else
                    {
                        axisIndex = axisNum;
                    }

                    break;
                default:
                    ex = new Exception(string.Format("Axis:{0} Does not exist on Controller", axisNum));
                    throw (ex);                    
            }
        }

        public double Position
        {
            get 
            {
                double posRet = 0;
                switch (axisIndex)
                {
                    case 1:
                        posRet = asilv4000_obj.ReadPositionX();                        
                        break;
                    case 2:
                        posRet = asilv4000_obj.ReadPositionY();                        
                        break;

                    case 3:
                        posRet = asilv4000_obj.ReadPositionZ();
                        break;
                }

                return (posRet);
            }
        }

        public double Velocity
        {
            get
            {
                double velocity = 0;
                switch (axisIndex)
                {

                    case 1:
                        velocity =  asilv4000_obj.ReadSpeedX();
                        break;
                    case 2:
                        velocity = asilv4000_obj.ReadSpeedY();
                        break;
                    case 3:
                        velocity = asilv4000_obj.ReadSpeedZ();
                        break;
                }

                return (velocity);
            }
            set
            {
                switch (axisIndex)
                {

                    case 1:
                        asilv4000_obj.SetSpeedX(value);
                        break;
                    case 2:
                        asilv4000_obj.SetSpeedY(value);
                        break;
                    case 3:
                        asilv4000_obj.SetSpeedZ(value);
                        break;
                }
            }
        }

        public string Description
        {
            get
            {
                switch (axisIndex)
                { 
                    case 1:
                        return ("ASI LV4000 X-Axis");
                    
                    case 2:
                        return ("ASI LV4000 Y-Axis");

                    case 3:
                        return ("ASI LV4000 Z-Axis");
                }

                return ("Axis Not Initalized");
            }
        }

        public override string ToString()
        {
            return Description;
        }

        public void MoveAbsolute(double position)
        {
            switch (axisIndex)
            {

                case 1:
                    asilv4000_obj.MoveX(position);
                    break;
                case 2:
                    asilv4000_obj.MoveY(position);
                    break;
                case 3:
                    asilv4000_obj.MoveZ(position);
                    break;
            }
        }

        public void Halt()
        {
            switch(axisIndex)
            {
                case 1:
                case 2:
                    asilv4000_obj.HaltXY();
                    break;
                case 3:
                    asilv4000_obj.HaltZ();
                    break;
            }
        }

        public IAsyncResult BeginMoveAbsolute(double position, AsyncCallback acbObj, System.Windows.Forms.Control sender)
        {
            throw new NotImplementedException();
        }

        public void EndMoveAbsolute(IAsyncResult iascResultObj)
        {
            throw new NotImplementedException();
        }
    }
}
