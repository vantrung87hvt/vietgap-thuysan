/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:1/12/2009 11:16:03 AM
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
    public class PositionBRL
    {
        #region Init
        private static string EX_NOT_EXIST="Không Tồn Tại Position Này";
		private static string EX_SNAME_EMPTY="sName không được để trống";
		private static string EX_ID_INVALID="iPositionID không hợp lệ";
        private static string EX_IDPOSITION_NOTFOUND = "Không tìm thấy vị trí này";
        #endregion
        #region Public Methods
        /// <summary>
        /// Get Position Theo ID
        /// </summary>
        /// <param name="iPositionID">Int32:Position ID</param>
        /// <returns>PositionEntity</returns>        
        public static PositionEntity GetOne(Int32 iPositionID)
        {
            
			if(iPositionID<=0)
				throw new Exception(EX_ID_INVALID);
            return PositionDAL.GetOne(iPositionID);
        }
        /// <summary>
        /// Lấy về List các Position
        /// </summary>
        /// <returns>List PositionEntity:List Position Cần lấy</returns>
        public static List<PositionEntity> GetAll()
        {
            return PositionDAL.GetAll();
        }
        /// <summary>
        /// Kiểm tra và thêm mới Position
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Int32: ID của Position Mới Thêm Vào</returns>
        public static Int32 Add(PositionEntity entity)
        {   
            checkLogic(entity);
            checkDuplicate(entity, true);
            checkFK(entity);
            return PositionDAL.Add(entity);
        }
        /// <summary>
        /// Kiểm tra và chỉnh sửa Position
        /// </summary>
        /// <param name="entity">PositionEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Edit(PositionEntity entity)
        {
            checkExist(entity);
            checkLogic(entity);
            checkDuplicate(entity, false);
            checkFK(entity);
            return PositionDAL.Edit(entity);
        }
        /// <summary>
        /// Kiểm tra và xoá Position
        /// </summary>
        /// <param name="entity">PositionEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Remove(PositionEntity entity)
        {
            checkExist(entity);
            
            return PositionDAL.Remove(entity.iPositionID);
        }
        #endregion
        #region Private Methods
        private static void checkExist(PositionEntity entity)
        {
            PositionEntity oPosition=PositionDAL.GetOne(entity.iPositionID);
            if(oPosition==null)
                throw new Exception(EX_NOT_EXIST);
        }
        /// <summary>
        /// Kiểm tra logic Entity
        /// </summary>
        /// <param name="entity">PositionEntity: entity</param>
        private static void checkLogic(PositionEntity entity)
        {   
			if (String.IsNullOrEmpty(entity.sName))
				throw new Exception(EX_SNAME_EMPTY);
        }
        /// <summary>
        /// Kiểm tra trùng lặp bản ghi
        /// </summary>
        /// <param name="entity">PositionEntity: PositionEntity</param>
        private static void checkDuplicate(PositionEntity entity,bool CheckInsert)
        {
           
            List<PositionEntity> list = PositionDAL.GetAll();
            if (list.Exists(
                delegate(PositionEntity oldEntity)
                {
                    bool result =oldEntity.sName.Equals(entity.sName, StringComparison.OrdinalIgnoreCase);
                    if(!CheckInsert)
                        result=result && oldEntity.iPositionID != entity.iPositionID;
                    return result;
                }
            ))
            {
                list.Clear();
                throw new Exception("Vị trí này đã tồn tại");
            }
           
        }
        /// <summary>
        /// Kiểm tra tồn tại khóa ngoại
        /// </summary>
        /// <param name="entity">PositionEntity:entity</param>
        private static void checkFK(PositionEntity entity)
        {
            PositionEntity oPosition = PositionDAL.GetOne(entity.iPositionID);
            if (oPosition == null)
            {
                throw new Exception(EX_IDPOSITION_NOTFOUND);
            }
        }
        #endregion
    }
}
