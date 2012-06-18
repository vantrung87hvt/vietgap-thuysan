/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:10/26/2011 9:45:31 PM
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
    public class AdvCategoryDAL : SqlProvider<AdvCategoryEntity>
    {
        static AdvCategoryDAL()
        {
            InitReader();
        }
        protected static void InitReader()
        {
            getFromReader=delegate(SqlDataReader dr)
            {
                AdvCategoryEntity entity = new AdvCategoryEntity();
				entity.iAdvCategory = Int32.Parse("0"+dr["iAdvCategory"].ToString());
				entity.iAdvID = Int32.Parse("0"+dr["iAdvID"].ToString());
				entity.iCategoryID = Int32.Parse("0"+dr["iCategoryID"].ToString());
                return entity;
            };
        }
        public static AdvCategoryEntity GetOne(int iAdvCategory)
        {
            string cmdName = "spAdvCategory_GetByPK";
            SqlParameter p = new SqlParameter("@iAdvCategory", iAdvCategory);
            AdvCategoryEntity entity = GetOne(cmdName, p);
            return entity;
        }
        public static List<AdvCategoryEntity> GetAll()
        {
            string cmdName = "spAdvCategory_Get";
            return GetList(cmdName);
        }
        public static List<AdvCategoryEntity> GetByiAdvID(Int32 iAdvID)
		{
			string cmdName = "spAdvCategory_GetByFK_iAdvID";
			SqlParameter p = new SqlParameter("@iAdvID",iAdvID);
			List<AdvCategoryEntity> list = GetList(cmdName, p);
			return list;
		}public static List<AdvCategoryEntity> GetByiCategoryID(Int32 iCategoryID)
		{
			string cmdName = "spAdvCategory_GetByFK_iCategoryID";
			SqlParameter p = new SqlParameter("@iCategoryID",iCategoryID);
			List<AdvCategoryEntity> list = GetList(cmdName, p);
			return list;
		}
        public static int Add(AdvCategoryEntity entity)
        {
            string cmdName = "spAdvCategory_Insert";
            return Run(cmdName,true,initParams(entity));

        }
        public static bool Edit(AdvCategoryEntity entity)
        {
            string cmdName = "spAdvCategory_Update";
            return Run(cmdName,false,initParams(entity))>0;
        }
        public static bool Remove(Int32 iAdvCategory)
        {
            string cmdName = "spAdvCategory_Delete";
            SqlParameter p = new SqlParameter("@iAdvCategory", iAdvCategory);
            return Run(cmdName,false,p)>0;
        }
        #region private
        private static SqlParameter[] initParams(AdvCategoryEntity entity)
        {
            SqlParameter[] p = new SqlParameter[3];
			p[0] = new SqlParameter("@iAdvCategory", entity.iAdvCategory);
			p[1] = new SqlParameter("@iAdvID", entity.iAdvID);
			p[2] = new SqlParameter("@iCategoryID", entity.iCategoryID);
            return p;
        }
        #endregion
       
    }
}