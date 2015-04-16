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
    public class Image
    {
        public int ImageId { get; set; }
        [ForeignKey("Listing")]
        public int ListingId { get; set; }
        public string FileName { get; set; }
        public int ImageSize { get; set; }
        public byte[] ImageData { get; set; }
        
        public virtual Listing Listing { get; set; }
    }
}