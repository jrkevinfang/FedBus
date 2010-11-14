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
    static class RecoveryManager
    {
        static public FedBus fedBus;

        static public FedBus makeFedBus(string oUrl, string bUrl, string sUrl)
        {
            //  try { return load(); }
            //  catch { 
            fedBus = new FedBus(oUrl, bUrl, sUrl);
            return fedBus;
            //}
        }

        static public void save()
        {
            Stream stream = File.Open("recovery.bin", FileMode.Create);
            BinaryFormatter bFormatter = new BinaryFormatter();
            bFormatter.Serialize(stream, fedBus);
            stream.Close();
        }
        static public FedBus load()
        {
            Stream stream = File.Open("recovery.bin", FileMode.Open);
            BinaryFormatter bFormatter = new BinaryFormatter();
            fedBus = (FedBus)bFormatter.Deserialize(stream);
            stream.Close();
            return fedBus;
        }
        static public void delete()
        {
            File.Delete("recovery.bin");
        }
    }
}