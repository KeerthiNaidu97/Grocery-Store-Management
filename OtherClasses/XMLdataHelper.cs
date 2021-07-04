using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;
using KGNGorceryStore.ModelClasses;

namespace KGNGorceryStore.OtherClasses
{
    class XMLdataHelper
    {
        public static T ReadXml<T>(string file)
        {
            try
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(T));
                    return (T)xs.Deserialize(sr);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return default(T);
            }
        }

        public static void WriteXml<T>(T data, string file)
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                FileStream fs;
                fs = new FileStream(file, FileMode.Create);
                xs.Serialize(fs, data);
                fs.Close();
            }

            catch (Exception x)
            {
                MessageBox.Show(x.ToString(), "Error");
                throw;
            }
        }

    }
}
