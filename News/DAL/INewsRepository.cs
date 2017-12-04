using System;
using System.Collections.Generic;
using News.Models;

namespace News.DAL
{
    public interface INewsRepository : IDisposable
    {
        IEnumerable<NewsItem> GetNews();
        NewsItem GetNewsById(long id);
        void InsertNews(NewsItem item);
        void DeleteNews(NewsItem item);
        void UpdateNews(NewsItem item);
        void SaveChanges();
    }
}
