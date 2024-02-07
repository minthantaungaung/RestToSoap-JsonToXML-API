using svici.bo2.core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace svici.bo2.core.Data
{
    [XmlRoot(ElementName = "Envelope", Namespace = Namespaces.EnvelopeNamespace)]
    public class RequestEnvelope<T> : AutoConvert
    {
        [XmlElement(ElementName = "Header", Namespace = Namespaces.EnvelopeNamespace)]
        public Header? Header { get; set; } = new();

        [XmlElement(ElementName = "Body", Namespace = Namespaces.EnvelopeNamespace)]
        public T? Body { get; set; }
    }

    public class Header
    {
        [XmlElement(ElementName = "Security", Namespace = Namespaces.WssSecurity)]
        public Security Security { get; set; } = new Security();
    }

    public class Security
    {
        [XmlElement(ElementName = "UsernameToken", Namespace = Namespaces.WssSecurity)]
        public UsernameToken UsernameToken { get; set; } = new UsernameToken();
    }

    public class UsernameToken
    {
        [XmlElement(ElementName = "Username", Namespace = Namespaces.WssSecurity)]
        public string? Username { get; set; }

        [XmlElement(ElementName = "Password", Namespace = Namespaces.WssSecurity)]
        public Password Password { get; set; } = new Password();
    }

    public class Password
    {
        [XmlAttribute(AttributeName = "Type")]
        public string? Type { get; set; } = Namespaces.WssSecurityPwd;

        [XmlText]
        public string? Value { get; set; }
    }

    [XmlRoot(ElementName = "Envelope", Namespace = Namespaces.EnvelopeNamespace)]
    public class ResponseEnvelope<T> : AutoConvert
    {
        [XmlElement(ElementName = "Body")]
        public T? Body { get; set; }
    }

    public static class Namespaces
    {
        public const string EnvelopeNamespace = "http://schemas.xmlsoap.org/soap/envelope/";
        public const string BodyNamespace = "http://bpc.ru/SVIS/cmsSvng/v1.1/";
        public const string BodyNamespace3 = "http://bpc.ru/common/types/v0.1/";
        public const string BodyNamespace4 = "http://www.w3.org/2001/XMLSchema-instance";
        public const string WssSecurity = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd";
        public const string WssSecurityPwd = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText";
    }

}
