/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:10/26/2011 9:45:35 PM
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
    public class NewsCategoryDAL : SqlProvider<NewsCategoryEntity>
    {
        static NewsCategoryDAL()
        {
            InitReader();
        }
        protected static void InitReader()
        {
            getFromReader=delegate(SqlDataReader dr)
            {
                NewsCategoryEntity entity = new NewsCategoryEntity();
				entity.iNewsCategoryID = Int32.Parse("0"+dr["iNewsCategoryID"].ToString());
				entity.iCategoryID = Int32.Parse("0"+dr["iCategoryID"].ToString());
				entity.iNewsID = Int32.Parse("0"+dr["iNewsID"].ToString());
                return entity;
            };
        }
        public static NewsCategoryEntity GetOne(int iNewsCategoryID)
        {
            string cmdName = "spNewsCategory_GetByPK";
            SqlParameter p = new SqlParameter("@iNewsCategoryID", iNewsCategoryID);
            NewsCategoryEntity entity = GetOne(cmdName, p);
            return entity;
        }
        public static List<NewsCategoryEntity> GetAll()
        {
            string cmdName = "spNewsCategory_Get";
            return GetList(cmdName);
        }
        public static List<NewsCategoryEntity> GetByiCategoryID(Int32 iCategoryID)
		{
			string cmdName = "spNewsCategory_GetByFK_iCategoryID";
			SqlParameter p = new SqlParameter("@iCategoryID",iCategoryID);
			List<NewsCategoryEntity> list = GetList(cmdName, p);
			return list;
		}public static List<NewsCategoryEntity> GetByiNewsID(Int32 iNewsID)
		{
			string cmdName = "spNewsCategory_GetByFK_iNewsID";
			SqlParameter p = new SqlParameter("@iNewsID",iNewsID);
			List<NewsCategoryEntity> list = GetList(cmdName, p);
			return list;
		}
        public static int Add(NewsCategoryEntity entity)
        {
            string cmdName = "spNewsCategory_Insert";
            return Run(cmdName,true,initParams(entity));

        }
        public static bool Edit(NewsCategoryEntity entity)
        {
            string cmdName = "spNewsCategory_Update";
            return Run(cmdName,false,initParams(entity))>0;
        }
        public static bool Remove(Int32 iNewsCategoryID)
        {
            string cmdName = "spNewsCategory_Delete";
            SqlParameter p = new SqlParameter("@iNewsCategoryID", iNewsCategoryID);
            return Run(cmdName,false,p)>0;
        }
        #region private
        private static SqlParameter[] initParams(NewsCategoryEntity entity)
        {
            SqlParameter[] p = new SqlParameter[3];
			p[0] = new SqlParameter("@iNewsCategoryID", entity.iNewsCategoryID);
			p[1] = new SqlParameter("@iCategoryID", entity.iCategoryID);
			p[2] = new SqlParameter("@iNewsID", entity.iNewsID);
            return p;
        }
        #endregion
       
    }
}