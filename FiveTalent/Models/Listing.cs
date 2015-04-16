using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FiveTalent.Models
{
    public class Listing
    {
        [KeyAttribute()]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ListingId { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zipcode { get; set; }
        public string Neighborhood { get; set; }
        public float SalesPrice { get; set; }
        public DateTime DateListed { get; set; }
        public int Bedrooms { get; set; }
        public int FullBathrooms { get; set; }
        public int PartialBathrooms { get; set; }
        public int GarageSize { get; set; }
        public int SquareFeet { get; set; }
        public int LotSize { get; set; }
        public bool IsAcres { get; set; }
        public string Description { get; set; }

        public virtual List<Image> Images { get; set; }
    }

    public class ListingSearchFilter
    {
        public int? MLS { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int? Zipcode { get; set; }
        public int? Bedrooms { get; set; }
        public int? FullBathrooms { get; set; }
        public int? PartialBathrooms { get; set; }
        public int? SquareFeet { get; set; }
    }

    public class ListingViewModel
    {
        public ListingSearchFilter ListingSearchFilter { get; set; }
        public IEnumerable<Listing> Listings { get; set; }
    }
}