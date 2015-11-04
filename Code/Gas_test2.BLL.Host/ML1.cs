using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLApp;
namespace Gas_test2.BLL
{
    class ML1
    {
        public double[,] ExeAlgorithm(string algType, double[] inputData)
        {
            MLAppClass matlab1 = new MLAppClass();

            double[,] outputData = new double[inputData.Length, 1];

            if (algType == "bp")
            {
                matlab1.PutWorkspaceData("a", "base", inputData);
                matlab1.Execute("b=2*a");//matlab1.Execute("b=funBP(a)");
                var b = matlab1.GetVariable("b", "base");

                outputData = (double[,])b;
                Console.WriteLine("This is the first algorithm");
                foreach (var i in outputData)
                {
                    Console.Write(i);
                }
            }
            if (algType == "rbf")
            {
                matlab1.PutWorkspaceData("a", "base", inputData);
                matlab1.Execute("b=4*a");//matlab1.Execute("b=funRBF(a)");
                var b = matlab1.GetVariable("b", "base");

                outputData = (double[,])b;
                Console.WriteLine("This is the second algorithm");
                foreach (var i in outputData)
                {
                    Console.Write(i);
                }
            }
            if (algType == "multi_regression")
            {
                matlab1.PutWorkspaceData("a", "base", inputData);
                matlab1.Execute("b=10*a");// matlab1.Execute("b=funMultiRegression(a)");
                var b = matlab1.GetVariable("b", "base");

                outputData = (double[,])b;
                Console.WriteLine("This is the third algorithm");
                foreach (var i in outputData)
                {
                    Console.Write(i);
                }
            }
            if (algType == "BF_RBF_15")
            {
                matlab1.Execute("path(path,'K:\\Users\\kevin\\Desktop\\现有算法\\TestAlg')");
                matlab1.PutWorkspaceData("a", "base", inputData);
                matlab1.Execute("b=BF_RBF_15()");// matlab1.Execute("b=funMultiRegression(a)");
                var b = matlab1.GetVariable("b", "base");

                outputData = (double[,])b;
                //Console.WriteLine("This is the third algorithm");
                //foreach (var i in outputData)
                //{
                //    Console.Write(i);
                //}
            }


            return outputData;

        }
    }
}
