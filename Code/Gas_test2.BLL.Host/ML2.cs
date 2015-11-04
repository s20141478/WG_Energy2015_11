using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLApp;

namespace Gas_test2.BLL
{
    class ML2
    {
        public double[,] ExeAlgorithm3(double[] inputData, string algType)
        {
            MLAppClass matlab2 = new MLAppClass();
            double[,] outputData = new double[inputData.Length, 1];

            if (algType == "dbp")
            {
                matlab2.PutWorkspaceData("n1", "base", inputData);
                matlab2.Execute("n2=funBP(n1)");

                var n = matlab2.GetVariable("n2", "base");

                outputData = (double[,])n;
            }
            return outputData;

        }
    }
}
