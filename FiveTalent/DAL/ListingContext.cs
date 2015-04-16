using FiveTalent.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace FiveTalent.DAL
{
    public class ListingContext : DbContext
    {
        public ListingContext() : base("DefaultConnection")
        {
        }

        public DbSet<Listing> Listings { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}