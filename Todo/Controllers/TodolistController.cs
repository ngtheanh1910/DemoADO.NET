using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Todo.Repository;
using Todo.Models;

namespace Todo.Controllers
{
    public class TodolistController : Controller
    {
        // GET: Todolist/Details/5
        public ActionResult Show()
        {
            TodoRepository Todo = new TodoRepository();
            ModelState.Clear();
            return View(Todo.GetAllTodo());
        }

        public ActionResult AddTodo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTodo(Todolist todo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TodoRepository repo = new TodoRepository();
                    if (repo.AddTodo(todo))
                    {
                        ViewBag.Message = "Add successfully";
                    }
                }
                return RedirectToAction("Show");
            }
            catch
            {
                return View();
            }
        }
    
        public ActionResult UpdateTodo(int id)
        {
            TodoRepository repo = new TodoRepository();
            
            return View(repo.GetAllTodo().Find(t => t.id == id));
        }
        
        [HttpPost]
        public ActionResult UpdateTodo(int id, Todolist todo)
        {
            try
            {
                TodoRepository repo = new TodoRepository();
                repo.UpdateTodo(todo);
                return RedirectToAction("Show");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult DeleteTodo(int id)
        {
            try
            {
                TodoRepository repo = new TodoRepository();
                if (repo.DeleteTodo(id))
                {
                    ViewBag.msgDelete = "Deleted successfully";
                }
                return RedirectToAction("Show");
            }
            catch
            {
                return View();
            }
        }
    }//end class
}
