namespace NET.W._2019.Shchahlou._17.XML.Interfaces
{
    using System.Xml.Linq;

    /// <summary>
    /// Converts string data into XDocument by some algorithm.
    /// </summary>
    public interface IStringToXML
    {
        public XDocument Convert(string data);
    }
}
