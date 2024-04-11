using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using it3048_group3_final.Models;
using System;

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

        public async Task<int> DeleteItemAsync(CalendarItem item)
        {
            try
            {
                Console.WriteLine("Deleting item: " + item.ID);
                int rowsDeleted = await _database.DeleteAsync(item);
                Console.WriteLine("Rows deleted: " + rowsDeleted);
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting item: " + ex.Message);
                return 0; // Return 0 to indicate failure
            }
        }

    }
}

