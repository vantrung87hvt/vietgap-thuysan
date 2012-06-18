/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:12/15/2011 9:17:17 PM
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
    public class DanhmucchitieuDAL : SqlProvider<DanhmucchitieuEntity>
    {
        static DanhmucchitieuDAL()
        {
            InitReader();
        }
        protected static void InitReader()
        {
            getFromReader=delegate(SqlDataReader dr)
            {
                DanhmucchitieuEntity entity = new DanhmucchitieuEntity();
				entity.PK_iDanhmucchitieuID = Int32.Parse("0"+dr["PK_iDanhmucchitieuID"].ToString());
				entity.sTenchuyenmuc = dr["sTenchuyenmuc"].ToString();
				entity.iThutu = Int16.Parse("0"+dr["iThutu"].ToString());
                return entity;
            };
        }
        public static DanhmucchitieuEntity GetOne(Int32 PK_iDanhmucchitieuID)
        {
            string cmdName = "spDanhmucchitieu_GetByPK";
            SqlParameter p = new SqlParameter("@PK_iDanhmucchitieuID", PK_iDanhmucchitieuID);
            DanhmucchitieuEntity entity = GetOne(cmdName, p);
            return entity;
        }
        public static List<DanhmucchitieuEntity> GetAll()
        {
            string cmdName = "spDanhmucchitieu_Get";
            return GetList(cmdName);
        }
        
        public static int Add(DanhmucchitieuEntity entity)
        {
            string cmdName = "spDanhmucchitieu_Insert";
            return Run(cmdName,true,initParams(entity));

        }
        public static bool Edit(DanhmucchitieuEntity entity)
        {
            string cmdName = "spDanhmucchitieu_Update";
            return Run(cmdName,false,initParams(entity))>0;
        }
        public static bool Remove(Int32 PK_iDanhmucchitieuID)
        {
            string cmdName = "spDanhmucchitieu_Delete";
            SqlParameter p = new SqlParameter("@PK_iDanhmucchitieuID", PK_iDanhmucchitieuID);
            return Run(cmdName,false,p)>0;
        }
        #region private
        private static SqlParameter[] initParams(DanhmucchitieuEntity entity)
        {
            SqlParameter[] p = new SqlParameter[3];
			p[0] = new SqlParameter("@PK_iDanhmucchitieuID", entity.PK_iDanhmucchitieuID);
			p[1] = new SqlParameter("@sTenchuyenmuc", entity.sTenchuyenmuc);
			p[2] = new SqlParameter("@iThutu", entity.iThutu);
            return p;
        }
        #endregion
       
    }
}