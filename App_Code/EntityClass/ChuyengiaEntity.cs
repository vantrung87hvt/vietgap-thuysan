/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:6/24/2012 2:35:47 PM
------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace INVI.Entity
{
    public class ChuyengiaEntity
    {
        public ChuyengiaEntity()
        {
			m_pk_ichuyengiaid=0;
			m_shoten="";
			m_fk_itochucchungnhanid=0;
			m_inamkinhnghiem=0;
			m_smaso="";
			m_bduyet=false;
			m_itrangthai=0;
			m_imanh=null;
			m_fk_itrinhdoid=0;
            m_inamsinh = 0;
        }
		private Int32 m_pk_ichuyengiaid;
		public Int32 PK_iChuyengiaID
		{
			get { return m_pk_ichuyengiaid ; }
			set { m_pk_ichuyengiaid = value; }
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
		private Int16 m_inamkinhnghiem;
		public Int16 iNamkinhnghiem
		{
			get { return m_inamkinhnghiem ; }
			set { m_inamkinhnghiem = value; }
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
		
        private Byte[] m_imanh;
        public Byte[] imAnh
        {
            get { return m_imanh; }
            set { m_imanh = value; }
        }
		private Int16 m_fk_itrinhdoid;
		public Int16 FK_iTrinhdoID
		{
			get { return m_fk_itrinhdoid ; }
			set { m_fk_itrinhdoid = value; }
		}
        private Int32 m_inamsinh;
        public Int32 iNamsinh
        {
            get { return m_inamsinh; }
            set { m_inamsinh = value; }
        }

        #region Comparison
        public static List<ChuyengiaEntity> Sort(List<ChuyengiaEntity> list, String SortExpression, String SortDirection)
        {
            string strComparisonAttrb="COMPARISON_"+SortExpression;
            PropertyInfo propInfo= typeof(ChuyengiaEntity).GetProperty(strComparisonAttrb);
            if (propInfo != null)
            {
                list.Sort(propInfo.GetGetMethod().Invoke(null,null) as Comparison<ChuyengiaEntity>);
                if (SortDirection == "DESC")
                    list.Reverse();
            }
            return list;
        }
        
		public static Comparison<ChuyengiaEntity> COMPARISON_PK_iChuyengiaID
		{
			get
			{
				return delegate(ChuyengiaEntity entity,ChuyengiaEntity other)
				{
					return entity.PK_iChuyengiaID.CompareTo(other.PK_iChuyengiaID);
				};
			}
		}
		public static Comparison<ChuyengiaEntity> COMPARISON_sHoten
		{
			get
			{
				return delegate(ChuyengiaEntity entity,ChuyengiaEntity other)
				{
					return entity.sHoten.CompareTo(other.sHoten);
				};
			}
		}
		public static Comparison<ChuyengiaEntity> COMPARISON_FK_iTochucchungnhanID
		{
			get
			{
				return delegate(ChuyengiaEntity entity,ChuyengiaEntity other)
				{
					return entity.FK_iTochucchungnhanID.CompareTo(other.FK_iTochucchungnhanID);
				};
			}
		}
		public static Comparison<ChuyengiaEntity> COMPARISON_iNamkinhnghiem
		{
			get
			{
				return delegate(ChuyengiaEntity entity,ChuyengiaEntity other)
				{
					return entity.iNamkinhnghiem.CompareTo(other.iNamkinhnghiem);
				};
			}
		}
		public static Comparison<ChuyengiaEntity> COMPARISON_sMaso
		{
			get
			{
				return delegate(ChuyengiaEntity entity,ChuyengiaEntity other)
				{
					return entity.sMaso.CompareTo(other.sMaso);
				};
			}
		}
		public static Comparison<ChuyengiaEntity> COMPARISON_bDuyet
		{
			get
			{
				return delegate(ChuyengiaEntity entity,ChuyengiaEntity other)
				{
					return entity.bDuyet.CompareTo(other.bDuyet);
				};
			}
		}
		public static Comparison<ChuyengiaEntity> COMPARISON_iTrangthai
		{
			get
			{
				return delegate(ChuyengiaEntity entity,ChuyengiaEntity other)
				{
					return entity.iTrangthai.CompareTo(other.iTrangthai);
				};
			}
		}
		public static Comparison<ChuyengiaEntity> COMPARISON_imAnh
		{
			get
			{
				return delegate(ChuyengiaEntity entity,ChuyengiaEntity other)
				{
                    if (entity.imAnh.Equals(other.imAnh) == true)
                        return 1;
                    else
                        return 0;
				};
			}
		}
       
		public static Comparison<ChuyengiaEntity> COMPARISON_FK_iTrinhdoID
		{
			get
			{
				return delegate(ChuyengiaEntity entity,ChuyengiaEntity other)
				{
					return entity.FK_iTrinhdoID.CompareTo(other.FK_iTrinhdoID);
				};
			}
		}
        public static Comparison<ChuyengiaEntity> COMPARISON_iNamsinh
        {
            get
            {
                return delegate(ChuyengiaEntity entity, ChuyengiaEntity other)
                {
                    return entity.iNamsinh.CompareTo(other.iNamsinh);
                };
            }
        }
        #endregion
    }
}
