﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PQMDataViewer.Class;
using Npgsql;
using System.Diagnostics;

namespace PQMDataViewer
{
    public partial class DataViewer : Form
    {
        private string SQLConnectString = @"Server=192.168.145.12;Port=5432;UserId=pqm;Password=dbuser;Database=pqmdb;";
        DataTable PQMDataTable = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();

        #region FORM EVENT
        public DataViewer()
        {
            InitializeComponent();
            rbData.Checked = true;
            rbSerial.Checked = true;
            cbProcess.Checked = true;
            cbCheckDate.Checked = true;
        }

        private async void DataViewer_Load(object sender, EventArgs e)
        {
            await GetModel();
        }
        #endregion

        #region BUTTONS EVENT
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Restart();
            Cursor = Cursors.WaitCursor;
            await UpdateGrid(true);
            Cursor = Cursors.Default;
            stopWatch.Stop();
            tsTime.Text = ((double)stopWatch.ElapsedMilliseconds / 1000).ToString("00.##") + " s";
        }

        private void btnExport_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtbarcode.Clear();
            PQMDataTable.Clear();
            dgvData.DataSource = null;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region FIELDS EVENT
        private async void cmbModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            await GetLine(cmbModel.Text);
            await GetProcess(cmbModel.Text);
        }

        private async void cmbProcess_SelectedIndexChanged(object sender, EventArgs e)
        {
            await GetInspect(cmbModel.Text, cmbProcess.Text);
        }
        #endregion

        #region SUBS EVENT
        #region ADD FIELDS DATA
        private async Task GetModel()
        {
            PostgresDatabase database = new PostgresDatabase();
            List<processtbl> listModel = new List<processtbl>();
            string sSQL = "select distinct model from processtbl order by model asc";
            await database.ExecuteReaderAsync(SQLConnectString, sSQL)
                          .ContinueWith(t => this.Invoke((Action)(() => { ModelResult(t.Result); })));
        }

        private async Task GetLine(string inModel)
        {
            PostgresDatabase database = new PostgresDatabase();
            string sSQL = "select distinct line from processtbl where model = @model order by line asc";
            var modelpara = new NpgsqlParameter("@model", inModel);
            await database.ExecuteReaderAsync(SQLConnectString, sSQL, modelpara)
                          .ContinueWith(t => this.Invoke((Action)(() => { LineResult(t.Result); })));
        }

        private async Task GetProcess(string inModel)
        {
            PostgresDatabase database = new PostgresDatabase();
            string sSQL = "select distinct process from processtbl where model = @model order by process asc";
            var modelpara = new NpgsqlParameter("@model", inModel);
            await database.ExecuteReaderAsync(SQLConnectString, sSQL, modelpara)
                          .ContinueWith(t => this.Invoke((Action)(() => { ProcessResult(t.Result); })));
        }

        private async Task GetInspect(string inModel, string inProcess)
        {
            PostgresDatabase database = new PostgresDatabase();
            string sSQL = "select distinct inspect from procinsplink where model = @model and process = @process order by inspect asc";
            var modelpara = new NpgsqlParameter("@model", inModel);
            var processpara = new NpgsqlParameter("@process", inProcess);
            await database.ExecuteReaderAsyncIns(SQLConnectString, sSQL, modelpara, processpara)
                          .ContinueWith(t => this.Invoke((Action)(() => { InspectResult(t.Result); })));
        }

        private void ModelResult(PostgresDatabase.PGDatabaseResult dbResult)
        {
            if (dbResult.Success)
            {
                cmbModel.DataSource = dbResult.Data;
                cmbModel.DisplayMember = "model";
            }
            else
            {
                MessageBox.Show(dbResult.Result);
            }
        }

        private void LineResult(PostgresDatabase.PGDatabaseResult dbResult)
        {
            if (dbResult.Success)
            {
                cmbLine.DataSource = dbResult.Data;
                cmbLine.DisplayMember = "line";
            }
            else
            {
                MessageBox.Show(dbResult.Result);
            }
        }

        private void ProcessResult(PostgresDatabase.PGDatabaseResult dbResult)
        {
            if (dbResult.Success)
            {
                cmbProcess.DataSource = dbResult.Data;
                cmbProcess.DisplayMember = "process";
            }
            else
            {
                MessageBox.Show(dbResult.Result);
            }
        }

        private void InspectResult(PostgresDatabase.PGDatabaseResult dbResult)
        {
            if (dbResult.Success)
            {
                clInspect.Items.Clear();
                clInspect.Items.AddRange(dbResult.Data.Select(x => x.GetType().GetProperty("inspect").GetValue(x)).ToArray());
            }
            else
            {
                MessageBox.Show(dbResult.Result);
            }
        }
        #endregion

        private async Task UpdateGrid(bool isSearch)
        {
            if (isSearch)
            {
                await GetDataTable();
            }
            dgvData.DataSource = PQMDataTable;
            tsRows.Text = dgvData.Rows.Count.ToString();
        }

        private string DefineTableName()
        {
            if (cbCheckDate.Checked)
            {
                string table = string.Empty;
                DateTime date = dtpFromDate.Value;
                DateTime toDate = dtpToDate.Value;
                table = cmbModel.Text + date.ToString("yyyyMM") + ",";
                while (int.Parse(date.ToString("yyyyMM")) < int.Parse(toDate.ToString("yyyyMM")))
                {
                    date = date.AddMonths(1);
                    table = cmbModel.Text + date.ToString("yyyyMM") + ",";
                }
                if (table.Contains(",")) table = table.Remove(table.Length - 1);
                return table;
            }
            else
                return cmbModel.Text + DateTime.Now.ToString("yyyyMM");
        }

        private string SerialString()
        {
            string serno = string.Empty;
            foreach (string line in txtbarcode.Lines)
            {
                serno += "'" + line + "',";
            }
            serno = serno.Remove(serno.Length - 1);
            return serno;
        }

        private string InspectString()
        {
            string inspect = string.Empty;
            if (cbInspect.Checked)
            {
                foreach (string item in clInspect.CheckedItems)
                {
                    inspect += "'" + item + "',";
                }
                inspect = inspect.Remove(inspect.Length - 1);
            }
            else
            {
                foreach (string item in clInspect.Items)
                {
                    inspect += "'" + item + "',";
                }
                inspect = inspect.Remove(inspect.Length - 1);
            }
            return inspect;
        }

        private async Task GetDataTable()
        {
            try
            {
                PostgresDatabase database = new PostgresDatabase();
                string table = DefineTableName();
                string sSQL = "SELECT a.serno, a.lot, a.model, a.site, a.factory, a.line, a.process, a.inspectdate, a.tjudge ";
                sSQL += "FROM " + table + " a WHERE 1=1 ";
                //sSQL += "FROM " + table + " a LEFT JOIN " + table + "data b on a.serno = b.serno and a.inspectdate = b.inspectdate WHERE 1=1 ";
                if (cbLine.Checked) sSQL += "and line ='" + cmbLine.Text + "' ";
                if (cbProcess.Checked) sSQL += "and process ='" + cmbProcess.Text + "' ";
                if (!string.IsNullOrEmpty(txtbarcode.Text))
                {
                    string serno = SerialString();
                    if (rbLot.Checked) sSQL += "and lot in (" + serno + ") ";
                    if (rbSerial.Checked) sSQL += "and serno in (" + serno + ") ";
                }
                if (cbCheckDate.Checked)
                {
                    sSQL += "and inspectdate >= '" + dtpFromDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
                    sSQL += "' and inspectdate <= '" + dtpToDate.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' ";
                }
                sSQL += "ORDER BY inspectdate ASC, serno ASC";
                DataSet results1 = await database.GetDatasetAsync(SQLConnectString, sSQL);
                dt1 = results1.Tables[0];

                if (rbData.Checked)
                    sSQL = "SELECT b.serno, b.inspectdate, b.inspect,  b.inspectdata ";
                if (rbJudge.Checked)
                    sSQL = "SELECT b.serno, b.inspectdate, b.inspect,  b.judge ";
                sSQL += "FROM " + table + "data b WHERE 1=1 ";
                if (!string.IsNullOrEmpty(txtbarcode.Text))
                {
                    string serno = SerialString();
                    if (rbLot.Checked) sSQL += "and lot in (" + serno + ") ";
                    if (rbSerial.Checked) sSQL += "and serno in (" + serno + ") ";
                }
                if (cbInspect.Checked)
                {
                    string inspect = InspectString();
                    sSQL += "and inspect in (" + inspect + ") ";
                }
                if (cbCheckDate.Checked)
                {
                    sSQL += "and inspectdate >= '" + dtpFromDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
                    sSQL += "' and inspectdate <= '" + dtpToDate.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' ";
                }
                sSQL += "ORDER BY inspectdate ASC, serno ASC";

                DataSet results2 = await database.GetDatasetAsync(SQLConnectString, sSQL);
                dt2 = results2.Tables[0];
                DataTable pivot = new DataTable();
                pivot = LinQ_Class.Pivot(dt2, dt2.Columns["inspect"], dt2.Columns[3]);
                PQMDataTable = LinQ_Class.Joined(dt1, pivot);
                MessageBox.Show("Completed!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
    }
}
