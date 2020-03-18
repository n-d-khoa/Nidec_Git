﻿using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class DeleteEquipmentMasterMntCbm : CbmController
    {

        private readonly DataAccessObject deleteEquipmentDao = new DeleteEquipmentMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return deleteEquipmentDao.Execute(trxContext, vo);

        }
    }
}
