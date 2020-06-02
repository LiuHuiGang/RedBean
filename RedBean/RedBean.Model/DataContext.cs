using Microsoft.EntityFrameworkCore;
using RedBean.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedBean.Model
{
   public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<ContentInfo> ContentInfo { get; set; }
    }
}
