using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Nwuram.Framework.Data;
using Nwuram.Framework.Settings.Connection;
using System.Data;
using System.Threading.Tasks;
using Nwuram.Framework.Settings.User;

namespace dllInventoryScaners
{
    class readSQL
    {
        static ArrayList ap = new ArrayList();
        static SqlProvider sql = new SqlProvider(ConnectionSettings.GetServer(), ConnectionSettings.GetDatabase(), ConnectionSettings.GetUsername(), ConnectionSettings.GetPassword(), ConnectionSettings.ProgramName);
        static SqlProvider sql_dop = new SqlProvider(ConnectionSettings.GetServer("2"), ConnectionSettings.GetDatabase("2"), ConnectionSettings.GetUsername(), ConnectionSettings.GetPassword(), ConnectionSettings.ProgramName);

        /// <summary>
        /// Получение сотрудника по коду бейджика
        /// </summary>        
        /// <returns></returns>
        public static DataTable getKadForScaner(Int64? code=null,Int64? beject = null)
        {
            ap.Clear();
            ap.Add(code);
            ap.Add(beject);
            return sql.executeProcedure("[inventory].[getKadForScaner]",
                new string[2] {"@code", "@numbejec" },
                new DbType[2] { DbType.Int64, DbType.Int64 }, ap);
        }

        /// <summary>
        /// Запись выдачи/приёмки сканера 
        /// </summary>        
        /// <returns></returns>
        public static DataTable setScanerOrBlankForKadrs(Int32 id_kadr, Int32 id_ttost, string time, Int32 type, string numberScaner, bool isValidate,int id_Shop,int? id_spacing)
        {
            ap.Clear();
            ap.Add(id_kadr);
            ap.Add(id_ttost);
            ap.Add(time);
            ap.Add(type);
            ap.Add(numberScaner);
            ap.Add(isValidate);
            ap.Add(Nwuram.Framework.Settings.User.UserSettings.User.Id);
            ap.Add(id_Shop);
            ap.Add(id_spacing);
            ap.Add(Nwuram.Framework.Settings.Connection.ConnectionSettings.GetIdProgram());

            return sql.executeProcedure("[inventory].[setScanerOrBlankForKadrs]",
                new string[] { "@id_kadr", "@id_ttost", "@time", "@type", "@numberScaner","@isValidate","@idUser","@id_Shop", "@id_spasing", "@id_prog" },
                new DbType[] { DbType.Int32,DbType.Int32,DbType.Time,DbType.Int32,DbType.String,DbType.Boolean,DbType.Int32, DbType.Int32, DbType.Int32, DbType.Int32 }, ap);
        }

        /// <summary>
        /// Получение основной таблицы
        /// </summary>        
        /// <returns></returns>
        public static DataTable getMainTableForScaner(int id_ttost, int id_PersonnelType,string namePlace)
        {
            ap.Clear();            
            ap.Add(id_ttost);
            ap.Add(id_PersonnelType);
            ap.Add(namePlace);
            return sql.executeProcedure("[inventory].[getMainTableForScaner]",
                new string[] { "@id_ttost", "@id_PersonnelType", "@place" },
                new DbType[] { DbType.Int32, DbType.Int32, DbType.String }, ap);
        }

        /// <summary>
        /// Получение основной таблицы
        /// </summary>        
        /// <returns></returns>
        public static DataTable getSingleTableForScaner(int id_kadr, int id_ttost)
        {
            ap.Clear();
            ap.Add(id_kadr);
            ap.Add(id_ttost);
            return sql.executeProcedure("[inventory].[getSingleTableForScaner]",
                new string[] { "@id_kadr","@id_ttost" },
                new DbType[] { DbType.Int32, DbType.Int32 }, ap);
        }

        /// <summary>
        /// Получение сотрудника по коду бейджика
        /// </summary>        
        /// <returns></returns>
        public static DataTable getDepsForScaner()
        {
            ap.Clear();            
            return sql.executeProcedure("[inventory].[getDepsForScaner]",
                new string[] {},
                new DbType[] {}, ap);
        }

        /// <summary>
        /// Получение списка людей по отделу
        /// </summary>        
        /// <returns></returns>
        public static DataTable getPeopleForScaner(int id_deps)
        {
            ap.Clear();
            ap.Add(id_deps);
            return sql.executeProcedure("[inventory].[getPeopleForScaner]",
                new string[] { "@id_deps" },
                new DbType[] { DbType.Int32 }, ap);
        }

        /// <summary>
        /// Добавление плата по человеку
        /// </summary>        
        /// <returns></returns>
        public static DataTable setPlaneForScaner(int id_place, int id_ttost, int id_kadr, string timeStart, string timeEnd)
        {
            ap.Clear();
            ap.Add(id_place);
            ap.Add(id_ttost);
            ap.Add(id_kadr);
            ap.Add(timeStart);
            ap.Add(timeEnd);
            ap.Add(Nwuram.Framework.Settings.User.UserSettings.User.Id);
            return sql.executeProcedure("[inventory].[setPlaneForScaner]",
                new string[] { "@id_place", "@id_ttost", "@id_kadr", "@timeStart", "@timeEnd", "@id_user" },
                new DbType[] { DbType.Int32, DbType.Int32, DbType.Int32, DbType.Time, DbType.Time, DbType.Int32 }, ap);
        }

