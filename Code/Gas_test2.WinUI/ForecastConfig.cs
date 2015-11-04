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

namespace Gas_test2.WinUI
{
    [Module("B47CEC4B-CFE9-434C-8097-5F5B1FA7ACA7", "预测参数配置", "FunctionList")]

    public partial class ForecastConfig : UserControl
    {
        private DataSet dataset = new DataSet();
        public ForecastConfig()
        {
            InitializeComponent();
        }

        [ModuleStart]
        public void StartEx()
        {

        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            System.Type T = typeof(ForecastView);
            EAS.Application.Instance.OpenModule(T);
        }

        private void ForecastConfig_Load(object sender, EventArgs e)
        {
            FreshDG();
            FreshCbox();
        }


        private void FreshDG()
        {
            DataSet datasetAlg = new DataSet();
            

            DG_Forecast.Rows.Clear();
            dataset.Clear();
            try
                {
            dataset = ServiceContainer.GetService<IGasDAL>().QueryData("EquipName", "EquipTypeSlet");
                }
            catch (Exception ex)
            {
                Console.WriteLine("查询异常" + ex.Message);
                return;
            }
            int j = 0;
            foreach (DataRow dr in dataset.Tables[0].Rows)
            {



                DataGridViewRow row = new DataGridViewRow();
                DataGridViewTextBoxCell txtboxcell0 = new DataGridViewTextBoxCell();
                txtboxcell0.Value = dataset.Tables[0].Rows[j]["EquipName"];
                row.Cells.Add(txtboxcell0);
                txtboxcell0.ReadOnly = true;

                DataGridViewComboBoxCell comboxcell = new DataGridViewComboBoxCell();
                try
                {
                datasetAlg = ServiceContainer.GetService<IGasDAL>().QueryData("EquipAlgSlet", "EquipName", dataset.Tables[0].Rows[j]["EquipName"].ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("查询异常" + ex.Message);
                    return;
                }
                int i = 0;
                foreach (DataRow dr2 in datasetAlg.Tables[0].Rows)  
                {

                    comboxcell.Items.Add(datasetAlg.Tables[0].Rows[i]["AlgName"]);
                    
                    
                    i++;
                }
                row.Cells.Add(comboxcell);
                
                //comboxcell.DisplayMember=;

                //DataGridViewComboBoxCell comboxcel2 = new DataGridViewComboBoxCell();
                //comboxcel2.Items.Add("5");
                //comboxcel2.Items.Add("10");
                //row.Cells.Add(comboxcel2);
                //comboxcel2.Value = "10";

                //DataGridViewComboBoxCell comboxcel3 = new DataGridViewComboBoxCell();
                //comboxcel3.Items.Add("15");
                //comboxcel3.Items.Add("30");
                //comboxcel3.Items.Add("60");
                //row.Cells.Add(comboxcel3);
                //comboxcel3.Value = "30";

                DG_Forecast.Rows.Add(row);


                j++;
            }
            DG_Forecast.AllowUserToAddRows = false;
        }

        private void FreshCbox()
        {
            cbox_Triger.Items.Clear();
            cbox_Triger.Items.Add("5");
            cbox_Triger.Items.Add("10");
            cbox_Triger.Text = "10";

            cbox_Duration.Items.Clear();
            cbox_Duration.Items.Add("15");
            cbox_Duration.Items.Add("30");
            cbox_Duration.Items.Add("60");
            cbox_Duration.Text = "15";
        }

        private void btn_Enter_Click(object sender, EventArgs e)
        {

        }

       







    }
}
