using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Net.Mail;
using System.Net;

namespace Message
{
    public class sm_Email
    {
         /// <summary>
            /// 判断是否正确的邮箱格式
            /// </summary>
            /// <param name="str_Email">邮箱地址</param>
            /// <returns>bool</returns>
            public static bool IsEmail(string str_Email)
            {
                return System.Text.RegularExpressions.Regex.IsMatch(str_Email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            }
            /// <summary>
            /// 发送邮件,只发送一个邮箱。返回string[发送完成 或 错误信息]
            /// </summary>
            /// <param name="mailTo">收信人地址</param>
            /// <param name="subject">邮件标题</param>
            /// <param name="body">邮件内容</param>
            /// <param name="bodyHTML">内容格式:false为Text,true为Html</param>
            /// <param name="priority">优先级:0为低,1为中,2为高</param>
            /// <returns>string</returns>
            public static string SendEmail(string mailTo, string subject, string body, bool bodyHTML, int priority)
            {
                if (!IsEmail(mailTo))
                {
                    return "邮箱地址格式不正确。";
                }
                ArrayList toEmail = new ArrayList();
                toEmail.Add(mailTo);
                return sm_Email.SendEmail(toEmail, subject, body, bodyHTML, priority);
            }

            /// <summary>
            /// 发送邮件,同时发送多个邮箱。返回string[发送完成 或 错误信息]
            /// </summary>
            /// <param name="mailTo">收信人地址ArrayList数组</param>
            /// <param name="subject">邮件标题</param>
            /// <param name="body">邮件内容</param>
            /// <param name="bodyHTML">内容格式:false为Text,true为Html</param>
            /// <param name="priority">优先级:0为低,1为中,2为高</param>
            /// <returns>string</returns>
            public static string SendEmail(System.Collections.ArrayList mailTo, string subject, string body, bool bodyHTML, int priority)
            {
                string errEmail = "";

                //string smtp = "125.35.5.165";        //发信人所用邮箱的服务器
                //string mailUser = "zhaokun";    //发件人的用户名
                //string mailPwd = "jjily2007";     //发件人的密码

                //string mailTrueName = "测试系统"; //发件人的姓名
                //string mailForm = "zhaokun@ufida.com.cn";    //发件人的邮箱



                string smtp = "mail.hmgc.cn";        //发信人所用邮箱的服务器
                string mailUser = "shouhou";    //发件人的用户名
                string mailPwd = "hmgc87550788";     //发件人的密码

                string mailTrueName = "日立医疗售后系统"; //发件人的姓名
                string mailForm = "shouhou@hmgc.cn";    //发件人的邮箱

                System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
                foreach (object item in mailTo)
                {
                    if (!IsEmail(item.ToString()))
                    {
                        errEmail += item.ToString() + "<br />";
                    }
                    else
                    {
                        msg.To.Add(item.ToString());
                    }
                }

                msg.From = new MailAddress(mailForm, mailTrueName, System.Text.Encoding.UTF8);
                /* 上面3个参数分别是发件人地址（可以随便写），发件人姓名，编码*/
                msg.Subject = subject;
                msg.SubjectEncoding = System.Text.Encoding.UTF8;
                msg.Body = body;
                msg.BodyEncoding = System.Text.Encoding.UTF8;
                msg.IsBodyHtml = bodyHTML;  //是否是HTML邮件
                //邮件优先级
                if (priority == 0)
                    msg.Priority = MailPriority.Low;
                else if (priority == 1)
                    msg.Priority = MailPriority.Normal;
                else
                    msg.Priority = MailPriority.High;


                //string file = @"E:\1.txt";
                //Attachment data = new Attachment(file, MediaTypeNames.Application.Octet);
                //msg.Attachments.Add(data);

                //创建Smtp Mail对象
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.UseDefaultCredentials = false;   //要在下一行之前,否则无法登录服务器
                smtpClient.Credentials = new NetworkCredential(mailUser, mailPwd);
                smtpClient.Port = 25;
                smtpClient.Host = smtp;
                smtpClient.EnableSsl = false;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network; //指定如何处理待发的邮件

                //smtpClient.SendCompleted += new SendCompletedEventHandler(SendMailCompleted);
                try
                {
                    //smtpClient.SendAsync(msg, msg);
                    smtpClient.Send(msg);
                    string rval = "发送完成";
                    if (errEmail != "")
                        rval += "<hr /><strong>以下邮箱地址格式有问题：</strong><br />" + errEmail;
                    return rval;
                }
                catch (SmtpException ex)
                {
                    return ex.ToString();
                }
            }

            #region ==异步方法==
            //private static void SendMailCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
            //{
            //    MailMessage mailMsg = (MailMessage)e.UserState;
            //    string subject = mailMsg.Subject;
            //    if (e.Cancelled) // 邮件被取消
            //    {
            //        return subject + " 被取消。";
            //    }

            //    if (e.Error != null)
            //    {
            //       return "错误：" + e.Error.ToString();
            //    }
            //    else
            //    {
            //        return "发送完成。[邮件已发出，请检查是否有退信。]";
            //    }
            //}
            #endregion
        }
    
}
