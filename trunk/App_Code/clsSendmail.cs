﻿using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Net.Mail;
using System.Text.RegularExpressions;

/// <summary>
/// Summary description for Sendmail
/// </summary>
public class clsSendmail
{
    public clsSendmail()
    {
    }

    SmtpClient sClient = new SmtpClient();

    //xác định smtpserver để gửi mail, với gmail là smtp.gmail.com
    string smtpServer = "";
    /// <summary>
    /// Thuộc tính truyền hoặc lấy mail server khi gửi mail client
    /// </summary>
    public string SmtpServer
    {
        get { return smtpServer; }
        set { smtpServer = value; }
    }

    //Gửi từ mail nào, là một địa chỉ mail từ gmail ex: sunflower2441@gmail.com
    string smtpMailFrom = "";
    /// <summary>
    /// Thuộc tính truyền hoặc lấy giá trị địa chỉ gửi mail
    /// </summary>
    public string SmtpMailFrom
    {
        get { return smtpMailFrom; }
        set { smtpMailFrom = value; }
    }

    //user đăng nhập vào gmail
    string smtpUser = "";
    /// <summary>
    /// Thuộc tính user đăng nhập mail, chỉ có thể truyền
    /// </summary>
    public string SmtpUser
    {
        set { smtpUser = value; }
    }

    //mật khẩu đăng nhập gmail
    string smtpPassword = "";
    /// <summary>
    /// Thuộc tính mật khẩu đăng nhập mail, chỉ có thể truyền
    /// </summary>
    public string SmtpPassword
    {
        set { smtpPassword = value; }
    }

    //port của smtpserver khi dùng gmail là 587 hoặc 465
    int smtpPort = 587;
    /// <summary>
    /// Port khi gửi mail với smtpserver của mail client, chỉ có thể truyền
    /// </summary>
    public int SmtpPort
    {
        get { return smtpPort; }
        set { smtpPort = value; }
    }

    /// <summary>
    /// Hàm gửi mail với mail client là gmail
    /// </summary>
    /// <param name="strMailTo">Mail muốn gửi đến</param>
    /// <param name="strMailSubject">Tựa đề mail</param>
    /// <param name="strContent">Nội dung mail</param>
    /// <param name="bolIsHTMLFormat">Định dang mail gửi đi là HTML hay Text</param>
    /// <returns>Trả về thông tin sau khi gửi là thanh công hay thất bại và lỗi khi thất bại.</returns>
    public int SendMail(string strMailTo, string strMailSubject, string strContent, bool bolIsHTMLFormat)
    {
        try
        {
            MailMessage objMail = new MailMessage();
            //reg xác lập tính hợp lệ của mail
            Regex reg = new Regex(@"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$");
            objMail.From = new MailAddress(smtpMailFrom);
            objMail.ReplyTo = new MailAddress(smtpMailFrom);

            if (reg.IsMatch(strMailTo))
            {
                objMail.To.Add(new MailAddress(strMailTo));
                objMail.Subject = strMailSubject;
                if (bolIsHTMLFormat)
                {
                    objMail.IsBodyHtml = true;
                    objMail.Body = string.Format("<html><head><title>{0}</title></head><body>{1}</body></html>", strMailSubject, strContent);
                }
                else
                {
                    objMail.IsBodyHtml = false;
                    objMail.Body = strContent;
                }
                objMail.BodyEncoding = System.Text.Encoding.UTF8;
                sClient = new SmtpClient();

                sClient.Host = smtpServer;
                sClient.Port = smtpPort;
                sClient.Credentials = new System.Net.NetworkCredential(smtpUser, smtpPassword);
                sClient.EnableSsl = true;
                sClient.Send(objMail);

                return 1;
            }
            else
            {
                return 0;
            }
        }
        catch (Exception ex)
        {
            return -1;
        }
    }
}