using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gas_test2.BLL
{
    class Document
    {
        /// <summary>
        /// 队列中属性和构造函数设置
        /// </summary>

        public string algType { get; set; }
        public double[] inputData { get; set; }
        public Document(string algType, double[] inputData)
        {
            this.algType = algType;
            this.inputData = inputData;
        }
    }
}
