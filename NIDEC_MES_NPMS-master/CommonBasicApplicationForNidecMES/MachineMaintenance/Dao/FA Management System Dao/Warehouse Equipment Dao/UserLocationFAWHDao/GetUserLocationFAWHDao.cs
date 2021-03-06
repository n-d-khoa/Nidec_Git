﻿using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.FA_Management_System_Vo.Warehouse_Equipment_Vo;
using System;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao.FA_Management_System_Dao.Warehouse_Equipment_Dao
{
   public class GetUserLocationFAWHDao: AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            UserLocationFAWHVo inVo = (UserLocationFAWHVo)vo;
            ValueObjectList<UserLocationFAWHVo> voList = new ValueObjectList<UserLocationFAWHVo>();
            StringBuilder sql = new StringBuilder();
            //CREATE SQL ADAPTER AND PARAMETER LIST
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("select user_location_id, user_location_cd, user_location_name from m_user_location where 1=1 ");
            if (!string.IsNullOrEmpty(inVo.user_location_cd))
                sql.Append("and user_location_cd ='").Append(inVo.user_location_cd).Append("' ");
            if (!string.IsNullOrEmpty(inVo.user_location_name))
                sql.Append("and user_location_name ='").Append(inVo.user_location_name).Append("' ");
            sql.Append("order by user_location_id");
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());
            sql.Clear();
            //EXECUTE READER FROM COMMAND
            IDataReader datareader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);
            while (datareader.Read())
            {
                UserLocationFAWHVo outVo = new UserLocationFAWHVo
                {
                    user_location_id = (int)datareader["user_location_id"],
                    user_location_cd = datareader["user_location_cd"].ToString(),
                    user_location_name = datareader["user_location_name"].ToString()
                };
                voList.add(outVo);
            }
            datareader.Close();
            return voList;
        }
    }
}
