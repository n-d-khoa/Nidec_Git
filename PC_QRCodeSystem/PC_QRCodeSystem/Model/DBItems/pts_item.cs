﻿using System;
using System.ComponentModel;
using System.Data;

namespace PC_QRCodeSystem.Model
{
    /// <summary>
    /// ITEM IN PRODUCTION TRACEBILITY SYSTEM
    /// </summary>
    public class pts_item
    {
        #region ALL FIELDS
        public int item_id { get; set; }
        public int type_id { get; set; }
        public string item_cd { get; set; }
        public string item_name { get; set; }
        public string item_location { get; set; }
        public string item_unit { get; set; }
        public double lot_size { get; set; }
        public double wh_qty { get; set; }
        public double wip_qty { get; set; }
        public double repair_qty { get; set; }
        public string registration_user_cd { get; set; }
        public DateTime registration_date_time { get; set; }
        public BindingList<pts_item> listItems { get; set; }
        public pts_item()
        {
            listItems = new BindingList<pts_item>();
        }
        #endregion

        /// <summary>
        /// Get infomation of an item with item id
        /// </summary>
        /// <param name="itemID">item id</param>
        /// <returns></returns>
        public pts_item GetItem(int itemID)
        {
            //SQL library
            PSQL SQL = new PSQL();
            string query = string.Empty;
            //Open SQL connection
            SQL.Open();
            //SQL query string
            query = "SELECT item_id, type_id, item_cd, item_name, item_location, item_unit, lot_size, wh_qty, wip_qty, ";
            query += "repair_qty, registration_user_cd, registration_date_time FROM pts_item WHERE 1=1 ";
            query += "and item_id = '" + itemID + "' ";
            query += "order by item_id";
            //Execute reader for read database
            IDataReader reader = SQL.Command(query).ExecuteReader();
            query = string.Empty;
            //Get an item
            reader.Read();
            pts_item outItem = new pts_item
            {
                item_id = (int)reader["item_id"],
                type_id = (int)reader["type_id"],
                item_cd = reader["item_cd"].ToString(),
                item_name = reader["item_name"].ToString(),
                item_location = reader["item_location"].ToString(),
                item_unit = reader["item_unit"].ToString(),
                lot_size = (double)reader["lot_size"],
                wh_qty = (double)reader["wh_qty"],
                wip_qty = (double)reader["wip_qty"],
                repair_qty = (double)reader["repair_qty"],
                registration_date_time = (DateTime)reader["registration_date_time"],
                registration_user_cd = reader["registration_user_cd"].ToString()
            };
            reader.Close();
            //Close SQL connection
            SQL.Close();
            return outItem;
        }

