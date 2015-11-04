using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace Gas_test2.BLL
{
    class ProcessDocuments//处理队列中的文件。
    {
        /// <summary>
        /// 单独线程处理队列中的文档
        /// </summary>

        private DocumentManager documentManager;
        public ProcessDocuments(DocumentManager dm)   //这个类的构造函数，dm是构造函数的形参
        {
            this.documentManager = dm;
        }
        public void Run()
        {
            ML1 method = new ML1();
            while (true)
            {
                if (documentManager.IsDoctumentAvailable)  //如果队列不是空队列就执行下面的代码
                {
                    Document doc = documentManager.GetDocument();  //读取队列中的文件

                    string algType = doc.algType;
                    double[] inputData = doc.inputData;
                    double[,] result = method.ExeAlgorithm(algType, inputData);
                    //Console.WriteLine();
                }
                Thread.Sleep(20);//Thread.Sleep(new Random().Next(20));队列中相邻的两个文件的读取间隔20ms.
            }
        }
        public static void Start(DocumentManager dm)   //Start方法外部启动线程
        {
            ProcessDocuments p1 = new ProcessDocuments(dm);
            var t1 = new Thread(p1.Run);
            t1.Start();
        }
    }
   
}
