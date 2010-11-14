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
    class Communication
    {
        private string outUrl;
        private string busUrl;
        private string studentUrl;
        private FedBus fedBus;
        private DateTime lastUpdate;
        private DateTime lastUpload;

        public Communication(FedBus fBus, string oUrl, string bUrl, string sUrl)
        {
            fedBus = fBus;
            outUrl = oUrl;
            busUrl = bUrl;
            studentUrl = sUrl;
        }
        public void LoadAllData()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(new XmlTextReader(busUrl));
            fedBus.busList = MakeBusesFromXML(doc.GetElementsByTagName("bus"));
            fedBus.studentList = MakeStudentsFromXML(doc.GetElementsByTagName("student"));
            fedBus.currentBus = null;
        }
        private List<Bus> MakeBusesFromXML(XmlNodeList nodes)
        {
            List<Bus> list = new List<Bus>();
            foreach (XmlNode node in nodes)
            {
                list.Add(new Bus(node));
            }
            return list;
        }
        private List<Student> MakeStudentsFromXML(XmlNodeList nodes)
        {
            List<Student> list = new List<Student>();
            foreach (XmlNode node in nodes)
            {
                list.Add(new Student(node));
            }
            return list;
        }
        private string MakeStringFromXML(XmlDocument doc)
        {
            StringWriter sw = new StringWriter();
            XmlTextWriter xw = new XmlTextWriter(sw);
            doc.WriteTo(xw);
            return "textarea=" + sw.ToString();
        }
        private string GetUploadData()
        {
            string boardedList = "boarded=";
            foreach (Student student in fedBus.studentList)
            {
                if (student.Boarded == "1" && student.OriginallyBoarded == "0")
                    boardedList += student.ID + ",";
            }
            boardedList = boardedList.TrimEnd(',');
            return boardedList;
        }
        public void UpdateData()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(new XmlTextReader(busUrl));
            List<Student> newStudents = MakeStudentsFromXML(doc.GetElementsByTagName("student"));
            for (int n = 0; n < fedBus.studentList.Count; n++)
            {
                foreach (Student newStudent in newStudents)
                {
                    Student student = (Student)fedBus.studentList[n];
                    if (student.ID == newStudent.ID)
                    {
                        fedBus.studentList[n] = newStudent;
                    }
                }
            }
        }
        public void UploadData()
        {
            try
            {
                Console.WriteLine(GetUploadData());
                //copy pasta ftw
                byte[] buffer = Encoding.ASCII.GetBytes(GetUploadData()); //TODO: remove textarea=
                HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(outUrl);
                WebReq.Method = "POST";
                WebReq.ContentType = "application/x-www-form-urlencoded";
                WebReq.ContentLength = buffer.Length;
                Stream PostData = WebReq.GetRequestStream();
                PostData.Write(buffer, 0, buffer.Length);
                PostData.Close();
                HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();
                if (WebResp.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception("Server failed to understand data.");
                }

                foreach (Student student in fedBus.studentList)
                {
                    student.OriginallyBoarded = student.Boarded;
                }
                RecoveryManager.delete();
            }
            catch
            {

            }
        }
    }
}