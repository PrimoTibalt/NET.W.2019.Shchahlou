namespace NET.W._2019.Shchahlou._17.XML
{
    using System;
    using System.IO;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Linq;

    /// <summary>
    /// Validator for XML. 
    /// </summary>
    public class Validator : Interfaces.IValidator
    {
        private string schemaName = @"C:\Users\PrimoTibalt\Desktop\Studying\NET.W.2019.Shchahlou\NET.W.2019.Shchahlou.17\defaultSchema.xsd";

        /// <summary>
        /// Validate document by saving him and then loading by XmlReader.Load.
        /// </summary>
        /// <param name="document"></param>
        /// <returns>
        /// If document is valid - returns true.
        /// if doucument is unvalid - returns false.
        /// </returns>
        public bool Validation(XDocument document)
        {
            using (StreamWriter stream = new StreamWriter("def.xml"))
            {
                stream.Write(document);
            }

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.Schema;
            settings.Schemas.Add(null, schemaName);
            try
            {
                using (XmlReader reader = XmlReader.Create("def.xml", settings))
                {
                    XDocument doc = XDocument.Load(reader);
                }
            }
            catch (XmlSchemaException)
            {
                return false;
            }
            
            return true;
        }

        public void SetSchemaFile(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("You tried to set name for scheme as null or white space.");
            }

            this.schemaName = name;
        }
    }
}
