﻿using System;
using System.Data;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class PaletteForm
    {
        #region Variables

        /// <summary>
        /// datatable for item data
        /// </summary>
        private DataTable areaDatatable;

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(PaletteForm));

        /// <summary>
        ///  get message data
        /// </summary>
        private MessageData messageData;

        #endregion

        #region Constructor

        /// <summary>
        /// constructor of the form
        /// </summary>
        public PaletteForm()
        {
            InitializeComponent();
        }

        #endregion

        #region PrivateMethods

        /// <summary>
        /// Fills all user records to gridview control
        /// </summary>
        private void GridBind(PaletteVo conditionInVo)
        {
            Palette_dgv.DataSource = null;

            try
            {
                PaletteVo outVo = (PaletteVo)base.InvokeCbm(new GetPaletteMasterMntCbm(), conditionInVo, false);

                Palette_dgv.AutoGenerateColumns = false;

                BindingSource bindingSource1 = new BindingSource(outVo.PaletteListVo, null);

                if (bindingSource1 != null && bindingSource1.Count > 0)
                {
                    Palette_dgv.DataSource = bindingSource1;
                }
                else
                {
                    messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                }

                Palette_dgv.ClearSelection();

                Update_btn.Enabled = false;

                Delete_btn.Enabled = false;
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }


        /// <summary>
        /// Creates seacrh condition as per user inputs 
        /// </summary>
        /// <returns>search condition</returns>
        private PaletteVo FormConditionVo()
        {
            PaletteVo inVo = new PaletteVo();

            if (PaletteCode_txt.Text != string.Empty) { inVo.PaletteCode = PaletteCode_txt.Text; }

            if (PaletteName_txt.Text != string.Empty)
            {
                inVo.PaletteName = PaletteName_txt.Text;
            }

            if (Area_cmb.SelectedIndex > -1)
            {
                inVo.AreaId = Convert.ToInt32(Area_cmb.SelectedValue);
            }

            return inVo;

        }


        /// <summary>
        /// Handles Combobox loading for Item
        /// </summary>
        /// <param name="pCombo"></param>
        /// <param name="pDatasource"></param>
        /// <param name="pDisplay"></param>
        /// <param name="pValue"></param>
        private void ComboBind(ComboBox pCombo, DataTable pDatasource, string pDisplay, string pValue)
        {
            pCombo.DataSource = pDatasource;
            pCombo.DisplayMember = pDisplay;
            pCombo.ValueMember = pValue;
            pCombo.SelectedIndex = -1;
            pCombo.Text = string.Empty;

        }

        /// <summary>
        /// selects user record for updation and show user form
        /// </summary>
        private void BindUpdatePaletteData()
        {
            int selectedrowindex = Palette_dgv.SelectedCells[0].RowIndex;

            PaletteVo cavInVo = (PaletteVo)Palette_dgv.Rows[selectedrowindex].DataBoundItem;

            AddPaletteForm newAddForm = new AddPaletteForm(CommonConstants.MODE_UPDATE, cavInVo);

            newAddForm.ShowDialog(this);

            if (newAddForm.IntSuccess > 0)
            {
                messageData = new MessageData("mmci00002", Properties.Resources.mmci00002, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);

                GridBind(FormConditionVo());
            }
            else if (newAddForm.IntSuccess == 0)
            {
                messageData = new MessageData("mmci00007", Properties.Resources.mmci00007, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
                GridBind(FormConditionVo());
            }
        }


        /// <summary>
        /// form country and factory data for combo
        /// </summary>
        private void FormDatatableFromVo()
        {
            areaDatatable = new DataTable();
            areaDatatable.Columns.Add("id");
            areaDatatable.Columns.Add("name");

            try
            {
                AreaVo areaOutVo = (AreaVo)base.InvokeCbm(new GetAreaMasterMntCbm(), new AreaVo(), false);

                foreach (AreaVo area in areaOutVo.AreaListVo)
                {
                    areaDatatable.Rows.Add(area.AreaId, area.AreaName);
                }
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }


        #endregion

        #region FormEvents
        /// <summary>
        /// Loads area form
        /// Fill item combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PaletteForm_Load(object sender, EventArgs e)
        {
            FormDatatableFromVo();

            ComboBind(Area_cmb, areaDatatable, "name", "id");

            PaletteCode_txt.Select();

            Update_btn.Enabled = Delete_btn.Enabled = false;
        }

        #endregion

        #region ButtonClick

        /// <summary>
        /// event to clear the controls of search criteria
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Clear_btn_Click(object sender, EventArgs e)
        {
            PaletteCode_txt.Text = string.Empty;

            PaletteName_txt.Text = string.Empty;

            Area_cmb.SelectedIndex = -1;

            Palette_dgv.DataSource = null;

            PaletteCode_txt.Select();
            Update_btn.Enabled = Delete_btn.Enabled = false;
        }

        /// <summary>
        /// event to get the record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Search_btn_Click(object sender, EventArgs e)
        {
            GridBind(FormConditionVo());
        }

        /// <summary>
        /// event to open the  add screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_btn_Click(object sender, EventArgs e)
        {
            AddPaletteForm newAddForm = new AddPaletteForm(CommonConstants.MODE_ADD, null);

            newAddForm.ShowDialog();

            if (newAddForm.IntSuccess > 0)
            {
                messageData = new MessageData("mmci00001", Properties.Resources.mmci00001, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);

                GridBind(FormConditionVo());
            }
        }

        /// <summary>
        /// event to open the  updatescreen 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Update_btn_Click(object sender, EventArgs e)
        {
            BindUpdatePaletteData();
        }

        /// <summary>
        /// event to delete the selected record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Delete_btn_Click(object sender, EventArgs e)
        {
            int selectedrowindex = Palette_dgv.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = Palette_dgv.Rows[selectedrowindex];

            messageData = new MessageData("mmcc00004", Properties.Resources.mmcc00004, selectedRow.Cells["colPaletteCode"].Value.ToString());
            logger.Info(messageData);
            DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);


            if (dialogResult == DialogResult.OK)
            {
                PaletteVo inVo = new PaletteVo();

                inVo.PaletteId = Convert.ToInt32(selectedRow.Cells["colPaletteId"].Value);


                try
                {
                    PaletteVo outVo = (PaletteVo)base.InvokeCbm(new DeletePaletteMasterMntCbm(), inVo, false);

                    if (outVo.AffectedCount > 0)
                    {
                        messageData = new MessageData("mmci00003", Properties.Resources.mmci00003, null);
                        logger.Info(messageData);
                        popUpMessage.Information(messageData, Text);

                        GridBind(FormConditionVo());
                    }
                    else if (outVo.AffectedCount == 0)
                    {
                        messageData = new MessageData("mmci00007", Properties.Resources.mmci00007, null);
                        logger.Info(messageData);
                        popUpMessage.Information(messageData, Text);
                        GridBind(FormConditionVo());
                    }
                }
                catch (Framework.ApplicationException exception)
                {
                    popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                    logger.Error(exception.GetMessageData());
                }
            }
            else if (dialogResult == DialogResult.Cancel)
            {
                //do something else
            }
        }

        /// <summary>
        /// close form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region ControlEvents

        /// <summary>
        /// Handles user record selection for Update/Delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Palette_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Palette_dgv.SelectedRows.Count > 0)
            {
                Update_btn.Enabled = Delete_btn.Enabled = true;
            }
            else
            {
                Update_btn.Enabled = Delete_btn.Enabled = false;
            }
        }

        /// <summary>
        /// Handles update user form show on row double click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Palette_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Palette_dgv.SelectedRows.Count > 0)
            {
                BindUpdatePaletteData();
            }
        }

        #endregion




    }
}