        /// <summary>
        /// Получение списка инвентаризаций
        /// </summary>        
        /// <returns></returns>
        public static DataTable getDttostForScaner()
        {
            ap.Clear();
            return sql.executeProcedure("[inventory].[getDttostForScaner]",
                new string[] { },
                new DbType[] { }, ap);
        }

        /// <summary>
        /// Получение списка соотношения часов
        /// </summary>        
        /// <returns></returns>
        public static DataTable getTableCountHourForScaner()
        {
            ap.Clear();
            return sql.executeProcedure("[inventory].[getTableCountHourForScaner]",
                new string[] { },
                new DbType[] { }, ap);
        }

        /// <summary>
        /// Запись списка соотношения часов
        /// </summary>        
        /// <returns></returns>
        public static DataTable setTableCountHourForScaner(int id, DateTime timeStart, DateTime timeEnd, decimal day)
        {
            ap.Clear();
            ap.Add(id);
            ap.Add(timeStart.ToShortTimeString());
            ap.Add(timeEnd.ToShortTimeString());
            ap.Add(day);
            return sql.executeProcedure("[inventory].[setTableCountHourForScaner]",
                new string[] { "@id", "@timeStart", "@timeEnd", "@day" },
                new DbType[] { DbType.Int32,DbType.Time,DbType.Time,DbType.Decimal }, ap);
        }

        /// <summary>
        /// Удаление записи соотношения часов
        /// </summary>        
        /// <returns></returns>
        public static DataTable delTableCountHourForScaner(int id)
        {
            ap.Clear();
            ap.Add(id);
            ap.Add(true);
            return sql.executeProcedure("[inventory].[setTableCountHourForScaner]",
                new string[] { "@id", "@isDel" },
                new DbType[] { DbType.Int32, DbType.Boolean }, ap);
        }

        /// <summary>
        /// Получение Отчёта
        /// </summary>        
        /// <returns></returns>
        public static DataTable getReportFreeDaysForScaner(int id_ttost, int id_dep)
        {
            ap.Clear();
            ap.Add(id_ttost);
            ap.Add(id_dep);
            return sql.executeProcedure("[inventory].[getReportFreeDaysForScaner]",
                new string[] {"@id_ttost","@id_dep" },
                new DbType[] {DbType.Int32,DbType.Int32 }, ap);
        }


        /// <summary>
        /// Получение справочника отделов
        /// </summary>
        /// <param name=""></param>
        /// <returns>Таблица с данными</returns>        
        public static async Task<DataTable> getShop(bool withAllDeps = false)
        {
            ap.Clear();

            DataTable dtResult = sql.executeProcedure("[inventory].[getShop]",
                 new string[0] { },
                 new DbType[0] { }, ap);

            if (withAllDeps)
            {
                if (dtResult != null)
                {
                    if (!dtResult.Columns.Contains("isMain"))
                    {
                        DataColumn col = new DataColumn("isMain", typeof(int));
                        col.DefaultValue = 1;
                        dtResult.Columns.Add(col);
                        dtResult.AcceptChanges();
                    }

                    DataRow row = dtResult.NewRow();

                    row["cName"] = "Все магазины";
                    row["id"] = 0;
                    row["isMain"] = 0;
                    dtResult.Rows.Add(row);
                    dtResult.AcceptChanges();
                    dtResult.DefaultView.Sort = "isMain asc, cName asc";
                    dtResult = dtResult.DefaultView.ToTable().Copy();
                }
            }

            return dtResult;
        }

        /// <summary>
        /// Получение настроек.
        /// </summary>
        /// <param name="id_value">Код значния</param>
        public static async Task<DataTable> getSettings(string id_value)
        {
            ap.Clear();
            ap.Add(ConnectionSettings.GetIdProgram());
            ap.Add(id_value);

            return sql.executeProcedure("[inventory].[getSettings]",
                new string[2] { "@id_prog", "@id_value" },
                new DbType[2] { DbType.Int32, DbType.String }, ap);
        }

        /// <summary>
        /// Добавление, Редактирование и удаление выдачи сканеров/ведомостей.
        /// </summary>
        /// <param name="id_value">Код значния</param>
        public static async Task<DataTable> setScanerBlank(int id, int result, bool isDel)
        {
            ap.Clear();
            ap.Add(id);
            ap.Add(UserSettings.User.Id);
            ap.Add(result);
            ap.Add(isDel);

            return sql.executeProcedure("[inventory].[setScanerBlank]",
                new string[4] { "@id", "@id_user", "@result", "@isDel" },
                new DbType[4] { DbType.Int32, DbType.Int32, DbType.Int32, DbType.Boolean }, ap);
        }

