using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuotesWebApi.Data;
using QuotesWebApi.Models;

namespace QuotesWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : Controller
    {
        private QuotesContext quotesDbContext;

        public QuotesController(QuotesContext dbContext)
        {
            quotesDbContext = dbContext;
        }

        public static List<Quote> quotes = new List<Quote>()
        {
                new Quote() { Id = 0, Author = "Some Cool Author", Description = "Some DEscription", Title = "Some Title" },
                new Quote() { Id = 1, Author = "Another Author", Description = "Another DEscription", Title = "Another Title" }
        };

        // GET: api/values
        [HttpGet]
        public IEnumerable<Quote> Get()
        {
            return quotesDbContext.Quote;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Quote Get(int id)
        {
            return quotesDbContext.Quote.Find(id);
        }


        [Route("GetAllQuotesByCategory")]
        public IActionResult GetAllQuotesByCategory(string category)
        {
            return Ok(quotesDbContext.Quote.Where(p => p.Category.ToLower().Contains(category.ToLower())));
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Quote quote)
        {
            quotesDbContext.Quote.Add(quote);
            quotesDbContext.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Quote quote)
        {
            var foundQuote = quotesDbContext.Quote.Find(id);
            foundQuote.Author = quote.Author;
            foundQuote.Description = quote.Description;
            foundQuote.Title = quote.Title;
            quotesDbContext.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var foundQuote = quotesDbContext.Quote.Find(id);
            quotesDbContext.Remove(foundQuote);
            quotesDbContext.SaveChanges();
        }
    }
}