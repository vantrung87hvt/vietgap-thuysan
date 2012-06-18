/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:11/21/2011 9:47:55 PM
------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace INVI.Entity
{
    public class DocumentEntity
    {
        public DocumentEntity()
        {
			m_pk_idocumentid=0;
			m_stitle="";
			m_sdesc="";
			m_simage="";
			m_idownloadtime=0;
			m_iuserid=0;
			m_slinkfile="";
			m_tdate=DateTime.Now;
			m_sauthor="";
			m_scoquanbanhanh="";
			m_fk_iloaivanbanid=0;
			m_dngaybanhanh=DateTime.Now;
			m_dngaydangcongbao=DateTime.Now;
			m_dngaycohieuluc=DateTime.Now;
			m_dngayhethieuluc=DateTime.Now;
			m_sphamvi="";
			m_ssokyhieu="";
        }
		private Int32 m_pk_idocumentid;
		public Int32 PK_iDocumentID
		{
			get { return m_pk_idocumentid ; }
			set { m_pk_idocumentid = value; }
		}
		private String m_stitle;
		public String sTitle
		{
			get { return m_stitle ; }
			set { m_stitle = value; }
		}
		private String m_sdesc;
		public String sDesc
		{
			get { return m_sdesc ; }
			set { m_sdesc = value; }
		}
		private String m_simage;
		public String sImage
		{
			get { return m_simage ; }
			set { m_simage = value; }
		}
		private Int32 m_idownloadtime;
		public Int32 iDownloadTime
		{
			get { return m_idownloadtime ; }
			set { m_idownloadtime = value; }
		}
		private Int32 m_iuserid;
		public Int32 iUserID
		{
			get { return m_iuserid ; }
			set { m_iuserid = value; }
		}
		private String m_slinkfile;
		public String sLinkFile
		{
			get { return m_slinkfile ; }
			set { m_slinkfile = value; }
		}
		private DateTime m_tdate;
		public DateTime tDate
		{
			get { return m_tdate ; }
			set { m_tdate = value; }
		}
		private String m_sauthor;
		public String sAuthor
		{
			get { return m_sauthor ; }
			set { m_sauthor = value; }
		}
		private String m_scoquanbanhanh;
		public String sCoquanbanhanh
		{
			get { return m_scoquanbanhanh ; }
			set { m_scoquanbanhanh = value; }
		}
		private Int32 m_fk_iloaivanbanid;
		public Int32 FK_iLoaivanbanID
		{
			get { return m_fk_iloaivanbanid ; }
			set { m_fk_iloaivanbanid = value; }
		}
		private DateTime m_dngaybanhanh;
		public DateTime dNgaybanhanh
		{
			get { return m_dngaybanhanh ; }
			set { m_dngaybanhanh = value; }
		}
		private DateTime m_dngaydangcongbao;
		public DateTime dNgaydangcongbao
		{
			get { return m_dngaydangcongbao ; }
			set { m_dngaydangcongbao = value; }
		}
		private DateTime m_dngaycohieuluc;
		public DateTime dNgaycohieuluc
		{
			get { return m_dngaycohieuluc ; }
			set { m_dngaycohieuluc = value; }
		}
		private DateTime m_dngayhethieuluc;
		public DateTime dNgayhethieuluc
		{
			get { return m_dngayhethieuluc ; }
			set { m_dngayhethieuluc = value; }
		}
		private String m_sphamvi;
		public String sPhamvi
		{
			get { return m_sphamvi ; }
			set { m_sphamvi = value; }
		}
		private String m_ssokyhieu;
		public String sSokyhieu
		{
			get { return m_ssokyhieu ; }
			set { m_ssokyhieu = value; }
		}

        #region Comparison
        public static List<DocumentEntity> Sort(List<DocumentEntity> list, String SortExpression, String SortDirection)
        {
            string strComparisonAttrb="COMPARISON_"+SortExpression;
            PropertyInfo propInfo= typeof(DocumentEntity).GetProperty(strComparisonAttrb);
            if (propInfo != null)
            {
                list.Sort(propInfo.GetGetMethod().Invoke(null,null) as Comparison<DocumentEntity>);
                if (SortDirection == "DESC")
                    list.Reverse();
            }
            return list;
        }
        
		public static Comparison<DocumentEntity> COMPARISON_PK_iDocumentID
		{
			get
			{
				return delegate(DocumentEntity entity,DocumentEntity other)
				{
					return entity.PK_iDocumentID.CompareTo(other.PK_iDocumentID);
				};
			}
		}
		public static Comparison<DocumentEntity> COMPARISON_sTitle
		{
			get
			{
				return delegate(DocumentEntity entity,DocumentEntity other)
				{
					return entity.sTitle.CompareTo(other.sTitle);
				};
			}
		}
		public static Comparison<DocumentEntity> COMPARISON_sDesc
		{
			get
			{
				return delegate(DocumentEntity entity,DocumentEntity other)
				{
					return entity.sDesc.CompareTo(other.sDesc);
				};
			}
		}
		public static Comparison<DocumentEntity> COMPARISON_sImage
		{
			get
			{
				return delegate(DocumentEntity entity,DocumentEntity other)
				{
					return entity.sImage.CompareTo(other.sImage);
				};
			}
		}
		public static Comparison<DocumentEntity> COMPARISON_iDownloadTime
		{
			get
			{
				return delegate(DocumentEntity entity,DocumentEntity other)
				{
					return entity.iDownloadTime.CompareTo(other.iDownloadTime);
				};
			}
		}
		public static Comparison<DocumentEntity> COMPARISON_iUserID
		{
			get
			{
				return delegate(DocumentEntity entity,DocumentEntity other)
				{
					return entity.iUserID.CompareTo(other.iUserID);
				};
			}
		}
		public static Comparison<DocumentEntity> COMPARISON_sLinkFile
		{
			get
			{
				return delegate(DocumentEntity entity,DocumentEntity other)
				{
					return entity.sLinkFile.CompareTo(other.sLinkFile);
				};
			}
		}
		public static Comparison<DocumentEntity> COMPARISON_tDate
		{
			get
			{
				return delegate(DocumentEntity entity,DocumentEntity other)
				{
					return entity.tDate.CompareTo(other.tDate);
				};
			}
		}
		public static Comparison<DocumentEntity> COMPARISON_sAuthor
		{
			get
			{
				return delegate(DocumentEntity entity,DocumentEntity other)
				{
					return entity.sAuthor.CompareTo(other.sAuthor);
				};
			}
		}
		public static Comparison<DocumentEntity> COMPARISON_sCoquanbanhanh
		{
			get
			{
				return delegate(DocumentEntity entity,DocumentEntity other)
				{
					return entity.sCoquanbanhanh.CompareTo(other.sCoquanbanhanh);
				};
			}
		}
		public static Comparison<DocumentEntity> COMPARISON_FK_iLoaivanbanID
		{
			get
			{
				return delegate(DocumentEntity entity,DocumentEntity other)
				{
					return entity.FK_iLoaivanbanID.CompareTo(other.FK_iLoaivanbanID);
				};
			}
		}
		public static Comparison<DocumentEntity> COMPARISON_dNgaybanhanh
		{
			get
			{
				return delegate(DocumentEntity entity,DocumentEntity other)
				{
					return entity.dNgaybanhanh.CompareTo(other.dNgaybanhanh);
				};
			}
		}
		public static Comparison<DocumentEntity> COMPARISON_dNgaydangcongbao
		{
			get
			{
				return delegate(DocumentEntity entity,DocumentEntity other)
				{
					return entity.dNgaydangcongbao.CompareTo(other.dNgaydangcongbao);
				};
			}
		}
		public static Comparison<DocumentEntity> COMPARISON_dNgaycohieuluc
		{
			get
			{
				return delegate(DocumentEntity entity,DocumentEntity other)
				{
					return entity.dNgaycohieuluc.CompareTo(other.dNgaycohieuluc);
				};
			}
		}
		public static Comparison<DocumentEntity> COMPARISON_dNgayhethieuluc
		{
			get
			{
				return delegate(DocumentEntity entity,DocumentEntity other)
				{
					return entity.dNgayhethieuluc.CompareTo(other.dNgayhethieuluc);
				};
			}
		}
		public static Comparison<DocumentEntity> COMPARISON_sPhamvi
		{
			get
			{
				return delegate(DocumentEntity entity,DocumentEntity other)
				{
					return entity.sPhamvi.CompareTo(other.sPhamvi);
				};
			}
		}
		public static Comparison<DocumentEntity> COMPARISON_sSokyhieu
		{
			get
			{
				return delegate(DocumentEntity entity,DocumentEntity other)
				{
					return entity.sSokyhieu.CompareTo(other.sSokyhieu);
				};
			}
		}
        #endregion
    }
}
