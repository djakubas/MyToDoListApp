using Microsoft.EntityFrameworkCore;
using MyToDoListApp.Tables;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;


namespace MyToDoListApp.TablesService
{
    public static class TableTaskService
    {

        public static List<TableTask> Get(DBService context)
        {
            //var context = new DBService();
            List<TableTask> tasks = context.Tasks.ToList();
            return tasks;

            //testing api
            //List<TableTask> tasks = new List<TableTask>();
            //var t = new TableTask { Title = "123", Status = "ToDo", TaskId = 1 };
            //tasks.Add(t);
            //return tasks;
        }
        public static TableTask? Get(int id, DBService context)
        {
            var TaskByID = context.Tasks.Where(s => s.TaskId == id);
            return TaskByID.FirstOrDefault();

        }

        
        public static bool Add(TableTask t, DBService context)
        {
            try
            {
                context.Tasks.Add(t);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
        public static bool Update(TableTask t, DBService context)
        {    
            try
            {
                context.Tasks.Update(t);
                //context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
        public static bool Delete(TableTask task, DBService context)
        {
            try
            {
                context.Tasks.Remove(task);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.ToString());
                return false;
            }


        }

    }
}
