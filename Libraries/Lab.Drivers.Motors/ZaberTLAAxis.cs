using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Lab.Drivers.Motors
{
    public class ZaberTLAAxis : IAxis
    {
        int axisNumber;
        
        double position;
        double velocity;
        double home;

        public ZaberTLAAxis(int axisNumber)
        {
            this.axisNumber = axisNumber;

            GetAxisParameters();
        }

        private void GetAxisParameters()
        {   
            // make sure the dll is on the right axis
            ZaberDLLWrapper.Motor_SetAxis(axisNumber);

            velocity = ZaberDLLWrapper.Motor_GetVelocity();
            position = ZaberDLLWrapper.Motor_GetPosition();            
        }

        public int AxisNumber
        {
            get 
            {
                return (axisNumber);
            }
        }

        public double Position
        {
            get 
            {
                position = ZaberDLLWrapper.Motor_GetPosition();
                return (position);
            }
        }

        public string Description
        {
            get
            {
                return ("ZaberTLA Axis " + axisNumber);
            }
        }

        public double Velocity
        {
            get 
            {
                return (velocity);
            }
            set
            {
                ZaberDLLWrapper.Motor_SetAxis(axisNumber);
                ZaberDLLWrapper.Motor_SetVelocity(value);
                velocity = value;
            }
        }

        public override string ToString()
        {
            return Description;
        }

        // Syncronous move
        public void MoveAbsolute(double position)
        {
            ZaberDLLWrapper.Motor_SetAxis(axisNumber);
            // do the move
            ZaberDLLWrapper.Motor_GotoWait(position);
            this.position = ZaberDLLWrapper.Motor_GetPosition();            
        }

        // function points are wierd in c#, delegate implementation wraps them into a psudo object
        private delegate void AsyncMovePointer(double position, AsyncCallback ackObj, Control sender);
        IAsyncResult iAsyncResultAbsoluteObj;
        private AsyncMovePointer asyncMovePointerAbsoluteObj;

        public IAsyncResult BeginMoveAbsolute(double position, AsyncCallback ackObj, Control sender)
        {
            asyncMovePointerAbsoluteObj = new AsyncMovePointer(AsyncMoveAbsolute);
            // Begin Invoke on a delegate takes the delegate parameters followed by the 
            // a callback and then a object array
            // the callback and object array are null, eventhough the move() suports a callback
            // the callback is invoked inside of the MoveAbsolute function so that it can be
            // invoked on the senders thread instead of the new thread creatd in this beginInvoke
            iAsyncResultAbsoluteObj = asyncMovePointerAbsoluteObj.BeginInvoke(position, ackObj, sender, null, null);

            return (iAsyncResultAbsoluteObj);
        }

        private void AsyncMoveAbsolute(double position, AsyncCallback ackObj, Control sender)
        {
            ZaberDLLWrapper.Motor_SetAxis(axisNumber);
            ZaberDLLWrapper.Motor_GotoWait(position);   // blocks until the motor is at the final position

            this.position = ZaberDLLWrapper.Motor_GetPosition();

            // call the call back, if there is no call back do nothing
            if ((ackObj != null) && (sender != null))
            {
                sender.BeginInvoke(ackObj, new object[1] { iAsyncResultAbsoluteObj });
            }
        }

        public void EndMoveAbsolute(IAsyncResult iAsyncResultObj)
        {         
            if(iAsyncResultAbsoluteObj != null)
                asyncMovePointerAbsoluteObj.EndInvoke(iAsyncResultObj);
        }

        public void SetZero()
        {
            return;
        }
    }
}
