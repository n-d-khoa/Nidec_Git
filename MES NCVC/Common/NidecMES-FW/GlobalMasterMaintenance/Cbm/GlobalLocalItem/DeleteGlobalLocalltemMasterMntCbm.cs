﻿using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class DeleteGlobalLocalltemMasterMntCbm : CbmController
    {

        private readonly DataAccessObject deleteGlobalItemMasterMntDao = new DeleteGlobalLocalItemMasterMntDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return deleteGlobalItemMasterMntDao.Execute(trxContext, vo);

        }
    }
}
