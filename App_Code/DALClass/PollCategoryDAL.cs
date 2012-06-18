/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:10/26/2011 9:45:36 PM
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
    public class PollCategoryDAL : SqlProvider<PollCategoryEntity>
    {
        static PollCategoryDAL()
        {
            InitReader();
        }
        protected static void InitReader()
        {
            getFromReader=delegate(SqlDataReader dr)
            {
                PollCategoryEntity entity = new PollCategoryEntity();
				entity.iPollCategoryID = Int32.Parse("0"+dr["iPollCategoryID"].ToString());
				entity.iPollID = Int32.Parse("0"+dr["iPollID"].ToString());
				entity.iCategoryID = Int32.Parse("0"+dr["iCategoryID"].ToString());
                return entity;
            };
        }
        public static PollCategoryEntity GetOne(int iPollCategoryID)
        {
            string cmdName = "spPollCategory_GetByPK";
            SqlParameter p = new SqlParameter("@iPollCategoryID", iPollCategoryID);
            PollCategoryEntity entity = GetOne(cmdName, p);
            return entity;
        }
        public static List<PollCategoryEntity> GetAll()
        {
            string cmdName = "spPollCategory_Get";
            return GetList(cmdName);
        }
        public static List<PollCategoryEntity> GetByiPollID(Int32 iPollID)
		{
			string cmdName = "spPollCategory_GetByFK_iPollID";
			SqlParameter p = new SqlParameter("@iPollID",iPollID);
			List<PollCategoryEntity> list = GetList(cmdName, p);
			return list;
		}public static List<PollCategoryEntity> GetByiCategoryID(Int32 iCategoryID)
		{
			string cmdName = "spPollCategory_GetByFK_iCategoryID";
			SqlParameter p = new SqlParameter("@iCategoryID",iCategoryID);
			List<PollCategoryEntity> list = GetList(cmdName, p);
			return list;
		}
        public static int Add(PollCategoryEntity entity)
        {
            string cmdName = "spPollCategory_Insert";
            return Run(cmdName,true,initParams(entity));

        }
        public static bool Edit(PollCategoryEntity entity)
        {
            string cmdName = "spPollCategory_Update";
            return Run(cmdName,false,initParams(entity))>0;
        }
        public static bool Remove(Int32 iPollCategoryID)
        {
            string cmdName = "spPollCategory_Delete";
            SqlParameter p = new SqlParameter("@iPollCategoryID", iPollCategoryID);
            return Run(cmdName,false,p)>0;
        }
        #region private
        private static SqlParameter[] initParams(PollCategoryEntity entity)
        {
            SqlParameter[] p = new SqlParameter[3];
			p[0] = new SqlParameter("@iPollCategoryID", entity.iPollCategoryID);
			p[1] = new SqlParameter("@iPollID", entity.iPollID);
			p[2] = new SqlParameter("@iCategoryID", entity.iCategoryID);
            return p;
        }
        #endregion
       
    }
}