/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:12/17/2011 9:34:43 PM
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
    public class BaocaokhacphucloiDAL : SqlProvider<BaocaokhacphucloiEntity>
    {
        static BaocaokhacphucloiDAL()
        {
            InitReader();
        }
        protected static void InitReader()
        {
            getFromReader=delegate(SqlDataReader dr)
            {
                BaocaokhacphucloiEntity entity = new BaocaokhacphucloiEntity();
				entity.PK_iBaocaokhacphucloiID = Int64.Parse("0"+dr["PK_iBaocaokhacphucloiID"].ToString());
				entity.FK_iCosonuoiID = Int64.Parse("0"+dr["FK_iCosonuoiID"].ToString());
				entity.sTailieukiemtheo = dr["sTailieukiemtheo"].ToString();
				entity.dNgaykiemtra =String.IsNullOrEmpty(dr["dNgaykiemtra"].ToString())?DateTime.Now:DateTime.Parse(dr["dNgaykiemtra"].ToString());
				entity.sDoankiemtra = dr["sDoankiemtra"].ToString();
                return entity;
            };
        }
        public static BaocaokhacphucloiEntity GetOne(Int64 PK_iBaocaokhacphucloiID)
        {
            string cmdName = "spBaocaokhacphucloi_GetByPK";
            SqlParameter p = new SqlParameter("@PK_iBaocaokhacphucloiID", PK_iBaocaokhacphucloiID);
            BaocaokhacphucloiEntity entity = GetOne(cmdName, p);
            return entity;
        }
        public static List<BaocaokhacphucloiEntity> GetAll()
        {
            string cmdName = "spBaocaokhacphucloi_Get";
            return GetList(cmdName);
        }
        public static List<BaocaokhacphucloiEntity> GetByFK_iCosonuoiID(Int64 FK_iCosonuoiID)
		{
			string cmdName = "spBaocaokhacphucloi_GetByFK_FK_iCosonuoiID";
			SqlParameter p = new SqlParameter("@FK_iCosonuoiID",FK_iCosonuoiID);
			List<BaocaokhacphucloiEntity> list = GetList(cmdName, p);
			return list;
		}
        public static int Add(BaocaokhacphucloiEntity entity)
        {
            string cmdName = "spBaocaokhacphucloi_Insert";
            return Run(cmdName,true,initParams(entity));

        }
        public static bool Edit(BaocaokhacphucloiEntity entity)
        {
            string cmdName = "spBaocaokhacphucloi_Update";
            return Run(cmdName,false,initParams(entity))>0;
        }
        public static bool Remove(Int64 PK_iBaocaokhacphucloiID)
        {
            string cmdName = "spBaocaokhacphucloi_Delete";
            SqlParameter p = new SqlParameter("@PK_iBaocaokhacphucloiID", PK_iBaocaokhacphucloiID);
            return Run(cmdName,false,p)>0;
        }
        #region private
        private static SqlParameter[] initParams(BaocaokhacphucloiEntity entity)
        {
            SqlParameter[] p = new SqlParameter[5];
			p[0] = new SqlParameter("@PK_iBaocaokhacphucloiID", entity.PK_iBaocaokhacphucloiID);
			p[1] = new SqlParameter("@FK_iCosonuoiID", entity.FK_iCosonuoiID);
			p[2] = new SqlParameter("@sTailieukiemtheo", entity.sTailieukiemtheo);
			p[3] = new SqlParameter("@dNgaykiemtra", entity.dNgaykiemtra);
			p[4] = new SqlParameter("@sDoankiemtra", entity.sDoankiemtra);
            return p;
        }
        #endregion
       
    }
}