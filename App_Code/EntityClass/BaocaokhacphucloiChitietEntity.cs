/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:12/17/2011 9:34:35 PM
------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace INVI.Entity
{
    public class BaocaokhacphucloiChitietEntity
    {
        public BaocaokhacphucloiChitietEntity()
        {
			m_pk_ibaocaokhacphucloichitietid=0;
			m_sloisai="";
			m_sbienphapkhacphuc="";
			m_iketqua=0;
			m_fk_ibaocaokhacphucloiid=0;
        }
		private Int64 m_pk_ibaocaokhacphucloichitietid;
		public Int64 PK_iBaocaokhacphucloiChitietID
		{
			get { return m_pk_ibaocaokhacphucloichitietid ; }
			set { m_pk_ibaocaokhacphucloichitietid = value; }
		}
		private String m_sloisai;
		public String sLoisai
		{
			get { return m_sloisai ; }
			set { m_sloisai = value; }
		}
		private String m_sbienphapkhacphuc;
		public String sBienphapkhacphuc
		{
			get { return m_sbienphapkhacphuc ; }
			set { m_sbienphapkhacphuc = value; }
		}
		private Int16 m_iketqua;
		public Int16 iKetqua
		{
			get { return m_iketqua ; }
			set { m_iketqua = value; }
		}
		private Int64 m_fk_ibaocaokhacphucloiid;
		public Int64 FK_iBaocaokhacphucloiID
		{
			get { return m_fk_ibaocaokhacphucloiid ; }
			set { m_fk_ibaocaokhacphucloiid = value; }
		}

        #region Comparison
        public static List<BaocaokhacphucloiChitietEntity> Sort(List<BaocaokhacphucloiChitietEntity> list, String SortExpression, String SortDirection)
        {
            string strComparisonAttrb="COMPARISON_"+SortExpression;
            PropertyInfo propInfo= typeof(BaocaokhacphucloiChitietEntity).GetProperty(strComparisonAttrb);
            if (propInfo != null)
            {
                list.Sort(propInfo.GetGetMethod().Invoke(null,null) as Comparison<BaocaokhacphucloiChitietEntity>);
                if (SortDirection == "DESC")
                    list.Reverse();
            }
            return list;
        }
        
		public static Comparison<BaocaokhacphucloiChitietEntity> COMPARISON_PK_iBaocaokhacphucloiChitietID
		{
			get
			{
				return delegate(BaocaokhacphucloiChitietEntity entity,BaocaokhacphucloiChitietEntity other)
				{
					return entity.PK_iBaocaokhacphucloiChitietID.CompareTo(other.PK_iBaocaokhacphucloiChitietID);
				};
			}
		}
		public static Comparison<BaocaokhacphucloiChitietEntity> COMPARISON_sLoisai
		{
			get
			{
				return delegate(BaocaokhacphucloiChitietEntity entity,BaocaokhacphucloiChitietEntity other)
				{
					return entity.sLoisai.CompareTo(other.sLoisai);
				};
			}
		}
		public static Comparison<BaocaokhacphucloiChitietEntity> COMPARISON_sBienphapkhacphuc
		{
			get
			{
				return delegate(BaocaokhacphucloiChitietEntity entity,BaocaokhacphucloiChitietEntity other)
				{
					return entity.sBienphapkhacphuc.CompareTo(other.sBienphapkhacphuc);
				};
			}
		}
		public static Comparison<BaocaokhacphucloiChitietEntity> COMPARISON_iKetqua
		{
			get
			{
				return delegate(BaocaokhacphucloiChitietEntity entity,BaocaokhacphucloiChitietEntity other)
				{
					return entity.iKetqua.CompareTo(other.iKetqua);
				};
			}
		}
		public static Comparison<BaocaokhacphucloiChitietEntity> COMPARISON_FK_iBaocaokhacphucloiID
		{
			get
			{
				return delegate(BaocaokhacphucloiChitietEntity entity,BaocaokhacphucloiChitietEntity other)
				{
					return entity.FK_iBaocaokhacphucloiID.CompareTo(other.FK_iBaocaokhacphucloiID);
				};
			}
		}
        #endregion
    }
}
