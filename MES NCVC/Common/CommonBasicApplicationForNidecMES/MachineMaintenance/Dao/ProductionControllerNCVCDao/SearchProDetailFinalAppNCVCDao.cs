﻿using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Framework;
using System;
using System.Data;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class SearchProDetailFinalAppNCVCDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            ProductionControllerNCVCVo inVo = (ProductionControllerNCVCVo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList<ProductionControllerNCVCVo> voList = new ValueObjectList<ProductionControllerNCVCVo>();
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sql.Append(@"select (fc.dates+fc.times) datetimes, fc.model_cd,fc.line_cd, fc.process_cd, ");
            sql.Append("fc_endplay_small, fc_endplay_big, fc_shaft_scracth, fc_terminal_low, fc_case_scracth_dirty, fc_pinion_worm_ng, fc_shaft_lock, fc_ba_deform, fc_tape_hole_deform, fc_brush_rust, fc_metal_deform_scracth,  fc_washer_tape_hole ");
            sql.Append("from t_ncvc_pdc_fc fc ");
            sql.Append("where fc.line_cd = :line_cd ");
            sql.Append("and fc.dates = :dates ");
            sql.Append("and (fc.times in(select min(times) from t_ncvc_pdc_fc where times between '06:00:00' and '06:55:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd ) ");
            sql.Append("or fc.times in(select max(times) from t_ncvc_pdc_fc where times between '06:00:00' and '07:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or fc.times in(select max(times) from t_ncvc_pdc_fc where times between '07:00:00' and '08:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or fc.times in(select max(times) from t_ncvc_pdc_fc where times between '08:00:00' and '09:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or fc.times in(select max(times) from t_ncvc_pdc_fc where times between '09:00:00' and '10:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or fc.times in(select max(times) from t_ncvc_pdc_fc where times between '10:00:00' and '11:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or fc.times in(select max(times) from t_ncvc_pdc_fc where times between '11:00:00' and '12:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or fc.times in(select max(times) from t_ncvc_pdc_fc where times between '12:00:00' and '13:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or fc.times in(select max(times) from t_ncvc_pdc_fc where times between '13:00:00' and '14:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or fc.times in(select max(times) from t_ncvc_pdc_fc where times between '14:00:00' and '15:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or fc.times in(select max(times) from t_ncvc_pdc_fc where times between '15:00:00' and '16:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or fc.times in(select max(times) from t_ncvc_pdc_fc where times between '16:00:00' and '17:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or fc.times in(select max(times) from t_ncvc_pdc_fc where times between '17:00:00' and '18:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or fc.times in(select max(times) from t_ncvc_pdc_fc where times between '18:00:00' and '19:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or fc.times in(select max(times) from t_ncvc_pdc_fc where times between '19:00:00' and '20:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or fc.times in(select max(times) from t_ncvc_pdc_fc where times between '20:00:00' and '21:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or fc.times in(select max(times) from t_ncvc_pdc_fc where times between '21:00:00' and '22:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or fc.times in(select max(times) from t_ncvc_pdc_fc where times between '22:00:00' and '23:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd)) ");

            sql.Append("or fc.dates-1 =:dates and fc.line_cd = :line_cd ");
            sql.Append("and (fc.times in(select min(times) from t_ncvc_pdc_fc where times between '00:00:00' and '00:55:00' and dates-1 = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or fc.times in(select max(times) from t_ncvc_pdc_fc where times between '00:00:00' and '01:05:00' and dates-1 = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or fc.times in(select max(times) from t_ncvc_pdc_fc where times between '01:00:00' and '02:05:00' and dates-1 = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or fc.times in(select max(times) from t_ncvc_pdc_fc where times between '02:00:00' and '03:05:00' and dates-1 = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or fc.times in(select max(times) from t_ncvc_pdc_fc where times between '03:00:00' and '04:05:00' and dates-1 = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or fc.times in(select max(times) from t_ncvc_pdc_fc where times between '04:00:00' and '05:05:00' and dates-1 = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or fc.times in(select max(times) from t_ncvc_pdc_fc where times between '05:00:00' and '05:35:00' and dates-1 = :dates and line_cd = :line_cd and model_cd = :model_cd)) ");


            sqlParameter.AddParameterString("line_cd", inVo.ProLine);
            sqlParameter.AddParameterDateTime("dates", DateTime.Parse(inVo.Date));
            sqlParameter.AddParameterString("model_cd", inVo.ProModel);

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                ProductionControllerNCVCVo outVo = new ProductionControllerNCVCVo
                {
                    TimeHour = DateTime.Parse(dataReader["datetimes"].ToString()),
                    ProModel = dataReader["model_cd"].ToString(),
                    ProLine = dataReader["line_cd"].ToString(),

                    FC_endplay_small = int.Parse(dataReader["fc_endplay_small"].ToString()),
                    FC_endplay_big = int.Parse(dataReader["fc_endplay_big"].ToString()),
                    FC_shaft_scracth = int.Parse(dataReader["fc_shaft_scracth"].ToString()),
                    FC_terminal_low = int.Parse(dataReader["fc_terminal_low"].ToString()),
                    FC_case_scracth_dirty = int.Parse(dataReader["fc_case_scracth_dirty"].ToString()),
                    FC_pinion_worm_ng = int.Parse(dataReader["fc_pinion_worm_ng"].ToString()),
                    FC_shaft_lock = int.Parse(dataReader["fc_shaft_lock"].ToString()),
                    FC_deform = int.Parse(dataReader["fc_ba_deform"].ToString()),
                    FC_tape_hole_deform = int.Parse(dataReader["fc_tape_hole_deform"].ToString()),
                    FC_brush_rust = int.Parse(dataReader["fc_brush_rust"].ToString()),
                    FC_metal_deform_scracth = int.Parse(dataReader["fc_metal_deform_scracth"].ToString()),
                    FC_washer_tape_hole = int.Parse(dataReader["fc_washer_tape_hole"].ToString()),
                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        } 
    }
}
