using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using News.Models;
using News.DAL;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace News.Controllers
{
    [Route("api/[controller]")]
    public class NewsController : Controller
    {
        private INewsRepository newsRepository;
        private readonly NewsContext _context;

        public NewsController(NewsContext context)
        {
            _context = context;
            this.newsRepository = new NewsRepository(_context);
        }

        [HttpGet]
        public IEnumerable<NewsItem> GetAll()
        {
            return newsRepository.GetNews();
        }

        [HttpGet("{id}", Name = "GetNews")]
        public IActionResult GetById(long id)
        {
            var item = newsRepository.GetNewsById(id);

            if(item == null)
            {
                return NotFound();
            }

            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] NewsItem item)
        {
            if(item == null)
            {
                return BadRequest();
            }

            newsRepository.InsertNews(item);
            newsRepository.SaveChanges();

            return CreatedAtRoute("GetNews", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] NewsItem item)
        {
            if(item == null || id != item.Id)
            {
                return BadRequest();
            }

            NewsItem newsItem = newsRepository.GetNewsById(id);
            if (newsItem == null)
            {
                return NotFound();
            }

            newsItem.Title = item.Title;
            newsItem.Body = item.Body;
            newsItem.Content = item.Content;
            newsItem.DateCreated = item.DateCreated;

            newsRepository.UpdateNews(newsItem);
            newsRepository.SaveChanges();

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            NewsItem newsItem = newsRepository.GetNewsById(id);
            if (newsItem == null)
            {
                return NotFound();
            }

            newsRepository.DeleteNews(newsItem);
            newsRepository.SaveChanges();

            return new NoContentResult();
        }
    }
}
