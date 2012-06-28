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
using System.Web;
namespace INVI.Business
{
    public class PermissionBRL
    {
        #region Init
        private static string EX_NOT_EXIST="Không Tồn Tại Permission Này";
		private static string EX_SNAME_EMPTY="sName không được để trống";
		private static string EX_ID_INVALID="iPermissionID không hợp lệ";
        private static string EX_PERMISSIONID_NOTFOUND="Không tìm thấy quyền này";
        private static string EX_PERMISSION_EXISTED="Tên quyền đã tồn tại";
        private static string EX_GROUPID_INVALID = "Nhóm ID không hợp lệ";
        #endregion
        #region Public Methods

        public static Dictionary<string,int> Permission;
        static PermissionBRL()
        {
            Permission= new Dictionary<string,int>();
            Permission.Add("EditNews",5);
            Permission.Add("AddNews",2);
            Permission.Add("ManagerCategory", 25);
            Permission.Add("ManagerPoll", 32);
            Permission.Add("VerifyFeedback", 33);
            Permission.Add("ManagerUser",3);
            Permission.Add("ManagerGroupPermission",4);
            Permission.Add("ManagerDocument",6);
            Permission.Add("ManagerAdv", 18);
            Permission.Add("EditConfig",50);
            Permission.Add("DeleteNews", 9);
            Permission.Add("VerifyNews", 10);
            Permission.Add("ManagerGroup", 8);
            Permission.Add("licenseGAP",12);
            Permission.Add("AddCosonuoi", 13);
            Permission.Add("EditCosonuoi", 14);
            Permission.Add("AddTochuccapphep", 15);
            Permission.Add("EditTochuccapphep", 16);
            Permission.Add("VerifyCosonuoitrong", 17);
            Permission.Add("Manageprovince",19);
            Permission.Add("QuanlyDoituongnuoi", 21);
            Permission.Add("CapgiayphepVietGAP", 22);
            Permission.Add("ManageFeedback", 25);
            Permission.Add("ThemmoiQuyen", 26);
            Permission.Add("ManageNews", 27);
            Permission.Add("QuanlyTCCN", 28);
            Permission.Add("XoaCSNT", 30);
            Permission.Add("ManageFAQCate", 34);
            Permission.Add("ManageNewCateTree", 36);
            Permission.Add("ManageNewCatTable", 35);
            Permission.Add("ManageDoc", 37);
            Permission.Add("GiahanGCN", 38);
            Permission.Add("ManageMSVietGAP", 39);
            Permission.Add("Thongketheodoituong", 40);
            Permission.Add("Thongketheodialy", 41);
            Permission.Add("ThongketheoTCCN", 42);
            Permission.Add("GuiGiayCNVietGAP", 43);
            Permission.Add("QuanlyCSNT", 44);
            Permission.Add("QuanlyDanhgiavien", 45);
            Permission.Add("QuanlyHinhthucnuoi", 46);
            Permission.Add("Xemchitietgiaydangkyhoatdongchungnhan", 47);
            Permission.Add("Quanlycoquancaptren", 48);
            Permission.Add("Duyettochucchungnhan", 49);
            Permission.Add("EditContact", 7);
            Permission.Add("QuanlyQuanHuyen", 51);
            Permission.Add("QuanlyDanhmucchitieu", 52);
            Permission.Add("QuanlyMucdoChitieu", 53);
            Permission.Add("QuanlyPhuongphapkiemtra", 54);
            Permission.Add("Quanlychitieu", 55);
            Permission.Add("ManageFAQ", 57);
            Permission.Add("QuanlyPhongban", 58);
            Permission.Add("QuanlyChucvu", 59);
            Permission.Add("QuanlyDanhba", 60);
            Permission.Add("QuanlyDanhsachDanhba", 61);
            Permission.Add("QuanlyGiayto", 63);
            Permission.Add("Xemcacthongketonghop", 65);
            Permission.Add("QuanlyThanhvienDangkyBoiTochucchungnhan", 65);
            Permission.Add("QuanlyCacloaichungchiMachuyengiacotheco", 66);
            Permission.Add("Dangkyhoatdongchungnhan", 67);
            Permission.Add("Xemgiaydangkyhoatdongchungnhan_TCCN", 68);
            Permission.Add("Quanlycacloaitrinhdocuachuyengia", 69);
        }
        public static bool CheckPermission(string key)
        {
            if (HttpContext.Current.Session["GroupID"] == null)
                return false;
            int groupID = Convert.ToInt32(HttpContext.Current.Session["GroupID"]);
            List<PermissionEntity> lstPer = PermissionBRL.GetByGroupID(groupID);
            if (!lstPer.Exists(
                delegate(PermissionEntity obj)
                {
                    return obj.iPermissionID == PermissionBRL.Permission[key];
                }
            ))
            {
                HttpContext.Current.Response.Write("<script type='text/javascript'>alert('Bạn ko có quyền sử dụng chức năng này');history.back()</script>");
                return false;
            }
            return true;
        }
        public static List<PermissionEntity> GetByGroupID(int groupID)
        {
            if(groupID<=0)
                throw new Exception(EX_GROUPID_INVALID);
            List<PermissionEntity> lstPer=new List<PermissionEntity>();
            List<GroupPermissionEntity> lstGrpPer=GroupPermissionDAL.GetByiGroupID(groupID);
            foreach(GroupPermissionEntity obj in lstGrpPer)
            {
                PermissionEntity oPer=PermissionDAL.GetOne(obj.iPermissionID);
                lstPer.Add(oPer);
            }
            return lstPer;

        }
        /// <summary>
        /// Get Permission Theo ID
        /// </summary>
        /// <param name="iPermissionID">Int32:Permission ID</param>
        /// <returns>PermissionEntity</returns>        
        public static PermissionEntity GetOne(Int32 iPermissionID)
        {
            
			if(iPermissionID<=0)
				throw new Exception(EX_ID_INVALID);
            return PermissionDAL.GetOne(iPermissionID);
        }
        /// <summary>
        /// Lấy về List các Permission
        /// </summary>
        /// <returns>List PermissionEntity:List Permission Cần lấy</returns>
        public static List<PermissionEntity> GetAll()
        {
            return PermissionDAL.GetAll();
        }
        /// <summary>
        /// Kiểm tra và thêm mới Permission
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Int32: ID của Permission Mới Thêm Vào</returns>
        public static Int32 Add(PermissionEntity entity)
        {
            checkLogic(entity);
            checkDuplicate(entity, true);
            //checkFK(entity);
            return PermissionDAL.Add(entity);
        }
        /// <summary>
        /// Kiểm tra và chỉnh sửa Permission
        /// </summary>
        /// <param name="entity">PermissionEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Edit(PermissionEntity entity)
        {
            checkExist(entity);
            checkLogic(entity);
            checkDuplicate(entity, false);
            checkFK(entity);
            return PermissionDAL.Edit(entity);
        }
        /// <summary>
        /// Kiểm tra và xoá Permission
        /// </summary>
        /// <param name="entity">PermissionEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Remove(PermissionEntity entity)
        {
            checkExist(entity);
            
            return PermissionDAL.Remove(entity.iPermissionID);
        }
        #endregion
        #region Private Methods
        private static void checkExist(PermissionEntity entity)
        {
            PermissionEntity oPermission=PermissionDAL.GetOne(entity.iPermissionID);
            if(oPermission==null)
                throw new Exception(EX_NOT_EXIST);
        }
        /// <summary>
        /// Kiểm tra logic Entity
        /// </summary>
        /// <param name="entity">PermissionEntity: entity</param>
        private static void checkLogic(PermissionEntity entity)
        {   
			if (String.IsNullOrEmpty(entity.sName))
				throw new Exception(EX_SNAME_EMPTY);
        }
        /// <summary>
        /// Kiểm tra trùng lặp bản ghi
        /// </summary>
        /// <param name="entity">PermissionEntity: PermissionEntity</param>
        private static void checkDuplicate(PermissionEntity entity,bool CheckInsert)
        {
            List<PermissionEntity> list = PermissionDAL.GetAll();
            if (list.Exists(
                delegate(PermissionEntity oldEntity)
                {
                    bool result =oldEntity.sName.Equals(entity.sName, StringComparison.OrdinalIgnoreCase);
                    if(!CheckInsert)
                        result=result && oldEntity.iPermissionID != entity.iPermissionID;
                    return result;
                }
            ))
            {
                list.Clear();
                throw new Exception(EX_PERMISSION_EXISTED);
            }
            
        }
        /// <summary>
        /// Kiểm tra tồn tại khóa ngoại
        /// </summary>
        /// <param name="entity">PermissionEntity:entity</param>
        private static void checkFK(PermissionEntity entity)
        {
            PermissionEntity oPermission = PermissionDAL.GetOne(entity.iPermissionID);
            //oPermission.sDesc
            //oPermission.sName
            if (oPermission == null)
            {
                throw new Exception(EX_PERMISSIONID_NOTFOUND);
            }
        }
        #endregion
    }
}
