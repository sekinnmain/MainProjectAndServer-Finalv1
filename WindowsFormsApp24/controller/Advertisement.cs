using System;
namespace Main.yonor
{
    /// <summary>
    /// This class creates Ads to be promote and send by email to restaurant's clients.
    /// Instances created with this class will Queue by MailingList and send by the Mailer class.
    /// Developed by Yonatan Orozko.
    /// </summary>
    public class Advertisement
    {
        public string CompanyName { get; set; }//Name of the Ad
        public string ImgPath { get; set; }//Ad image
        public string AdBody { get; set; }//Ad Description 
        public bool Active { get; set; }//Ad activation mode, if disable Ad wont be sent or queued by MailingList
        public DateTime CreationDate { get; set; }//Date stamp of creation
        public DateTime ExpirationDate { get; set; }//Date stamp of expiration date
        public float Price { get; set; }//Price the company paid for advertisement in the program
        public string Url { get; set; }//URL to be visited, given by the company that advertises in our platform.
        public Advertisement()//Constructor that sets Active to false. Meaning Ads by default are not active until the manager Enables them
        {
            //
            // Start campaign but don't send email yet until Active is set to true. 
            //
            Active = false;
        }
        public void DisableAd()//Sets Active to false. Ad will not be Queued by MailingList there for not sent by Mailer.
        {
            Active = false;
        }
        public void EnableAd()//Set Active to true. This enable the add to be Queued and send by email.
        {
            Active = true;
        }
        public string GetStatus()//Returns the Active status of the ad.
        {
            if (Active)
            {
                return "1";
            }
            else
            {
                return "0";
            }

        }
        public override string ToString()//Override method to print the CompanyName of the Ad
        {
            return CompanyName;
        }
    }
}
