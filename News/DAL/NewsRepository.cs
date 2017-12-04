using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using News.Models;
using Microsoft.EntityFrameworkCore;

namespace News.DAL
{
    public class NewsRepository : INewsRepository, IDisposable
    {
        private NewsContext context;

        public NewsRepository(NewsContext context)
        {
            this.context = context;
        }

        public IEnumerable<NewsItem> GetNews()
        {
            return context.NewsItems.ToList();
        }

        public NewsItem GetNewsById(long id)
        {
            return context.NewsItems.FirstOrDefault(it => it.Id == id);
        }

        public void InsertNews(NewsItem item)
        {
            context.NewsItems.Add(item);
        }

        public void UpdateNews(NewsItem item)
        {
            context.Entry(item).State = EntityState.Modified;
        }

        public void DeleteNews(NewsItem newsItem)
        {
            context.NewsItems.Remove(newsItem);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        private bool disposed = false;
        
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
