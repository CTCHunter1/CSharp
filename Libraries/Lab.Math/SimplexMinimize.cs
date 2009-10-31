using System;
using System.Collections.Generic;
using System.Text;

namespace Lab.Math
{
    public class SimplexMinimize
    {
        public delegate double FunctionDelegate(double [] constants);
        
        /*========================================================
        * SimplexMinimise
        * Minimise function *func by Nelder-Mead Simplex method
        ========================================================*/
        double SimplexMinimise(
                       //C code:  double (*func)(double [],void*),         // function to be minimised
                       FunctionDelegate fdObj, 
                       double [] xInitial,                      // initial search parameters
                       //C code: not needed int     nDim,                            // number of dimensions
                       ref int nMaxIter,                        // maximum iterations.  On return, stores "spare" iterations
                       double  fXTol,                           // parameter termination criterion
                       double  fYTol,                           // function termination criterion
                       //C code: void   *aux                              // auxiliary data for *func
                       double [] xData, 
                       double [] yData)
        {
            // new c# variables
            int nDim = xInitial.Length;

            //===Variables=========================================
            int      i, j;                           // loop counters
            int      nIter;                          // number of iterations
            int      iWorst,iNextWorst,iBest;        // "sorted" indices
            double [,] x = new double[nDim,nDim+1];
            //double **x;                              // simpex vertices' coordinates
            //double  *y;                              // function value at vertices
            double[] y = new double[nDim + 1];
            //double  *xC;                             // centroid coordinates of simplex
            double[] xC = new double[nDim];
            //double  *xTry;                           // try coordinates
            double[] xTry = new double[nDim];
            double   yTry;                           // try function value
            double   xMin, xMax;                     // used during parameter tolerance check
            


            //===Allocate Memory==============================================
            // fVertex: Number of ROWS: nDim+1.  Number of COLUMNS: nDim.
            //x    = (double **) malloc((size_t) ((nDim+1) * sizeof(double *)));
            //x[0] = (double *)  malloc((size_t) ((nDim+1) * nDim * sizeof(double))); // alocate the 2D array
            
            /*
            for(i = 1; i < nDim+1; i++) 
                x[i] = x[i-1] + nDim; // pointer arithmatic ??
            */
            //y    = (double *) malloc((size_t) (nDim + 1) * sizeof(double));
            //xC   = (double *) malloc(nDim * sizeof(double));
            //xTry = (double *) malloc(nDim * sizeof(double));

            //===Create Simplex===============================================
            for(i = 0; i < nDim + 1; i++) {
             for(j = 0; j < nDim; j++) {
                x[i,j] = xInitial[j];
                /* Move vertex along coordinate axis to form simplex.
                The last vertex (i = nDim + 1) is not shifted, since i != j.
                This simplex is particularly unsophisticated, possibly wasteful.*/
                if(i == j) x[i,j] = x[i,j] + 1;
             }

             y[i] = fdObj(x);
             //y[i] = func(x[i], aux);               // calculate function at vertex
            }

            //===Minimization Loop============================================
            for(nIter = 0; nIter < nMaxIter; nIter++) {
             //---Find smallest, next-smallest, and largest vertex----------
             iWorst = (y[0] > y[1]) ? 0 : 1;       // assign default values
             iNextWorst = 1 - iWorst;
             iBest = 0;
             for(i = 0; i < nDim+1; i++) {
                if(y[i] < y[iBest]) iBest = i;     // iBest: smallest function value
                if(y[i] > y[iWorst]) {             // iWorst: largest function value
                   iNextWorst = iWorst;            // iNextWorst: second-largest function value
                   iWorst = i;
                } else if(y[i] > y[iNextWorst] && i != iWorst) {
                   iNextWorst = i;
                }
             }
             //---Check Tolerances---------------------------------------------
             for(j = 0; j < nDim; j++) {           // check tolerance in each dimension
                xMin = xMax = x[0,j];
                for(i = 1; i < nDim+1; i++) {      // get min and max over all points
                   if(x[i,j] < xMin) xMin = x[i,j];
                   if(x[i,j] > xMax) xMax = x[i,j];
                }
                if((xMax - xMin) > fXTol) {        // at the first over tolerance,..
                   j = -1;                         //..set a flag and..
                   break;                          //..exit the checking loop
                }
             }
             /* Check tolerances.  j=-1 ==> fXtol exceeded.  Rest is written as
             dual-end check to avoid necessity of including <math.h>. */
             if((j>-1) || (((y[iWorst] - y[iBest]) < fYTol) && ((y[iBest] - y[iWorst]) > (-fYTol))) ) {
                // if we're done, swap best point into index 0
                for(j=0; j<nDim; j++) {
                   xTry[0] = x[0,j]; x[0,j] = x[iBest,j]; x[iBest,j] = xTry[0];
                }
                yTry = y[0]; y[0] = y[iBest]; y[iBest] = yTry;
                break;
             }

             //---Get face centroid-----------------------------------------
             for(j=0; j<nDim; j++) {               // find centroid in each dimension
                xC[j] = 0.0;
                for(i=0; i<nDim+1; i++) {          // average over all vertices
                   if(i!=iWorst) xC[j] += x[i,j]; // exclude worst point
                }
                xC[j] /= nDim;
             }

             //---Try a reflection---
             for(j=0; j < nDim; j++) xTry[j] = xC[j] + ALPHA * (x[iWorst,j] - xC[j]);
             yTry = func(xTry, aux);
             if(yTry < y[iNextWorst]) {
                // better than what we alread had -- replace worst
                for(j=0; j < nDim; j++) x[iWorst,j] = xTry[j];
                y[iWorst] = yTry;
                if(yTry < y[iBest]) {              // if also better than best, try expansion
                   //--Try expansion---
                   for(j=0; j<nDim; j++) xTry[j] = xC[j] + BETA * (x[iWorst,j] - xC[j]);
                   yTry = func(xTry, aux);
                   if(yTry < y[iBest]) {           // better than best again, keep it
                      for(j=0; j<nDim; j++) x[iWorst,j] = xTry[j];
                   }
                }
             } else {
                // keep reflection if it's better than the worst we had
                if(yTry < y[iWorst]) {
                   for(j=0; j<nDim; j++) x[iWorst,j] = xTry[j];
                   y[iWorst] = yTry;
                }
                //---Try contraction---
                for(j=0; j<nDim; j++) xTry[j] = xC[j] + GAMMA * (x[iWorst,j] - xC[j]);
                yTry = func(xTry, aux);
                if(yTry < y[iWorst]) {             // better than what we had, so keep it
                   for(j=0; j<nDim; j++) x[iWorst,j] = xTry[j];
                   y[iWorst] = yTry;
                } else {
                   //---Failing all those, shrink---
                   for(i=0; i<nDim+1; i++) {
                      if(i != iBest) {
                         for(j=0; j<nDim; j++) x[i][j] = (x[i][j] + x[iBest][j]) / 2.0;
                         y[i] = func(x[i], aux);
                      }
                   }
                }
             }
            }

            //===Prepare for Output===========================================
            nMaxIter = nMaxIter - nIter;           // return number of "spare" iterations
            for(j=0;j<nDim;j++) xInitial[j] = x[0,j]; // return best parameters
            yTry = y[0];                             // return best function value

            //---Free Memory------------------------------------------
            //free(*x);
            //free(x);
            //free(y);
            //free(xC);
            //free(xTry);

            return(yTry);                            // return best function value
            } 

    }
}
