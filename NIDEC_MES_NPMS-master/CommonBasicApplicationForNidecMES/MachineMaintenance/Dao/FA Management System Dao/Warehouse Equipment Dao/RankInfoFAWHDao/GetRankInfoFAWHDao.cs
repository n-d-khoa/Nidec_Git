﻿using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.FA_Management_System_Vo.Warehouse_Equipment_Vo;
using System;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao.FA_Management_System_Dao.Warehouse_Equipment_Dao
{
   public class GetRankInfoFAWHDao: AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            RankInfoFAWHVo inVo = (RankInfoFAWHVo)vo;
            ValueObjectList<RankInfoFAWHVo> voList = new ValueObjectList<RankInfoFAWHVo>();
            StringBuilder sql = new StringBuilder();
            //CREATE SQL ADAPTER AND PARAMETER LIST
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("select rank_id, rank_cd, rank_name from m_rank where 1=1 ");
            if (!string.IsNullOrEmpty(inVo.rank_cd))
                sql.Append("and rank_cd='").Append(inVo.rank_cd).Append("' ");
            if (!string.IsNullOrEmpty(inVo.rank_name))
                sql.Append("and rank_name='").Append(inVo.rank_name).Append("' ");
            sql.Append("order by rank_id");
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());
            sql.Clear();
            //EXECUTE READER FROM COMMAND
            IDataReader datareader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);
            while (datareader.Read())
            {
                RankInfoFAWHVo outVo = new RankInfoFAWHVo
                {
                    rank_id = (int)datareader["rank_id"],
                    rank_cd = datareader["rank_cd"].ToString(),
                    rank_name = datareader["rank_name"].ToString()
                };
                voList.add(outVo);
            }
            datareader.Close();
            return voList;
        }
    }
}
