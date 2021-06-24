using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NamaShow.Core.Services.InterFaces;


namespace NmaShow.EndPoint.ViewComponent
{
    //public class FOO:ViewComponent
    //{
    //    ICategorieService _categorieService;
    //public CategorieViewComponent(ICategorieService categorieService)
    //{
    //    _categorieService = categorieService;
    //}
    //    public async Task<IViewComponentResult> InvokeAsync()
    //    {
    //    return await Task.FromResult((IViewComponentResult)View("CourseGroup", _categorieService.ListOfCategorie()));
    //    }

    //}
//[ViewComponent]
//    public class PriorityListViewComponent 
//    {


//        public async Task<IViewComponentResult> InvokeAsync(
//        int maxPriority, bool isDone)
//        {
//            var items = await GetItemsAsync(maxPriority, isDone);
//            return View(items);
//        }
//        private Task<List<TodoItem>> GetItemsAsync(int maxPriority, bool isDone)
//        {
//            return db.ToDo.Where(x => x.IsDone == isDone &&
//                                 x.Priority <= maxPriority).ToListAsync();
//        }
//    }
}
