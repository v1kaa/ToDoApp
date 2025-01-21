using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication8.Data;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    public class ToDoAppController : Controller
    {
        public List<ToDoModel> trying;
        private readonly ApplicationDBContext _db;
        public ToDoAppController(ApplicationDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<ToDoModel> ToDoModelList = _db.ToDoApp.ToList();
            return View(ToDoModelList);
        }

        [HttpPost]
        public IActionResult SaveChanges(List<ToDoModel> tasks)
        {
            if (tasks != null)
            {
                foreach (var task in tasks)
                {
                    var existingTask = _db.ToDoApp.Find(task.Id);
                    if (existingTask != null)
                    {
                        existingTask.IsCompleted = task.IsCompleted;
                    }
                }
                _db.SaveChanges();
            }
            return RedirectToAction("Index"); // Redirect back to the ToDo list
        }

        [HttpPost]
        public IActionResult DeleteTask(int id)
        {
            var task = _db.ToDoApp.Find(id);
            if (task != null)
            {
                _db.ToDoApp.Remove(task);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AddNewTask(string taskName, bool isCompleted = false)
        {
            if (!string.IsNullOrEmpty(taskName))
            {
                var newTask = new ToDoModel
                {
                    Task = taskName,
                    IsCompleted = isCompleted 
                };
                _db.ToDoApp.Add(newTask);
                _db.SaveChanges();
            }
            return RedirectToAction("Index"); 
        }

    }
}
