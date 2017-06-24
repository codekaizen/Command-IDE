using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Command___IDE
{
    public class MCProj
    {
        public string name = "New Command++ Proj";
        public string path = "";
        public string[] functions = new string[0];

        public string GetFunction(string s)
        {
            if(!functions.Contains(s))
            {
                throw new ArgumentException();
            }
            else { return File.ReadAllText(path + "/" + s); }
        }

        public void Save()
        {
            try
            {
                DirectoryInfo under = new DirectoryInfo(path);
                if (!under.Exists)
                {
                    under = Directory.CreateDirectory(path);
                }
                File.WriteAllText(Path.Combine(under.FullName, name), SerializeOBJ.Serialize(this));
            }
            catch(Exception e) { MessageBox.Show("The project '" + name + "' was unable to be saved.  Reason:\n" + e); }
        }
    }

    public static class SerializeOBJ {
        public static string Serialize(object dataToSerialize)
        {
            if (dataToSerialize == null) { return "NIL"; }
            using (StringWriter stringwriter = new StringWriter())
            {
                var serializer = new XmlSerializer(dataToSerialize.GetType());
                serializer.Serialize(stringwriter, dataToSerialize);
                return stringwriter.ToString();
            }
        }

        ///Deserializes an object from a string.
        public static T Deserialize<T>(string xmlText)
        {
            if (xmlText == "NIL") { return default(T); }
            using (StringReader stringReader = new StringReader(xmlText))
            {
                return (T)new XmlSerializer(typeof(T)).Deserialize(stringReader);
            }
        }
    }
}