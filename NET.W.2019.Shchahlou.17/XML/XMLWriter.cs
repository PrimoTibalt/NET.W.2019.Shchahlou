namespace NET.W._2019.Shchahlou._17.XML
{
    using System;
    using System.Xml.Linq;
    using NET.W._2019.Shchahlou._17.XML.Interfaces;

    /// <summary>
    /// Class for writing your information in xml file.
    /// </summary>
    public class XMLWriter : IXMLWriter
    {
        /// <summary>
        /// Sets default file path for Writer.
        /// </summary>
        public XMLWriter()
        {
            this.FileName = @"default.xml";
        }

        /// <summary>
        /// Sets validator for XML data.
        /// </summary>
        /// <param name="validator"></param>
        public XMLWriter(IValidator validator) : this()
        {
            if (validator == null)
            {
                Console.WriteLine("You throw null as validator.");
            }

            this.Validator = validator;
        }

        /// <summary>
        /// Sets converter form string to XML and default validator.
        /// </summary>
        /// <param name="converter"></param>
        public XMLWriter(IStringToXML converter) : this()
        {
            if (converter == null)
            {
                throw new ArgumentNullException("You throw null as converter.");
            }

            this.Converter = converter;
        }

        /// <summary>
        /// Sets validator for XML data and file name.
        /// </summary>
        /// <param name="validator"></param>
        /// <param name="fileName"></param>
        public XMLWriter(IValidator validator, string fileName) : this(validator)
        {
            if (fileName == null || string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentNullException("You throw null or white space as filePath!");
            }

            this.FileName = fileName;
        }

        /// <summary>
        /// Sets validator for XML data and file name.
        /// </summary>
        /// <param name="validator"></param>
        /// <param name="fileName"></param>
        public XMLWriter(IStringToXML converter, string fileName) : this(converter)
        {
            if (fileName == null || string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentNullException("You throw null or white space as fileName!");
            }

            this.Converter = converter;
        }

        /// <summary>
        /// Sets validator for XML data, converter to XML data and file path.
        /// </summary>
        /// <param name="validator"></param>
        /// <param name="fileName"></param>
        public XMLWriter(IValidator validator, IStringToXML converter, string fileName)
        {
            if (fileName == null || string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentNullException("You throw null or white space as filePath!");
            }

            this.FileName = fileName;
            this.Converter = converter;
            this.Validator = validator;
        }

        protected IValidator Validator { get; set; }

        protected string FileName { get; private set; }

        protected IStringToXML Converter { get; set; }

        /// <summary>
        /// Converts string data to XDocument and calls void Write(XDocument).
        /// </summary>
        /// <param name="data"></param>
        public void Write(string data)
        {
            XDocument doc = Converter.Convert(data);
            if (this.Validator != null)
            {
                Validator.Validation(doc);
            }


        }

        /// <summary>
        /// Writes XDocument to .xml file on file path.
        /// </summary>
        /// <param name="data"></param>
        public void Write(XDocument data)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(this.FileName))
                {
                    data.Save(this.FileName);
                }
                else
                {
                    data.Save("default.xml");
                }
            } 
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
