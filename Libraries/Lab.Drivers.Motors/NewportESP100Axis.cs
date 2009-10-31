using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO.Ports;
using System.Windows.Forms;


namespace Lab.Drivers.Motors
{
    public class NewportESP100Axis : IAxis
    {
        int axisNumber;
        NewportESP100 esp100Obj;

        // axis properties
        string serialNumber;
        string modelNumber;
        double position;
        double velocity;
        double home;


        public NewportESP100Axis(int axisNumber, NewportESP100 esp100Obj)
        {
            this.axisNumber = axisNumber;
            this.esp100Obj = esp100Obj;

            GetAxisParameters();
        }

        private void GetAxisParameters()
        {
            esp100Obj.ReadStageModelAndSerialNumber(axisNumber,out modelNumber,out serialNumber);
            position = esp100Obj.ReadActualPosition(axisNumber);
            velocity = esp100Obj.GetVelocity(axisNumber);
            home = esp100Obj.GetHome(axisNumber);
        }

        public string SerialNumber
        {
            get
            {
                return (serialNumber);
            }
        }

        public string ModelNumber
        {
            get
            {
                return (modelNumber);
            }
        }

        public double Home
        { 
            get
            {
                return (home);
            }
            set
            {
                esp100Obj.DefineHome(axisNumber, value);
                home = value;
            }
        }

        public double Position
        {
            get
            {
                position = esp100Obj.ReadActualPosition(axisNumber);
                return (position);
            }
        }

        public double Velocity
        {
            get
            {
                velocity = esp100Obj.GetVelocity(axisNumber);
                return (velocity);
            }
            set
            {
                esp100Obj.SetVelocity(axisNumber, value);
                velocity = value;
            }
        }

        public string Description
        {
            get
            {
                return("Newport Axis " + axisNumber);
            }
        }

        public override string ToString()
        {
            return Description;
        }

        // this is the synchronous move call 
        public void MoveAbsolute(double position)
        {
            esp100Obj.MotorOn(axisNumber);
            int readTimeout = esp100Obj.ReadTimeout;
            // do the move
            esp100Obj.MoveToAbsolutePosition(axisNumber, position);
            esp100Obj.ReadTimeout = NewportESP100.InfiniteTimeout;
            esp100Obj.WaitForMotionStop(axisNumber, 0);
            bool motionDone = esp100Obj.ReadMotionDoneStatus(axisNumber);
            esp100Obj.ReadTimeout = readTimeout;        // set it back too 100 ms
            this.position = esp100Obj.ReadActualPosition(axisNumber);
            esp100Obj.MotorOff(axisNumber);
        }

        // function pointers are wierd in C#, delegate implementaion wraps them into
        // a psudo object
        private delegate void AsyncMovePointer(double position, AsyncCallback ackObj, Control sender);
        IAsyncResult iAysncResultAbsoluteObj;
        private AsyncMovePointer asyncMovePointerAbsoluteeObj;

        public IAsyncResult BeginMoveAbsolute(double position, AsyncCallback ackObj, Control sender)
        {
            // used to be AsyncMovePointer Here
            asyncMovePointerAbsoluteeObj = new AsyncMovePointer(AsyncMoveAbsolute);
            // Begin Invoke on a delegate takes the delegate parameters followed by the 
            // a callback and then a object array
            // the callback and object array are null, eventhough the move() suports a callback
            // the callback is invoked inside of the MoveAbsolute function so that it can be
            // invoked on the senders thread instead of the new thread creatd in this beginInvoke
            iAysncResultAbsoluteObj = asyncMovePointerAbsoluteeObj.BeginInvoke(position, ackObj, sender, null, null);
            return (iAysncResultAbsoluteObj);                      
        }

