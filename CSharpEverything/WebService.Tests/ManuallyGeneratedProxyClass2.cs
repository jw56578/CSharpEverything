using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WebService.Tests
{
    [XmlRoot(ElementName = "Sender", Namespace = "http://www.starstandard.org/STAR/5")]
    public class Sender
    {
        [XmlElement(ElementName = "ComponentID", Namespace = "http://www.starstandard.org/STAR/5")]
        public string ComponentID { get; set; }
        [XmlElement(ElementName = "TaskID", Namespace = "http://www.starstandard.org/STAR/5")]
        public string TaskID { get; set; }
        [XmlElement(ElementName = "CreatorNameCode", Namespace = "http://www.starstandard.org/STAR/5")]
        public string CreatorNameCode { get; set; }
        [XmlElement(ElementName = "SenderNameCode", Namespace = "http://www.starstandard.org/STAR/5")]
        public string SenderNameCode { get; set; }
    }

    [XmlRoot(ElementName = "ExtShow", Namespace = "urn:com.gm:vls")]
    public class ExtShow
    {
        [XmlAttribute(AttributeName = "recordSetCount")]
        public string RecordSetCount { get; set; }
    }

    [XmlRoot(ElementName = "DocumentIdentification", Namespace = "http://www.starstandard.org/STAR/5")]
    public class DocumentIdentification
    {
        [XmlElement(ElementName = "DocumentID", Namespace = "http://www.starstandard.org/STAR/5")]
        public string DocumentID { get; set; }
    }

    [XmlRoot(ElementName = "DocumentIdentificationGroup", Namespace = "http://www.starstandard.org/STAR/5")]
    public class DocumentIdentificationGroup
    {
        [XmlElement(ElementName = "DocumentIdentification", Namespace = "http://www.starstandard.org/STAR/5")]
        public DocumentIdentification DocumentIdentification { get; set; }
    }

    [XmlRoot(ElementName = "ExtVehicleInventoryHeader", Namespace = "urn:com.gm:vls")]
    public class ExtVehicleInventoryHeader
    {
        [XmlElement(ElementName = "DocumentIdentificationGroup", Namespace = "http://www.starstandard.org/STAR/5")]
        public DocumentIdentificationGroup DocumentIdentificationGroup { get; set; }
    }

    [XmlRoot(ElementName = "ExtVehicle", Namespace = "urn:com.gm:vls")]
    public class ExtVehicle
    {
        [XmlElement(ElementName = "Model", Namespace = "http://www.starstandard.org/STAR/5")]
        public string Model { get; set; }
        [XmlElement(ElementName = "ModelYear", Namespace = "http://www.starstandard.org/STAR/5")]
        public string ModelYear { get; set; }
        [XmlElement(ElementName = "ModelDescription", Namespace = "http://www.starstandard.org/STAR/5")]
        public string ModelDescription { get; set; }
        [XmlElement(ElementName = "MakeString", Namespace = "http://www.starstandard.org/STAR/5")]
        public string MakeString { get; set; }
        [XmlElement(ElementName = "SaleClassCode", Namespace = "http://www.starstandard.org/STAR/5")]
        public string SaleClassCode { get; set; }
        [XmlElement(ElementName = "VehicleNote", Namespace = "http://www.starstandard.org/STAR/5")]
        public string VehicleNote { get; set; }
        [XmlElement(ElementName = "BodyStyle", Namespace = "http://www.starstandard.org/STAR/5")]
        public string BodyStyle { get; set; }
        [XmlElement(ElementName = "VehicleID", Namespace = "http://www.starstandard.org/STAR/5")]
        public string VehicleID { get; set; }
        [XmlElement(ElementName = "SeriesCode", Namespace = "http://www.starstandard.org/STAR/5")]
        public string SeriesCode { get; set; }
        [XmlElement(ElementName = "SeriesName", Namespace = "http://www.starstandard.org/STAR/5")]
        public string SeriesName { get; set; }
        [XmlElement(ElementName = "MakeCode", Namespace = "urn:com.gm:vls")]
        public string MakeCode { get; set; }
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
        [XmlElement(ElementName = "LineThree", Namespace = "http://www.starstandard.org/STAR/5")]
        public string LineThree { get; set; }
        [XmlElement(ElementName = "LineFour", Namespace = "http://www.starstandard.org/STAR/5")]
        public string LineFour { get; set; }
        [XmlElement(ElementName = "CityName", Namespace = "http://www.starstandard.org/STAR/5")]
        public string CityName { get; set; }
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
        [XmlElement(ElementName = "DoingBusinessAsName", Namespace = "http://www.starstandard.org/STAR/5")]
        public string DoingBusinessAsName { get; set; }
    }

    [XmlRoot(ElementName = "ExtOwnerParty", Namespace = "urn:com.gm:vls")]
    public class ExtOwnerParty
    {
        [XmlElement(ElementName = "PartyID", Namespace = "http://www.starstandard.org/STAR/5")]
        public string PartyID { get; set; }
        [XmlElement(ElementName = "DealerManagementSystemID", Namespace = "http://www.starstandard.org/STAR/5")]
        public string DealerManagementSystemID { get; set; }
        [XmlElement(ElementName = "RelationshipTypeCode", Namespace = "http://www.starstandard.org/STAR/5")]
        public string RelationshipTypeCode { get; set; }
        [XmlElement(ElementName = "SpecifiedOrganization", Namespace = "http://www.starstandard.org/STAR/5")]
        public SpecifiedOrganization SpecifiedOrganization { get; set; }
        [XmlElement(ElementName = "ManufacturerCustomerID", Namespace = "http://www.starstandard.org/STAR/5")]
        public string ManufacturerCustomerID { get; set; }
        [XmlElement(ElementName = "ManufacturerHouseholdID", Namespace = "http://www.starstandard.org/STAR/5")]
        public string ManufacturerHouseholdID { get; set; }
    }

    [XmlRoot(ElementName = "ExtPartyActionEvent", Namespace = "urn:com.gm:vls")]
    public class ExtPartyActionEvent
    {
        [XmlElement(ElementName = "EventID", Namespace = "http://www.starstandard.org/STAR/5")]
        public string EventID { get; set; }
        [XmlElement(ElementName = "EventDescription", Namespace = "http://www.starstandard.org/STAR/5")]
        public string EventDescription { get; set; }
        [XmlElement(ElementName = "ExtEventOccurrenceDateTime", Namespace = "urn:com.gm:vls")]
        public string ExtEventOccurrenceDateTime { get; set; }
    }

    [XmlRoot(ElementName = "ExtShipToParty", Namespace = "urn:com.gm:vls")]
    public class ExtShipToParty
    {
        [XmlElement(ElementName = "ExtPartyActionEvent", Namespace = "urn:com.gm:vls")]
        public List<ExtPartyActionEvent> ExtPartyActionEvent { get; set; }
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
    }

    [XmlRoot(ElementName = "Pricing", Namespace = "urn:com.gm:vls")]
    public class Pricing
    {
        [XmlElement(ElementName = "Price", Namespace = "http://www.starstandard.org/STAR/5")]
        public List<Price> Price { get; set; }
    }

    [XmlRoot(ElementName = "Option", Namespace = "urn:com.gm:vls")]
    public class Option
    {
        [XmlElement(ElementName = "OptionID", Namespace = "http://www.starstandard.org/STAR/5")]
        public string OptionID { get; set; }
        [XmlElement(ElementName = "OptionTypeCode", Namespace = "http://www.starstandard.org/STAR/5")]
        public string OptionTypeCode { get; set; }
        [XmlElement(ElementName = "OptionName", Namespace = "http://www.starstandard.org/STAR/5")]
        public string OptionName { get; set; }
    }

    [XmlRoot(ElementName = "OrderType", Namespace = "urn:com.gm:vls")]
    public class OrderType
    {
        [XmlAttribute(AttributeName = "generalOrderType")]
        public string GeneralOrderType { get; set; }
        [XmlAttribute(AttributeName = "vehicleOrderType")]
        public string VehicleOrderType { get; set; }
    }

    [XmlRoot(ElementName = "ServiceCampaign", Namespace = "urn:com.gm:vls")]
    public class ServiceCampaign
    {
        [XmlElement(ElementName = "CampaignNumberString", Namespace = "urn:com.gm:vls")]
        public string CampaignNumberString { get; set; }
        [XmlElement(ElementName = "CampaignDispositionCode", Namespace = "urn:com.gm:vls")]
        public string CampaignDispositionCode { get; set; }
        [XmlElement(ElementName = "CampaignDescription", Namespace = "urn:com.gm:vls")]
        public string CampaignDescription { get; set; }
        [XmlElement(ElementName = "CampaignTypeCode", Namespace = "urn:com.gm:vls")]
        public string CampaignTypeCode { get; set; }
        [XmlElement(ElementName = "CampaignDate", Namespace = "urn:com.gm:vls")]
        public string CampaignDate { get; set; }
        [XmlElement(ElementName = "CampaignExpirationDate", Namespace = "urn:com.gm:vls")]
        public string CampaignExpirationDate { get; set; }
        [XmlElement(ElementName = "CampaignTypeDescription", Namespace = "urn:com.gm:vls")]
        public string CampaignTypeDescription { get; set; }
        [XmlElement(ElementName = "OriginalCampaignNumberString", Namespace = "urn:com.gm:vls")]
        public string OriginalCampaignNumberString { get; set; }
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
        [XmlElement(ElementName = "VehicleOrderNumber", Namespace = "urn:com.gm:vls")]
        public string VehicleOrderNumber { get; set; }
        [XmlElement(ElementName = "VehicleStockString", Namespace = "urn:com.gm:vls")]
        public string VehicleStockString { get; set; }
        [XmlElement(ElementName = "Pricing", Namespace = "urn:com.gm:vls")]
        public Pricing Pricing { get; set; }
        [XmlElement(ElementName = "Option", Namespace = "urn:com.gm:vls")]
        public List<Option> Option { get; set; }
        [XmlElement(ElementName = "VehicleActivityStatus", Namespace = "urn:com.gm:vls")]
        public string VehicleActivityStatus { get; set; }
        [XmlElement(ElementName = "OrderType", Namespace = "urn:com.gm:vls")]
        public OrderType OrderType { get; set; }
        [XmlElement(ElementName = "InvoiceNumber", Namespace = "urn:com.gm:vls")]
        public string InvoiceNumber { get; set; }
        [XmlElement(ElementName = "CriticalRecallIndicator", Namespace = "urn:com.gm:vls")]
        public string CriticalRecallIndicator { get; set; }
        [XmlElement(ElementName = "ServiceCampaign", Namespace = "urn:com.gm:vls")]
        public List<ServiceCampaign> ServiceCampaign { get; set; }
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
        public List<ExtVehicleInventoryVehicleLineItem> ExtVehicleInventoryVehicleLineItem { get; set; }
    }

    [XmlRoot(ElementName = "ExtVehicleInventory", Namespace = "urn:com.gm:vls")]
    public class ExtVehicleInventory
    {
        [XmlElement(ElementName = "ExtVehicleInventoryHeader", Namespace = "urn:com.gm:vls")]
        public ExtVehicleInventoryHeader ExtVehicleInventoryHeader { get; set; }
        [XmlElement(ElementName = "ExtVehicleInventoryInvoice", Namespace = "urn:com.gm:vls")]
        public ExtVehicleInventoryInvoice ExtVehicleInventoryInvoice { get; set; }
    }

    [XmlRoot(ElementName = "ExtShowVehicleInventoryDataArea", Namespace = "urn:com.gm:vls")]
    public class ExtShowVehicleInventoryDataArea
    {
        [XmlElement(ElementName = "ExtShow", Namespace = "urn:com.gm:vls")]
        public ExtShow ExtShow { get; set; }
        [XmlElement(ElementName = "ExtVehicleInventory", Namespace = "urn:com.gm:vls")]
        public ExtVehicleInventory ExtVehicleInventory { get; set; }
    }

    [XmlRoot(ElementName = "ExtShowVehicleInventory", Namespace = "urn:com.gm:vls")]
    public class ExtShowVehicleInventory
    {
        [XmlElement(ElementName = "ExtApplicationArea", Namespace = "urn:com.gm:vls")]
        public ExtApplicationArea ExtApplicationArea { get; set; }
        [XmlElement(ElementName = "ExtShowVehicleInventoryDataArea", Namespace = "urn:com.gm:vls")]
        public ExtShowVehicleInventoryDataArea ExtShowVehicleInventoryDataArea { get; set; }
        [XmlAttribute(AttributeName = "schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string SchemaLocation { get; set; }
        [XmlAttribute(AttributeName = "star", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Star { get; set; }
        [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xsi { get; set; }
        [XmlAttribute(AttributeName = "udt", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Udt { get; set; }
        [XmlAttribute(AttributeName = "vls", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Vls { get; set; }
    }

}
