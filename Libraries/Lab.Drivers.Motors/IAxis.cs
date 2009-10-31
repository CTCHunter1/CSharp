using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Lab.Drivers.Motors
{
    public interface IAxis
    {
        // properties
        double Position
        {
            get;
        }

        double Velocity
        {
            get;
            set;
        }

        string Description
        {
            get;
        }

        // methods
        void MoveAbsolute(double position);
        IAsyncResult BeginMoveAbsolute(double position, AsyncCallback acbObj, Control sender);
        void EndMoveAbsolute(IAsyncResult iascResultObj);
    }
}
