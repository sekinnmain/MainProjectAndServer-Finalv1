using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Xml.Linq;
using System.Xml.XPath;
using MAIN_GUI_Mangaer_window.ma_controller;
using Nustache.Core;
using NewUsers;
using System.Data;
using MAIN_GUI_Mangaer_window;

namespace Main.yonor
{
    /// <summary>
    /// This static class is responsible of connection to the SMTP host, delivery of Ads through email, testing SMTP host connection and sending
    /// password to users who forgot and asked for it.
    /// Developed by Yonatan Orozko.
    /// </summary>

    public static class Mailer
    {
        private static int smtpPortSrv { get; set; }
        private static string smtpHost { get; set; }
        private static string smtpUser { get; set; }
        private static string smtpPassSrv { get; set; }
        public static string recieptEmail { get; set; }
        public static MailMessage message = new MailMessage();
        public static SmtpClient smtp = new SmtpClient();

        public static void EmailAd(Advertisement adToEmail)//Takes and instance of Advertisement and send it to Recipients
        {

            using (StreamReader reader = File.OpenText(XmlParser.adTemp)) // Path to your 
            {
                try
                {

                    message.From = new MailAddress("main-delivery@yonor.me");
                    message.Subject = "Test";
                    message.IsBodyHtml = true; //to make message body as html  
                    string templateHtml = reader.ReadToEnd();
                    message.Body = Render.StringToString(templateHtml, adToEmail);

                }
                catch (Exception) { }
            }
            LoadClientAndSendEmail();

        }
        public static void TestConection(string emailToTest)//Test connection with the SMTP host and send email to emailToTest
        {

            message.From = new MailAddress("main-delivery@main.com");
            message.To.Add(new MailAddress($"{emailToTest}"));
            message.Subject = "Test";
            message.IsBodyHtml = false; //to make message body as html  
            message.Body = "Connection Successful";
            LoadClientAndSendEmail();


        }
        public static void EmailPassword(string userEmailRecover) // Method takes email of the user to recover password, and send him/her a email with the password
        {
            SetHostValuesFromXml();
            foreach (XElement xe in (XDocument.Load(XmlParser.xmlUsers).XPathSelectElements($"//RegisteredUser")))
            {
                if (xe.Element("Email").Value.Equals(userEmailRecover))
                {
                    using (StreamReader reader = File.OpenText(XmlParser.recoverTempl))
                    {
                        try
                        {
                            VipCustomer recoUser = new VipCustomer();
                            recoUser.FirstName = xe.Element("FirstName").Value;
                            recoUser.Email = xe.Element("Email").Value;
                            recoUser.PassWord = xe.Element("PassWord").Value;
                            message.From = new MailAddress("main-delivery@main.com");
                            message.To.Add(new MailAddress($"{recoUser.Email}"));
                            message.Subject = $"Password recovery for {recoUser.FirstName}";
                            message.IsBodyHtml = true; //to make message body as html  
                            string templateHtml = reader.ReadToEnd();//Makes used of the NutGet packaged called Nustage who takes the HTML template in Resources and bind the information accordantly in the {{TAGS}}
                            message.Body = Render.StringToString(templateHtml, recoUser);
                            LoadClientAndSendEmail();

                        }
                        catch (Exception e) { Console.WriteLine(e.Message); }
                    }
                }
            }


        }
        public static void addRecipientsToAd(string Email)//Takes email and add it to the recipients.
        {
            message.To.Add(new MailAddress($"{Email}"));

        }
        public static void SendEmail()//Sends email. Body and recipients depend other methods.
        {
            try
            {
                smtp.Send(message);

            }
            catch (Exception e)
            {
                main_manager_wnd.RaiseOnSmtpNotConnected(e.Message);
            }

        }
        public static void LoadClientAndSendEmail()//Loads the connection details and send the email. 
        {
            smtp.Port = smtpPortSrv;
            smtp.Host = smtpHost;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(smtpUser, smtpPassSrv);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            SendEmail();
        }
        public static void SetHostValuesFromXml()//Gets values from XML and set them to the class properties.
        {
            DataSet smtpLoadSe = new DataSet();
            smtpLoadSe.ReadXml(MAIN_GUI_Mangaer_window.ma_controller.XmlParser.xmlSmtpSettings);
            smtpHost = smtpLoadSe.Tables[0].Rows[0][0].ToString();
            smtpPortSrv = Convert.ToInt32(smtpLoadSe.Tables[0].Rows[0][1].ToString());
            smtpUser = smtpLoadSe.Tables[0].Rows[0][2].ToString();
            smtpPassSrv = smtpLoadSe.Tables[0].Rows[0][3].ToString();
        }
    }

}
