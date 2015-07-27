using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DealershipLab1.Models
{
    public class AutoModel
    {
        public int ID { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int year { get; set; }
        public int MPG { get; set; }
        public string color { get; set; }
        public int MSRP { get; set; }


    }
    public class AutoDBContext:DbContext
    {
        public DbSet<AutoModel> AutoModel { get; set; }
    }
}