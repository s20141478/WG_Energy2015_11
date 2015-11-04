using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gas_test2.BLL;
using EAS.Services;

namespace Gas_test2.WinUI.FormView
{
    public partial class AddAlgorithm : Form
    {
        public AddAlgorithm()
        {
            InitializeComponent();
        }

        private void btn_Enter_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() != "" && txtSName.Text.Trim() != "")
                try
                {
                ServiceContainer.GetService<IGasDAL>().InsertData("AddAlgTypeAbl", "AlgName", txtName.Text.Trim(), "ATabName", txtSName.Text.Trim());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("添加异常" + ex.Message);
                    return;
                }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
