using MAIN_GUI_Mangaer_window.ma_controller;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Xml;

namespace Main.ServerOs
{
    /// <summary>
    ///This static class represents a server which opens a SocketConnction in the port 9999 and send the Order.xml file.
    ///This information is used by the client to show the latest Orders placed in the Program.
    /// Developed by Amit Dahari and Yonatan Orozko
    /// </summary>
    public static class MyTcpListener
    {
        public static object ClientSocket { get; private set; }

        public static void StartListening()//Server starts listening for connection on port 9999
        {
            TcpListener server = null;
            try
            {
                // Set the TcpListener on port 13000.
                Int32 port = 9999;
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");
                // TcpListener server = new TcpListener(port);
                server = new TcpListener(localAddr, port);
                // Start listening for client requests.
                server.Start();
                while (true)
                {
                    Console.Write("Waiting for a connection... ");
                    // Perform a blocking call to accept requests.
                    // You could also user server.AcceptSocket() here.
                    Socket client = server.AcceptSocket();
                    Console.WriteLine("Connected!");
                    // Loop to receive all the data sent by the client.
                    XmlDocument myDoc = new XmlDocument();
                    myDoc.Load(XmlParser.xmlOrder);
                    string welcome = $"{GetXMLAsString(myDoc)}";
                    byte[] data = new byte[8192];
                    data = Encoding.ASCII.GetBytes(welcome);
                    client.Send(data, data.Length, SocketFlags.None);
                    // Shutdown and end connection
                    client.Close();
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                // Stop listening for new clients.
                server.Stop();

            }
            Console.WriteLine("\nHit enter to continue...");
            Console.Read();
        }
        public static string GetXMLAsString(XmlDocument myxml)// Takes as parameter and XDocumnt and returns a string from XML
        {
            StringWriter sw = new StringWriter();
            XmlTextWriter tx = new XmlTextWriter(sw);
            myxml.WriteTo(tx);

            string str = sw.ToString();// 
            return str;
        }
    }

}
