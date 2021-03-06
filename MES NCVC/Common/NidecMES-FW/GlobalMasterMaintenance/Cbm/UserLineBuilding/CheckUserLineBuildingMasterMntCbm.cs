﻿using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CheckUserLineBuildingMasterMntCbm : CbmController
    {

        private readonly DataAccessObject checkUserLineBuildingMasterMntDao = new CheckUserLineBuildingMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return checkUserLineBuildingMasterMntDao.Execute(trxContext, vo);

        }
    }
}
