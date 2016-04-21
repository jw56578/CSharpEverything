using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace WebService.Tests.ProxyClasses
{
    [XmlRoot(ElementName = "Sender", Namespace = "http://www.starstandard.org/STAR/5")]
    public class Sender
    {
        [XmlElement(ElementName = "DealerNumberID", Namespace = "http://www.starstandard.org/STAR/5")]
        public string DealerNumberID { get; set; }
        [XmlElement(ElementName = "DealerCountryCode", Namespace = "http://www.starstandard.org/STAR/5")]
        public string DealerCountryCode { get; set; }
        [XmlElement(ElementName = "LanguageCode", Namespace = "http://www.starstandard.org/STAR/5")]
        public string LanguageCode { get; set; }
        [XmlAttribute(AttributeName = "ns2", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Ns2 { get; set; }
    }

    [XmlRoot(ElementName = "CreationDateAndTime", Namespace = "http://www.starstandard.org/STAR/5")]
    public class CreationDateAndTime
    {
        [XmlAttribute(AttributeName = "ns2", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Ns2 { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "Model", Namespace = "http://www.starstandard.org/STAR/5")]
    public class Model
    {
        [XmlAttribute(AttributeName = "ns2", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Ns2 { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "ModelYear", Namespace = "http://www.starstandard.org/STAR/5")]
    public class ModelYear
    {
        [XmlAttribute(AttributeName = "ns2", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Ns2 { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "ModelDescription", Namespace = "http://www.starstandard.org/STAR/5")]
    public class ModelDescription
    {
        [XmlAttribute(AttributeName = "ns2", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Ns2 { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "MakeString", Namespace = "http://www.starstandard.org/STAR/5")]
    public class MakeString
    {
        [XmlAttribute(AttributeName = "ns2", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Ns2 { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "BodyStyle", Namespace = "http://www.starstandard.org/STAR/5")]
    public class BodyStyle
    {
        [XmlAttribute(AttributeName = "ns2", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Ns2 { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "VehicleID", Namespace = "http://www.starstandard.org/STAR/5")]
    public class VehicleID
    {
        [XmlAttribute(AttributeName = "ns2", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Ns2 { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "SeriesCode", Namespace = "http://www.starstandard.org/STAR/5")]
    public class SeriesCode
    {
        [XmlAttribute(AttributeName = "ns2", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Ns2 { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "SeriesName", Namespace = "http://www.starstandard.org/STAR/5")]
    public class SeriesName
    {
        [XmlAttribute(AttributeName = "ns2", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Ns2 { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "ExtVehicle", Namespace = "urn:com.gm:vls")]
    public class ExtVehicle
    {
        [XmlElement(ElementName = "Model", Namespace = "http://www.starstandard.org/STAR/5")]
        public Model Model { get; set; }
        [XmlElement(ElementName = "ModelYear", Namespace = "http://www.starstandard.org/STAR/5")]
        public ModelYear ModelYear { get; set; }
        [XmlElement(ElementName = "ModelDescription", Namespace = "http://www.starstandard.org/STAR/5")]
        public ModelDescription ModelDescription { get; set; }
        [XmlElement(ElementName = "MakeString", Namespace = "http://www.starstandard.org/STAR/5")]
        public MakeString MakeString { get; set; }
        [XmlElement(ElementName = "BodyStyle", Namespace = "http://www.starstandard.org/STAR/5")]
        public BodyStyle BodyStyle { get; set; }
        [XmlElement(ElementName = "VehicleID", Namespace = "http://www.starstandard.org/STAR/5")]
        public VehicleID VehicleID { get; set; }
        [XmlElement(ElementName = "SeriesCode", Namespace = "http://www.starstandard.org/STAR/5")]
        public SeriesCode SeriesCode { get; set; }
        [XmlElement(ElementName = "SeriesName", Namespace = "http://www.starstandard.org/STAR/5")]
        public SeriesName SeriesName { get; set; }
        [XmlElement(ElementName = "MakeCode", Namespace = "urn:com.gm:vls")]
        public string MakeCode { get; set; }
    }

    [XmlRoot(ElementName = "PartyID", Namespace = "http://www.starstandard.org/STAR/5")]
    public class PartyID
    {
        [XmlAttribute(AttributeName = "ns2", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Ns2 { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "TelephoneCommunication", Namespace = "http://www.starstandard.org/STAR/5")]
    public class TelephoneCommunication
    {
        [XmlElement(ElementName = "ChannelCode", Namespace = "http://www.starstandard.org/STAR/5")]
        public string ChannelCode { get; set; }
        [XmlElement(ElementName = "CompleteNumber", Namespace = "http://www.starstandard.org/STAR/5")]
        public string CompleteNumber { get; set; }
    }

    [XmlRoot(ElementName = "PostalAddress", Namespace = "http://www.starstandard.org/STAR/5")]
    public class PostalAddress
    {
        [XmlElement(ElementName = "AddressType", Namespace = "http://www.starstandard.org/STAR/5")]
        public string AddressType { get; set; }
        [XmlElement(ElementName = "LineOne", Namespace = "http://www.starstandard.org/STAR/5")]
        public string LineOne { get; set; }
        [XmlElement(ElementName = "LineTwo", Namespace = "http://www.starstandard.org/STAR/5")]
        public string LineTwo { get; set; }
        [XmlElement(ElementName = "LineThree", Namespace = "http://www.starstandard.org/STAR/5")]
        public string LineThree { get; set; }
        [XmlElement(ElementName = "CountryID", Namespace = "http://www.starstandard.org/STAR/5")]
        public string CountryID { get; set; }
        [XmlElement(ElementName = "Postcode", Namespace = "http://www.starstandard.org/STAR/5")]
        public string Postcode { get; set; }
    }

    [XmlRoot(ElementName = "URICommunication", Namespace = "http://www.starstandard.org/STAR/5")]
    public class URICommunication
    {
        [XmlElement(ElementName = "ChannelCode", Namespace = "http://www.starstandard.org/STAR/5")]
        public string ChannelCode { get; set; }
        [XmlElement(ElementName = "CompleteNumber", Namespace = "http://www.starstandard.org/STAR/5")]
        public string CompleteNumber { get; set; }
    }

    [XmlRoot(ElementName = "PrimaryContact", Namespace = "http://www.starstandard.org/STAR/5")]
    public class PrimaryContact
    {
        [XmlElement(ElementName = "TypeCode", Namespace = "http://www.starstandard.org/STAR/5")]
        public string TypeCode { get; set; }
        [XmlElement(ElementName = "PersonName", Namespace = "http://www.starstandard.org/STAR/5")]
        public string PersonName { get; set; }
        [XmlElement(ElementName = "TelephoneCommunication", Namespace = "http://www.starstandard.org/STAR/5")]
        public List<TelephoneCommunication> TelephoneCommunication { get; set; }
        [XmlElement(ElementName = "PostalAddress", Namespace = "http://www.starstandard.org/STAR/5")]
        public PostalAddress PostalAddress { get; set; }
        [XmlElement(ElementName = "URICommunication", Namespace = "http://www.starstandard.org/STAR/5")]
        public URICommunication URICommunication { get; set; }
    }

    [XmlRoot(ElementName = "SpecifiedOrganization", Namespace = "http://www.starstandard.org/STAR/5")]
    public class SpecifiedOrganization
    {
        [XmlElement(ElementName = "BusinessTypeCode", Namespace = "http://www.starstandard.org/STAR/5")]
        public string BusinessTypeCode { get; set; }
        [XmlElement(ElementName = "PrimaryContact", Namespace = "http://www.starstandard.org/STAR/5")]
        public PrimaryContact PrimaryContact { get; set; }
        [XmlAttribute(AttributeName = "ns2", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Ns2 { get; set; }
    }

    [XmlRoot(ElementName = "ManufacturerCustomerID", Namespace = "http://www.starstandard.org/STAR/5")]
    public class ManufacturerCustomerID
    {
        [XmlAttribute(AttributeName = "ns2", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Ns2 { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "ManufacturerHouseholdID", Namespace = "http://www.starstandard.org/STAR/5")]
    public class ManufacturerHouseholdID
    {
        [XmlAttribute(AttributeName = "ns2", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Ns2 { get; set; }
    }

    [XmlRoot(ElementName = "ExtOwnerParty", Namespace = "urn:com.gm:vls")]
    public class ExtOwnerParty
    {
        [XmlElement(ElementName = "PartyID", Namespace = "http://www.starstandard.org/STAR/5")]
        public PartyID PartyID { get; set; }
        [XmlElement(ElementName = "SpecifiedOrganization", Namespace = "http://www.starstandard.org/STAR/5")]
        public SpecifiedOrganization SpecifiedOrganization { get; set; }
        [XmlElement(ElementName = "ManufacturerCustomerID", Namespace = "http://www.starstandard.org/STAR/5")]
        public ManufacturerCustomerID ManufacturerCustomerID { get; set; }
        [XmlElement(ElementName = "ManufacturerHouseholdID", Namespace = "http://www.starstandard.org/STAR/5")]
        public ManufacturerHouseholdID ManufacturerHouseholdID { get; set; }
    }

    [XmlRoot(ElementName = "PartyActionEvent", Namespace = "http://www.starstandard.org/STAR/5")]
    public class PartyActionEvent
    {
        [XmlElement(ElementName = "EventID", Namespace = "http://www.starstandard.org/STAR/5")]
        public string EventID { get; set; }
        [XmlElement(ElementName = "EventDescription", Namespace = "http://www.starstandard.org/STAR/5")]
        public string EventDescription { get; set; }
        [XmlElement(ElementName = "ExtEventOccurrenceDateTime", Namespace = "http://www.starstandard.org/STAR/5")]
        public string ExtEventOccurrenceDateTime { get; set; }
        [XmlAttribute(AttributeName = "ns2", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Ns2 { get; set; }
    }

    [XmlRoot(ElementName = "ExtShipToParty", Namespace = "urn:com.gm:vls")]
    public class ExtShipToParty
    {
        [XmlElement(ElementName = "PartyActionEvent", Namespace = "http://www.starstandard.org/STAR/5")]
        public List<PartyActionEvent> PartyActionEvent { get; set; }
    }

    [XmlRoot(ElementName = "ChargeAmount", Namespace = "http://www.starstandard.org/STAR/5")]
    public class ChargeAmount
    {
        [XmlAttribute(AttributeName = "currencyID")]
        public string CurrencyID { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "Price", Namespace = "http://www.starstandard.org/STAR/5")]
    public class Price
    {
        [XmlElement(ElementName = "ChargeAmount", Namespace = "http://www.starstandard.org/STAR/5")]
        public ChargeAmount ChargeAmount { get; set; }
        [XmlElement(ElementName = "PriceDescription", Namespace = "http://www.starstandard.org/STAR/5")]
        public string PriceDescription { get; set; }
        [XmlAttribute(AttributeName = "ns2", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Ns2 { get; set; }
    }

    [XmlRoot(ElementName = "Pricing", Namespace = "urn:com.gm:vls")]
    public class Pricing
    {
        [XmlElement(ElementName = "Price", Namespace = "http://www.starstandard.org/STAR/5")]
        public List<Price> Price { get; set; }
    }

    [XmlRoot(ElementName = "OptionID", Namespace = "http://www.starstandard.org/STAR/5")]
    public class OptionID
    {
        [XmlAttribute(AttributeName = "ns2", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Ns2 { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "OptionTypeCode", Namespace = "http://www.starstandard.org/STAR/5")]
    public class OptionTypeCode
    {
        [XmlAttribute(AttributeName = "ns2", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Ns2 { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "OptionName", Namespace = "http://www.starstandard.org/STAR/5")]
    public class OptionName
    {
        [XmlAttribute(AttributeName = "ns2", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Ns2 { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "OptionNotes", Namespace = "http://www.starstandard.org/STAR/5")]
    public class OptionNotes
    {
        [XmlAttribute(AttributeName = "ns2", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Ns2 { get; set; }
    }

    [XmlRoot(ElementName = "Option", Namespace = "urn:com.gm:vls")]
    public class Option
    {
        [XmlElement(ElementName = "OptionID", Namespace = "http://www.starstandard.org/STAR/5")]
        public OptionID OptionID { get; set; }
        [XmlElement(ElementName = "OptionTypeCode", Namespace = "http://www.starstandard.org/STAR/5")]
        public OptionTypeCode OptionTypeCode { get; set; }
        [XmlElement(ElementName = "OptionName", Namespace = "http://www.starstandard.org/STAR/5")]
        public OptionName OptionName { get; set; }
        [XmlElement(ElementName = "OptionNotes", Namespace = "http://www.starstandard.org/STAR/5")]
        public OptionNotes OptionNotes { get; set; }
    }

    [XmlRoot(ElementName = "ExtVehicleInventoryVehicleLineItem", Namespace = "urn:com.gm:vls")]
    public class ExtVehicleInventoryVehicleLineItem
    {
        [XmlElement(ElementName = "ExtVehicle", Namespace = "urn:com.gm:vls")]
        public ExtVehicle ExtVehicle { get; set; }
        [XmlElement(ElementName = "ExtOwnerParty", Namespace = "urn:com.gm:vls")]
        public ExtOwnerParty ExtOwnerParty { get; set; }
        [XmlElement(ElementName = "ExtShipToParty", Namespace = "urn:com.gm:vls")]
        public ExtShipToParty ExtShipToParty { get; set; }
        [XmlElement(ElementName = "Pricing", Namespace = "urn:com.gm:vls")]
        public Pricing Pricing { get; set; }
        [XmlElement(ElementName = "Option", Namespace = "urn:com.gm:vls")]
        public List<Option> Option { get; set; }
        [XmlElement(ElementName = "OrderType", Namespace = "urn:com.gm:vls")]
        public string OrderType { get; set; }
        [XmlElement(ElementName = "StockNumber", Namespace = "urn:com.gm:vls")]
        public string StockNumber { get; set; }
        [XmlAttribute(AttributeName = "confidenceRating")]
        public string ConfidenceRating { get; set; }
        [XmlAttribute(AttributeName = "distance")]
        public string Distance { get; set; }
        [XmlAttribute(AttributeName = "distanceUnitOfMeasure")]
        public string DistanceUnitOfMeasure { get; set; }
        [XmlAttribute(AttributeName = "searchCriteria")]
        public string SearchCriteria { get; set; }
    }

    [XmlRoot(ElementName = "ExtVehicleInventoryInvoice", Namespace = "urn:com.gm:vls")]
    public class ExtVehicleInventoryInvoice
    {
        [XmlElement(ElementName = "ExtVehicleInventoryVehicleLineItem", Namespace = "urn:com.gm:vls")]
        public ExtVehicleInventoryVehicleLineItem[] ExtVehicleInventoryVehicleLineItem { get; set; }
    }

    [XmlRoot(ElementName = "ExtVehicleInventory", Namespace = "urn:com.gm:vls")]
    public class ExtVehicleInventory
    {
        [XmlElement(ElementName = "ExtVehicleInventoryInvoice", Namespace = "urn:com.gm:vls")]
        public ExtVehicleInventoryInvoice ExtVehicleInventoryInvoice { get; set; }
    }

    [XmlRoot(ElementName = "ChangeStatus")]
    public class ChangeStatus
    {
        [XmlElement(ElementName = "Code")]
        public string Code { get; set; }
        [XmlElement(ElementName = "Description")]
        public string Description { get; set; }
    }

    [XmlRoot(ElementName = "ResponseCriteria", Namespace = "http://www.openapplications.org/oagis/9")]
    public class ResponseCriteria
    {
        [XmlElement(ElementName = "ChangeStatus")]
        public ChangeStatus ChangeStatus { get; set; }
        [XmlAttribute(AttributeName = "oagis", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Oagis { get; set; }
    }

    [XmlRoot(ElementName = "ExtShow", Namespace = "urn:com.gm:vls")]
    public class ExtShow
    {
        [XmlElement(ElementName = "ResponseCriteria", Namespace = "http://www.openapplications.org/oagis/9")]
        public ResponseCriteria ResponseCriteria { get; set; }
    }

    [XmlRoot(ElementName = "ExtShowVehicleInventoryDataArea", Namespace = "urn:com.gm:vls")]
    public class ExtShowVehicleInventoryDataArea
    {
        [XmlElement(ElementName = "ExtVehicleInventory", Namespace = "urn:com.gm:vls")]
        public ExtVehicleInventory ExtVehicleInventory { get; set; }
        [XmlElement(ElementName = "ExtShow", Namespace = "urn:com.gm:vls")]
        public ExtShow ExtShow { get; set; }
    }

    [XmlRoot(ElementName = "ExtShowVehicleInventory", Namespace = "urn:com.gm:vls")]
    public class ExtShowVehicleInventory
    {
        [XmlElement(ElementName = "ExtApplicationArea", Namespace = "urn:com.gm:vls")]
        public ExtApplicationArea ExtApplicationArea { get; set; }
        [XmlElement(ElementName = "ExtShowVehicleInventoryDataArea", Namespace = "urn:com.gm:vls")]
        public ExtShowVehicleInventoryDataArea ExtShowVehicleInventoryDataArea { get; set; }
        [XmlAttribute(AttributeName = "inp1", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Inp1 { get; set; }
        [XmlAttribute(AttributeName = "ns99", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Ns99 { get; set; }
    }

    [XmlRoot(ElementName = "content", Namespace = "http://www.starstandards.org/webservices/2005/10/transport")]
    public class Content
    {
        [XmlElement(ElementName = "ExtShowVehicleInventory", Namespace = "urn:com.gm:vls")]
        public ExtShowVehicleInventory ExtShowVehicleInventory { get; set; }
    }

    [XmlRoot(ElementName = "payload", Namespace = "http://www.starstandards.org/webservices/2005/10/transport")]
    public class Payload
    {
        [XmlElement(ElementName = "content", Namespace = "http://www.starstandards.org/webservices/2005/10/transport")]
        public Content Content { get; set; }
    }

    [XmlRoot(ElementName = "ProcessMessageResponse", Namespace = "http://www.starstandards.org/webservices/2005/10/transport")]
    public class ProcessMessageResponse
    {
        [XmlElement(ElementName = "payload", Namespace = "http://www.starstandards.org/webservices/2005/10/transport")]
        public Payload Payload { get; set; }
        [XmlAttribute(AttributeName = "tran", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Tran { get; set; }
    }

    [XmlRoot(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public class Body
    {
        [XmlElement(ElementName = "ProcessMessageResponse", Namespace = "http://www.starstandards.org/webservices/2005/10/transport")]
        public ProcessMessageResponse ProcessMessageResponse { get; set; }
        [XmlAttribute(AttributeName = "env", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Env { get; set; }
        [XmlAttribute(AttributeName = "wsa", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Wsa { get; set; }
    }

    [XmlRoot(ElementName = "Envelope", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public class Envelope
    {
        [XmlElement(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        public Body Body { get; set; }
        [XmlAttribute(AttributeName = "soapenv", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Soapenv { get; set; }
    }

}
