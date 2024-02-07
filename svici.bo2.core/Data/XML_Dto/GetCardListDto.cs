using svici.bo2.core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace svici.bo2.core.Data.XML_Dto
{
    // Request XML Model
    [XmlRoot(Namespace = Namespaces.BodyNamespace)]
    public class GetCardListRequestDto
    {
        [XmlElement(ElementName = "getCardsListRequest", Namespace = Namespaces.BodyNamespace)]
        public GetCardListRequest? getCardsListRequestModel { get; set; }
    }
    public class GetCardListRequest : AutoConvert
    {
        [XmlElement(Namespace = Namespaces.BodyNamespace)]
        public string? customerNumber { get; set; }

        [XmlElement(Namespace = Namespaces.BodyNamespace)]
        public string? instId { get; set; }
    }

    // Response XML Model
    public class GetCardListResponseDto
    {
        [XmlElement(ElementName = "getCardsListResponse", Namespace = Namespaces.BodyNamespace)]
        public GetCardsListResponse GetCardsListResponse { get; set; }
    }

    [XmlRoot(ElementName = "getCardsListResponse", Namespace = Namespaces.BodyNamespace)]
    public class GetCardsListResponse
    {
        [XmlElement(Namespace = Namespaces.BodyNamespace3)]
        public string? status { get; set; }

        [XmlElement(Namespace = Namespaces.BodyNamespace3)]
        public string? errorCode { get; set; }

        [XmlElement(ElementName = "card")]
        public Card[]? cards { get; set; }
    }
    public class Card
    {
        public string? cardNumber { get; set; }
        public string? cardId { get; set; }
        public string? memNumber { get; set; }
        public string? cardStatus { get; set; }
        public string? cardType { get; set; }
        public string? cardHolderName { get; set; }
        public string? productId { get; set; }
        public string? productName { get; set; }
        public string? expirationDate { get; set; }
        public CardAccounts? cardAccounts { get; set; }
        public CardLimits? cardLimits { get; set; }
    }

    public class CardAccounts
    {
        [XmlElement("account")]
        public string[]? account { get; set; }
    }

    public class CardLimits
    {
        [XmlElement(ElementName = "limit")]
        public Limit[]? limit { get; set; }
    }

    public class Limit
    {
        public string? limitEntity { get; set; }
        public string? limitName { get; set; }
        public string? limitValue { get; set; }
        public string? limitCurrency { get; set; }
        public string? limitCount { get; set; }
    }
}
