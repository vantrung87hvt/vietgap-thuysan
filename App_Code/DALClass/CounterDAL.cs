/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:28/10/2011 4:31:25 CH
------------------------------------------------------*/
using INVI.DataAccess.Base;
using INVI.Entity;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Collections;
using System.Web;

namespace INVI.DataAccess
{    
    public class CounterDAL : SqlProvider<CounterEntity>
    {
        static CounterDAL()
        {
            InitReader();
        }
        protected static void InitReader()
        {
            getFromReader=delegate(SqlDataReader dr)
            {
                CounterEntity entity = new CounterEntity();
				entity.PK_iCounterID = int.Parse("0"+dr["PK_iCounterID"].ToString());
				entity.sIP = dr["sIP"].ToString();
				entity.tDate =String.IsNullOrEmpty(dr["tDate"].ToString())?DateTime.Now:DateTime.Parse(dr["tDate"].ToString());
                return entity;
            };
        }
        public static CounterEntity GetOne(int PK_iCounterID)
        {
            string cmdName = "spCounter_GetByPK";
            SqlParameter p = new SqlParameter("@PK_iCounterID", PK_iCounterID);
            CounterEntity entity = GetOne(cmdName, p);
            return entity;
        }
        public static List<CounterEntity> GetAll()
        {
            string cmdName = "spCounter_Get";
            return GetList(cmdName);
        }
        
        public static int Add(CounterEntity entity)
        {
            string cmdName = "spCounter_Insert";
            return Run(cmdName,true,initParams(entity));

        }
        public static bool Edit(CounterEntity entity)
        {
            string cmdName = "spCounter_Update";
            return Run(cmdName,false,initParams(entity))>0;
        }
        public static bool Remove(int PK_iCounterID)
        {
            string cmdName = "spCounter_Delete";
            SqlParameter p = new SqlParameter("@PK_iCounterID", PK_iCounterID);
            return Run(cmdName,false,p)>0;
        }
        #region private
        private static SqlParameter[] initParams(CounterEntity entity)
        {
            SqlParameter[] p = new SqlParameter[3];
			p[0] = new SqlParameter("@PK_iCounterID", entity.PK_iCounterID);
			p[1] = new SqlParameter("@sIP", entity.sIP);
			p[2] = new SqlParameter("@tDate", entity.tDate);
            return p;
        }
        #endregion
       
    }
}