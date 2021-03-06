﻿using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class DeleteLineItemCycleTimeMasterMntCbm : CbmController
    {

        private readonly DataAccessObject deleteLineItemCycleTimeMasterMntDao = new DeleteLineItemCycleTimeMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return deleteLineItemCycleTimeMasterMntDao.Execute(trxContext, vo);

        }
    }
}
