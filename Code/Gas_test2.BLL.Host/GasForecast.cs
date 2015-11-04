using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using EAS.Data.Linq;
using EAS.Data.ORM;
using Gas_test2.Entities;
using EAS.Services;
using Gas_test2.DAL;
using MLApp;

namespace Gas_test2.BLL
{
    [ServiceObject("预测服务")]
    [ServiceBind(typeof(IGasBLL))]
    public class GasForecast : IGasBLL
    {
        private FileClass fileControl = new FileClass();
        private DataClass dataControl = new DataClass();
        System.Threading.Timer Thread_Time;

        public int Forecast()
        {
            Thread_Time = new System.Threading.Timer(Thread_Timer_Method2, null, 0, 2000);  //定时器
            return 0;
        }

        private void Thread_Timer_Method2(object state)
        {
            //定时启动几个线程
            //取数据库数据
            //调用算法计算
            //数据返回数据库
            //释放线程

            ////////////
            testAlg2();
            ///////////

        }

        private void testAlg()
        {
            //////////////////////////////////
            //用来存储算法名字的数组  
            string[] algName = new string[] { "bp", "multi_regression", "rbf" };
            //用来存储算法名字对应数据的数组  
            double[][] inputData = new double[3][] { new double[] { 1, 2, 3, 4, 5 }, new double[] { 2, 4, 6, 8, 10 }, new double[] { 10, 20, 30, 40, 50 } };
            DocumentManager dm = new DocumentManager();
            for (int i = 0; i < inputData.GetLength(0); i++)   //将设备对应的算法名字以及数据加入队列。
            {
                Document doc = new Document(algName[i], inputData[i]);//将文件实例化。
                dm.AddDocument(doc);    //循环的将所有的文件先加入到队列中。

                Thread.Sleep(new Random().Next(20));//延时20ms
            }
            ProcessDocuments.Start(dm);//启动线程
            Thread.Sleep(2000);

            GC.Collect();
            /////////////////////////////////
        }

        private void testAlg2()
        {
            //////////////////////////////////
            //用来存储算法名字的数组  
            string[] algName = new string[] { "BF_RBF_15" };
            //用来存储算法名字对应数据的数组  
            double[][] inputData = new double[1][] { new double[] { 1, 2, 3, 4, 5 } };
            DocumentManager dm = new DocumentManager();
            for (int i = 0; i < inputData.GetLength(0); i++)   //将设备对应的算法名字以及数据加入队列。
            {
                Document doc = new Document(algName[i], inputData[i]);//将文件实例化。
                dm.AddDocument(doc);    //循环的将所有的文件先加入到队列中。

                Thread.Sleep(new Random().Next(20));//延时20ms
            }
            ProcessDocuments.Start(dm);//启动线程
            Thread.Sleep(2000);

            GC.Collect();
            /////////////////////////////////
        }


        //定时启动几个线程
        //private void Thread_Timer_Linshi_Method3()
        //{
        //    double[] data1 = new double[] { -0.9602, -0.5770, -0.0729, 0.3771, 0.6405, 0.6600, 0.4609, 0.1336, -0.2013, -0.4344, -0.5000, -0.3930, -0.1647, -.0988, 0.3072, 0.3960, 0.3449, 0.1816, -0.312, -0.2189, -0.3201 };
        //    double[] data2 = new double[] { 12, 2, -23, 9, -32, 3, 21, 25, -65, -22, -77, 212, -47, 88, 72, 30, 49, 16, -312, -89, -51 };
        //    double[,] outdata1 = new double[21, 1];
        //    double[,] outdata2 = new double[21, 1];

        //    ML1 m1 = new ML1();
        //    ML2 m2 = new ML2();

        //    Parallel.Invoke(
        //        () =>
        //        {

        //            outdata1 = m1.ExeAlgorithm(data1, "bp");
        //            foreach (var item1 in outdata1)
        //            {
        //                double num1 = Math.Round(item1, 4);
        //                Console.WriteLine("This is the first threadProgram.");
        //                Console.WriteLine(num1);
        //            }
        //        },

        //        () =>
        //        {
        //            outdata2 = m2.ExeAlgorithm3(data2, "dbp");
        //            foreach (var item2 in outdata2)
        //            {
        //                double num2 = Math.Round(item2, 4);
        //                Console.WriteLine("This is the  second threadProgram.");
        //                Console.WriteLine(num2);
        //            }

        //        }
        //        );

        //    GC.Collect();
        //    GC.WaitForPendingFinalizers();

        //    Console.WriteLine("The Thread program is end.");
        //}





        public int Forecast(string AlgName)//预测
        {

            #region 参数设定
            int i0 = 100;    //输入行
            int i1 = 1;      //输入列
            int o0 = 10;    //输入行
            int o1 = 1;      //输入列
            float[,] w = new float[i0, i1];


            string FnameI = @"E:\a.txt";
            string FnameO = @"E:\b.txt";

            //DbEntities db = new DbEntities();
            //var t = db.CreateTransaction();
            #endregion


            Thread_Time = new System.Threading.Timer(Thread_Timer_Method, null, 0, 2000);
            ///////查询数据                   


            //数组赋值
            for (int i = 0; i < 100; i++)
            {
                //w[i, 0] = tempList[i].Consumption;
            }

            //数组到txt
            fileControl.saveMatrix(w, FnameO);
            //Matlab运算
            Matlabfunc();
            //读txt到数组
            w = fileControl.readMatrix(o0, o1, FnameI);
            ////////数组到数据库



            //t.Commit();

            //DataSet ds= dataControl.QueryData("","","");
            //ds.Tables[0].Rows[];

            return 0;
        }

        public int StopForecast()
        {
            Thread_Time.Dispose();
            return 0;
        }

        private void Thread_Timer_Method(object state)
        {
            int i = 0;
            i = i + 1;
        }

        /// <summary>
        /// matlab调用
        /// </summary>
        private void Matlabfunc()
        {
            MLApp.MLAppClass matlab = new MLApp.MLAppClass();//调用matlab引擎
            string command;
            //command = "path(path,'E:\\code\\oldGas\\mcd')";
            command = @"path(path,'E:\code\gas_eas\Gas_test2\MATcode\test')";
            matlab.Execute(command);
            //command = "BFGWAVELET";
            command = "LSSVR";
            matlab.Visible = 0;
            matlab.Execute(command);     // 执行Matlab命令
        }



    }
}
