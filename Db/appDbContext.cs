using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFileTask.Db
{
  public class appDbContext:DbContext
    {
        public appDbContext():base("name =imgdb ")
        { 
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
         
        }
      public  DbSet<Domain.Image_Data> Image_Data { get; set; }
    }
}
