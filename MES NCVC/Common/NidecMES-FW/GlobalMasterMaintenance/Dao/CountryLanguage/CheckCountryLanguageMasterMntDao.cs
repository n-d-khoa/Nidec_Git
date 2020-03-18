﻿using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;


namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class CheckCountryLanguageMasterMntDao : AbstractDataAccessObject
    {

        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {

            CountryLanguageVo inVo = (CountryLanguageVo)arg;

            CountryLanguageVo outVo = new CountryLanguageVo();

            StringBuilder sqlQuery = new StringBuilder();

            //create SQL
            sqlQuery.Append("Select Count(*) as CntCount from m_country_language ");

            sqlQuery.Append(" where 1=1 ");

            if (inVo.Country != null)
            {
                sqlQuery.Append(" and UPPER(country) = UPPER(:country)");
            }

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            if (inVo.Country != null)
            {
                sqlParameter.AddParameterString("country", inVo.Country);
            }
            
            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            outVo.AffectedCount = 0;

            while (dataReader.Read())
            {
               outVo.AffectedCount = Convert.ToInt32(dataReader["CntCount"]);
            }

            dataReader.Close();

            return outVo;
        }

 
    }
}
