using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EAS.Data;
using EAS.Data.ORM;
using EAS.Data.Access;
using EAS.Modularization;
using EAS;
using EAS.Services;
using EAS.Data.Linq;
using Gas_test2.Entities;
using Gas_test2.BLL;

namespace ConsoleApplication1
{
    class Class1
    {
        private DataSet dataset3 = new DataSet();
        public string[] mahsahas()//把所有的设备名称存放到数组中。
        {           
            int j = 0;
            dataset3 = ServiceContainer.GetService<IGasDAL>().QueryTabName();
            string[] equipNum=new string [dataset3.Tables[0].Rows.Count];
            for (int i = 0; i < dataset3.Tables[0].Rows.Count;i++ )
            {
                equipNum[i] = dataset3.Tables[0].Rows[j].ToString();               
            }
            return equipNum;//返回一个数组。
        }
    }
}
