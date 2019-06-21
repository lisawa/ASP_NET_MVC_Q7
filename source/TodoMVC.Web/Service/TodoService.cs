using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TodoMVC.Web.Models;
using TodoMVC.Web.Repository;

namespace TodoMVC.Web.Service
{
    public class TodoService
    {
        TodoRespository _todorespository;

        public TodoService() {
            _todorespository = new TodoRespository();
        }

        public TodoListServiceModel GetAll()
        {
            var result = new TodoListServiceModel()
            {
                TodoItemList = _todorespository.GetTodoLists()
            };
            return result;
        }

        public TodoListServiceModel GetShow()
        {
            var result = new TodoListServiceModel()
            {
                TodoItemList = _todorespository.GetTodoListWithShow()
            };
            return result;
        }

        public void HideRecord(int id)
        {
            _todorespository.HideTodoByID(id);
        }

        public void UpdateStatus(int id, bool status){
            _todorespository.UpdateStatus(id, status);
        }

        public void AddNewTodo(string topic)
        {
            _todorespository.AddNewTopic(topic);
        }
    }
}