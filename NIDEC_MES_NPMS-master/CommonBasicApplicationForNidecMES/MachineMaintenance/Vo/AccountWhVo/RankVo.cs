﻿using System;
using System.Collections.Generic;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo
{
    public class RankVo : ValueObject
    {
        /// <summary>
        /// get and set RankId
        /// </summary>
        public int RankId { get; set; }

        /// <summary>
        /// get and set RankCode
        /// </summary>
        public string RankCode { get; set; }

        /// <summary>
        /// get and set RankName
        /// </summary>
        public string RankName { get; set; }

        /// <summary>
        /// get and set RegistrationUserCode
        /// </summary>
        public string RegistrationUserCode { get; set; }

        /// <summary>
        /// get and set RegistrationDateTime
        /// </summary>
        public DateTime RegistrationDateTime { get; set; }

        /// <summary>
        /// get and set FactoryCode
        /// </summary>
        public string FactoryCode { get; set; }

        /// <summary>
        /// store AffectedCount
        /// </summary>
        public int AffectedCount { get; set; }

        /// <summary>
        /// list of RankVo
        /// </summary>
        public List<RankVo> RankListVo = new List<RankVo>();

    }
}
