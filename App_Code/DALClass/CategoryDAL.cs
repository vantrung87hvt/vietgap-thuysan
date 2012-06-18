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
    public class CategoryDAL : SqlProvider<CategoryEntity>
    {
        static CategoryDAL()
        {
            InitReader();
        }
        protected static void InitReader()
        {
            getFromReader=delegate(SqlDataReader dr)
            {
                CategoryEntity entity = new CategoryEntity();
				entity.iCategoryID = Int32.Parse("0"+dr["iCategoryID"].ToString());
				entity.sTitle = dr["sTitle"].ToString();
				entity.sDesc = dr["sDesc"].ToString();
				entity.iOrder = Byte.Parse("0"+dr["iOrder"].ToString());
				entity.iTopID = Int32.Parse("0"+dr["iTopID"].ToString());
                return entity;
            };
        }
        public static CategoryEntity GetOne(int iCategoryID)
        {
            string cmdName = "spCategory_GetByPK";
            SqlParameter p = new SqlParameter("@iCategoryID", iCategoryID);
            CategoryEntity entity = GetOne(cmdName, p);
            return entity;
        }
        public static List<CategoryEntity> GetAll()
        {
            string cmdName = "spCategory_Get";
            return GetList(cmdName);
        }
        public static List<CategoryEntity> GetByiTopID(Int32 iTopID)
		{
			string cmdName = "spCategory_GetByFK_iTopID";
			SqlParameter p = new SqlParameter("@iTopID",iTopID);
			List<CategoryEntity> list = GetList(cmdName, p);
			return list;
		}
        public static int Add(CategoryEntity entity)
        {
            string cmdName = "spCategory_Insert";
            return Run(cmdName,true,initParams(entity));

        }
        public static bool Edit(CategoryEntity entity)
        {
            string cmdName = "spCategory_Update";
            return Run(cmdName,false,initParams(entity))>0;
        }
        public static bool Remove(Int32 iCategoryID)
        {
            string cmdName = "spCategory_Delete";
            SqlParameter p = new SqlParameter("@iCategoryID", iCategoryID);
            return Run(cmdName,false,p)>0;
        }
        #region private
        private static SqlParameter[] initParams(CategoryEntity entity)
        {
            SqlParameter[] p = new SqlParameter[5];
			p[0] = new SqlParameter("@iCategoryID", entity.iCategoryID);
			p[1] = new SqlParameter("@sTitle", entity.sTitle);
			p[2] = new SqlParameter("@sDesc", entity.sDesc);
			p[3] = new SqlParameter("@iOrder", entity.iOrder);
			p[4] = new SqlParameter("@iTopID", entity.iTopID);
            return p;
        }
        #endregion
       
    }
}