﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Nidec.Mes.Framework;
namespace Com.Nidec.Mes.GlobalMasterMaintenance.Vo
{
    public class EmployeeVo : ValueObject
    {
        /// <summary>
        /// get and set EmployeeCode
        /// </summary>
        public string EmployeeCode { get; set; }

        /// <summary>
        /// get and set EmployeeName
        /// </summary>
        public string EmployeeName { get; set; }

        /// <summary>
        /// get and set EmployeeName
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// get and set EmployeeName
        /// </summary>
        public int IsActive { get; set; }

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
        /// get and set AffectedCount
        /// </summary>
        public int AffectedCount = 0;

        /// <summary>
        /// get and set Mode
        /// </summary>
        public string Mode = string.Empty;

        /// <summary>
        /// get and set list EmployeeVo
        /// </summary>
        public List<EmployeeVo> EmployeeListVo = new List<EmployeeVo>();
    }
}
