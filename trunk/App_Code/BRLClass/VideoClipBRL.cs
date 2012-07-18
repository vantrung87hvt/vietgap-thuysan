/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:7/18/2012 5:20:37 PM
------------------------------------------------------*/
using INVI.Entity;
using INVI.DataAccess;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
namespace INVI.Business
{
    public class VideoClipBRL
    {
        #region Init
        private static string EX_NOT_EXIST="Không Tồn Tại VideoClip Này";
		private static string EX_STENTEP_EMPTY="sTentep không được để trống";
		private static string EX_STIEUDE_EMPTY="sTieude không được để trống";
		private static string EX_ISOLANXEM_INVALID="iSolanxem không hợp lệ";
		private static string EX_IDUNGLUONG_INVALID="iDungluong không hợp lệ";
		private static string EX_IWIDTH_INVALID="iWidth không hợp lệ";
		private static string EX_IHEIGHT_INVALID="iHeight không hợp lệ";
		private static string EX_FK_ICATEGORYID_INVALID="FK_iCategoryID không hợp lệ";
		private static string EX_DNGAYTAI_INVALID="dNgaytai không hợp lệ";
		private static string EX_SANHMINHHOA_EMPTY="sAnhMinhHoa không được để trống";
		private static string EX_ID_INVALID="PK_iVideoID không hợp lệ";
        #endregion
        #region Public Methods
        /// <summary>
        /// Get VideoClip Theo ID
        /// </summary>
        /// <param name="PK_iVideoID">Int32:VideoClip ID</param>
        /// <returns>VideoClipEntity</returns>        
        public static VideoClipEntity GetOne(Int32 PK_iVideoID)
        {
            
			if(PK_iVideoID<=0)
				throw new Exception(EX_ID_INVALID);
            return VideoClipDAL.GetOne(PK_iVideoID);
        }
        /// <summary>
        /// Lấy về List các VideoClip
        /// </summary>
        /// <returns>List VideoClipEntity:List VideoClip Cần lấy</returns>
        public static List<VideoClipEntity> GetAll()
        {
            return VideoClipDAL.GetAll();
        }
        public static List<VideoClipEntity> GetByFK_iCategoryID(Int32 FK_iCategoryID)
		{
			if(FK_iCategoryID<=0)
				throw new Exception(EX_FK_ICATEGORYID_INVALID);
			return VideoClipDAL.GetByFK_iCategoryID(FK_iCategoryID);
		}
        /// <summary>
        /// Kiểm tra và thêm mới VideoClip
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Int32: ID của VideoClip Mới Thêm Vào</returns>
        public static Int32 Add(VideoClipEntity entity)
        {
            checkLogic(entity);
            checkDuplicate(entity, false);
            checkFK(entity);
            return VideoClipDAL.Add(entity);
        }
        /// <summary>
        /// Kiểm tra và chỉnh sửa VideoClip
        /// </summary>
        /// <param name="entity">VideoClipEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Edit(VideoClipEntity entity)
        {
            checkExist(entity.PK_iVideoID);
            checkLogic(entity);
            checkDuplicate(entity, true);
            checkFK(entity);
            return VideoClipDAL.Edit(entity);
        }
        /// <summary>
        /// Kiểm tra và xoá VideoClip
        /// </summary>
        /// <param name="PK_iVideoID">Int32 : PK_iVideoID</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Remove(Int32 PK_iVideoID)
        {
            checkExist(PK_iVideoID);
            return VideoClipDAL.Remove(PK_iVideoID);
        }
        #endregion
        #region Private Methods
        private static void checkExist(Int32 PK_iVideoID)
        {
            VideoClipEntity oVideoClip=VideoClipDAL.GetOne(PK_iVideoID);
            if(oVideoClip==null)
                throw new Exception(EX_NOT_EXIST);
        }
        /// <summary>
        /// Kiểm tra logic Entity
        /// </summary>
        /// <param name="entity">VideoClipEntity: entity</param>
        private static void checkLogic(VideoClipEntity entity)
        {   
			if (String.IsNullOrEmpty(entity.sTentep))
				throw new Exception(EX_STENTEP_EMPTY);
			if (String.IsNullOrEmpty(entity.sTieude))
				throw new Exception(EX_STIEUDE_EMPTY);
			if (entity.iSolanxem < 0)
				throw new Exception(EX_ISOLANXEM_INVALID);
			if (entity.iDungluong < 0)
				throw new Exception(EX_IDUNGLUONG_INVALID);
			if (entity.iWidth < 0)
				throw new Exception(EX_IWIDTH_INVALID);
			if (entity.iHeight < 0)
				throw new Exception(EX_IHEIGHT_INVALID);
			if (entity.FK_iCategoryID < 0)
				throw new Exception(EX_FK_ICATEGORYID_INVALID);
			if (DateTime.Parse("1753-01-01")>entity.dNgaytai)
				throw new Exception(EX_DNGAYTAI_INVALID);
			if (String.IsNullOrEmpty(entity.sAnhMinhHoa))
				throw new Exception(EX_SANHMINHHOA_EMPTY);
        }
        /// <summary>
        /// Kiểm tra trùng lặp bản ghi
        /// </summary>
        /// <param name="entity">VideoClipEntity: VideoClipEntity</param>
        private static void checkDuplicate(VideoClipEntity entity,bool checkPK)
        {
            /* 
            Example
            List<VideoClipEntity> list = VideoClipDAL.GetAll();
            if (list.Exists(
                delegate(VideoClipEntity oldEntity)
                {
                    bool result =oldEntity.FIELD.Equals(entity.FIELD, StringComparison.OrdinalIgnoreCase);
                    if(checkPK)
                        result=result && oldEntity.PK_iVideoID != entity.PK_iVideoID;
                    return result;
                }
            ))
            {
                list.Clear();
                throw new Exception(EX_FIELD_EXISTED);
            }
            */
        }
        /// <summary>
        /// Kiểm tra tồn tại khóa ngoại
        /// </summary>
        /// <param name="entity">VideoClipEntity:entity</param>
        private static void checkFK(VideoClipEntity entity)
        {            
			CategoryEntity oCategory = CategoryDAL.GetOne(entity.FK_iCategoryID);
			if (oCategory==null)
			{
				throw new Exception("Không tìm thấy :FK_iCategoryID");
			}
        }
        #endregion
    }
}
