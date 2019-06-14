using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Main;
using NewUsers;
using main;
using Main.yonor;

namespace MAIN_GUI_Mangaer_window.ma_controller
{
    public class XmlParser
    {
        /// <summary>
        /// This class handles all Data writing of the Application. It sets dynamically the paths of all XML files used in the Application.
        /// Developed by Yonatan and Michael.
        /// </summary>
        private static string AppPath => Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);
        private static DirectoryInfo myDir = new DirectoryInfo(AppPath);
        private static string dataDir = myDir.Parent.Parent.FullName.ToString();
        public static string xmlDishPath = $"{dataDir}\\Data\\Dishes.xml";
        public static string xmlFeedBack = $"{dataDir}\\Data\\FeedBacks.xml";
        public static string xmlUsers = $"{dataDir}\\Data\\Users.xml";
        public static string xmlOrder = $"{dataDir}\\Data\\Orders.xml";
        public static string xmlAds = $"{dataDir}\\Data\\Ads.xml";
        public static string xmlSmtpSettings = $"{dataDir}\\Data\\Smtp.xml";
        public static string adTemp = $"{dataDir}\\Resources\\email-temp.html";
        public static string recoverTempl = $"{dataDir}\\Resources\\main-recoverpass.html";

        public static void XmlParserDish(Dish passDish)//Receives a Dish instance and writes to its respective XML file 
        {
            XDocument doc = XDocument.Load(xmlDishPath);
            XElement school = doc.Element("Dishes");
            school.Add(new XElement("Dish",
                       new XElement("Name", passDish.dishName),
                       new XElement("Price", passDish.dishPrice),
                       new XElement("Size", passDish.dishSize),
                       new XElement("Description", passDish.dishDescription),
                       new XElement("Type", passDish.dishType),
                       new XElement("Image", passDish.dishImage)));
            doc.Save(xmlDishPath);
        }
        public static void XmlParserVipCustomer(VipCustomer vip)//Receives a VipCustomer instance and writes to its respective XML file
        {
            XDocument doc = XDocument.Load(xmlUsers);
            XElement school = doc.Element("Users");
            school.Add(new XElement("RegisteredUser",
                       new XElement("FirstName", vip.FirstName),
                       new XElement("LastName", vip.LastName),
                       new XElement("Type", vip.userType),
                       new XElement("UserName", vip.UserName),
                       new XElement("PassWord", vip.PassWord),
                       new XElement("Email", vip.Email),
                       new XElement("Address", vip.Address),
                       new XElement("PhoneNumber", vip.PhoneNumber)));

            doc.Save(xmlUsers);
        }
        public static void XmlParserEmployee(Employee crtEmp)//Receives a Employee instance and writes to its respective XML file
        {
            XDocument doc = XDocument.Load(xmlUsers);
            XElement school = doc.Element("Users");
            school.Add(new XElement("RegisteredUser",
                       new XElement("FirstName", crtEmp.FirstName),
                       new XElement("LastName", crtEmp.LastName),
                        new XElement("Type", crtEmp.userType),
                       new XElement("UserName", ""),
                       new XElement("ID", crtEmp.ID),
                       new XElement("Email", crtEmp.Email),
                       new XElement("Address", crtEmp.Address),
                       new XElement("PhoneNumber", crtEmp.PhoneNumber)
                    ));

            doc.Save(xmlUsers);
        }
        public static void XmlParserManager(Manager crtManager)//Receives a Manager instance and writes to its respective XML file
        {
            XDocument doc = XDocument.Load(xmlUsers);
            XElement school = doc.Element("Users");
            school.Add(new XElement("RegisteredUser",
                       new XElement("FirstName", crtManager.FirstName),
                       new XElement("LastName", crtManager.LastName),
                        new XElement("Type", crtManager.userType),
                       new XElement("UserName", ""),
                       //new XElement("ID", crtManager.ID),
                       new XElement("Email", crtManager.Email),
                       new XElement("Address", crtManager.Address),
                       new XElement("PhoneNumber", crtManager.PhoneNumber)
                    ));

            doc.Save(xmlUsers);
        }
        public static void XmlParserAds(Advertisement crtAd)//Receives a Advertisement instance and writes to its respective XML file
        {
            XDocument doc = XDocument.Load(xmlAds);
            XElement school = doc.Element("Ads");
            school.Add(new XElement("Ad",
                       new XElement("CompanyName", crtAd.CompanyName),
                       new XElement("Price", crtAd.Price.ToString()),
                       new XElement("Active", crtAd.GetStatus()),
                        new XElement("AdBody", crtAd.AdBody),
                       new XElement("CreationDate", crtAd.CreationDate),
                       new XElement("ExpirationDate", crtAd.ExpirationDate.ToString()),
                       new XElement("URL", crtAd.Url),
                       new XElement("Image", crtAd.ImgPath)
                    ));

            doc.Save(xmlAds);
        }
        public static void XmlParserOrder(OrderService myOrder)//Receives a OrderService instance and writes to its respective XML file
        {
            XDocument doc = XDocument.Load(xmlOrder);
            XElement school = doc.Element("Orders");
            school.Add(new XElement("Order",
                       new XElement("IdOrder", myOrder.idOrder),
                       new XElement("user", myOrder.user),
                       new XElement("dishes", myOrder.dishNameFromOrder()),
                       new XElement("TimeOrder", DateTime.Now),
                       new XElement("SeatOrGo", myOrder.seatOrGo),
                       new XElement("TableBnum", myOrder.tableBnum),
                       new XElement("ClinetRequest", myOrder.notes),
                       new XElement("ClinetFeedbackRate", myOrder.feedBack.rateFeedback),
                       new XElement("ClinetFeedbackNote", myOrder.feedBack.customerFeedback),
                       new XElement("Price", myOrder.price)));


            doc.Save(xmlOrder);
        }
        public static void XmlParserFeedback(Feedback myfeedback)//Receives a Feedback instance and writes to its respective XML file
        {
            XDocument doc = XDocument.Load(xmlFeedBack);
            XElement school = doc.Element("Feedbacks");
            school.Add(new XElement("Feedback",
                       new XElement("FeedbackDate", DateTime.Now),
                       new XElement("RatedFeedback", myfeedback.rateFeedback),
                       new XElement("CustomerReply", myfeedback.customerFeedback)
                       ));


            doc.Save(xmlFeedBack);
        }
    }
}