        /// <summary>
        /// Получение информации по месту подсчёта на дату инвентаризации по человеку.
        /// </summary>
        /// <param name="id_value">Код значния</param>
        public static async Task<DataTable> getInfoSpasingAndPlace(DateTime dateInvent, int id_kadr, bool isSecondShop)
        {
            ap.Clear();
            ap.Add(dateInvent);
            ap.Add(id_kadr);

            return (isSecondShop ? sql_dop : sql).executeProcedure("[inventory].[getInfoSpasingAndPlace]",
                new string[2] { "@dateInvent", "@id_kadr" },
                new DbType[2] { DbType.Date, DbType.Int32 }, ap);
        }

        /// <summary>
        /// Получение данных по подсчёту сотрудников офиса
        /// </summary>
        /// <param name="id_value">Код значния</param>
        public static async Task<DataTable> getDataForCalculateTimeInvent(DateTime dateInvent)
        {
            ap.Clear();
            ap.Add(dateInvent);
            
            return sql.executeProcedure("[inventory].[getDataForCalculateTimeInvent]",
                new string[1] { "@dateInvent" },
                new DbType[1] { DbType.Date }, ap);
        }

        /// <summary>
        /// Получение данных по подсчёту сотрудников офиса
        /// </summary>
        /// <param name="id_value">Код значния</param>
        public static async Task<DataTable> getTableHourForHoliday()
        {
            ap.Clear();

            return sql.executeProcedure("[inventory].[getTableHourForHoliday]",
                new string[0] { },
                new DbType[0] { }, ap);
        }


        /// <summary>
        /// Запись и удаление данных по отгулам человека
        /// </summary>
        /// <param name="id_value">Код значния</param>
        public static async Task<DataTable> setCalcCompensatoryTime(int id_ttost,int id_kadr,int timeWorked, decimal compenstaionTime,bool isDel)
        {
            ap.Clear();

            ap.Add(id_ttost);
            ap.Add(id_kadr);
            ap.Add(timeWorked);
            ap.Add(compenstaionTime);
            ap.Add(UserSettings.User.Id);
            ap.Add(isDel);


            return sql.executeProcedure("[inventory].[setCalcCompensatoryTime]",
                new string[6] { "@id_ttost", "@id_kadr", "@timeWorked", "@compenstaionTime", "@id_user", "@isDel" },
                new DbType[6] { DbType.Int32, DbType.Int32, DbType.Int32, DbType.Decimal, DbType.Int32, DbType.Boolean }, ap);
        }


        /// <summary>
        /// Получение данных по подсчёту сотрудников офиса
        /// </summary>
        /// <param name="id_value">Код значния</param>
        public static async Task<DataTable> getIdSpasingForForm(DateTime dateInvent, int id_kadr, bool isSecond)
        {
            ap.Clear();

            ap.Add(dateInvent);
            ap.Add(id_kadr);
            ap.Add(ConnectionSettings.GetIdProgram());


            return (isSecond ? sql_dop : sql).executeProcedure("[inventory].[getIdSpasingForForm]",
                new string[3] { "@dateInvent", "@id_kadr", "@id_prog" },
                new DbType[3] { DbType.Date, DbType.Int32, DbType.Int32 }, ap);
        }


        /// <summary>
        /// Получение данных по отгулам человека
        /// </summary>
        /// <param name="id_value">Код значния</param>
        public static async Task<DataTable> getInfoCalcCompensatoryTime(int id_ttost)
        {
            ap.Clear();

            ap.Add(id_ttost);

            return sql.executeProcedure("[inventory].[getInfoCalcCompensatoryTime]",
                new string[1] { "@id_ttost" },
                new DbType[1] { DbType.Int32}, ap);
        }

        #region "Марчкенко"
        /// <summary>
        /// Получение основной таблицы
        /// </summary>        
        /// <returns></returns>
        /// 
        public static DataTable AddNewTime(int id_kadr, int id_ttost, DateTime timeS, DateTime timeEnd, int type, string scan, int idCreater,int? id_spacing)
        {
            ap.Clear();
            ap.Add(id_kadr);
            ap.Add(id_ttost);
            ap.Add(timeS);
            ap.Add(timeEnd);
            ap.Add(type);
            ap.Add(scan);
            ap.Add(idCreater);
            ap.Add(id_spacing);

            return sql.executeProcedure("[inventory].[AddNewTime]",
                new string[] { "@id_kadr", "@id_ttost", "@timeS", "@timeEnd", "@type", "@scan", "@idCreater", "@id_spacing" },
                new DbType[] { DbType.Int32, DbType.Int32, DbType.DateTime, DbType.DateTime, DbType.Int32, DbType.String, DbType.Int32, DbType.Int32 }, ap);
        }

        public static DataTable EditSingleTableForScaner(int id, DateTime timeStart, DateTime timeEnd, int? id_spacing)
        {
            ap.Clear();
            ap.Add(id);
            ap.Add(timeStart);
            ap.Add(timeEnd);
            ap.Add(UserSettings.User.Id);
            ap.Add(id_spacing);
            return sql.executeProcedure("[inventory].[EditSingleTableForScaner]",
                new string[5] { "@id", "@timeStart", "@timeEnd","@id_Editor", "@id_spacing" },
                new DbType[5] { DbType.Int32, DbType.DateTime, DbType.DateTime, DbType.Int32, DbType.Int32 }, ap);
        }

        #endregion

    }
}
