using MyToDoListApp.Tables;

namespace MyToDoListApp.TablesService
{
    public static class TableStatusesService
    {
        public static List<TableStatuses> Get()
        {
            var context = new DBService();
            List<TableStatuses> statuses = context.Statuses.ToList();
            return statuses;
        }
    }
}
