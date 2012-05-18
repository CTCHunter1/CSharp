using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beluga
{
    class DataLocation
    {
        double[] positions;
        int numExposures;

        public DataLocation(double[] positions, int numExposures)
        {
            this.positions = positions;
            this.numExposures = numExposures;
        }

        public double[] Positions
        {
            get
            {
                return (positions);
            }
        }

        public int NumExposures
        {
            get
            {
                return (numExposures);
            }
        }
    }
}
