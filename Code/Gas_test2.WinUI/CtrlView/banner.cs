using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EAS;
using EAS.Services;
using Gas_test2.BLL;
using Gas_test2.DAL;

namespace Gas_test2.WinUI.CtrlView
{
    public partial class banner : UserControl
    {
        private string bName = "null";   //显示设备的控件名称
        private int bNum = 0;

        public string LabelText //定义设备名称属性；
        {
            get
            {
                return this.lab_Name.Text;//设备名称，例如：电炉煤气柜，高炉煤气柜，焦炉煤气柜
            }
            set
            {
                this.lab_Name.Text = value;
                this.bName = value;//bName就是等于lab_Name.Text的值
            }
        }

        public int UDNum    //设备数量属性
        {
            get
            {
                return int.Parse(this.NoUD.Value.ToString());
            }
            set
            {
                this.NoUD.Value = value;
                //this.bNum = value;  
            }
        }
        public banner()
        {
            InitializeComponent();

        }
        public banner(string name, int num)
        {
            this.bName = name;
            this.bNum = num;
        }
        public void NoUD_ValueChanged(object sender, EventArgs e)
        {
            
            try
            {            
                if (NoUD.Value == 0)
                {
                    MessageBox.Show("友情提示:请输入正确的设备数目");
                    //return;
                }
                //DataClass t1 = new DataClass();
                if (NoUD.Value != 0)
                {
                    ServiceContainer.GetService<IGasDAL>().UpdateData("GasometerType", "GasometerNum", NoUD.Value.ToString(), "GasometerName", lab_Name.Text);
                                                                                                                  
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("更新异常" + ex.Message);
                return;
            }
        }

        private void banner_Load(object sender, EventArgs e)
        {

        }

        private void lab_Name_Click(object sender, EventArgs e)
        {

        }
    }
}