        private void AsyncMoveAbsolute(double position, AsyncCallback ackObj, Control sender)
        {
            // this is nearly identical to the MoveAbsolute Call
            esp100Obj.MotorOn(axisNumber);
            int readTimeout = esp100Obj.ReadTimeout;
            // do the move
            esp100Obj.MoveToAbsolutePosition(axisNumber, position);
            esp100Obj.ReadTimeout = NewportESP100.InfiniteTimeout;
            esp100Obj.WaitForMotionStop(axisNumber, 0);

            bool motionDone = esp100Obj.ReadMotionDoneStatus(axisNumber);
            esp100Obj.ReadTimeout = readTimeout;        // set it back too 100 ms

            // call the call back, if there is no callback do nothing
            if ((ackObj != null) && (sender != null))
            {
                sender.BeginInvoke(ackObj, new object[1] { iAysncResultAbsoluteObj });
            }
        }

        public void EndMoveAbsolute(IAsyncResult iAsyncResultObj)
        {
            // stop the motion
            esp100Obj.StopMotion(axisNumber);
            esp100Obj.MotorOff(axisNumber);
            position = esp100Obj.ReadActualPosition(axisNumber);
            asyncMovePointerAbsoluteeObj.EndInvoke(iAsyncResultObj);            
        }        


        // functions to move relative
        public void MoveRelative(double position)
        {
            // do the move
            esp100Obj.MotorOn(axisNumber);
            esp100Obj.MoveToRelativePosition(axisNumber, position);
            esp100Obj.ReadTimeout = NewportESP100.InfiniteTimeout;
            esp100Obj.WaitForMotionStop(axisNumber, 0);
            bool motionDone = esp100Obj.ReadMotionDoneStatus(axisNumber);
            esp100Obj.ReadTimeout = 100;        // set it back too 100 ms
            this.position = esp100Obj.ReadActualPosition(axisNumber);
            esp100Obj.MotorOff(axisNumber);
        }

        private AsyncMovePointer asyncMovePointerRelativeObj;        
        IAsyncResult iAysncResultRelativeObj;
        public IAsyncResult BeginMoveRelative(double position, AsyncCallback ackObj, Control sender)
        {

            asyncMovePointerRelativeObj = new AsyncMovePointer(AsyncMoveRelative);
            // Begin Invoke on a delegate takes the delegate parameters followed by the 
            // a callback and then a object array
            // the callback and object array are null, eventhough the move suports a callback
            // the callback is invoked inside of the MoveAbsolute function so that it can be
            // invoked on the senders thread instead of the new thread creatd in this execution
            iAysncResultRelativeObj = asyncMovePointerRelativeObj.BeginInvoke(position, ackObj, sender, null, null);
            return (iAysncResultAbsoluteObj);
        }

        private void AsyncMoveRelative(double position, AsyncCallback ackObj, Control sender)
        {
            // this is nearly identical to the MoveAbsolute Call
            esp100Obj.MotorOn(axisNumber);
            int readTimeout = esp100Obj.ReadTimeout;
            // do the move
            esp100Obj.MoveToRelativePosition(axisNumber, position);
            esp100Obj.ReadTimeout = NewportESP100.InfiniteTimeout;
            esp100Obj.WaitForMotionStop(axisNumber, 0);

            bool motionDone = esp100Obj.ReadMotionDoneStatus(axisNumber);
            esp100Obj.ReadTimeout = readTimeout;        // set it back too 100 ms

            // call the call back, if there is no callback do nothing
            if ((ackObj != null) && (sender != null))
            {
                sender.BeginInvoke(ackObj, new object[1] { iAysncResultRelativeObj });
            }
        }

        public void EndMoveRelative(IAsyncResult iAsyncResultObj)
        {
            // stop the motion
            esp100Obj.StopMotion(axisNumber);
            esp100Obj.MotorOff(axisNumber);
            position = esp100Obj.ReadActualPosition(axisNumber);
            asyncMovePointerRelativeObj.EndInvoke(iAsyncResultObj);
        }        
    }
}
