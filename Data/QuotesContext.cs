using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuotesWebApi.Models;

namespace QuotesWebApi.Data
{
    public class QuotesContext : DbContext
    {
        public QuotesContext (DbContextOptions<QuotesContext> options)
            : base(options)
        {

        }
        public DbSet<QuotesWebApi.Models.Quote> Quote{ get; set; }
    }
}