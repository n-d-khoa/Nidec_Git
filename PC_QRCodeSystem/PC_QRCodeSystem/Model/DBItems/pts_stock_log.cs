﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_QRCodeSystem.Model
{
    public class pts_stock_log
    {
        #region ALL FIELDS
        public int log_id { get; set; }
        public DateTime log_date { get; set; }
        public string log_action { get; set; }
        public string log_user_cd { get; set; }
        public string stock_id { get; set; }
        public string stock_field { get; set; }
        public string before_value { get; set; }
        public string after_value { get; set; }
        public List<pts_stock_log> listStockLog { get; set; }
        public pts_stock_log()
        {
            listStockLog = new List<pts_stock_log>();
        }
        #endregion

        public void Search(pts_stock_log inItem, DateTime fromDate, DateTime toDate, bool checkDate)
        {
            //SQL library
            PSQL SQL = new PSQL();
            string query = string.Empty;
            //Open SQL connection
            SQL.Open();
            //SQL query string
            query = "SELECT log_id, log_date, log_action, log_user_cd, stock_id, stock_field, before_value, after_value ";
            query += "FROM pts_stock_log WHERE 1=1 ";
            if (checkDate)
            {
                query += "AND log_date >= '" + fromDate.ToString("yyyy-MM--dd HH:mm:ss") + "' ";
                query += "AND log_date <= '" + toDate.ToString("yyyy-MM--dd HH:mm:ss") + "' ";
            }
            if (!string.IsNullOrEmpty(inItem.log_action))
                query += "AND log_action ='" + inItem.log_action + "' ";
            if (!string.IsNullOrEmpty(inItem.log_user_cd))
                query += "AND log_user_cd ='" + inItem.log_user_cd + "' ";
            if (!string.IsNullOrEmpty(inItem.stock_field))
                query += "AND stock_field ='" + inItem.stock_field + "' ";
            query += "ORDER BY log_id";
            //Execute reader for read database
            IDataReader reader = SQL.Command(query).ExecuteReader();
            while (reader.Read())
            {
                pts_stock_log outItem = new pts_stock_log
                {
                    log_id = (int)reader["log_id"],
                    log_date = (DateTime)reader["log_date"],
                    log_action = reader["log_action"].ToString(),
                    log_user_cd = reader["log_user_cd"].ToString(),
                    stock_id = reader["stock_id"].ToString(),
                    stock_field = reader["stock_field"].ToString(),
                    before_value = reader["before_value"].ToString(),
                    after_value = reader["after_value"].ToString(),
                };
                listStockLog.Add(outItem);
            }
            query = string.Empty;
            SQL.Close();
        }
    }
}
