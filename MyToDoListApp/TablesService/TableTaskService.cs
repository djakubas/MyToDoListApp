using Microsoft.EntityFrameworkCore;
using MyToDoListApp.Tables;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDoListApp.TablesService
{
    public static class TableTaskService
    {
        public static TableTask? Get(int id)
        {
            var context = new DBService();
            var TaskByID = context.Tasks.Where(s => s.TaskId == id);
            return TaskByID.FirstOrDefault();
        }

        public static List<TableTask> Get()
        {
            var context = new DBService();
            List<TableTask> tasks = context.Tasks.ToList();
            return tasks;
        }
        public static bool Add(TableTask t)
        {
            var context = new DBService();
            try
            {
                context.Add(t);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
        public static bool Update(TableTask t)
        {
            var context = new DBService();
            
            try
            {
                context.Tasks.Update(t);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
        public static bool Delete(TableTask task)
        {
            var context = new DBService();
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
