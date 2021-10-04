using System;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Reporting.Models.Repositerie;
using Reporting.ViewModels;



#nullable disable

namespace Reporting.Models
{
    public partial class ReportingContext : DbContext
    {
        public ReportingContext()
        {
        }

        public ReportingContext(DbContextOptions<ReportingContext> options)
            : base(options)
        {
        }

       
        public virtual DbSet<WaFacs> WaFacs { get; set; }
        public virtual DbSet<ListeAgence> ListeAgence { get; set; }
        public virtual DbSet<Dop> Dop { get; set; }
        public virtual DbSet<wa_cat_abt> wa_cat_abt { get; set; }
        public virtual DbSet<wa_fraudes> wa_fraudes { get; set; }
        public virtual DbSet<Direction> Direction { get; set; }
        public DbSet<Reporting.ViewModels.FraudesViewModel> FraudesViewModel { get; set; }
        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }*/


    }
}
