﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YieldMonitor.Model;

namespace YieldMonitor.View
{
    public partial class SettingForm : Form
    {
        public string Model
        {
            get { return lbModel.Text; }
            set { lbModel.Text = value; }
        }
        public List<string> listprocess { get; set; }
        public List<string> listTemp { get; set; }

        public SettingForm()
        {
            listprocess = new List<string>();
            listTemp = new List<string>();
            InitializeComponent();
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            foreach (string item in listTemp)
            {
                lsbBefore.Items.Add(item);
            }
            foreach(string item in listprocess)
            {
                lsbAfter.Items.Add(item);
            }
            lsbAfter.Refresh();
            lsbBefore.Refresh();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //listprocess.Add(lsbBefore.SelectedItem.ToString());
            //listTemp.Remove(lsbBefore.SelectedItem.ToString());
            lsbAfter.Items.Add(lsbBefore.SelectedItem);
            lsbBefore.Items.Remove(lsbBefore.SelectedItem);
            if (lsbBefore.Items.Count > 0)
                lsbBefore.SelectedIndex = 0;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            //listprocess.Remove(lsbAfter.SelectedItem.ToString());
            //listTemp.Add(lsbAfter.SelectedItem.ToString());
            lsbBefore.Items.Add(lsbAfter.SelectedItem);
            lsbAfter.Items.Remove(lsbAfter.SelectedItem);
            if (lsbAfter.Items.Count > 0)
                lsbAfter.SelectedIndex = 0;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            listTemp.Clear();
            listprocess.Clear();
            foreach(string item in lsbBefore.Items)
            {
                listTemp.Add(item);
            }
            foreach (string item in lsbAfter.Items)
            {
                listprocess.Add(item);
            }
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lsbBefore_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsbBefore.SelectedItem != null)
            {
                btnAdd.Enabled = true;
            }
            else
                btnAdd.Enabled = false;
        }

        private void lsbAfter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsbAfter.SelectedItem != null)
            {
                btnRemove.Enabled = true;
            }
            else
                btnRemove.Enabled = false;
        }

        private void btnAddAll_Click(object sender, EventArgs e)
        {
            foreach(string p in listTemp)
            {
                //listprocess.Add(p);
                lsbAfter.Items.Add(p);
            }
            lsbBefore.Items.Clear();
            //listTemp.Clear();
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            foreach (string p in listprocess)
            {
                //listTemp.Add(p);
                lsbBefore.Items.Add(p);
            }
            lsbAfter.Items.Clear();
            //listprocess.Clear();
        }
    }
}
