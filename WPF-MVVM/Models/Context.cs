using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Text;

namespace WPF_MVVM.Models
{
    public class Context
    {
        private string sConnectionString;
        private Log LogObject;

        public Context()
        {
            LogObject = new Log();
            sConnectionString = GetAppSettingsJson()["DBConnection"]["ConnectionString"].ToString();
        }

        public JObject GetAppSettingsJson()
        {
            string sStartupPath = Environment.CurrentDirectory;
            string sJsonString = File.ReadAllText(Path.Combine(sStartupPath, "AppSettings.json"), Encoding.UTF8);

            return JObject.Parse(sJsonString);
        }

        /// <summary>
        /// Select Action
        /// </summary>
        /// <param name="sSql">SQL Query</param>
        /// <param name="sTableKey">테이블 키</param>
        /// <returns></returns>
        public DataTable SelectMethod(string sSql, string sTableKey)
        {
            try
            {
                using (var db = new OleDbConnection(sConnectionString))
                {
                    DataSet dsResult = new DataSet();
                    OleDbDataAdapter OleDbAdt = new OleDbDataAdapter(sSql, db);

                    OleDbAdt.Fill(dsResult, sTableKey);

                    return dsResult.Tables[sTableKey];
                }
            }
            catch (Exception e)
            {
                LogObject.WirteLog(e.Message);
            }

            return new DataTable();
        }

        /// <summary>
        /// Update Action
        /// </summary>
        /// <param name="sSql">SQL Query</param>
        public void UpdateMethod(string sSql)
        {
            using (var db = new OleDbConnection(sConnectionString))
            {
                try
                {
                    OleDbDataAdapter OleDbAdt = new OleDbDataAdapter(sSql, db);

                    db.Open();

                    OleDbAdt.UpdateCommand = new OleDbCommand(sSql, db);
                    OleDbAdt.UpdateCommand.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    LogObject.WirteLog(e.Message);
                }
            }
        }

        /// <summary>
        /// Insert Action
        /// </summary>
        /// <param name="sSql">SQL Query</param>
        /// <param name="sTableName">테이블 명</param>
        public void InsertMethod(string sSql)
        {
            using (var db = new OleDbConnection(sConnectionString))
            {
                try
                {
                    OleDbDataAdapter OleDbAdt = new OleDbDataAdapter(sSql, db);

                    db.Open();

                    OleDbAdt.InsertCommand = new OleDbCommand(sSql, db);
                    OleDbAdt.InsertCommand.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    LogObject.WirteLog(e.Message);
                }
            }
        }

        /// <summary>
        /// Delete Action
        /// </summary>
        /// <param name="sSql">SQL Query</param>
        public void DeleteMethod(string sSql)
        {
            using (var db = new OleDbConnection(sConnectionString))
            {
                try
                {
                    OleDbDataAdapter OleDbAdt = new OleDbDataAdapter(sSql, db);

                    db.Open();

                    OleDbAdt.DeleteCommand = new OleDbCommand(sSql, db);
                    OleDbAdt.DeleteCommand.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    LogObject.WirteLog(e.Message);
                }
            }
        }
    }
}
