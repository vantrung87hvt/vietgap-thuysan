/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:11/21/2011 4:39:38 PM
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
    public class LoaivanbanDAL : SqlProvider<LoaivanbanEntity>
    {
        static LoaivanbanDAL()
        {
            InitReader();
        }
        protected static void InitReader()
        {
            getFromReader=delegate(SqlDataReader dr)
            {
                LoaivanbanEntity entity = new LoaivanbanEntity();
				entity.PK_iLoaivanbanID = Int32.Parse("0"+dr["PK_iLoaivanbanID"].ToString());
				entity.sTenloai = dr["sTenloai"].ToString();
                return entity;
            };
        }
        public static LoaivanbanEntity GetOne(Int32 PK_iLoaivanbanID)
        {
            string cmdName = "spLoaivanban_GetByPK";
            SqlParameter p = new SqlParameter("@PK_iLoaivanbanID", PK_iLoaivanbanID);
            LoaivanbanEntity entity = GetOne(cmdName, p);
            return entity;
        }
        public static List<LoaivanbanEntity> GetAll()
        {
            string cmdName = "spLoaivanban_Get";
            return GetList(cmdName);
        }
        
        public static int Add(LoaivanbanEntity entity)
        {
            string cmdName = "spLoaivanban_Insert";
            return Run(cmdName,true,initParams(entity));

        }
        public static bool Edit(LoaivanbanEntity entity)
        {
            string cmdName = "spLoaivanban_Update";
            return Run(cmdName,false,initParams(entity))>0;
        }
        public static bool Remove(Int32 PK_iLoaivanbanID)
        {
            string cmdName = "spLoaivanban_Delete";
            SqlParameter p = new SqlParameter("@PK_iLoaivanbanID", PK_iLoaivanbanID);
            return Run(cmdName,false,p)>0;
        }
        #region private
        private static SqlParameter[] initParams(LoaivanbanEntity entity)
        {
            SqlParameter[] p = new SqlParameter[2];
			p[0] = new SqlParameter("@PK_iLoaivanbanID", entity.PK_iLoaivanbanID);
			p[1] = new SqlParameter("@sTenloai", entity.sTenloai);
            return p;
        }
        #endregion
       
    }
}