﻿using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Framework_Batch.Vo;
using System.Data;

namespace Com.Nidec.Mes.Framework_Batch.Dao
{
    internal class GetBatchProcessDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {

            AddBatchProcessVo inVo = (AddBatchProcessVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            //create SQL
            sqlQuery.Append("SELECT ");
            sqlQuery.Append(" batch_process_cd");
            sqlQuery.Append(" FROM t_batch_process ");
            sqlQuery.Append(" WHERE batch_process_cd = :batchprocesscd ");
            sqlQuery.Append(" AND factory_cd = :factorycd ");
            sqlQuery.Append(" FOR UPDATE ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("batchprocesscd", inVo.BatchProcessCode);
            sqlParameter.AddParameterString("factorycd", trxContext.UserData.FactoryCode);
            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            AddBatchProcessVo outVo = null;

            while (dataReader.Read())
            {
                outVo = new AddBatchProcessVo();
                outVo.BatchProcessCode = ConvertDBNull<string>(dataReader, "batch_process_cd");
            }

            dataReader.Close();

            return outVo;
        }
    }
}
