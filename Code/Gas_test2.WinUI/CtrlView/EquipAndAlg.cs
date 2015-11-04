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
using EAS.Data.Linq;

using Gas_test2.Entities;

using Gas_test2.BLL;

namespace Gas_test2.WinUI.CtrlView
{
    public partial class EquipAndAlg : UserControl
    {
        private DataSet dataset = new DataSet();
        string Alg1 = "BP算法";
        string Alg2 = "RBF算法";
        string Alg3 = "多元线性回归";
        string Alg4 = "多层递阶";

        public EquipAndAlg()
        {
            InitializeComponent();
        }

        private void EquipAndAlg_Load(object sender, EventArgs e)
        {
            FreshCbox();
            FreshTree();
            //FreshDG();
            InitFactor();
            FreshFactor();
        }

        private void InitFactor()
        {
            cbox11.Items.Clear();
            cbox12.Items.Clear();
            cbox13.Items.Clear();
            cbox21.Items.Clear();
            cbox22.Items.Clear();
            cbox23.Items.Clear();
            cbox31.Items.Clear();
            cbox32.Items.Clear();
            cbox33.Items.Clear();
            cbox41.Items.Clear();
            cbox42.Items.Clear();
            cbox43.Items.Clear();
            dataset.Clear();
            
                if (cbox_Eq.Text.Trim() != "")
                {
                    try
                    {
                        dataset = ServiceContainer.GetService<IGasDAL>().QueryData("EquipTypeSlet", "EquipName", cbox_Eq.Text.Trim());
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine("查询异常" + ex.Message);
                        return;
                    }
                    
                    string Factor = dataset.Tables[0].Rows[0]["L1"].ToString() + dataset.Tables[0].Rows[0]["L2"].ToString() + dataset.Tables[0].Rows[0]["L3"].ToString();
                    string[] FactorD = Factor.Split(';');

                    for (int i = 0; i < FactorD.Count() - 1; i++)
                    {
                        cbox11.Items.Add(FactorD[i]);
                        cbox12.Items.Add(FactorD[i]);
                        cbox13.Items.Add(FactorD[i]);
                        cbox21.Items.Add(FactorD[i]);
                        cbox22.Items.Add(FactorD[i]);
                        cbox23.Items.Add(FactorD[i]);
                        cbox31.Items.Add(FactorD[i]);
                        cbox32.Items.Add(FactorD[i]);
                        cbox33.Items.Add(FactorD[i]);
                        cbox41.Items.Add(FactorD[i]);
                        cbox42.Items.Add(FactorD[i]);
                        cbox43.Items.Add(FactorD[i]);
                    }
                }
           
            
        }

