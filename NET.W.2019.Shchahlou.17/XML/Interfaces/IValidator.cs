using System.Xml.Linq;

namespace NET.W._2019.Shchahlou._17.XML.Interfaces
{
    public interface IValidator
    {
        public bool Validation(XDocument document);
    }
}
