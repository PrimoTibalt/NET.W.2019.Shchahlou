namespace NET.W._2019.Shchahlou._17
{
    using System;
    using System.Text;
    using NET.W._2019.Shchahlou._17.XML;
    using NET.W._2019.Shchahlou._17.XML.Interfaces;

    public class Program
    {
        public static void Main(string[] args)
        {
            FileReader re = new FileReader(@"C:\Users\PrimoTibalt\Desktop\Studying\NET.W.2019.Shchahlou\NET.W.2019.Shchahlou.17\text.txt");
            string[] text = re.ReadAll();
            StringBuilder bldr = new StringBuilder();
            foreach(string str in text)
            {
                bldr.AppendLine(str);
            }

            Validator val = new Validator();
            StringToXml converter = new StringToXml();
            XMLWriter writer = new XMLWriter(val, converter, "default.xml");
            writer.Write(bldr.ToString());

        }
    }
}
