/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:10/26/2011 9:45:37 PM
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
    public class RateDAL : SqlProvider<RateEntity>
    {
        static RateDAL()
        {
            InitReader();
        }
        protected static void InitReader()
        {
            getFromReader=delegate(SqlDataReader dr)
            {
                RateEntity entity = new RateEntity();
				entity.iRateID = Int32.Parse("0"+dr["iRateID"].ToString());
				entity.iNewsID = Int32.Parse("0"+dr["iNewsID"].ToString());
				entity.iRate = Int32.Parse("0"+dr["iRate"].ToString());
				entity.iCount = Int32.Parse("0"+dr["iCount"].ToString());
                return entity;
            };
        }
        public static RateEntity GetOne(int iRateID)
        {
            string cmdName = "spRate_GetByPK";
            SqlParameter p = new SqlParameter("@iRateID", iRateID);
            RateEntity entity = GetOne(cmdName, p);
            return entity;
        }
        public static List<RateEntity> GetAll()
        {
            string cmdName = "spRate_Get";
            return GetList(cmdName);
        }
        public static List<RateEntity> GetByiNewsID(Int32 iNewsID)
		{
			string cmdName = "spRate_GetByFK_iNewsID";
			SqlParameter p = new SqlParameter("@iNewsID",iNewsID);
			List<RateEntity> list = GetList(cmdName, p);
			return list;
		}
        public static int Add(RateEntity entity)
        {
            string cmdName = "spRate_Insert";
            return Run(cmdName,true,initParams(entity));

        }
        public static bool Edit(RateEntity entity)
        {
            string cmdName = "spRate_Update";
            return Run(cmdName,false,initParams(entity))>0;
        }
        public static bool Remove(Int32 iRateID)
        {
            string cmdName = "spRate_Delete";
            SqlParameter p = new SqlParameter("@iRateID", iRateID);
            return Run(cmdName,false,p)>0;
        }
        #region private
        private static SqlParameter[] initParams(RateEntity entity)
        {
            SqlParameter[] p = new SqlParameter[4];
			p[0] = new SqlParameter("@iRateID", entity.iRateID);
			p[1] = new SqlParameter("@iNewsID", entity.iNewsID);
			p[2] = new SqlParameter("@iRate", entity.iRate);
			p[3] = new SqlParameter("@iCount", entity.iCount);
            return p;
        }
        #endregion
       
    }
}