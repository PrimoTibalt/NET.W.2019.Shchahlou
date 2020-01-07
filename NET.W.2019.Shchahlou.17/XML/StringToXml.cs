namespace NET.W._2019.Shchahlou._17.XML
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Xml.Linq;
    using NET.W._2019.Shchahlou._17.XML.Interfaces;

    /// <summary>
    /// Class-converter for URL to represent them in XML.
    /// </summary>
    public class StringToXml : IStringToXML
    {
        /// <summary>
        /// Data is urls with protocol, host name, uri and parameters
        /// or with protocol, host name and uri
        /// or protocol and host name.
        /// URLs separated by \n or white spaces.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public XDocument Convert(string data)
        {
            XDocument doc = new XDocument(new XDeclaration("1.0", "UTF-8", "yes"));
            // Main tag.
            XElement urlAddresses = new XElement("urlAddresses");
            string[] everyUrl = data.Split();
            for (int i = 0; i < everyUrl.Length - 1; i++)
            {
                string url = everyUrl[i];
                if (string.IsNullOrWhiteSpace(url))
                {
                    continue;
                }

                // Construct <urlAddress>.
                XElement urlAddress = new XElement("urlAddress");
                string[] elements = url.Split("//")[1].Split("/");

                // Add host name.
                urlAddress.Add(new XElement("host", new XAttribute("name", elements[0])));

                // If we dont have uri and parameters.
                if (elements.Length < 1)
                {
                    urlAddresses.Add(urlAddress);
                    continue;
                }

                XElement uri = new XElement("uri");
                // Add segments of uri.
                for (int j = 1; j < elements.Length; j++)
                {
                    if (elements[j].Contains("?"))
                    {
                        uri.Add(new XElement("segment", elements[j].Split("?")[0]));
                        break;
                    }

                    if (string.IsNullOrWhiteSpace(elements[j]))
                    {
                        continue;
                    }

                    uri.Add(new XElement("segment", elements[j]));
                }

                urlAddress.Add(uri);
                if (!url.Contains("?"))
                {
                    urlAddresses.Add(urlAddress);
                    continue;
                }

                // Contructing parameters.
                IEnumerable<string> parametersEnum = elements[elements.Length - 1].Split("?").Where(x => x.Contains("="));
                XElement parameters = new XElement("parameters");
                foreach (string parameter in parametersEnum)
                {
                    parameters.Add(new XElement("parametr", new XAttribute("value", parameter.Split("=")[1]), new XAttribute("key", parameter.Split("=")[0])));
                }

                urlAddress.Add(parameters);
                // Final adding for url which consist both uri and parameters.
                urlAddresses.Add(urlAddress);
            }

            doc.Add(urlAddresses);
            return doc;
        }
    }
}
