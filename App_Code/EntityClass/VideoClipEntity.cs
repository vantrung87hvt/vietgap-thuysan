/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:7/18/2012 5:20:41 PM
------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace INVI.Entity
{
    public class VideoClipEntity
    {
        public VideoClipEntity()
        {
			m_pk_ivideoid=0;
			m_stentep="";
			m_stieude="";
			m_isolanxem=0;
			m_idungluong=0;
			m_iwidth=0;
			m_iheight=0;
			m_fk_icategoryid=0;
			m_smota="";
			m_dngaytai=DateTime.Now;
			m_sanhminhhoa="";
        }
		private Int32 m_pk_ivideoid;
		public Int32 PK_iVideoID
		{
			get { return m_pk_ivideoid ; }
			set { m_pk_ivideoid = value; }
		}
		private String m_stentep;
		public String sTentep
		{
			get { return m_stentep ; }
			set { m_stentep = value; }
		}
		private String m_stieude;
		public String sTieude
		{
			get { return m_stieude ; }
			set { m_stieude = value; }
		}
		private Int32 m_isolanxem;
		public Int32 iSolanxem
		{
			get { return m_isolanxem ; }
			set { m_isolanxem = value; }
		}
		private Int64 m_idungluong;
		public Int64 iDungluong
		{
			get { return m_idungluong ; }
			set { m_idungluong = value; }
		}
		private Int32 m_iwidth;
		public Int32 iWidth
		{
			get { return m_iwidth ; }
			set { m_iwidth = value; }
		}
		private Int32 m_iheight;
		public Int32 iHeight
		{
			get { return m_iheight ; }
			set { m_iheight = value; }
		}
		private Int32 m_fk_icategoryid;
		public Int32 FK_iCategoryID
		{
			get { return m_fk_icategoryid ; }
			set { m_fk_icategoryid = value; }
		}
		private String m_smota;
		public String sMota
		{
			get { return m_smota ; }
			set { m_smota = value; }
		}
		private DateTime m_dngaytai;
		public DateTime dNgaytai
		{
			get { return m_dngaytai ; }
			set { m_dngaytai = value; }
		}
		private String m_sanhminhhoa;
		public String sAnhMinhHoa
		{
			get { return m_sanhminhhoa ; }
			set { m_sanhminhhoa = value; }
		}

        #region Comparison
        public static List<VideoClipEntity> Sort(List<VideoClipEntity> list, String SortExpression, String SortDirection)
        {
            string strComparisonAttrb="COMPARISON_"+SortExpression;
            PropertyInfo propInfo= typeof(VideoClipEntity).GetProperty(strComparisonAttrb);
            if (propInfo != null)
            {
                list.Sort(propInfo.GetGetMethod().Invoke(null,null) as Comparison<VideoClipEntity>);
                if (SortDirection == "DESC")
                    list.Reverse();
            }
            return list;
        }
        
		public static Comparison<VideoClipEntity> COMPARISON_PK_iVideoID
		{
			get
			{
				return delegate(VideoClipEntity entity,VideoClipEntity other)
				{
					return entity.PK_iVideoID.CompareTo(other.PK_iVideoID);
				};
			}
		}
		public static Comparison<VideoClipEntity> COMPARISON_sTentep
		{
			get
			{
				return delegate(VideoClipEntity entity,VideoClipEntity other)
				{
					return entity.sTentep.CompareTo(other.sTentep);
				};
			}
		}
		public static Comparison<VideoClipEntity> COMPARISON_sTieude
		{
			get
			{
				return delegate(VideoClipEntity entity,VideoClipEntity other)
				{
					return entity.sTieude.CompareTo(other.sTieude);
				};
			}
		}
		public static Comparison<VideoClipEntity> COMPARISON_iSolanxem
		{
			get
			{
				return delegate(VideoClipEntity entity,VideoClipEntity other)
				{
					return entity.iSolanxem.CompareTo(other.iSolanxem);
				};
			}
		}
		public static Comparison<VideoClipEntity> COMPARISON_iDungluong
		{
			get
			{
				return delegate(VideoClipEntity entity,VideoClipEntity other)
				{
					return entity.iDungluong.CompareTo(other.iDungluong);
				};
			}
		}
		public static Comparison<VideoClipEntity> COMPARISON_iWidth
		{
			get
			{
				return delegate(VideoClipEntity entity,VideoClipEntity other)
				{
					return entity.iWidth.CompareTo(other.iWidth);
				};
			}
		}
		public static Comparison<VideoClipEntity> COMPARISON_iHeight
		{
			get
			{
				return delegate(VideoClipEntity entity,VideoClipEntity other)
				{
					return entity.iHeight.CompareTo(other.iHeight);
				};
			}
		}
		public static Comparison<VideoClipEntity> COMPARISON_FK_iCategoryID
		{
			get
			{
				return delegate(VideoClipEntity entity,VideoClipEntity other)
				{
					return entity.FK_iCategoryID.CompareTo(other.FK_iCategoryID);
				};
			}
		}
		public static Comparison<VideoClipEntity> COMPARISON_sMota
		{
			get
			{
				return delegate(VideoClipEntity entity,VideoClipEntity other)
				{
					return entity.sMota.CompareTo(other.sMota);
				};
			}
		}
		public static Comparison<VideoClipEntity> COMPARISON_dNgaytai
		{
			get
			{
				return delegate(VideoClipEntity entity,VideoClipEntity other)
				{
					return entity.dNgaytai.CompareTo(other.dNgaytai);
				};
			}
		}
		public static Comparison<VideoClipEntity> COMPARISON_sAnhMinhHoa
		{
			get
			{
				return delegate(VideoClipEntity entity,VideoClipEntity other)
				{
					return entity.sAnhMinhHoa.CompareTo(other.sAnhMinhHoa);
				};
			}
		}
        #endregion
    }
}
