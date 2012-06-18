/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:12/22/2011 5:32:50 PM
------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace INVI.Entity
{
    public class GiaytonopkemhosoEntity
    {
        public GiaytonopkemhosoEntity()
        {
			m_pk_igiaytoguikemid=0;
			m_fk_igiaytoid=0;
			m_btrangthai=false;
			m_pk_ihosodangkychungnhanid=0;
        }
		private Int64 m_pk_igiaytoguikemid;
		public Int64 PK_iGiaytoguikemID
		{
			get { return m_pk_igiaytoguikemid ; }
			set { m_pk_igiaytoguikemid = value; }
		}
		private Int32 m_fk_igiaytoid;
		public Int32 FK_iGiaytoID
		{
			get { return m_fk_igiaytoid ; }
			set { m_fk_igiaytoid = value; }
		}
		private Boolean m_btrangthai;
		public Boolean bTrangthai
		{
			get { return m_btrangthai ; }
			set { m_btrangthai = value; }
		}
		private Int64 m_pk_ihosodangkychungnhanid;
		public Int64 PK_iHosodangkychungnhanID
		{
			get { return m_pk_ihosodangkychungnhanid ; }
			set { m_pk_ihosodangkychungnhanid = value; }
		}

        #region Comparison
        public static List<GiaytonopkemhosoEntity> Sort(List<GiaytonopkemhosoEntity> list, String SortExpression, String SortDirection)
        {
            string strComparisonAttrb="COMPARISON_"+SortExpression;
            PropertyInfo propInfo= typeof(GiaytonopkemhosoEntity).GetProperty(strComparisonAttrb);
            if (propInfo != null)
            {
                list.Sort(propInfo.GetGetMethod().Invoke(null,null) as Comparison<GiaytonopkemhosoEntity>);
                if (SortDirection == "DESC")
                    list.Reverse();
            }
            return list;
        }
        
		public static Comparison<GiaytonopkemhosoEntity> COMPARISON_PK_iGiaytoguikemID
		{
			get
			{
				return delegate(GiaytonopkemhosoEntity entity,GiaytonopkemhosoEntity other)
				{
					return entity.PK_iGiaytoguikemID.CompareTo(other.PK_iGiaytoguikemID);
				};
			}
		}
		public static Comparison<GiaytonopkemhosoEntity> COMPARISON_FK_iGiaytoID
		{
			get
			{
				return delegate(GiaytonopkemhosoEntity entity,GiaytonopkemhosoEntity other)
				{
					return entity.FK_iGiaytoID.CompareTo(other.FK_iGiaytoID);
				};
			}
		}
		public static Comparison<GiaytonopkemhosoEntity> COMPARISON_bTrangthai
		{
			get
			{
				return delegate(GiaytonopkemhosoEntity entity,GiaytonopkemhosoEntity other)
				{
					return entity.bTrangthai.CompareTo(other.bTrangthai);
				};
			}
		}
		public static Comparison<GiaytonopkemhosoEntity> COMPARISON_PK_iHosodangkychungnhanID
		{
			get
			{
				return delegate(GiaytonopkemhosoEntity entity,GiaytonopkemhosoEntity other)
				{
					return entity.PK_iHosodangkychungnhanID.CompareTo(other.PK_iHosodangkychungnhanID);
				};
			}
		}
        #endregion
    }
}
