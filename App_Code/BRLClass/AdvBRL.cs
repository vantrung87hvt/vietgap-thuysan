/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:1/12/2009 11:16:01 AM
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
    public class AdvBRL
    {
        #region Init
        private static string EX_NOT_EXIST="Không Tồn Tại quảng cáo Này";
		private static string EX_STITLE_EMPTY="Tiêu đề không được để trống";
		private static string EX_SLINK_EMPTY="Liên kết không được để trống";
		private static string EX_SMEDIA_EMPTY="Đường dẫn không được để trống";
		private static string EX_ITYPE_INVALID="loại quảng cáo không hợp lệ";
		private static string EX_IORDER_INVALID="Thứ tự không hợp lệ";
		private static string EX_IPOSITIONID_INVALID="vị trí ID không hợp lệ";
		private static string EX_ID_INVALID="Quảng cáo ID không hợp lệ";
        private static string EX_ADV_EXISTED = "Quảng cáo này đã tồn tại";
        private static string EX_IWIDTH_INVALID = "Chiều rộng phải >=0";
        private static string EX_IHEIGHT_INVALID = "Chiều cao phải >=0";

        #endregion
        #region Public Methods
        /// <summary>
        /// Get Adv Theo ID
        /// </summary>
        /// <param name="iAdvID">Int32:Adv ID</param>
        /// <returns>AdvEntity</returns>        
        public static AdvEntity GetOne(Int32 iAdvID)
        {
            
			if(iAdvID<=0)
				throw new Exception(EX_ID_INVALID);
            return AdvDAL.GetOne(iAdvID);
        }
        /// <summary>
        /// Lấy về List các Adv
        /// </summary>
        /// <returns>List AdvEntity:List Adv Cần lấy</returns>
        public static List<AdvEntity> GetAll()
        {
            return AdvDAL.GetAll();
        }
        public static List<AdvEntity> GetByPositionID(int positionID)
        {
            if (positionID <= 0)
                throw new Exception(EX_IPOSITIONID_INVALID);
            return AdvDAL.GetByiPositionID(positionID);
        }
        /// <summary>
        /// Kiểm tra và thêm mới Adv
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Int32: ID của Adv Mới Thêm Vào</returns>
        public static Int32 Add(AdvEntity entity)
        {
            checkLogic(entity);
            //checkDuplicate(entity, true);
            checkFK(entity);
            return AdvDAL.Add(entity);
        }
        /// <summary>
        /// Kiểm tra và chỉnh sửa Adv
        /// </summary>
        /// <param name="entity">AdvEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Edit(AdvEntity entity)
        {
            checkExist(entity);
            checkLogic(entity);
            //checkDuplicate(entity, false);
            checkFK(entity);
            return AdvDAL.Edit(entity);
        }
        /// <summary>
        /// Kiểm tra và xoá Adv
        /// </summary>
        /// <param name="entity">AdvEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Remove(AdvEntity entity)
        {
            checkExist(entity);
            //checkFK(entity);
            return AdvDAL.Remove(entity.iAdvID);
        }
        #endregion
        #region Private Methods
        private static void checkExist(AdvEntity entity)
        {
            AdvEntity oAdv=AdvDAL.GetOne(entity.iAdvID);
            if(oAdv==null)
                throw new Exception(EX_NOT_EXIST);
        }
        /// <summary>
        /// Kiểm tra logic Entity
        /// </summary>
        /// <param name="entity">AdvEntity: entity</param>
        private static void checkLogic(AdvEntity entity)
        {   
			if (String.IsNullOrEmpty(entity.sTitle))
				throw new Exception(EX_STITLE_EMPTY);
			if (String.IsNullOrEmpty(entity.sLink))
				throw new Exception(EX_SLINK_EMPTY);
			if (String.IsNullOrEmpty(entity.sMedia))
				throw new Exception(EX_SMEDIA_EMPTY);
			if (entity.iType < 0)
				throw new Exception(EX_ITYPE_INVALID);
			if (entity.iOrder < 0)
				throw new Exception(EX_IORDER_INVALID);
			if (entity.iPositionID < 0)
				throw new Exception(EX_IPOSITIONID_INVALID);
            if (entity.iWidth < 0)
                throw new Exception(EX_IWIDTH_INVALID);
            if (entity.iHeight < 0)
                throw new Exception(EX_IHEIGHT_INVALID);
        }
        /// <summary>
        /// Kiểm tra trùng lặp bản ghi
        /// </summary>
        /// <param name="entity">AdvEntity: AdvEntity</param>
        private static void checkDuplicate(AdvEntity entity,bool CheckInsert)
        {
            
            List<AdvEntity> list = AdvDAL.GetAll();
            if (list.Exists(
                delegate(AdvEntity oldEntity)
                {
                    bool result =oldEntity.sTitle.Equals(entity.sTitle, StringComparison.OrdinalIgnoreCase);
                    if(!CheckInsert)
                        result=result && oldEntity.iAdvID != entity.iAdvID;
                    return result;
                }
            ))
            {
                list.Clear();
                throw new Exception(EX_ADV_EXISTED);
            }
            
        }
        /// <summary>
        /// Kiểm tra tồn tại khóa ngoại
        /// </summary>
        /// <param name="entity">AdvEntity:entity</param>
        private static void checkFK(AdvEntity entity)
        {            
			PositionEntity oPosition = PositionDAL.GetOne(entity.iPositionID);
			if (oPosition==null)
			{
				throw new Exception("Không tìm thấy vị trí này");
			}
        }
        #endregion
    }
}
