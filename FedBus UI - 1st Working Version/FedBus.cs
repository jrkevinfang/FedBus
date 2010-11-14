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
    class FedBus
    {
        public List<Bus> busList;
        public Bus currentBus;
        public List<Student> studentList;
        private Communication communication;

        // Constructor
        public FedBus(string oUrl, string bUrl, string sUrl)
        {
            communication = new Communication(this, oUrl, bUrl, sUrl);
            communication.LoadAllData();
        }

        // Used to populate the UI drop down
        public Bus[] BusList
        {
            get
            {
                Bus[] newBusList = new Bus[busList.Count];
                for (int n = 0; n < busList.Count; n++)
                {
                    newBusList[n] = (Bus)busList[n];
                }
                return newBusList;
            }
        }

        public string studentListDebug()
        {
            try
            {
                string output = "";
                foreach (Student student in studentList)
                {
                    output += "student id: " + student.ID + "\n";
                    output += "boarded: " + student.Boarded + "\n";
                    output += "bus: " + student.MyBusID + "\n";
                }
                return output;
            }
            catch { }
            return "";
        }

        // Returns an XmlNodeList of all the students on a particular bus
        public Bus CurrentBus
        {
            set
            {
                currentBus = value;
            }
        }

        // Called when an id is swiped or a student number is typed in
        public studentStatus studentCheckIn(string studentId)
        {
            studentId = this.HashStudentID(studentId);

            foreach (Student student in studentList)
            {
                if (System.String.Compare(student.ID, studentId, true) == 0) // found student
                {
                    if (student.MyBusID == currentBus.ID) // good bus
                    {
                        if (student.Boarded == "1")
                        {
                            return studentStatus.AlreadyBoarded; // already boarded
                        }
                        else
                        {
                            student.Boarded = "1";
                            communication.UploadData();
                            RecoveryManager.save();
                            return studentStatus.Accepted; // good
                        }
                    }
                    else // wrong bus
                    {
                        if (student.Boarded == "1")
                        {
                            return studentStatus.BoardedAnotherBus; // already boarded another bus
                        }
                        else
                        {
                            return studentStatus.AnotherBus; // should be on another bus
                        }
                    }
                }
            }
            return studentStatus.Denied; // denied
        }

        // Gets the student id hash based on student ID
        public String HashStudentID(String studentId)
        {
            SHA256Managed hash = new SHA256Managed();
            String hex = "";
            foreach (byte x in hash.ComputeHash(Encoding.UTF8.GetBytes(studentId)))
            {
                hex += String.Format("{0:x2}", x);
            }
            return hex;
        }
    }
}