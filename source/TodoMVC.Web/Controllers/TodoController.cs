using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoMVC.Web.Models;
using TodoMVC.Web.Service;

namespace TodoMVC.Web.Controllers
{
    public class TodoController : Controller
    {
        TodoService _todoService;

        public TodoController()
        {
            _todoService = new TodoService();
        }

        // GET: Todo
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult TodoList()
        {
            return View();
        }

        public ActionResult GetList()
        {
            TodoListServiceModel serviceVM = _todoService.GetShow();

            return Content(Newtonsoft.Json.JsonConvert.SerializeObject(serviceVM));
        }

        public ActionResult UpdateStatus(int id, bool status)
        {
            _todoService.UpdateStatus(id, status);

            TodoListServiceModel serviceVM = _todoService.GetShow();

            return Content(Newtonsoft.Json.JsonConvert.SerializeObject(serviceVM));
        }

        public ActionResult RemoveShow(int id)
        {
            _todoService.HideRecord(id);

            TodoListServiceModel serviceVM = _todoService.GetShow();

            return Content(Newtonsoft.Json.JsonConvert.SerializeObject(serviceVM));
        }

        public ActionResult AddNewTopic(string topic)
        {
            _todoService.AddNewTodo(topic);

            TodoListServiceModel serviceVM = _todoService.GetShow();

            return Content(Newtonsoft.Json.JsonConvert.SerializeObject(serviceVM));
        }

        public ActionResult HideAllFinish()
        {
            _todoService.HideAllFinish();

            TodoListServiceModel serviceVM = _todoService.GetShow();

            return Content(Newtonsoft.Json.JsonConvert.SerializeObject(serviceVM));
        }
        
    }
}