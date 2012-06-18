/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:12/17/2011 9:34:40 PM
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
    public class BaocaokhacphucloiChitietDAL : SqlProvider<BaocaokhacphucloiChitietEntity>
    {
        static BaocaokhacphucloiChitietDAL()
        {
            InitReader();
        }
        protected static void InitReader()
        {
            getFromReader=delegate(SqlDataReader dr)
            {
                BaocaokhacphucloiChitietEntity entity = new BaocaokhacphucloiChitietEntity();
				entity.PK_iBaocaokhacphucloiChitietID = Int64.Parse("0"+dr["PK_iBaocaokhacphucloiChitietID"].ToString());
				entity.sLoisai = dr["sLoisai"].ToString();
				entity.sBienphapkhacphuc = dr["sBienphapkhacphuc"].ToString();
				entity.iKetqua = Int16.Parse("0"+dr["iKetqua"].ToString());
				entity.FK_iBaocaokhacphucloiID = Int64.Parse("0"+dr["FK_iBaocaokhacphucloiID"].ToString());
                return entity;
            };
        }
        public static BaocaokhacphucloiChitietEntity GetOne(Int64 PK_iBaocaokhacphucloiChitietID)
        {
            string cmdName = "spBaocaokhacphucloiChitiet_GetByPK";
            SqlParameter p = new SqlParameter("@PK_iBaocaokhacphucloiChitietID", PK_iBaocaokhacphucloiChitietID);
            BaocaokhacphucloiChitietEntity entity = GetOne(cmdName, p);
            return entity;
        }
        public static List<BaocaokhacphucloiChitietEntity> GetAll()
        {
            string cmdName = "spBaocaokhacphucloiChitiet_Get";
            return GetList(cmdName);
        }
        public static List<BaocaokhacphucloiChitietEntity> GetByFK_iBaocaokhacphucloiID(Int64 FK_iBaocaokhacphucloiID)
		{
			string cmdName = "spBaocaokhacphucloiChitiet_GetByFK_FK_iBaocaokhacphucloiID";
			SqlParameter p = new SqlParameter("@FK_iBaocaokhacphucloiID",FK_iBaocaokhacphucloiID);
			List<BaocaokhacphucloiChitietEntity> list = GetList(cmdName, p);
			return list;
		}
        public static int Add(BaocaokhacphucloiChitietEntity entity)
        {
            string cmdName = "spBaocaokhacphucloiChitiet_Insert";
            return Run(cmdName,true,initParams(entity));

        }
        public static bool Edit(BaocaokhacphucloiChitietEntity entity)
        {
            string cmdName = "spBaocaokhacphucloiChitiet_Update";
            return Run(cmdName,false,initParams(entity))>0;
        }
        public static bool Remove(Int64 PK_iBaocaokhacphucloiChitietID)
        {
            string cmdName = "spBaocaokhacphucloiChitiet_Delete";
            SqlParameter p = new SqlParameter("@PK_iBaocaokhacphucloiChitietID", PK_iBaocaokhacphucloiChitietID);
            return Run(cmdName,false,p)>0;
        }
        #region private
        private static SqlParameter[] initParams(BaocaokhacphucloiChitietEntity entity)
        {
            SqlParameter[] p = new SqlParameter[5];
			p[0] = new SqlParameter("@PK_iBaocaokhacphucloiChitietID", entity.PK_iBaocaokhacphucloiChitietID);
			p[1] = new SqlParameter("@sLoisai", entity.sLoisai);
			p[2] = new SqlParameter("@sBienphapkhacphuc", entity.sBienphapkhacphuc);
			p[3] = new SqlParameter("@iKetqua", entity.iKetqua);
			p[4] = new SqlParameter("@FK_iBaocaokhacphucloiID", entity.FK_iBaocaokhacphucloiID);
            return p;
        }
        #endregion
       
    }
}