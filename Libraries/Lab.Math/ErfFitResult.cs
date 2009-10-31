using System;
using System.Collections.Generic;
using System.Text;

namespace Lab.Math
{

    public enum TerminationReason
    {
        MaxFunctionEvaluations,
        Converged,
        Unspecified
    }

    public class ErfFitResult
    {
        private TerminationReason terminationReason;
        private double a, b, c, d;
        private double[] yDataFit;
        private double errorValue;
        private int evaluationCount;

        public ErfFitResult(TerminationReason terminationReason,
                            double a,
                            double b,
                            double c,
                            double d,
                            double errorValue,
                            int evaluationCount,
                            double[] yDataFit)
        {
            this.terminationReason = terminationReason;
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
            this.errorValue = errorValue;
            this.evaluationCount = evaluationCount;
            this.yDataFit = yDataFit;
        }

        // coefficents A,B,C,D are y = a*erf((x-c)/b) + d

        public double A
        {
            get
            {
                return (a);
            }
        }

        public double B
        {
            get
            {
                return (b);
            }
        }

        public double C
        {
            get
            {
                return (c);
            }
        }

        public double D
        {
            get
            {
                return (d);
            }
        }

        public double ErrorValue
        {
            get
            {
                return (errorValue);
            }
        }

        public int EvaluationCount
        {
            get
            {
                return (evaluationCount);
            }
        }

        public TerminationReason TerminationReason
        {
            get
            {
                return (terminationReason);
            }
        }

        public double[] YDataFit
        {
            get
            {
                return (yDataFit);
            }
        }
    }
}
