using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
namespace WebService.Tests
{
    /* 
this is the website that made the code
the xsd.exe is not reliable
  http://xmltocsharp.azurewebsites.net/

  */


    [XmlRoot(ElementName = "ExtSender", Namespace = "urn:com.gm:vls")]
    public class ExtSender
    {
        [XmlElement(ElementName = "ComponentID", Namespace = "http://www.starstandard.org/STAR/5")]
        public string ComponentID { get; set; }
        [XmlElement(ElementName = "TaskID", Namespace = "http://www.starstandard.org/STAR/5")]
        public string TaskID { get; set; }
        [XmlElement(ElementName = "CreatorNameCode", Namespace = "http://www.starstandard.org/STAR/5")]
        public string CreatorNameCode { get; set; }
        [XmlElement(ElementName = "SenderNameCode", Namespace = "http://www.starstandard.org/STAR/5")]
        public string SenderNameCode { get; set; }
        [XmlElement(ElementName = "DealerNumberID", Namespace = "http://www.starstandard.org/STAR/5")]
        public string DealerNumberID { get; set; }
        [XmlElement(ElementName = "ExtDealerCountryCode", Namespace = "urn:com.gm:vls")]
        public string ExtDealerCountryCode { get; set; }
        [XmlElement(ElementName = "ExtLanguageCode", Namespace = "urn:com.gm:vls")]
        public string ExtLanguageCode { get; set; }
    }

    [XmlRoot(ElementName = "Destination", Namespace = "urn:com.gm:vls")]
    public class Destination
    {
        [XmlElement(ElementName = "DestinationNameCode", Namespace = "http://www.starstandard.org/STAR/5")]
        public string DestinationNameCode { get; set; }
        [XmlElement(ElementName = "DestinationSoftwareCode", Namespace = "http://www.starstandard.org/STAR/5")]
        public string DestinationSoftwareCode { get; set; }
    }

    [XmlRoot(ElementName = "ExtApplicationArea", Namespace = "urn:com.gm:vls")]
    public class ExtApplicationArea
    {
        [XmlElement(ElementName = "ExtSender", Namespace = "urn:com.gm:vls")]
        public ExtSender ExtSender { get; set; }
        [XmlElement(ElementName = "CreationDateAndTime", Namespace = "urn:com.gm:vls")]
        public string CreationDateAndTime { get; set; }
        [XmlElement(ElementName = "Destination", Namespace = "urn:com.gm:vls")]
        public Destination Destination { get; set; }
    }

    [XmlRoot(ElementName = "SearchByCity", Namespace = "urn:com.gm:vls")]
    public class SearchByCity
    {
        [XmlElement(ElementName = "RegionCode", Namespace = "urn:com.gm:vls")]
        public string RegionCode { get; set; }
        [XmlElement(ElementName = "Proximity", Namespace = "urn:com.gm:vls")]
        public string Proximity { get; set; }
        [XmlElement(ElementName = "City", Namespace = "urn:com.gm:vls")]
        public string City { get; set; }
    }

    [XmlRoot(ElementName = "SearchByMultipleVendor", Namespace = "urn:com.gm:vls")]
    public class SearchByMultipleVendor
    {
        [XmlElement(ElementName = "VendorId", Namespace = "urn:com.gm:vls")]
        public List<string> VendorId { get; set; }
        [XmlAttribute(AttributeName = "isTradingPartnerSearch")]
        public string IsTradingPartnerSearch { get; set; }
    }

    [XmlRoot(ElementName = "SearchByPostalCode", Namespace = "urn:com.gm:vls")]
    public class SearchByPostalCode
    {
        [XmlElement(ElementName = "Proximity", Namespace = "urn:com.gm:vls")]
        public string Proximity { get; set; }
        [XmlElement(ElementName = "PostalCode", Namespace = "urn:com.gm:vls")]
        public string PostalCode { get; set; }
    }

    [XmlRoot(ElementName = "SearchByRegion", Namespace = "urn:com.gm:vls")]
    public class SearchByRegion
    {
        [XmlElement(ElementName = "RegionCode", Namespace = "urn:com.gm:vls")]
        public List<string> RegionCode { get; set; }
    }

