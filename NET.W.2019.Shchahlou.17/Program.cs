namespace NET.W._2019.Shchahlou._17
{
    using System;
    using System.IO;
    using System.Text;
    using NET.W._2019.Shchahlou._17.XML;
    using NET.W._2019.Shchahlou._17.XML.Interfaces;

    public class Program
    {
        public static void Main(string[] args)
        {
            FileReader re = new FileReader(@"C:\Users\PrimoTibalt\Desktop\Studying\NET.W.2019.Shchahlou\NET.W.2019.Shchahlou.17\text.txt");
            string[] text = re.ReadAll();
            Console.WriteLine("URLs for test: ");
            StringBuilder bldr = new StringBuilder();
            foreach(string str in text)
            {
                Console.WriteLine(str);
                bldr.AppendLine(str);
            }

            Validator val = new Validator();
            StringToXml converter = new StringToXml();
            XMLWriter writer = new XMLWriter(val, converter, "default.xml");
            writer.Write(bldr.ToString());
            Console.WriteLine("The final XML File : ");
            string xml;
            using (StreamReader reader = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "default.xml"))
            {
                xml = reader.ReadToEnd();
            }
            Console.WriteLine(xml);
        }
    }
}
