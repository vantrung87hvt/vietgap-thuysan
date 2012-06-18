/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:10/26/2011 9:45:30 PM
------------------------------------------------------*/
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Collections;
namespace INVI.DataAccess.Base
{
    public abstract class SqlProvider<T>
    {
        private static string m_strCnn = ConfigurationManager.ConnectionStrings["db_NewsConnectionString"].ConnectionString;
        protected static string ConnectionString
        {
            get { return m_strCnn; }
            set { m_strCnn = value; }
        }
        protected static int Run(string cmdName,bool setOutput,params SqlParameter[] p)
        {
            using (SqlConnection cnn = new SqlConnection(m_strCnn))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = cmdName;
                    cmd.Parameters.AddRange(p);
                    if(setOutput)
                        p[0].Direction=ParameterDirection.Output;
                    cnn.Open();
                    int result=cmd.ExecuteNonQuery();
                    cnn.Close();
                    return setOutput?Convert.ToInt32(cmd.Parameters[0].Value):result;
                }
            }
        }
        protected static DataSet GetDataSet(string cmdName,string tblName)
        {
            using (SqlConnection cnn = new SqlConnection(m_strCnn))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandText = cmdName;
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        da.Fill(ds, tblName);
                        return ds;
                    }
                }
            }
        }
        protected static T GetOne(string cmdName, params SqlParameter[] p)
        {
            using (SqlConnection cnn = new SqlConnection(m_strCnn))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandText = cmdName;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(p);
                    cnn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                           T objT = getFromReader(dr);
                           dr.Close();
                           cnn.Close();
                           return objT;
                        }
                        dr.Close();
                        cnn.Close();
                        return default(T);
                    }
                }
            }
        }
        protected static List<T> GetList(string cmdName, params SqlParameter[] p)
        {            
            using (SqlConnection cnn = new SqlConnection(m_strCnn))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandText = cmdName;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(p);
                    cnn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {                       
                        List<T> list = new List<T>();
                        while (dr.Read())
                        {
                            T objT = getFromReader(dr);
                            list.Add(objT);
                        }
                        dr.Close();
                        cnn.Close();
                        return list;
                    }
                }
            }
        }
        protected delegate T DLG_GFR(SqlDataReader dr);
        protected static DLG_GFR getFromReader;
    }
}