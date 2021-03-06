﻿using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetEmployeeMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            EmployeeVo inVo = (EmployeeVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            //create SQL
            sqlQuery.Append("Select em.employee_cd, em.employee_name, em.department, em.is_active ");
            sqlQuery.Append(" from m_employee em ");
            sqlQuery.Append(" where 1 = 1 ");

            if (inVo.EmployeeCode != null)
            {
                sqlQuery.Append(" and employee_cd like :empcd ");
            }

            if (inVo.EmployeeName != null)
            {
                sqlQuery.Append(" and employee_name like :empname ");
            }

            sqlQuery.Append(" order by em.employee_cd");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            if (inVo.EmployeeCode != null)
            {
                sqlParameter.AddParameterString("empcd", inVo.EmployeeCode + "%");
            }

            if (inVo.EmployeeName != null)
            {
                sqlParameter.AddParameterString("empname", inVo.EmployeeName + "%");
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            EmployeeVo outVo = new EmployeeVo();

            while (dataReader.Read())
            {
                EmployeeVo currOutVo = new EmployeeVo();

                currOutVo.EmployeeCode = ConvertDBNull<string>(dataReader, "employee_cd");
                currOutVo.EmployeeName = ConvertDBNull<string>(dataReader, "employee_name");
                currOutVo.Department = ConvertDBNull<string>(dataReader, "department");
                currOutVo.IsActive = ConvertDBNull<int>(dataReader, "is_active");

                outVo.EmployeeListVo.Add(currOutVo);
            }

            dataReader.Close();

            return outVo;
        }
    }
}
