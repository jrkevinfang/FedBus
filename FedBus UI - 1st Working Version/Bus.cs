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
    class Bus
    {
        private string id;
        private string destination;
        private DateTime time;
        private string maximumSeats;

        public int BoardedCount;

        public string ID { get { return id; } set { id = value; } }
        public string Destination { get { return destination; } set { destination = value; } }
        public string Time
        {
            get
            {
                return time.ToString("HH:mm");
            }
            set
            {
                time = DateTime.Parse(value);
            }
        }
        public string MaximumSeats { get { return maximumSeats; } set { maximumSeats = value; } }
        public string TimeDestination { get { return Time + " - " + Destination; } }

        public Bus(XmlNode node)
        {
            LoadFromXML(node);
        }

        public override string ToString()
        {
            return TimeDestination;
        }

        private string getContentsOfChildByName(XmlNode node, string name)
        {
            foreach (XmlNode child_node in node.ChildNodes)
            {
                if (child_node.Name == name)
                {
                    return child_node.InnerText;
                }
            }
            return "";
        }
        public void LoadFromXML(XmlNode node)
        {
            ID = getContentsOfChildByName(node, "id");
            Time = getContentsOfChildByName(node, "departure");
            Destination = getContentsOfChildByName(node, "name");
            MaximumSeats = getContentsOfChildByName(node, "maximum-seats");
        }
    }
}