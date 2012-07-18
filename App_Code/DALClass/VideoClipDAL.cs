/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:7/18/2012 5:20:45 PM
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
    public class VideoClipDAL : SqlProvider<VideoClipEntity>
    {
        static VideoClipDAL()
        {
            InitReader();
        }
        protected static void InitReader()
        {
            getFromReader=delegate(SqlDataReader dr)
            {
                VideoClipEntity entity = new VideoClipEntity();
				entity.PK_iVideoID = Int32.Parse("0"+dr["PK_iVideoID"].ToString());
				entity.sTentep = dr["sTentep"].ToString();
				entity.sTieude = dr["sTieude"].ToString();
				entity.iSolanxem = Int32.Parse("0"+dr["iSolanxem"].ToString());
				entity.iDungluong = Int64.Parse("0"+dr["iDungluong"].ToString());
				entity.iWidth = Int32.Parse("0"+dr["iWidth"].ToString());
				entity.iHeight = Int32.Parse("0"+dr["iHeight"].ToString());
				entity.FK_iCategoryID = Int32.Parse("0"+dr["FK_iCategoryID"].ToString());
				entity.sMota = dr["sMota"].ToString();
				entity.dNgaytai =String.IsNullOrEmpty(dr["dNgaytai"].ToString())?DateTime.Now:DateTime.Parse(dr["dNgaytai"].ToString());
				entity.sAnhMinhHoa = dr["sAnhMinhHoa"].ToString();
                return entity;
            };
        }
        public static VideoClipEntity GetOne(int PK_iVideoID)
        {
            string cmdName = "spVideoClip_GetByPK";
            SqlParameter p = new SqlParameter("@PK_iVideoID", PK_iVideoID);
            VideoClipEntity entity = GetOne(cmdName, p);
            return entity;
        }
        public static List<VideoClipEntity> GetAll()
        {
            string cmdName = "spVideoClip_Get";
            return GetList(cmdName);
        }
        public static List<VideoClipEntity> GetByFK_iCategoryID(Int32 FK_iCategoryID)
		{
			string cmdName = "spVideoClip_GetByFK_FK_iCategoryID";
			SqlParameter p = new SqlParameter("@FK_iCategoryID",FK_iCategoryID);
			List<VideoClipEntity> list = GetList(cmdName, p);
			return list;
		}
        public static int Add(VideoClipEntity entity)
        {
            string cmdName = "spVideoClip_Insert";
            return Run(cmdName,true,initParams(entity));

        }
        public static bool Edit(VideoClipEntity entity)
        {
            string cmdName = "spVideoClip_Update";
            return Run(cmdName,false,initParams(entity))>0;
        }
        public static bool Remove(Int32 PK_iVideoID)
        {
            string cmdName = "spVideoClip_Delete";
            SqlParameter p = new SqlParameter("@PK_iVideoID", PK_iVideoID);
            return Run(cmdName,false,p)>0;
        }
        #region private
        private static SqlParameter[] initParams(VideoClipEntity entity)
        {
            SqlParameter[] p = new SqlParameter[11];
			p[0] = new SqlParameter("@PK_iVideoID", entity.PK_iVideoID);
			p[1] = new SqlParameter("@sTentep", entity.sTentep);
			p[2] = new SqlParameter("@sTieude", entity.sTieude);
			p[3] = new SqlParameter("@iSolanxem", entity.iSolanxem);
			p[4] = new SqlParameter("@iDungluong", entity.iDungluong);
			p[5] = new SqlParameter("@iWidth", entity.iWidth);
			p[6] = new SqlParameter("@iHeight", entity.iHeight);
			p[7] = new SqlParameter("@FK_iCategoryID", entity.FK_iCategoryID);
			p[8] = new SqlParameter("@sMota", entity.sMota);
			p[9] = new SqlParameter("@dNgaytai", entity.dNgaytai);
			p[10] = new SqlParameter("@sAnhMinhHoa", entity.sAnhMinhHoa);
            return p;
        }
        #endregion
       
    }
}