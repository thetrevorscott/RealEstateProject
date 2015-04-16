using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FiveTalent.Models;
using FiveTalent.DAL;
using System.Threading.Tasks;
using System.IO;

namespace FiveTalent.Controllers
{
    public class ImageController : Controller
    {
        private ListingContext db = new ListingContext();

        //
        // GET: /Image/

        public ActionResult Index()
        {
            var images = db.Images.Include(i => i.Listing);
            return View(images.ToList());
        }

        //
        // GET: /Image/Details/5

        public ActionResult Details(int id = 0)
        {
            Image image = db.Images.Find(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            return View(image);
        }

        //
        // GET: /Image/Create

        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase[] uploadImages)
        {
            var imageUploads = Request.Files;
            int listingID = Convert.ToInt32(Request["listingId"]);

            if (imageUploads.Count > 0)
            {
                for (int i = 0; i < imageUploads.Count; i++)
                {
                    HttpPostedFileBase image = imageUploads[i];
                    if (image.ContentLength > 0)
                    {
                        Image newImage = new Image
                        {
                            ListingId = listingID,
                            FileName = image.FileName,
                            ImageSize = image.ContentLength,
                            ImageData = new byte[image.ContentLength]
                        };
                        image.InputStream.Read(newImage.ImageData, 0, image.ContentLength);

                        db.Images.Add(newImage);
                        db.SaveChanges();
                    }
                }
            }

            return View("~/Views/Listing/Index.cshtml", db.Listings.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}