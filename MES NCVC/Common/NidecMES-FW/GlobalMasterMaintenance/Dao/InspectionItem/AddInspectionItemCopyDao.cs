﻿using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class AddInspectionItemCopyDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            ValueObjectList<InspectionItemVo> inVo = (ValueObjectList<InspectionItemVo>)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Insert into m_inspection_item");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" inspection_item_cd, ");
            sqlQuery.Append(" inspection_item_name, ");
            sqlQuery.Append(" parent_inspection_item_id, ");
            sqlQuery.Append(" inspection_item_result_input_decimal_digits, ");
            sqlQuery.Append(" inspection_process_id, ");
            sqlQuery.Append(" is_inspection_item_mandatory, ");
            sqlQuery.Append(" is_inspection_employee_mandatory, ");
            sqlQuery.Append(" is_inspection_machine_mandatory, ");
            sqlQuery.Append(" inspection_item_data_type, ");
            sqlQuery.Append(" display_order,");
            sqlQuery.Append(" registration_user_cd, ");
            sqlQuery.Append(" registration_date_time, ");
            sqlQuery.Append(" factory_cd ");
            sqlQuery.Append(" ) ");
            sqlQuery.Append("VALUES	");

            StringBuilder sqlValues = new StringBuilder();
            UserData userdata = trxContext.UserData;

            foreach (InspectionItemVo getItemVo in inVo.GetList())
            {
                if (sqlValues.Length > 0)
                {
                    sqlValues.Append(" , ");
                }

                sqlValues.Append(" (");

                sqlValues.Append("'" + getItemVo.InspectionItemCode + "' ,");
                sqlValues.Append("'" + getItemVo.InspectionItemName + "' ,");
                sqlValues.Append(getItemVo.ParentInspectionItemId + ",");
                sqlValues.Append(getItemVo.InspectionResultItemDecimalDigits + ",");
                sqlValues.Append(getItemVo.InspectionProcessId + ",");
                sqlValues.Append(getItemVo.InspectionItemMandatory + ",");
                sqlValues.Append(getItemVo.InspectionEmployeeMandatory + ",");
                sqlValues.Append(getItemVo.InspectionMachineMandatory + ",");
                sqlValues.Append(getItemVo.InspectionItemDataType + ",");
                sqlValues.Append(getItemVo.DisplayOrder + ",");
                sqlValues.Append("'" + userdata.UserCode + "' ,");
                sqlValues.Append("'" + trxContext.ProcessingDBDateTime + "' ,");
                sqlValues.Append("'" + userdata.FactoryCode + "'");

                sqlValues.Append(" ) ");
            }

            sqlQuery.Append(sqlValues.ToString());

            //sqlQuery.Append(" ( ");
            //sqlQuery.Append(" :inspectionitemcd ,");
            //sqlQuery.Append(" :inspectionitemname ,");

            //if (inVo.ParentInspectionItemId>0)
            //{
            //    sqlQuery.Append(" :parentitemcd ,");
            //}
            //if (inVo.InspectionResultItemDecimalDigits > 0)
            //{
            //    sqlQuery.Append(" :inputdecimaldigits ,");
            //}
            //sqlQuery.Append(" :inspectionprocessid, ");
            //sqlQuery.Append(" :inspectionitemmandatory, ");
            //sqlQuery.Append(" :inspectionemployeemandatory, ");
            //sqlQuery.Append(" :inspectionmachinemandatory, ");
            //sqlQuery.Append(" :inspectionitemdatatype, ");
            //sqlQuery.Append(" :displayorder,");
            //sqlQuery.Append(" :registrationusercode ,");
            //sqlQuery.Append(" :registrationdatetime, ");
            //sqlQuery.Append(" :factorycode ");
            //sqlQuery.Append(" ) ");
            //sqlQuery.Append(" RETURNING inspection_item_id;");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            //sqlParameter.AddParameterString("inspectionitemcd", inVo.InspectionItemCode);
            //sqlParameter.AddParameterString("inspectionitemname", inVo.InspectionItemName);

            //if (inVo.ParentInspectionItemId > 0)
            //{
            //    sqlParameter.AddParameterInteger("parentitemcd", inVo.ParentInspectionItemId);
            //}
            ////else
            ////{
            ////    sqlParameter.AddParameterString("parentitemcd", DBNull.Value);
            ////}
            //sqlParameter.AddParameterInteger("inspectionitemmandatory", inVo.InspectionItemMandatory);
            //sqlParameter.AddParameterInteger("inspectionemployeemandatory", inVo.InspectionEmployeeMandatory);
            //sqlParameter.AddParameterInteger("inspectionmachinemandatory", inVo.InspectionMachineMandatory);
            //sqlParameter.AddParameterInteger("inspectionprocessid", inVo.InspectionProcessId);
            //sqlParameter.AddParameterInteger("inspectionitemdatatype", inVo.InspectionItemDataType);
            //sqlParameter.AddParameterInteger("inputdecimaldigits", inVo.InspectionResultItemDecimalDigits);
            //sqlParameter.AddParameterInteger("displayorder", inVo.DisplayOrder);
            //sqlParameter.AddParameterString("registrationusercode", UserData.GetUserData().UserCode);
            //sqlParameter.AddParameterDateTime("registrationdatetime", trxContext.ProcessingDBDateTime);
            //sqlParameter.AddParameterString("factorycode", UserData.GetUserData().FactoryCode);

            InspectionItemVo outVo = new InspectionItemVo();
            //outVo.InspectionItemId = (int?)sqlCommandAdapter.ExecuteScalar(sqlParameter) ?? 0;
            outVo.InspectionItemId = sqlCommandAdapter.ExecuteNonQuery(sqlParameter);

            return outVo;
        }
    }
}