        /// <summary>
        /// Get infomation of an item with item code
        /// </summary>
        /// <param name="itemCD">item code</param>
        /// <returns></returns>
        public pts_item GetItem(string itemCD)
        {
            try
            {
                //SQL library
                PSQL SQL = new PSQL();
                string query = string.Empty;
                //Open SQL connection
                SQL.Open();
                //SQL query string
                query = "SELECT item_id, type_id, item_cd, item_name, item_location, item_unit, lot_size, wh_qty, wip_qty, ";
                query += "repair_qty, registration_user_cd, registration_date_time FROM pts_item WHERE 1=1 ";
                query += "and item_cd = '" + itemCD + "' ";
                query += "order by item_id";
                //Execute reader for read database
                IDataReader reader = SQL.Command(query).ExecuteReader();
                query = string.Empty;
                reader.Read();
                //Get an item
                pts_item outItem = new pts_item
                {
                    item_id = (int)reader["item_id"],
                    type_id = (int)reader["type_id"],
                    item_cd = reader["item_cd"].ToString(),
                    item_name = reader["item_name"].ToString(),
                    item_location = reader["item_location"].ToString(),
                    item_unit = reader["item_unit"].ToString(),
                    lot_size = (double)reader["lot_size"],
                    wh_qty = (double)reader["wh_qty"],
                    wip_qty = (double)reader["wip_qty"],
                    repair_qty = (double)reader["repair_qty"],
                    registration_date_time = (DateTime)reader["registration_date_time"],
                    registration_user_cd = reader["registration_user_cd"].ToString()
                };
                reader.Close();
                //Close SQL connection
                SQL.Close();
                return outItem;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get list item
        /// </summary>
        /// <param name="item_code">string.empty if get list without item code</param>
        /// <param name="unit_code">string.empty if get list without unit type</param>
        /// <param name="location_code">string.empty if get list without location type</param>
        /// <param name="typeID">item type id</param>
        public void GetListItems(string item_code, string unit_code, string location_code, int typeID)
        {
            //SQL library
            PSQL SQL = new PSQL();
            string query = string.Empty;
            listItems = new BindingList<pts_item>();
            //Open SQL connection
            SQL.Open();
            //SQL query string
            query = "SELECT item_id, type_id, item_cd, item_name, item_location, item_unit, lot_size, wh_qty, wip_qty, ";
            query += "repair_qty, registration_user_cd, registration_date_time FROM pts_item WHERE 1=1 ";
            if (!string.IsNullOrEmpty(item_code))
                query += "and item_cd = '" + item_code + "' ";
            if (!string.IsNullOrEmpty(unit_code))
                query += "and item_unit = '" + unit_code + "' ";
            if (!string.IsNullOrEmpty(location_code))
                query += "and item_location ='" + location_code + "' ";
            query += "and type_id = '" + typeID + "' ";
            query += "order by item_id";
            //Execute reader for read database
            IDataReader reader = SQL.Command(query).ExecuteReader();
            query = string.Empty;
            while (reader.Read())
            {
                //Get an item
                pts_item outItem = new pts_item
                {
                    item_id = (int)reader["item_id"],
                    type_id = (int)reader["type_id"],
                    item_cd = reader["item_cd"].ToString(),
                    item_name = reader["item_name"].ToString(),
                    item_location = reader["item_location"].ToString(),
                    item_unit = reader["item_unit"].ToString(),
                    lot_size = (double)reader["lot_size"],
                    wh_qty = (double)reader["wh_qty"],
                    wip_qty = (double)reader["wip_qty"],
                    repair_qty = (double)reader["repair_qty"],
                    registration_date_time = (DateTime)reader["registration_date_time"],
                    registration_user_cd = reader["registration_user_cd"].ToString()
                };
                //Add item into list
                listItems.Add(outItem);
            }
            reader.Close();
            //Close SQL connection
            SQL.Close();
        }

        /// <summary>
        /// Get list item
        /// </summary>
        /// <param name="item_code">string.empty if get list without item code</param>
        /// <param name="unit_code">string.empty if get list without unit type</param>
        /// <param name="location_code">string.empty if get list without location type</param>
        public void GetListItems(string item_code, string unit_code, string location_code)
        {
            //SQL library
            PSQL SQL = new PSQL();
            string query = string.Empty;
            listItems = new BindingList<pts_item>();
            //Open SQL connection
            SQL.Open();
            //SQL query string
            query = "SELECT item_id, type_id, item_cd, item_name, item_location, item_unit, lot_size, wh_qty, wip_qty, ";
            query += "repair_qty, registration_user_cd, registration_date_time FROM pts_item WHERE 1=1 ";
            if (!string.IsNullOrEmpty(item_code))
                query += "and item_cd = '" + item_code + "' ";
            if (!string.IsNullOrEmpty(unit_code))
                query += "and item_unit = '" + unit_code + "' ";
            if (!string.IsNullOrEmpty(location_code))
                query += "and item_location='" + location_code + "' ";
            query += "order by item_id";
            //Execute reader for read database
            IDataReader reader = SQL.Command(query).ExecuteReader();
            query = string.Empty;
            while (reader.Read())
            {
                //Get an item
                pts_item outItem = new pts_item
                {
                    item_id = (int)reader["item_id"],
                    type_id = (int)reader["type_id"],
                    item_cd = reader["item_cd"].ToString(),
                    item_name = reader["item_name"].ToString(),
                    item_location = reader["item_location"].ToString(),
                    item_unit = reader["item_unit"].ToString(),
                    lot_size = (double)reader["lot_size"],
                    wh_qty = (double)reader["wh_qty"],
                    wip_qty = (double)reader["wip_qty"],
                    repair_qty = (double)reader["repair_qty"],
                    registration_date_time = (DateTime)reader["registration_date_time"],
                    registration_user_cd = reader["registration_user_cd"].ToString()
                };
                //Add item into list
                listItems.Add(outItem);
            }
            reader.Close();
            //Close SQL connection
            SQL.Close();
        }

        /// <summary>
        /// Get all unit code
        /// </summary>
        /// <returns></returns>
        public void GetListUnit()
        {
            try
            {
                //SQL library
                PSQL SQL = new PSQL();
                string query = string.Empty;
                listItems = new BindingList<pts_item>();
                //Open SQL connection
                SQL.Open();
                //SQL query string
                query = "select distinct item_unit from pts_item order by item_unit";
                //Execute reader for read database
                IDataReader reader = SQL.Command(query).ExecuteReader();
                query = string.Empty;
                while (reader.Read())
                {
                    //Get an item
                    pts_item outItem = new pts_item
                    {
                        item_unit = reader["item_unit"].ToString(),
                    };
                    listItems.Add(outItem);
                }
                reader.Close();
                //Close SQL connection
                SQL.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get all item location
        /// </summary>
        public void GetListLocation()
        {
            try
            {
                //SQL library
                PSQL SQL = new PSQL();
                string query = string.Empty;
                listItems = new BindingList<pts_item>();
                //Open SQL connection
                SQL.Open();
                //SQL query string
                query = "select distinct item_location from pts_item order by item_location";
                //Execute reader for read database
                IDataReader reader = SQL.Command(query).ExecuteReader();
                query = string.Empty;
                while (reader.Read())
                {
                    //Get an item
                    pts_item outItem = new pts_item
                    {
                        item_location = reader["item_location"].ToString(),
                    };
                    listItems.Add(outItem);
                }
                reader.Close();
                //Close SQL connection
                SQL.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Add an item into database
        /// </summary>
        /// <param name="inItem"></param>
        /// <returns></returns>
        public int AddItem(pts_item inItem)
        {
            //SQL library
            PSQL SQL = new PSQL();
            string query = string.Empty;
            //Open SQL connection
            SQL.Open();
            //SQL query string
            query = "INSERT INTO pts_item(type_id, item_cd, item_name, item_location, item_unit, lot_size, registration_user_cd) ";
            query += "VALUES ('" + inItem.type_id + "','" + inItem.item_cd + "','" + inItem.item_name + "','";
            query += inItem.item_location + "','" + inItem.item_unit + "','" + inItem.lot_size + "','";
            query += inItem.registration_user_cd + "')";
            //Execute non query for read database
            int result = SQL.Command(query).ExecuteNonQuery();
            query = string.Empty;
            return result;
        }

        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="inItem"></param>
        /// <returns></returns>
        public int Update(pts_item inItem)
        {
            //SQL library
            PSQL SQL = new PSQL();
            string query = string.Empty;
            //Open SQL connection
            SQL.Open();
            //SQL query string
            query = "UPDATE pts_item SET type_id='" + inItem.type_id + "', item_cd='" + inItem.item_cd + "', item_name='";
            query += inItem.item_name + "', item_location='" + inItem.item_location + "', item_unit='" + inItem.item_unit;
            query += "', lot_size ='" + inItem.lot_size + "', wh_qty ='" + inItem.wh_qty + "', wip_qty ='" + inItem.wip_qty;
            query += "', repair_qty ='" + inItem.repair_qty + "', registration_user_cd ='" + inItem.registration_user_cd;
            query += "', registration_date_time = now() where item_id ='" + inItem.item_id + "'";
            //Execute non query for read database
            int result = SQL.Command(query).ExecuteNonQuery();
            query = string.Empty;
            return result;
        }

        /// <summary>
        /// Delete an item
        /// </summary>
        /// <param name="id">item id</param>
        /// <returns></returns>
        public int Delete(int id)
        {
            //SQL library
            PSQL SQL = new PSQL();
            string query = string.Empty;
            //Open SQL connection
            SQL.Open();
            //SQL query string
            query = "DELETE FROM pts_item WHERE item_id ='" + id + "'";
            //Execute non query for read database
            int result = SQL.Command(query).ExecuteNonQuery();
            query = string.Empty;
            return result;

        }
    }
}
