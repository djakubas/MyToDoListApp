using MyToDoListApp.Tables;

namespace MyToDoListApp.TablesService
{
    public static class TableStatusesService
    {
        public static List<TableStatuses> Get(DBService context)
        {
            List<TableStatuses> statuses = context.Statuses.ToList();
            return statuses;
        }
    }
}
