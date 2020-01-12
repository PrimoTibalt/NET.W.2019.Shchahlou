namespace NET.W._2019.Shchahlou._17.XML.Interfaces
{
    using System.Xml.Linq;

    public interface IValidator
    {
        public bool Validation(XDocument document);
    }
}
