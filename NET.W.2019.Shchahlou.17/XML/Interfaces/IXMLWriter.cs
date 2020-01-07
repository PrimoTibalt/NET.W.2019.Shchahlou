namespace NET.W._2019.Shchahlou._17.XML.Interfaces
{
    using System.Xml.Linq;

    /// <summary>
    /// Writes into XML file some string.
    /// </summary>
    public interface IXMLWriter
    {
        public void Write(XDocument data);
    }
}
