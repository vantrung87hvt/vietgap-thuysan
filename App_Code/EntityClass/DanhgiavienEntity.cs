/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:01/01/2012 4:22:09 CH
------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace INVI.Entity
{
    public class DanhgiavienEntity
    {
        public DanhgiavienEntity()
        {
			m_pk_idanhgiavienid=0;
			m_shoten="";
			m_fk_itochucchungnhanid=0;
			m_strinhdo="";
			m_inamkinhnghiem=0;
			m_btcvn190112003=false;
			m_biso190112002=false;
			m_bvietgapcer=false;
			m_smaso="";
			m_bduyet=false;
			m_itrangthai=0;
        }
		private Int32 m_pk_idanhgiavienid;
		public Int32 PK_iDanhgiavienID
		{
			get { return m_pk_idanhgiavienid ; }
			set { m_pk_idanhgiavienid = value; }
		}
		private String m_shoten;
		public String sHoten
		{
			get { return m_shoten ; }
			set { m_shoten = value; }
		}
		private Int32 m_fk_itochucchungnhanid;
		public Int32 FK_iTochucchungnhanID
		{
			get { return m_fk_itochucchungnhanid ; }
			set { m_fk_itochucchungnhanid = value; }
		}
		private String m_strinhdo;
		public String sTrinhdo
		{
			get { return m_strinhdo ; }
			set { m_strinhdo = value; }
		}
		private Int16 m_inamkinhnghiem;
		public Int16 iNamkinhnghiem
		{
			get { return m_inamkinhnghiem ; }
			set { m_inamkinhnghiem = value; }
		}
		private Boolean m_btcvn190112003;
		public Boolean bTCVN190112003
		{
			get { return m_btcvn190112003 ; }
			set { m_btcvn190112003 = value; }
		}
		private Boolean m_biso190112002;
		public Boolean bISO190112002
		{
			get { return m_biso190112002 ; }
			set { m_biso190112002 = value; }
		}
		private Boolean m_bvietgapcer;
		public Boolean bVietGapCer
		{
			get { return m_bvietgapcer ; }
			set { m_bvietgapcer = value; }
		}
		private String m_smaso;
		public String sMaso
		{
			get { return m_smaso ; }
			set { m_smaso = value; }
		}
		private Boolean m_bduyet;
		public Boolean bDuyet
		{
			get { return m_bduyet ; }
			set { m_bduyet = value; }
		}
		private Int16 m_itrangthai;
		public Int16 iTrangthai
		{
			get { return m_itrangthai ; }
			set { m_itrangthai = value; }
		}

        #region Comparison
        public static List<DanhgiavienEntity> Sort(List<DanhgiavienEntity> list, String SortExpression, String SortDirection)
        {
            string strComparisonAttrb="COMPARISON_"+SortExpression;
            PropertyInfo propInfo= typeof(DanhgiavienEntity).GetProperty(strComparisonAttrb);
            if (propInfo != null)
            {
                list.Sort(propInfo.GetGetMethod().Invoke(null,null) as Comparison<DanhgiavienEntity>);
                if (SortDirection == "DESC")
                    list.Reverse();
            }
            return list;
        }
        
		public static Comparison<DanhgiavienEntity> COMPARISON_PK_iDanhgiavienID
		{
			get
			{
				return delegate(DanhgiavienEntity entity,DanhgiavienEntity other)
				{
					return entity.PK_iDanhgiavienID.CompareTo(other.PK_iDanhgiavienID);
				};
			}
		}
		public static Comparison<DanhgiavienEntity> COMPARISON_sHoten
		{
			get
			{
				return delegate(DanhgiavienEntity entity,DanhgiavienEntity other)
				{
					return entity.sHoten.CompareTo(other.sHoten);
				};
			}
		}
		public static Comparison<DanhgiavienEntity> COMPARISON_FK_iTochucchungnhanID
		{
			get
			{
				return delegate(DanhgiavienEntity entity,DanhgiavienEntity other)
				{
					return entity.FK_iTochucchungnhanID.CompareTo(other.FK_iTochucchungnhanID);
				};
			}
		}
		public static Comparison<DanhgiavienEntity> COMPARISON_sTrinhdo
		{
			get
			{
				return delegate(DanhgiavienEntity entity,DanhgiavienEntity other)
				{
					return entity.sTrinhdo.CompareTo(other.sTrinhdo);
				};
			}
		}
		public static Comparison<DanhgiavienEntity> COMPARISON_iNamkinhnghiem
		{
			get
			{
				return delegate(DanhgiavienEntity entity,DanhgiavienEntity other)
				{
					return entity.iNamkinhnghiem.CompareTo(other.iNamkinhnghiem);
				};
			}
		}
		public static Comparison<DanhgiavienEntity> COMPARISON_bTCVN190112003
		{
			get
			{
				return delegate(DanhgiavienEntity entity,DanhgiavienEntity other)
				{
					return entity.bTCVN190112003.CompareTo(other.bTCVN190112003);
				};
			}
		}
		public static Comparison<DanhgiavienEntity> COMPARISON_bISO190112002
		{
			get
			{
				return delegate(DanhgiavienEntity entity,DanhgiavienEntity other)
				{
					return entity.bISO190112002.CompareTo(other.bISO190112002);
				};
			}
		}
		public static Comparison<DanhgiavienEntity> COMPARISON_bVietGapCer
		{
			get
			{
				return delegate(DanhgiavienEntity entity,DanhgiavienEntity other)
				{
					return entity.bVietGapCer.CompareTo(other.bVietGapCer);
				};
			}
		}
		public static Comparison<DanhgiavienEntity> COMPARISON_sMaso
		{
			get
			{
				return delegate(DanhgiavienEntity entity,DanhgiavienEntity other)
				{
					return entity.sMaso.CompareTo(other.sMaso);
				};
			}
		}
		public static Comparison<DanhgiavienEntity> COMPARISON_bDuyet
		{
			get
			{
				return delegate(DanhgiavienEntity entity,DanhgiavienEntity other)
				{
					return entity.bDuyet.CompareTo(other.bDuyet);
				};
			}
		}
		public static Comparison<DanhgiavienEntity> COMPARISON_iTrangthai
		{
			get
			{
				return delegate(DanhgiavienEntity entity,DanhgiavienEntity other)
				{
					return entity.iTrangthai.CompareTo(other.iTrangthai);
				};
			}
		}
        #endregion
    }
}
