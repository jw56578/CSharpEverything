using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService.Tests.Star
{
    public class SearchInventoryCriteria
    {
        public Zipcode? Zipcode { get; set; }
        public City? City { get; set; }
        public State? State { get; set; }
        public Company? Company { get; set; }
        public OutputToInclude? OutputToInclude { get; set; }
        public int MaxItems { get; set; }
        


    }
    public struct OutputToInclude
    {
        public bool IncludeModelInfo { get; set; }
        public bool IncludePricing { get; set; }
        public bool IncludeOptions { get; set; }
        public bool IncludeStatus { get; set; }
        public bool IncludeVendorAssigned { get; set; }
        public bool IncludeVendorDetail { get; set; }
        public bool OptionDescriptionType { get; set; }
    }


    public struct Zipcode
    {
        public string PostalCode { get; set; }
        public int Proximity { get; set; }
    }
    public struct City
    {
        public string Name { get; set; }
        public int Proximity { get; set; }
        public string RegionCode { get; set; }
    }
    public struct State
    {
        public string Country { get; set; }
        public string RegionCode { get; set; }
    }
    public struct Company
    {
        public string Id { get; set; }
        public string VendorType { get; set; }
    }
}
