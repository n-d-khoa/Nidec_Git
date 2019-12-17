﻿using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CheckPaletteMasterMntCbm : CbmController
    {

        private readonly DataAccessObject checkPaletteDao = new CheckPaletteMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return checkPaletteDao.Execute(trxContext, vo);

        }
    }
}
