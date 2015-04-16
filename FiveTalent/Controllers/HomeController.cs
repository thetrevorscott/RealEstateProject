using FiveTalent.DAL;
using FiveTalent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FiveTalent.Controllers
{
    public class HomeController : Controller
    {
        private ListingContext db = new ListingContext();

        public ActionResult Index()
        {
            ListingViewModel listingViewModel = new ListingViewModel();
            listingViewModel.ListingSearchFilter = new ListingSearchFilter();
            listingViewModel.Listings = new List<Listing>();
            return View(listingViewModel);
        }

        [HttpPost]
        public ActionResult Search(ListingViewModel listingViewModel)
        {
            var listingSearchFilter = listingViewModel.ListingSearchFilter;
            List<Listing> listingsFound = db.Listings.Where(listing => 
                (listing.ListingId == listingSearchFilter.MLS || listingSearchFilter.MLS == null)
                && (listing.City == listingSearchFilter.City || listingSearchFilter.City == null)
                && (listing.State == listingSearchFilter.State || listingSearchFilter.State == null)
                && (listing.Zipcode == listingSearchFilter.Zipcode || listingSearchFilter.Zipcode == null)
                && (listing.Bedrooms == listingSearchFilter.Bedrooms || listingSearchFilter.Bedrooms == null)
                && (listing.FullBathrooms == listingSearchFilter.FullBathrooms || listingSearchFilter.FullBathrooms == null)
                && (listing.PartialBathrooms == listingSearchFilter.PartialBathrooms || listingSearchFilter.PartialBathrooms == null)
                && (listing.SquareFeet == listingSearchFilter.SquareFeet || listingSearchFilter.SquareFeet == null)).ToList();

            var resultListingView = new ListingViewModel
                {
                    ListingSearchFilter = listingViewModel.ListingSearchFilter,
                    Listings = listingsFound
                };
            return View("Index", resultListingView);
        }
    }
}