    [XmlRoot(ElementName = "SearchBySingleVendor", Namespace = "urn:com.gm:vls")]
    public class SearchBySingleVendor
    {
        [XmlElement(ElementName = "VendorId", Namespace = "urn:com.gm:vls")]
        public string VendorId { get; set; }
    }

    [XmlRoot(ElementName = "SearchCriteria", Namespace = "urn:com.gm:vls")]
    public class SearchCriteria
    {
        [XmlElement(ElementName = "SearchByCity", Namespace = "urn:com.gm:vls")]
        public SearchByCity SearchByCity { get; set; }
        [XmlElement(ElementName = "SearchByMultipleVendor", Namespace = "urn:com.gm:vls")]
        public List<SearchByMultipleVendor> SearchByMultipleVendor { get; set; }
        [XmlElement(ElementName = "SearchByPostalCode", Namespace = "urn:com.gm:vls")]
        public SearchByPostalCode SearchByPostalCode { get; set; }
        [XmlElement(ElementName = "SearchByRegion", Namespace = "urn:com.gm:vls")]
        public SearchByRegion SearchByRegion { get; set; }
        [XmlElement(ElementName = "SearchBySingleVendor", Namespace = "urn:com.gm:vls")]
        public SearchBySingleVendor SearchBySingleVendor { get; set; }
    }

    [XmlRoot(ElementName = "VehicleSpecification", Namespace = "urn:com.gm:vls")]
    public class VehicleSpecification
    {
        [XmlElement(ElementName = "MakeCode", Namespace = "urn:com.gm:vls")]
        public string MakeCode { get; set; }
        [XmlElement(ElementName = "MerchandisingModelDesignator", Namespace = "urn:com.gm:vls")]
        public string MerchandisingModelDesignator { get; set; }
        [XmlElement(ElementName = "SellingSourceCode", Namespace = "urn:com.gm:vls")]
        public string SellingSourceCode { get; set; }
        [XmlElement(ElementName = "Year", Namespace = "urn:com.gm:vls")]
        public string Year { get; set; }
    }

    [XmlRoot(ElementName = "EventCodeRange", Namespace = "urn:com.gm:vls")]
    public class EventCodeRange
    {
        [XmlAttribute(AttributeName = "startingEventCode")]
        public string StartingEventCode { get; set; }
        [XmlAttribute(AttributeName = "endingEventCode")]
        public string EndingEventCode { get; set; }
    }

    [XmlRoot(ElementName = "FilterCriteria", Namespace = "urn:com.gm:vls")]
    public class FilterCriteria
    {
        [XmlElement(ElementName = "EventCodeRange", Namespace = "urn:com.gm:vls")]
        public EventCodeRange EventCodeRange { get; set; }
    }

