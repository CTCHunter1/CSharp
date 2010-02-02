using System;
using System.Collections.Generic;
using System.Text;

using Lab.Math.NelderMeadSimplex;

namespace Lab.Math
{
    public class ErfFit
    {
        // this needes to be part of the class to use by the delegate
        private double[] xData;
        private double[] yData;

        double tolerance;
        int maxEvals;
        double[] startingValues;
        double[] startingStep;

        public ErfFit()
        {
            // initalize to usable values
            tolerance = 1E-9;
            maxEvals = 1000;
            startingValues = new double[4] {1, .1, 1.6, 0};
            startingStep = new double[4] { .1, .01, .1, .1 };            
        }

        // fits the constants a,b,c,d function of form y = a*erf((x-c)/b)+d
        public ErfFit(double tolerance, int maxEvals, double[] startingValues, double[] startingStep)
        {
            if (startingStep.Length != 4 || startingValues.Length != 4)
            {
                Exception ex = new Exception("Starting Values and Starting Step must be 4 long");
                throw (ex);
            }

            this.tolerance = tolerance;
            this.maxEvals = maxEvals;
            this.startingValues = startingValues;
            this.startingStep = startingStep;
        }

        public ErfFitResult Fit(double[] xData, double [] yData)
        {
            this.xData = xData;
            this.yData = yData;

            SimplexConstant[] simplexConstants = new SimplexConstant[] {
                new SimplexConstant(startingValues[0], startingStep[0]),
                new SimplexConstant(startingValues[1], startingStep[1]), 
                new SimplexConstant(startingValues[2], startingStep[2]),
                new SimplexConstant(startingValues[3], startingStep[3])};

            ObjectiveFunctionDelegate objFunction = new ObjectiveFunctionDelegate(ErfFunctionFit);
            RegressionResult result = NelderMeadSimplex.NelderMeadSimplex.Regress(simplexConstants, tolerance, maxEvals, objFunction);

            double[] yDataFit = ErfYDataFitResult(result);

            ErfFitResult erfResultObj = new ErfFitResult(result.TerminationReason,
                result.Constants[0],
                result.Constants[1],
                result.Constants[2],
                result.Constants[3],
                result.ErrorValue,
                result.EvaluationCount,
                yDataFit);

            return (erfResultObj);
        }

        private double ErfFunctionFit(double[] constants)
        {
            // check that the constants are of the correct length
            if (constants.Length != 4)
                return (0);

            double sumSquaredError = 0;
            double funcEval = 0;

            // sum the error
            for (int i = 0; i < xData.Length; i++)
            {
                funcEval = constants[0] * SpecialFunction.erf((xData[i] - constants[2]) / constants[1]) + constants[3];

                sumSquaredError += System.Math.Pow(yData[i] - funcEval, 2);
            }

            return sumSquaredError;
        }

        // produces a data series from the fit data parameters
        private double[] ErfYDataFitResult(RegressionResult resultObj)
        {
            double[] yDataFit = new double[xData.Length];

            for (int i = 0; i < xData.Length; i++)
            {
                yDataFit[i] = resultObj.Constants[0] * SpecialFunction.erf((xData[i] - resultObj.Constants[2]) / resultObj.Constants[1]) + resultObj.Constants[3];
            }

            return (yDataFit);
        }
    }
}
