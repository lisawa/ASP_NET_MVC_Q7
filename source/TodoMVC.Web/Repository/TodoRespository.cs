using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TodoMVC.Web.Repository
{
    public class TodoRespository
    {
        public List<TodoList> GetTodoLists()
        {
            List<TodoList> result = new List<TodoList>();

            using (var ctx = new Q7DBEntities())
            {
                result = ctx.TodoLists
                        .SqlQuery("Select * from todoList")
                        .ToList();
            }
        
            return result;
        }

        public List<TodoList> GetTodoListWithShow()
        {
            List<TodoList> result = new List<TodoList>();

            using (var ctx = new Q7DBEntities())
            {
                result = ctx.TodoLists
                        .SqlQuery("select * from TodoList where showstatus = '1'")
                        .ToList();
            }

            return result;
        }

        public void HideTodoByID (int id)
        {
            using (var ctx = new Q7DBEntities())
            {
                string sqlquery = "UPDATE TodoList SET ShowStatus = '0' Where ID = @id";
                
                var result = ctx.Database.ExecuteSqlCommand(sqlquery, new SqlParameter("@id", id));
            }
        }

        public void UpdateStatus (int id, bool status)
        {
            using (var ctx = new Q7DBEntities())
            {
                string sqlquery = "UPDATE TodoList SET Status = @status Where ID = @id";
                
                var paramId = (new SqlParameter("@id", id));
                var paramStatus = (new SqlParameter("@status", status));

                var result = ctx.Database.ExecuteSqlCommand(sqlquery, paramId, paramStatus);
            }
        }

        public void AddNewTopic(string topic)
        {
            using (var ctx = new Q7DBEntities())
            {
                string sqlquery = @"insert into TodoList
                                    (UserName, TodoTopic, Status, CreateDate, FinishTime, ShowStatus)
                                    VALUES('', @topic, 0, GETDATE(), null, 1); ";
                
                var paramTopic = (new SqlParameter("@topic", topic));

                var result = ctx.Database.ExecuteSqlCommand(sqlquery, paramTopic);
            }
        }
    }
}