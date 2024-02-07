using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using System;
using System.Xml.Serialization;
using System.Threading.Tasks;

namespace svici.bo2.core.Data.XML_Dto.storeApplicationRequest
{
    [XmlRoot(Namespace = Namespaces.EnvelopeNamespace)]
    public class StoreApplicationRequestDto
    {
        [XmlElement(ElementName = "application")]
        public StoreApplicationRequest? application { get; set; }
    }
    [XmlRoot("application")]
    public class StoreApplicationRequest
    {
        [XmlElement("application_type")]
        public string ApplicationType { get; set; }

        [XmlElement("application_flow_id")]
        public string? ApplicationFlowId { get; set; }

        [XmlElement("application_status")]
        public string ApplicationStatus { get; set; }

        [XmlElement("operator_id")]
        public string OperatorId { get; set; }

        [XmlElement("institution_id")]
        public string? InstitutionId { get; set; }

        [XmlElement("agent_id")]
        public string? AgentId { get; set; }

        [XmlElement("customer_type")]
        public string CustomerType { get; set; }

        [XmlElement("customer")]
        public Customer Customer { get; set; }
    }

    public class Customer
    {
        [XmlElement("command")]
        public string Command { get; set; }

        [XmlElement("customer_number")]
        public string CustomerNumber { get; set; }

        [XmlElement("customer_relation")]
        public string CustomerRelation { get; set; }

        [XmlElement("contract")]
        public Contract Contract { get; set; }

        [XmlElement("person")]
        public Person Person { get; set; }

        [XmlElement("contact")]
        public Contact Contact { get; set; }

        [XmlElement("address")]
        public Address Address { get; set; }
    }

    public class Contract
    {
        [XmlElement("command")]
        public string Command { get; set; }

        [XmlElement("contract_type")]
        public string ContractType { get; set; }

        [XmlElement("product_id")]
        public string? ProductId { get; set; }

        [XmlElement("start_date")]
        public string? StartDate { get; set; }

        [XmlElement("card")]
        public Card Card { get; set; }

        [XmlElement("service")]
        public Service[] Services { get; set; }

        [XmlElement("account")]
        public Account Account { get; set; }
    }

    public class Card
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlElement("command")]
        public string Command { get; set; }

        [XmlElement("card_number")]
        public string CardNumber { get; set; }

        [XmlElement("card_type")]
        public string CardType { get; set; }

        [XmlElement("category")]
        public string Category { get; set; }

        [XmlElement("start_date")]
        public string? StartDate { get; set; }

        [XmlElement("cardholder")]
        public Cardholder Cardholder { get; set; }
    }

    public class Cardholder
    {
        [XmlElement("command")]
        public string Command { get; set; }

        [XmlElement("cardholder_name")]
        public string CardholderName { get; set; }

        [XmlElement("sec_word")]
        public SecWord SecWord { get; set; }

        [XmlElement("customer_relation")]
        public string CustomerRelation { get; set; }
    }

    public class SecWord
    {
        [XmlElement("secret_question")]
        public string SecretQuestion { get; set; }

        [XmlElement("secret_answer")]
        public string SecretAnswer { get; set; }
    }

    public class Service
    {
        [XmlAttribute("value")]
        public string? Value { get; set; }

        [XmlElement("service_object")]
        public ServiceObject ServiceObject { get; set; }
    }

    public class ServiceObject
    {
        [XmlAttribute("ref_id")]
        public string RefId { get; set; }

        [XmlElement("start_date")]
        public string? StartDate { get; set; }
    }

    public class Account
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlElement("command")]
        public string Command { get; set; }

        [XmlElement("account_number")]
        public string AccountNumber { get; set; }

        [XmlElement("currency")]
        public string Currency { get; set; }

        [XmlElement("account_type")]
        public string AccountType { get; set; }

        [XmlElement("account_status")]
        public string AccountStatus { get; set; }

        [XmlElement("account_object")]
        public AccountObject AccountObject { get; set; }
    }

    public class AccountObject
    {
        [XmlAttribute("ref_id")]
        public string RefId { get; set; }

        [XmlElement("account_link_flag")]
        public string? AccountLinkFlag { get; set; }

        [XmlElement("is_pos_default")]
        public string? IsPosDefault { get; set; }

        [XmlElement("is_atm_default")]
        public string? IsAtmDefault { get; set; }
    }

    public class Person
    {
        [XmlElement("command")]
        public string Command { get; set; }

        [XmlElement("person_name")]
        public PersonName PersonName { get; set; }

        [XmlElement("birthday")]
        public string? Birthday { get; set; }

        [XmlElement("identity_card")]
        public IdentityCard IdentityCard { get; set; }
    }

    public class PersonName
    {
        [XmlElement("surname")]
        public string Surname { get; set; }

        [XmlElement("first_name")]
        public string FirstName { get; set; }
    }

    public class IdentityCard
    {
        [XmlElement("command")]
        public string Command { get; set; }

        [XmlElement("id_type")]
        public string IdType { get; set; }

        [XmlElement("id_series")]
        public string IdSeries { get; set; }

        [XmlElement("id_number")]
        public string IdNumber { get; set; }
    }

    public class Contact
    {
        [XmlElement("command")]
        public string Command { get; set; }

        [XmlElement("contact_type")]
        public string ContactType { get; set; }

        [XmlElement("preferred_lang")]
        public string PreferredLang { get; set; }

        [XmlElement("contact_data")]
        public ContactData ContactData { get; set; }
    }

    public class ContactData
    {
        [XmlElement("commun_method")]
        public string CommunMethod { get; set; }

        [XmlElement("commun_address")]
        public string CommunAddress { get; set; }
    }

    public class Address
    {
        [XmlElement("command")]
        public string Command { get; set; }

        [XmlElement("address_type")]
        public string AddressType { get; set; }

        [XmlElement("country")]
        public string? Country { get; set; }

        [XmlElement("address_name")]
        public AddressName AddressName { get; set; }

        [XmlElement("house")]
        public string House { get; set; }
    }

    public class AddressName
    {
        [XmlElement("region")]
        public string Region { get; set; }

        [XmlElement("city")]
        public string City { get; set; }

        [XmlElement("street")]
        public string Street { get; set; }
    }

}
