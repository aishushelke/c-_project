﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace MEDICAL
{
   
    public partial class StockReport : Form
    {
        DS.DS_STOCK.StockMst_SelectDataTable SDT = new DS.DS_STOCK.StockMst_SelectDataTable();
        DS.DS_STOCKTableAdapters.StockMst_SelectTableAdapter SAdapter = new DS.DS_STOCKTableAdapters.StockMst_SelectTableAdapter();
        DS.DS_ITEM.StockInMst_SelectDataTable IDT = new MEDICAL.DS.DS_ITEM.StockInMst_SelectDataTable();
        DS.DS_ITEMTableAdapters.StockInMst_SelectTableAdapter IAdapter = new MEDICAL.DS.DS_ITEMTableAdapters.StockInMst_SelectTableAdapter();



        public StockReport()
        {
            InitializeComponent();
        }

        private void btncomsearch_Click(object sender, EventArgs e)
        {
            txtiname.Text = "";
            //SDT = SAdapter.SelectBY_INAME(txtiname.Text);
            IDT = IAdapter.Select_By_CNAME(txtcname.Text);
            GVReports.DataSource = IDT;
        }

        private void btnitemsearch_Click(object sender, EventArgs e)
        {
            txtcname.Text = "";
            //SDT = SAdapter.SelectBY_INAME(txtiname.Text);
            IDT = IAdapter.SelectByINmae(txtiname.Text);
            GVReports.DataSource = IDT;
           
        }

        private void StockReport_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source='.\\SQLEXPRESS';Integrated Security='true';Initial Catalog='MEDICAL'");
            SqlCommand cmd = new SqlCommand("SELECT I_name FROM StockInMst", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            AutoCompleteStringCollection SCollection = new AutoCompleteStringCollection();
            while (reader.Read())
            {
                SCollection.Add(reader.GetString(0));
            }
            txtiname.AutoCompleteCustomSource = SCollection;
            con.Close();

            SqlCommand cmdd = new SqlCommand("SELECT cname FROM companymst", con);
            con.Open();
            SqlDataReader readerr = cmdd.ExecuteReader();
            AutoCompleteStringCollection SCollectionn = new AutoCompleteStringCollection();
            while (readerr.Read())
            {
                SCollectionn.Add(readerr.GetString(0));
            }
            txtcname.AutoCompleteCustomSource = SCollectionn;
            con.Close();
        }
    }
}
