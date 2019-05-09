using LibraryEntity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleSelection.ViewComponents
{
    /// <summary>
    /// 用于显示不属于父级view的数据
    /// </summary>
    public class WelcomeViewComponent:ViewComponent
    {
        private readonly dbContext _repository;
        public WelcomeViewComponent( dbContext repository)
        {
            _repository = repository;
        }

        public IViewComponentResult Invoke()
        {
            var count = _repository.AllFiles.Count();
            return View("Default",count);
        }

    }
}