        private void FreshFactor()
        {
            dataset.Clear();

            lbl_Alg1.Text = Alg1 + "：";
            lbl_Alg2.Text = Alg2 + "：";
            lbl_Alg3.Text = Alg3 + "：";
            lbl_Alg4.Text = Alg4 + "：";

            
                if (cbox_Eq.Text.Trim() != "")
                {

                    try
                    {
                        dataset = ServiceContainer.GetService<IGasDAL>().QueryData("Factor", "EquipAlgSlet", "EquipName", cbox_Eq.Text.Trim(), "AlgName", Alg1);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine("查询异常" + ex.Message);
                        return;
                    }
                    string Factor;
                    string[] FactorD;
                    if (dataset.Tables[0].Rows.Count != 0)
                    {
                        Factor = dataset.Tables[0].Rows[0][0].ToString();
                        FactorD = Factor.Split(';');
                        for (int i = 0; i < FactorD.Count(); i++)
                        {
                            switch (i)
                            {
                                case 0:
                                    cbox11.Text = FactorD[i];
                                    break;
                                case 1:
                                    cbox12.Text = FactorD[i];
                                    break;
                                case 2:
                                    cbox13.Text = FactorD[i];
                                    break;
                                default:
                                    break;

                            }
                        }
                    }


                    try
                    {
                        dataset = ServiceContainer.GetService<IGasDAL>().QueryData("Factor", "EquipAlgSlet", "EquipName", cbox_Eq.Text.Trim(), "AlgName", Alg2);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("抛出异常" + ex.Message);
                        return;
                    }
                    if (dataset.Tables[0].Rows.Count != 0)
                    {
                        Factor = dataset.Tables[0].Rows[0][0].ToString();
                        FactorD = Factor.Split(';');
                        for (int i = 0; i < FactorD.Count(); i++)
                        {
                            switch (i)
                            {
                                case 0:
                                    cbox21.Text = FactorD[i];
                                    break;
                                case 1:
                                    cbox22.Text = FactorD[i];
                                    break;
                                case 2:
                                    cbox23.Text = FactorD[i];
                                    break;
                                default:
                                    break;

                            }
                        }
                    }

                    try
                    {
                        dataset = ServiceContainer.GetService<IGasDAL>().QueryData("Factor", "EquipAlgSlet", "EquipName", cbox_Eq.Text.Trim(), "AlgName", Alg3);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine("查询异常" + ex.Message);
                        return;
                    }
                    if (dataset.Tables[0].Rows.Count != 0)
                    {
                        Factor = dataset.Tables[0].Rows[0][0].ToString();
                        FactorD = Factor.Split(';');
                        for (int i = 0; i < FactorD.Count(); i++)
                        {
                            switch (i)
                            {
                                case 0:
                                    cbox31.Text = FactorD[i];
                                    break;
                                case 1:
                                    cbox32.Text = FactorD[i];
                                    break;
                                case 2:
                                    cbox33.Text = FactorD[i];
                                    break;
                                default:
                                    break;

                            }
                        }
                    }

                    try
                    {
                        dataset = ServiceContainer.GetService<IGasDAL>().QueryData("Factor", "EquipAlgSlet", "EquipName", cbox_Eq.Text.Trim(), "AlgName", Alg4);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine("查询异常" + ex.Message);
                        return;
                    }
                    if (dataset.Tables[0].Rows.Count != 0)
                    {
                        Factor = dataset.Tables[0].Rows[0][0].ToString();
                        FactorD = Factor.Split(';');
                        for (int i = 0; i < FactorD.Count(); i++)
                        {
                            switch (i)
                            {
                                case 0:
                                    cbox41.Text = FactorD[i];
                                    break;
                                case 1:
                                    cbox42.Text = FactorD[i];
                                    break;
                                case 2:
                                    cbox43.Text = FactorD[i];
                                    break;
                                default:
                                    break;

                            }
                        }
                    }
                }

            
        }


        private void FreshDG()
        {
            /*
            if (cbox_Eq.Text.Trim() != "")
            {
                DataSet datasetAlg = new DataSet();
                datasetAlg = ServiceContainer.GetService<IGasDAL>().QueryData("AlgName","AlgTypeAbl" );

                DG_Alg.Rows.Clear();
                dataset.Clear();
                dataset = ServiceContainer.GetService<IGasDAL>().QueryData("EquipAlgSlet", "EquipName", cbox_Eq.Text.Trim());
                int j = 0;
                foreach (DataRow dr in dataset.Tables[0].Rows)
                {

                    string Factor= dataset.Tables[0].Rows[j]["Factor"].ToString();

                    string[] FactorD = Factor.Split(';');
                    

                    DataGridViewRow row = new DataGridViewRow();
                    DataGridViewComboBoxCell comboxcell0 = new DataGridViewComboBoxCell();
                    for (int i = 0; i < datasetAlg.Tables[0].Rows.Count; i++)
                    {
                        comboxcell0.Items.Add(datasetAlg.Tables[0].Rows[i]["AlgName"]);
                        //comboxcell0.Selected
                    }
                    row.Cells.Add(comboxcell0);
                    //comboxcell0.DisplayMember = dataset.Tables[0].Rows[j]["AlgName"].ToString();
                    comboxcell0.Value = dataset.Tables[0].Rows[j]["AlgName"].ToString();
                    
                    
                    for (int i = 0; i < FactorD.Count() - 1; i++)
                    {
                        DataGridViewComboBoxCell comboxcell = new DataGridViewComboBoxCell();
                        comboxcell.Items.Add(FactorD[i]);
                        //comboxcell.Value=FactorD[i];
                        row.Cells.Add(comboxcell);
                        
                    }
                    

                    DG_Alg.Rows.Add(row);

                    j++;
                }
            }*/
        }

