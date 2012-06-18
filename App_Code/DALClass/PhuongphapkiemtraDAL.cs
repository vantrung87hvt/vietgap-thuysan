/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:12/15/2011 9:17:21 PM
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
    public class PhuongphapkiemtraDAL : SqlProvider<PhuongphapkiemtraEntity>
    {
        static PhuongphapkiemtraDAL()
        {
            InitReader();
        }
        protected static void InitReader()
        {
            getFromReader=delegate(SqlDataReader dr)
            {
                PhuongphapkiemtraEntity entity = new PhuongphapkiemtraEntity();
				entity.PK_iPhuongphapkiemtraID = Int32.Parse("0"+dr["PK_iPhuongphapkiemtraID"].ToString());
				entity.sTenphuongphapkiemtra = dr["sTenphuongphapkiemtra"].ToString();
                return entity;
            };
        }
        public static PhuongphapkiemtraEntity GetOne(Int32 PK_iPhuongphapkiemtraID)
        {
            string cmdName = "spPhuongphapkiemtra_GetByPK";
            SqlParameter p = new SqlParameter("@PK_iPhuongphapkiemtraID", PK_iPhuongphapkiemtraID);
            PhuongphapkiemtraEntity entity = GetOne(cmdName, p);
            return entity;
        }
        public static List<PhuongphapkiemtraEntity> GetAll()
        {
            string cmdName = "spPhuongphapkiemtra_Get";
            return GetList(cmdName);
        }
        
        public static int Add(PhuongphapkiemtraEntity entity)
        {
            string cmdName = "spPhuongphapkiemtra_Insert";
            return Run(cmdName,true,initParams(entity));

        }
        public static bool Edit(PhuongphapkiemtraEntity entity)
        {
            string cmdName = "spPhuongphapkiemtra_Update";
            return Run(cmdName,false,initParams(entity))>0;
        }
        public static bool Remove(Int32 PK_iPhuongphapkiemtraID)
        {
            string cmdName = "spPhuongphapkiemtra_Delete";
            SqlParameter p = new SqlParameter("@PK_iPhuongphapkiemtraID", PK_iPhuongphapkiemtraID);
            return Run(cmdName,false,p)>0;
        }
        #region private
        private static SqlParameter[] initParams(PhuongphapkiemtraEntity entity)
        {
            SqlParameter[] p = new SqlParameter[2];
			p[0] = new SqlParameter("@PK_iPhuongphapkiemtraID", entity.PK_iPhuongphapkiemtraID);
			p[1] = new SqlParameter("@sTenphuongphapkiemtra", entity.sTenphuongphapkiemtra);
            return p;
        }
        #endregion
       
    }
}