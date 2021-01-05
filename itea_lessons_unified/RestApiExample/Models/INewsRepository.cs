using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicInfo.Models
{
    public interface INewsRepository
    {
        List<News> GetNews();
        void AddNews(News _new);
        void DeleteNews(int id);

        void UpdateNews(News _new);

        void PatchNews(int id, JsonPatchDocument<News> news);
    }
}
