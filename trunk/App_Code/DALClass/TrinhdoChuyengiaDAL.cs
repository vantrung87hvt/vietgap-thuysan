/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:6/28/2012 10:03:05 PM
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
    public class TrinhdoChuyengiaDAL : SqlProvider<TrinhdoChuyengiaEntity>
    {
        static TrinhdoChuyengiaDAL()
        {
            InitReader();
        }
        protected static void InitReader()
        {
            getFromReader=delegate(SqlDataReader dr)
            {
                TrinhdoChuyengiaEntity entity = new TrinhdoChuyengiaEntity();
				entity.PK_iTrinhdoChuyengiaID = Int16.Parse("0"+dr["PK_iTrinhdoChuyengiaID"].ToString());
				entity.sTrinhdo = dr["sTrinhdo"].ToString();
                return entity;
            };
        }
        public static TrinhdoChuyengiaEntity GetOne(int PK_iTrinhdoChuyengiaID)
        {
            string cmdName = "spTrinhdoChuyengia_GetByPK";
            SqlParameter p = new SqlParameter("@PK_iTrinhdoChuyengiaID", PK_iTrinhdoChuyengiaID);
            TrinhdoChuyengiaEntity entity = GetOne(cmdName, p);
            return entity;
        }
        public static List<TrinhdoChuyengiaEntity> GetAll()
        {
            string cmdName = "spTrinhdoChuyengia_Get";
            return GetList(cmdName);
        }
        
        public static int Add(TrinhdoChuyengiaEntity entity)
        {
            string cmdName = "spTrinhdoChuyengia_Insert";
            return Run(cmdName,true,initParams(entity));

        }
        public static bool Edit(TrinhdoChuyengiaEntity entity)
        {
            string cmdName = "spTrinhdoChuyengia_Update";
            return Run(cmdName,false,initParams(entity))>0;
        }
        public static bool Remove(Int16 PK_iTrinhdoChuyengiaID)
        {
            string cmdName = "spTrinhdoChuyengia_Delete";
            SqlParameter p = new SqlParameter("@PK_iTrinhdoChuyengiaID", PK_iTrinhdoChuyengiaID);
            return Run(cmdName,false,p)>0;
        }
        #region private
        private static SqlParameter[] initParams(TrinhdoChuyengiaEntity entity)
        {
            SqlParameter[] p = new SqlParameter[2];
			p[0] = new SqlParameter("@PK_iTrinhdoChuyengiaID", entity.PK_iTrinhdoChuyengiaID);
			p[1] = new SqlParameter("@sTrinhdo", entity.sTrinhdo);
            return p;
        }
        #endregion
       
    }
}