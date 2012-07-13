/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:7/13/2012 11:25:43 AM
------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace INVI.Entity
{
    public class CosonuoitrongEntity
    {
        public CosonuoitrongEntity()
        {
			m_pk_icosonuoitrongid=0;
			m_smaso_vietgap="";
			m_stencoso="";
			m_stenchucoso="";
			m_sap="";
			m_sxa="";
			m_fk_iquanhuyenid=0;
			m_sdienthoai="";
			m_ftongdientich=0;
			m_ftongdientichmatnuoc=0;
			m_fk_itoadoid=0;
			m_ssodoaonuoi="";
			m_fk_idoituongnuoiid=0;
			m_inamsanxuat=0;
			m_ichukynuoi=0;
			m_dngaydangky=DateTime.Now;
			m_bduyet=false;
			m_smasocoso="";
			m_isanluongdukien=0;
			m_fdientichaolang=0;
			m_fk_ihinhthucnuoiid=0;
			m_fk_itochucchungnhanid=0;
			m_fk_iuserid=0;
			m_bxoa=false;
        }
		private Int64 m_pk_icosonuoitrongid;
		public Int64 PK_iCosonuoitrongID
		{
			get { return m_pk_icosonuoitrongid ; }
			set { m_pk_icosonuoitrongid = value; }
		}
		private String m_smaso_vietgap;
		public String sMaso_vietgap
		{
			get { return m_smaso_vietgap ; }
			set { m_smaso_vietgap = value; }
		}
		private String m_stencoso;
		public String sTencoso
		{
			get { return m_stencoso ; }
			set { m_stencoso = value; }
		}
		private String m_stenchucoso;
		public String sTenchucoso
		{
			get { return m_stenchucoso ; }
			set { m_stenchucoso = value; }
		}
		private String m_sap;
		public String sAp
		{
			get { return m_sap ; }
			set { m_sap = value; }
		}
		private String m_sxa;
		public String sXa
		{
			get { return m_sxa ; }
			set { m_sxa = value; }
		}
		private Int64 m_fk_iquanhuyenid;
		public Int64 FK_iQuanHuyenID
		{
			get { return m_fk_iquanhuyenid ; }
			set { m_fk_iquanhuyenid = value; }
		}
		private String m_sdienthoai;
		public String sDienthoai
		{
			get { return m_sdienthoai ; }
			set { m_sdienthoai = value; }
		}
		private float m_ftongdientich;
		public float fTongdientich
		{
			get { return m_ftongdientich ; }
			set { m_ftongdientich = value; }
		}
		private float m_ftongdientichmatnuoc;
		public float fTongdientichmatnuoc
		{
			get { return m_ftongdientichmatnuoc ; }
			set { m_ftongdientichmatnuoc = value; }
		}
		private Int32 m_fk_itoadoid;
		public Int32 FK_iToadoID
		{
			get { return m_fk_itoadoid ; }
			set { m_fk_itoadoid = value; }
		}
		private String m_ssodoaonuoi;
		public String sSodoaonuoi
		{
			get { return m_ssodoaonuoi ; }
			set { m_ssodoaonuoi = value; }
		}
		private Int32 m_fk_idoituongnuoiid;
		public Int32 FK_iDoituongnuoiID
		{
			get { return m_fk_idoituongnuoiid ; }
			set { m_fk_idoituongnuoiid = value; }
		}
		private Int32 m_inamsanxuat;
		public Int32 iNamsanxuat
		{
			get { return m_inamsanxuat ; }
			set { m_inamsanxuat = value; }
		}
		private Int32 m_ichukynuoi;
		public Int32 iChukynuoi
		{
			get { return m_ichukynuoi ; }
			set { m_ichukynuoi = value; }
		}
		private DateTime m_dngaydangky;
		public DateTime dNgaydangky
		{
			get { return m_dngaydangky ; }
			set { m_dngaydangky = value; }
		}
		private Boolean m_bduyet;
		public Boolean bDuyet
		{
			get { return m_bduyet ; }
			set { m_bduyet = value; }
		}
		private String m_smasocoso;
		public String sMasocoso
		{
			get { return m_smasocoso ; }
			set { m_smasocoso = value; }
		}
		private Int32 m_isanluongdukien;
		public Int32 iSanluongdukien
		{
			get { return m_isanluongdukien ; }
			set { m_isanluongdukien = value; }
		}
		private float m_fdientichaolang;
		public float fDientichAolang
		{
			get { return m_fdientichaolang ; }
			set { m_fdientichaolang = value; }
		}
		private Int32 m_fk_ihinhthucnuoiid;
		public Int32 FK_iHinhthucnuoiID
		{
			get { return m_fk_ihinhthucnuoiid ; }
			set { m_fk_ihinhthucnuoiid = value; }
		}
		private Int32 m_fk_itochucchungnhanid;
		public Int32 FK_iTochucchungnhanID
		{
			get { return m_fk_itochucchungnhanid ; }
			set { m_fk_itochucchungnhanid = value; }
		}
		private Int64 m_fk_iuserid;
		public Int64 FK_iUserID
		{
			get { return m_fk_iuserid ; }
			set { m_fk_iuserid = value; }
		}
		private Boolean m_bxoa;
		public Boolean bXoa
		{
			get { return m_bxoa ; }
			set { m_bxoa = value; }
		}

        #region Comparison
        public static List<CosonuoitrongEntity> Sort(List<CosonuoitrongEntity> list, String SortExpression, String SortDirection)
        {
            string strComparisonAttrb="COMPARISON_"+SortExpression;
            PropertyInfo propInfo= typeof(CosonuoitrongEntity).GetProperty(strComparisonAttrb);
            if (propInfo != null)
            {
                list.Sort(propInfo.GetGetMethod().Invoke(null,null) as Comparison<CosonuoitrongEntity>);
                if (SortDirection == "DESC")
                    list.Reverse();
            }
            return list;
        }
        
		public static Comparison<CosonuoitrongEntity> COMPARISON_PK_iCosonuoitrongID
		{
			get
			{
				return delegate(CosonuoitrongEntity entity,CosonuoitrongEntity other)
				{
					return entity.PK_iCosonuoitrongID.CompareTo(other.PK_iCosonuoitrongID);
				};
			}
		}
		public static Comparison<CosonuoitrongEntity> COMPARISON_sMaso_vietgap
		{
			get
			{
				return delegate(CosonuoitrongEntity entity,CosonuoitrongEntity other)
				{
					return entity.sMaso_vietgap.CompareTo(other.sMaso_vietgap);
				};
			}
		}
		public static Comparison<CosonuoitrongEntity> COMPARISON_sTencoso
		{
			get
			{
				return delegate(CosonuoitrongEntity entity,CosonuoitrongEntity other)
				{
					return entity.sTencoso.CompareTo(other.sTencoso);
				};
			}
		}
		public static Comparison<CosonuoitrongEntity> COMPARISON_sTenchucoso
		{
			get
			{
				return delegate(CosonuoitrongEntity entity,CosonuoitrongEntity other)
				{
					return entity.sTenchucoso.CompareTo(other.sTenchucoso);
				};
			}
		}
		public static Comparison<CosonuoitrongEntity> COMPARISON_sAp
		{
			get
			{
				return delegate(CosonuoitrongEntity entity,CosonuoitrongEntity other)
				{
					return entity.sAp.CompareTo(other.sAp);
				};
			}
		}
		public static Comparison<CosonuoitrongEntity> COMPARISON_sXa
		{
			get
			{
				return delegate(CosonuoitrongEntity entity,CosonuoitrongEntity other)
				{
					return entity.sXa.CompareTo(other.sXa);
				};
			}
		}
		public static Comparison<CosonuoitrongEntity> COMPARISON_FK_iQuanHuyenID
		{
			get
			{
				return delegate(CosonuoitrongEntity entity,CosonuoitrongEntity other)
				{
					return entity.FK_iQuanHuyenID.CompareTo(other.FK_iQuanHuyenID);
				};
			}
		}
		public static Comparison<CosonuoitrongEntity> COMPARISON_sDienthoai
		{
			get
			{
				return delegate(CosonuoitrongEntity entity,CosonuoitrongEntity other)
				{
					return entity.sDienthoai.CompareTo(other.sDienthoai);
				};
			}
		}
		public static Comparison<CosonuoitrongEntity> COMPARISON_fTongdientich
		{
			get
			{
				return delegate(CosonuoitrongEntity entity,CosonuoitrongEntity other)
				{
					return entity.fTongdientich.CompareTo(other.fTongdientich);
				};
			}
		}
		public static Comparison<CosonuoitrongEntity> COMPARISON_fTongdientichmatnuoc
		{
			get
			{
				return delegate(CosonuoitrongEntity entity,CosonuoitrongEntity other)
				{
					return entity.fTongdientichmatnuoc.CompareTo(other.fTongdientichmatnuoc);
				};
			}
		}
		public static Comparison<CosonuoitrongEntity> COMPARISON_FK_iToadoID
		{
			get
			{
				return delegate(CosonuoitrongEntity entity,CosonuoitrongEntity other)
				{
					return entity.FK_iToadoID.CompareTo(other.FK_iToadoID);
				};
			}
		}
		public static Comparison<CosonuoitrongEntity> COMPARISON_sSodoaonuoi
		{
			get
			{
				return delegate(CosonuoitrongEntity entity,CosonuoitrongEntity other)
				{
					return entity.sSodoaonuoi.CompareTo(other.sSodoaonuoi);
				};
			}
		}
		public static Comparison<CosonuoitrongEntity> COMPARISON_FK_iDoituongnuoiID
		{
			get
			{
				return delegate(CosonuoitrongEntity entity,CosonuoitrongEntity other)
				{
					return entity.FK_iDoituongnuoiID.CompareTo(other.FK_iDoituongnuoiID);
				};
			}
		}
		public static Comparison<CosonuoitrongEntity> COMPARISON_iNamsanxuat
		{
			get
			{
				return delegate(CosonuoitrongEntity entity,CosonuoitrongEntity other)
				{
					return entity.iNamsanxuat.CompareTo(other.iNamsanxuat);
				};
			}
		}
		public static Comparison<CosonuoitrongEntity> COMPARISON_iChukynuoi
		{
			get
			{
				return delegate(CosonuoitrongEntity entity,CosonuoitrongEntity other)
				{
					return entity.iChukynuoi.CompareTo(other.iChukynuoi);
				};
			}
		}
		public static Comparison<CosonuoitrongEntity> COMPARISON_dNgaydangky
		{
			get
			{
				return delegate(CosonuoitrongEntity entity,CosonuoitrongEntity other)
				{
					return entity.dNgaydangky.CompareTo(other.dNgaydangky);
				};
			}
		}
		public static Comparison<CosonuoitrongEntity> COMPARISON_bDuyet
		{
			get
			{
				return delegate(CosonuoitrongEntity entity,CosonuoitrongEntity other)
				{
					return entity.bDuyet.CompareTo(other.bDuyet);
				};
			}
		}
		public static Comparison<CosonuoitrongEntity> COMPARISON_sMasocoso
		{
			get
			{
				return delegate(CosonuoitrongEntity entity,CosonuoitrongEntity other)
				{
					return entity.sMasocoso.CompareTo(other.sMasocoso);
				};
			}
		}
		public static Comparison<CosonuoitrongEntity> COMPARISON_iSanluongdukien
		{
			get
			{
				return delegate(CosonuoitrongEntity entity,CosonuoitrongEntity other)
				{
					return entity.iSanluongdukien.CompareTo(other.iSanluongdukien);
				};
			}
		}
		public static Comparison<CosonuoitrongEntity> COMPARISON_fDientichAolang
		{
			get
			{
				return delegate(CosonuoitrongEntity entity,CosonuoitrongEntity other)
				{
					return entity.fDientichAolang.CompareTo(other.fDientichAolang);
				};
			}
		}
		public static Comparison<CosonuoitrongEntity> COMPARISON_FK_iHinhthucnuoiID
		{
			get
			{
				return delegate(CosonuoitrongEntity entity,CosonuoitrongEntity other)
				{
					return entity.FK_iHinhthucnuoiID.CompareTo(other.FK_iHinhthucnuoiID);
				};
			}
		}
		public static Comparison<CosonuoitrongEntity> COMPARISON_FK_iTochucchungnhanID
		{
			get
			{
				return delegate(CosonuoitrongEntity entity,CosonuoitrongEntity other)
				{
					return entity.FK_iTochucchungnhanID.CompareTo(other.FK_iTochucchungnhanID);
				};
			}
		}
		public static Comparison<CosonuoitrongEntity> COMPARISON_FK_iUserID
		{
			get
			{
				return delegate(CosonuoitrongEntity entity,CosonuoitrongEntity other)
				{
					return entity.FK_iUserID.CompareTo(other.FK_iUserID);
				};
			}
		}
		public static Comparison<CosonuoitrongEntity> COMPARISON_bXoa
		{
			get
			{
				return delegate(CosonuoitrongEntity entity,CosonuoitrongEntity other)
				{
					return entity.bXoa.CompareTo(other.bXoa);
				};
			}
		}
        #endregion
    }
}