    [XmlRoot(ElementName = "OutputSpecification", Namespace = "urn:com.gm:vls")]
    public class OutputSpecification
    {
        [XmlElement(ElementName = "IncludeAvailableFinancing", Namespace = "urn:com.gm:vls")]
        public string IncludeAvailableFinancing { get; set; }
        [XmlElement(ElementName = "IncludeHistory", Namespace = "urn:com.gm:vls")]
        public string IncludeHistory { get; set; }
        [XmlElement(ElementName = "IncludeModelInfo", Namespace = "urn:com.gm:vls")]
        public string IncludeModelInfo { get; set; }
        [XmlElement(ElementName = "IncludeOptions", Namespace = "urn:com.gm:vls")]
        public string IncludeOptions { get; set; }
        [XmlElement(ElementName = "IncludePricing", Namespace = "urn:com.gm:vls")]
        public string IncludePricing { get; set; }
        [XmlElement(ElementName = "IncludeReservationInfo", Namespace = "urn:com.gm:vls")]
        public string IncludeReservationInfo { get; set; }
        [XmlElement(ElementName = "IncludeStatus", Namespace = "urn:com.gm:vls")]
        public string IncludeStatus { get; set; }
        [XmlElement(ElementName = "IncludeVendorAssigned", Namespace = "urn:com.gm:vls")]
        public string IncludeVendorAssigned { get; set; }
        [XmlElement(ElementName = "IncludeVendorDetail", Namespace = "urn:com.gm:vls")]
        public string IncludeVendorDetail { get; set; }
        [XmlElement(ElementName = "OptionDescriptionType", Namespace = "urn:com.gm:vls")]
        public string OptionDescriptionType { get; set; }
        [XmlElement(ElementName = "IncludeProgramCodes", Namespace = "urn:com.gm:vls")]
        public string IncludeProgramCodes { get; set; }
        [XmlElement(ElementName = "IncludeTotalCashAllowance", Namespace = "urn:com.gm:vls")]
        public string IncludeTotalCashAllowance { get; set; }
        [XmlElement(ElementName = "IncludeOptionLevelPricing", Namespace = "urn:com.gm:vls")]
        public string IncludeOptionLevelPricing { get; set; }
        [XmlElement(ElementName = "IncludeSoldFleetVehicles", Namespace = "urn:com.gm:vls")]
        public string IncludeSoldFleetVehicles { get; set; }
        [XmlElement(ElementName = "IncludeDemoVehicles", Namespace = "urn:com.gm:vls")]
        public string IncludeDemoVehicles { get; set; }
        [XmlElement(ElementName = "IncludeDMSInventoryInfo", Namespace = "urn:com.gm:vls")]
        public string IncludeDMSInventoryInfo { get; set; }
        [XmlElement(ElementName = "IncludeServiceCampaigns", Namespace = "urn:com.gm:vls")]
        public string IncludeServiceCampaigns { get; set; }
    }

    [XmlRoot(ElementName = "ExtGet", Namespace = "urn:com.gm:vls")]
    public class ExtGet
    {
        [XmlElement(ElementName = "Expression", Namespace = "http://www.openapplications.org/oagis/9")]
        public string Expression { get; set; }
        [XmlElement(ElementName = "SearchCriteria", Namespace = "urn:com.gm:vls")]
        public SearchCriteria SearchCriteria { get; set; }
        [XmlElement(ElementName = "VehicleSpecification", Namespace = "urn:com.gm:vls")]
        public VehicleSpecification VehicleSpecification { get; set; }
        [XmlElement(ElementName = "FilterCriteria", Namespace = "urn:com.gm:vls")]
        public FilterCriteria FilterCriteria { get; set; }
        [XmlElement(ElementName = "OutputSpecification", Namespace = "urn:com.gm:vls")]
        public OutputSpecification OutputSpecification { get; set; }
        [XmlAttribute(AttributeName = "extMaxItems")]
        public string ExtMaxItems { get; set; }
    }

    [XmlRoot(ElementName = "ExtGetVehicleInventoryDataArea", Namespace = "urn:com.gm:vls")]
    public class ExtGetVehicleInventoryDataArea
    {
        [XmlElement(ElementName = "ExtGet", Namespace = "urn:com.gm:vls")]
        public ExtGet ExtGet { get; set; }
    }

    [XmlRoot(ElementName = "ExtGetVehicleInventory", Namespace = "urn:com.gm:vls")]
    public class ExtGetVehicleInventory
    {
        [XmlElement(ElementName = "ExtApplicationArea", Namespace = "urn:com.gm:vls")]
        public ExtApplicationArea ExtApplicationArea { get; set; }
        [XmlElement(ElementName = "ExtGetVehicleInventoryDataArea", Namespace = "urn:com.gm:vls")]
        public ExtGetVehicleInventoryDataArea ExtGetVehicleInventoryDataArea { get; set; }
        [XmlAttribute(AttributeName = "schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string SchemaLocation { get; set; }
        [XmlAttribute(AttributeName = "oagis", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Oagis { get; set; }
        [XmlAttribute(AttributeName = "star", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Star { get; set; }
        [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xsi { get; set; }
        [XmlAttribute(AttributeName = "vls", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Vls { get; set; }
    }

}

