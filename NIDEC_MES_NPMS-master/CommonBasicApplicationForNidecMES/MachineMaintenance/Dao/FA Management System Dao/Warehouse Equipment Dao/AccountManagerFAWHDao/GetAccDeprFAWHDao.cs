﻿using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.FA_Management_System_Vo.Warehouse_Equipment_Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao.FA_Management_System_Dao.Warehouse_Equipment_Dao
{
   public class GetAccDeprFAWHDao: AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            AccountManagerFAWHVo inVo = (AccountManagerFAWHVo)vo;
            DataTable dt = new DataTable();
            StringBuilder sql = new StringBuilder();
            //CREATE SQL ADAPTER AND PARAMETER LIST
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("select b.account_code_name, ");
            sql.Append("SUM(c.acquistion_cost) as acquistion_cost, ");
            sql.Append("SUM(a.monthly_depreciation) as monthly_depreciation,");
            sql.Append("SUM(a.current_depreciation) as current_depreciation, ");
            sql.Append("SUM(a.accum_depreciation_now) as accum_depreciation_now, ");
            sql.Append("SUM(a.net_value) as net_value ");
            sql.Append("from t_account_main a ");
            sql.Append("left join m_account_code b on a.account_code_id = b.account_code_id ");
            sql.Append("left join m_asset c on a.asset_id = c.asset_id ");
            sql.Append("group by b.account_code_name");
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());
            sql.Clear();
            //EXECUTE READER FROM COMMAND
            IDataReader datareader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);
            dt.Load(datareader);
            datareader.Close();
            AccountManagerFAWHVo outVo = new AccountManagerFAWHVo()
            {
                table = dt
            };
            return outVo;
        }
    }
}
