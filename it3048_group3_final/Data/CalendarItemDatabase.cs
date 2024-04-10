using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using it3048_group3_final.Models;

namespace it3048_group3_final.Data
{
    public class CalendarItemDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public CalendarItemDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<CalendarItem>().Wait(); // Make sure the table is created synchronously
        }

        public Task<List<CalendarItem>> GetItemsAsync()
        {
            return _database.Table<CalendarItem>().ToListAsync();
        }

        public Task<int> SaveItemAsync(CalendarItem item)
        {
            if (item.ID != 0)
            {
                return _database.UpdateAsync(item);
            }
            else
            {
                return _database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(CalendarItem item)
        {
            return _database.DeleteAsync(item);
        }
    }
}

