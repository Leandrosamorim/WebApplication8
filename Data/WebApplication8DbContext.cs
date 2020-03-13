using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication8.Models;

namespace WebApplication8.Data
{
    public class WebApplication8DbContext : DbContext
    {
        public WebApplication8DbContext(DbContextOptions<WebApplication8DbContext> options) : base(options)
        {

        }
        public DbSet<Pessoa> Pessoas { get; set; }
    }
}
