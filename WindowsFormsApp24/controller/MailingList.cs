using System;
using System.Collections.Generic;
using System.Threading;
using System.Xml.Linq;
using System.Xml.XPath;
using MAIN_GUI_Mangaer_window.ma_controller;

namespace Main.yonor
{
    /// <summary>
    /// Summary description for MailingList.
    /// This Class adds takes from users their email address and added to the TO: field
    /// in Mailer. 
    /// It also adds the Ads to the Queue to be dispatch.
    /// Developed by Yonatan Orozko.
    /// </summary>

    public class MailingList
    {
        private const int INTERVAL = 7000;
        private Queue<Advertisement> Ads = new Queue<Advertisement>();
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool scheduleState { get; set; }
        //public int DispacherFrecuency { get; set; }

        public MailingList(bool enbleAdsCampegin)//Class constructor who loads customers email, valid Ads(the ones that have Active set to 1,; true) and starts a timer to start Emailing ever INTERVAl milliseconds.
        {
            scheduleState = enbleAdsCampegin;
            LoadCusomersEmails();
            LoadValidAds();
            new Timer(StartMailing, null, 0, INTERVAL);
        }
        public void StartMailing(object o)//Emails Ads if the scheduleState is true and Dequeue them
        {

            if (scheduleState)
            {
                Mailer.EmailAd(Ads.Dequeue());

            }

        }
        private void LoadCusomersEmails()//Loads users emails from XML(users.xml) and add them to the Recipients
        {

            foreach (XElement xe in (XDocument.Load(XmlParser.xmlUsers).XPathSelectElements("//RegisteredUser")))
            {

                Mailer.addRecipientsToAd(xe.Element("Email").Value);

                //customersEmails.Enqueue(xe.Element("Email").Value);

            }
        }
        private void LoadValidAds()//Loads Ads who have active set to 1 in to the Queue
        {
            int counterAds = 0;
            foreach (XElement xe in (XDocument.Load(XmlParser.xmlAds).XPathSelectElements("//Ad")))
            {
                if (xe.Element("Active").Value.Equals("1"))
                {
                    Advertisement adToSend = new Advertisement();
                    adToSend.CompanyName = xe.Element("CompanyName").Value;
                    adToSend.Url = xe.Element("URL").Value;
                    //DateTime adExpTime = DateTime.Parse(xe.Element("ExpirationDate").Value);
                    adToSend.AdBody = xe.Element("AdBody").Value;
                    adToSend.ImgPath = xe.Element("Image").Value;
                    Ads.Enqueue(adToSend);
                    counterAds++;
                }

            }

        }
    }

}
