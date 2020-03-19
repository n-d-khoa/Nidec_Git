﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NewModelCheckingResult.Model;
using NewModelCheckingResult.View.Common;

namespace NewModelCheckingResult
{
    public partial class Login : Form
    {
        #region VARIABLE
        m_mes_user mesuser = new m_mes_user();
        m_mes_user_role userrole = new m_mes_user_role();
        m_login_password loginpass = new m_login_password();

       
        #endregion
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
            {
                Version deploy = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion;
                StringBuilder version = new StringBuilder();
                version.Append("VERSION: ");
                version.Append(deploy.Major);
                version.Append("_");
                version.Append(deploy.Build);
                version.Append("_");
                version.Append(deploy.Revision);
                lbVersion.Text = version.ToString();
            }
            txtUsername.Focus();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (ActiveControl == txtUsername)
                {
                    string temp = txtUsername.Text;
                    if (temp.Contains(";"))
                        txtUsername.Text = temp.Split(';')[0];
                    txtpass.Focus();
                    return true;
                }
                else if (ActiveControl == txtpass)
                {
                    btnOK.PerformClick();
                    return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Login_Shown(object sender, EventArgs e)
        {
            timerOnTimeSet.Enabled = false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtUsername.Text))
                {
                    loginpass = loginpass.CheckLogIn(txtUsername.Text, txtpass.Text);
                    if (loginpass.is_online)
                        if (CustomMessageBox.Question("This user is online." + Environment.NewLine + "Are you want re-login?") == DialogResult.No) return;
                    UserData.isOnline = loginpass.LogIO(txtUsername.Text, true);
                    mesuser = mesuser.GetUser(loginpass.user_cd);
                    UserData.onTime = 0;
                    timerOnTimeSet.Enabled = true;
                    UserData.dept = mesuser.dept_cd;
                    UserData.usercode = mesuser.user_cd;
                    UserData.username = mesuser.user_name;
                    UserData.position = mesuser.user_position_cd;
                    UserData.logintime = loginpass.last_login_time;
                    UserData.role_permision = userrole.GetListRole(loginpass.user_cd);
                    //Show main form
                    FormCommon main = new FormCommon();
                    this.Hide();
                    txtpass.Clear();
                    main.ShowDialog();
                    loginpass.LogIO(txtUsername.Text, false);
                    this.Show();
                    this.Focus();
                }
                else
                {
                    CustomMessageBox.Notice("Please fill user code!");
                    txtUsername.Focus();
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
                txtpass.Clear();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timerOnTimeSet_Tick(object sender, EventArgs e)
        {
            UserData.onTime++;
        }
    }
}