        private void FreshTree()
        {
            DataSet dataset2 = new DataSet();
           
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
                Tree_Alg.Nodes.Clear();
                int j = 0;
                foreach (DataRow dr in dataset.Tables[0].Rows)
                {
                    string equipname = dataset.Tables[0].Rows[j]["EquipName"].ToString();
                    TreeNode tn = Tree_Alg.Nodes.Add(equipname);

                    dataset2.Clear();
                    try
                    {
                    dataset2 = ServiceContainer.GetService<IGasDAL>().QueryData("EquipAlgSlet", "EquipName", equipname);
                     }
                    catch (Exception ex)
                    {
                        Console.WriteLine("查询异常" + ex.Message);
                        return;
                    }
                    int k = 0;
                    foreach (DataRow dr2 in dataset2.Tables[0].Rows)
                    {
                        string Factor;

                        TreeNode tn1 = new TreeNode(dataset2.Tables[0].Rows[k]["AlgName"].ToString());
                        tn.Nodes.Add(tn1);
                        Factor = dataset2.Tables[0].Rows[k]["Factor"].ToString();
                        string[] L1D = Factor.Split(';');
                        for (int i = 0; i < L1D.Count() - 1; i++)
                        {
                            TreeNode tn12 = new TreeNode(L1D[i]);
                            tn1.Nodes.Add(tn12);
                        }


                        k++;
                    }
                    j++;
                }
            
        }




        private void FreshCbox()
        {
            
                cbox_Eq.Items.Clear();
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
                    cbox_Eq.Items.Add(dataset.Tables[0].Rows[j][0]);
                    j++;
                }
                cbox_Eq.SelectedIndex = 0;
            
        }


        private void Tree_Alg_DoubleClick(object sender, EventArgs e)
        {
            FreshTree();
        }

        private void cbox_Eq_SelectedIndexChanged(object sender, EventArgs e)
        {
            //FreshDG();
            InitFactor();
            FreshFactor();
        }

        private void btn_Enter_Click(object sender, EventArgs e)
        {
             
            if (cbox_Eq.Text.Trim() != "")
            {
                //删除行
                try
                {
                ServiceContainer.GetService<IGasDAL>().DeleteData("EquipAlgSlet", "EquipName", cbox_Eq.Text.Trim());
                 }
                catch (Exception ex)
                {
                    Console.WriteLine("删除异常" + ex.Message);
                 }
                //添加
                string Factor = "";

                //Factor = cbox11.Text + ";" + cbox12.Text + ";" + cbox13.Text + ";";
                if (cbox11.Text != "")
                {
                    Factor += Factor + cbox11.Text+";";
                }
                if (cbox12.Text != "")
                {
                    Factor += Factor + cbox12.Text + ";";
                }
                if (cbox13.Text != "")
                {
                    Factor += Factor + cbox13.Text + ";";
                }
                 try
                {
                ServiceContainer.GetService<IGasDAL>().InsertData("EquipAlgSlet", "EquipName", cbox_Eq.Text.Trim(), "AlgName", Alg1, "Factor", Factor);
                }
                 catch (Exception ex)
                 {
                     Console.WriteLine("添加异常" + ex.Message);
                 }

                Factor = cbox21.Text + ";" + cbox22.Text + ";" + cbox23.Text + ";";   
                try
                {
                ServiceContainer.GetService<IGasDAL>().InsertData("EquipAlgSlet", "EquipName", cbox_Eq.Text.Trim(), "AlgName", Alg2, "Factor", Factor); 
                }
                catch (Exception ex)
                 {
                     Console.WriteLine("添加异常" + ex.Message);
                 }
                
                //Factor = cbox31.Text + ";" + cbox32.Text + ";" + cbox33.Text + ";";
                Factor = "";
                if (cbox11.Text != "")
                {
                    Factor += Factor + cbox11.Text + ";";
                }
                if (cbox12.Text != "")
                {
                    Factor += Factor + cbox12.Text + ";";
                }
                if (cbox13.Text != "")
                {
                    Factor += Factor + cbox13.Text + ";";
                }
                try
                {
                    ServiceContainer.GetService<IGasDAL>().InsertData("EquipAlgSlet", "EquipName", cbox_Eq.Text.Trim(), "AlgName", Alg3, "Factor", Factor);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("添加异常" + ex.Message);
                }

                //Factor = cbox41.Text + ";" + cbox42.Text + ";" + cbox43.Text + ";";
                Factor = "";
                if (cbox11.Text != "")
                {
                    Factor += Factor + cbox11.Text + ";";
                }
                if (cbox12.Text != "")
                {
                    Factor += Factor + cbox12.Text + ";";
                }
                if (cbox13.Text != "")
                {
                    Factor += Factor + cbox13.Text + ";";
                }
                try
                {
                    ServiceContainer.GetService<IGasDAL>().InsertData("EquipAlgSlet", "EquipName", cbox_Eq.Text.Trim(), "AlgName", Alg4, "Factor", Factor);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("添加异常" + ex.Message);
                } 

            }
            FreshTree();

        
        
}

        private void cbox11_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbox12_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

