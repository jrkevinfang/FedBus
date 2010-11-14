using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Security.Cryptography;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Collections;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace FedBusUI_New
{
    [Serializable()]
    class Student
    {
        private string id;
        private string boarded;
        private string originallyBoarded;
        private string myBusID;

        public string ID
        {
            get { return id; }
            set
            {
                if (value.Length == 8)
                {
                    SHA256Managed hash = new SHA256Managed();
                    id = "";
                    foreach (byte x in hash.ComputeHash(Encoding.UTF8.GetBytes(value)))
                    {
                        id += String.Format("{0:x2}", x);
                    }
                }
                else
                {
                    throw new Exception("Invalid student ID.");
                }
            }
        }
        public string Boarded
        {
            get
            {
                return boarded;
            }
            set
            {
                if (!(value == "1" || value == "0"))
                    throw new Exception("Boarded can only be the string \"1\" or \"0\".");
                if (value == "0" && Boarded == "1")
                    throw new Exception("You can't unboard.");
                boarded = value;
            }
        }
        public string OriginallyBoarded
        {
            get
            {
                return originallyBoarded;
            }
            set
            {
                if (value == "1" || value == "0")
                    originallyBoarded = value;
                else
                    throw new Exception("OriginallyBoarded can only be the string \"1\" or \"0\".");
            }
        }
        public string MyBusID { get { return myBusID; } set { myBusID = value; } }

        private string getContentsOfChildByName(XmlNode node, string name)
        {
            foreach (XmlNode child_node in node.ChildNodes)
            {
                if (child_node.Name == "id")
                {
                    return child_node.InnerText;
                }
            }
            return "";
        }

        public Student(XmlNode node)
        {
            LoadFromXML(node);
        }

        public void LoadFromXML(XmlNode node)
        {
            id = node.InnerText;
            OriginallyBoarded = node.Attributes["boarded"].Value;
            Boarded = OriginallyBoarded;
            MyBusID = node.Attributes["bus"].Value;
        }
    }
}