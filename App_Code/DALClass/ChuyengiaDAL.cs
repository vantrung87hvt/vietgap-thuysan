/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:6/24/2012 2:35:55 PM
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
    public class ChuyengiaDAL : SqlProvider<ChuyengiaEntity>
    {
        static ChuyengiaDAL()
        {
            InitReader();
        }
        protected static void InitReader()
        {
            getFromReader=delegate(SqlDataReader dr)
            {
                ChuyengiaEntity entity = new ChuyengiaEntity();
				entity.PK_iChuyengiaID = Int32.Parse("0"+dr["PK_iChuyengiaID"].ToString());
				entity.sHoten = dr["sHoten"].ToString();
				entity.FK_iTochucchungnhanID = Int32.Parse("0"+dr["FK_iTochucchungnhanID"].ToString());
				entity.iNamkinhnghiem = Int16.Parse("0"+dr["iNamkinhnghiem"].ToString());
				entity.sMaso = dr["sMaso"].ToString();
				entity.bDuyet =String.IsNullOrEmpty(dr["bDuyet"].ToString())?false:Boolean.Parse(dr["bDuyet"].ToString());
				entity.iTrangthai = Int16.Parse("0"+dr["iTrangthai"].ToString());
                entity.FK_iTrinhdoID = Int16.Parse("0" + dr["FK_iTrinhdoID"].ToString());
                entity.iNamsinh = Int32.Parse("0" + dr["iNamsinh"].ToString());
                try
                {
                    entity.imAnh = (byte[])(dr["imAnh"]);
                }
                catch { }
                return entity;
            };
        }
        public static ChuyengiaEntity GetOne(int PK_iChuyengiaID)
        {
            string cmdName = "spChuyengia_GetByPK";
            SqlParameter p = new SqlParameter("@PK_iChuyengiaID", PK_iChuyengiaID);
            ChuyengiaEntity entity = GetOne(cmdName, p);
            return entity;
        }
        public static List<ChuyengiaEntity> GetAll()
        {
            string cmdName = "spChuyengia_Get";
            return GetList(cmdName);
        }
        public static List<ChuyengiaEntity> GetByFK_iTochucchungnhanID(Int32 FK_iTochucchungnhanID)
		{
			string cmdName = "spChuyengia_GetByFK_FK_iTochucchungnhanID";
			SqlParameter p = new SqlParameter("@FK_iTochucchungnhanID",FK_iTochucchungnhanID);
			List<ChuyengiaEntity> list = GetList(cmdName, p);
			return list;
		}public static List<ChuyengiaEntity> GetByFK_iTrinhdoID(Int16 FK_iTrinhdoID)
		{
			string cmdName = "spChuyengia_GetByFK_FK_iTrinhdoID";
			SqlParameter p = new SqlParameter("@FK_iTrinhdoID",FK_iTrinhdoID);
			List<ChuyengiaEntity> list = GetList(cmdName, p);
			return list;
		}
        public static int Add(ChuyengiaEntity entity)
        {
            string cmdName = "spChuyengia_Insert";
            return Run(cmdName,true,initParams(entity));

        }
        public static bool Edit(ChuyengiaEntity entity)
        {
            string cmdName = "spChuyengia_Update";
            return Run(cmdName,false,initParams(entity))>0;
        }
        public static bool Remove(Int32 PK_iChuyengiaID)
        {
            string cmdName = "spChuyengia_Delete";
            SqlParameter p = new SqlParameter("@PK_iChuyengiaID", PK_iChuyengiaID);
            return Run(cmdName,false,p)>0;
        }
        #region private
        private static SqlParameter[] initParams(ChuyengiaEntity entity)
        {
            SqlParameter[] p = new SqlParameter[10];
			p[0] = new SqlParameter("@PK_iChuyengiaID", entity.PK_iChuyengiaID);
			p[1] = new SqlParameter("@sHoten", entity.sHoten);
			p[2] = new SqlParameter("@FK_iTochucchungnhanID", entity.FK_iTochucchungnhanID);
			p[3] = new SqlParameter("@iNamkinhnghiem", entity.iNamkinhnghiem);
			p[4] = new SqlParameter("@sMaso", entity.sMaso);
			p[5] = new SqlParameter("@bDuyet", entity.bDuyet);
			p[6] = new SqlParameter("@iTrangthai", entity.iTrangthai);
			p[7] = new SqlParameter("@imAnh", entity.imAnh);
			p[8] = new SqlParameter("@FK_iTrinhdoID", entity.FK_iTrinhdoID);
            p[9] = new SqlParameter("@iNamsinh", entity.iNamsinh);
            return p;
        }
        #endregion
       
    }
}