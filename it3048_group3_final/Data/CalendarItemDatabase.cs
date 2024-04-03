using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using it3048_group3_final.Models;


namespace it3048_group3_final.Data
{
    internal class CalendarItemDatabase
    {
        public readonly SQLiteAsyncConnection _database;
        public CalendarItemDatabase(String dbpath)
        {
            _database = new SQLiteAsyncConnection(dbpath);
            _database.CreateTableAsync<CalendarItem>();
        }

        public Task<List<CalendarItem>> GetItemsAsync()
        {
            return _database.Table<CalendarItem>().ToListAsync();
        }


        //idk if we need this
        public Task<List<CalendarItem>> GetItemsNotDoneAsync()
        {
            return _database.QueryAsync<CalendarItem>("SELECT * FROM [CalendarItem] WHERE [Done] = 0");
        }

        public Task<CalendarItem> GetItemAsync(int id)
        {
            return _database.Table<CalendarItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemsAsync(CalendarItem item) 
        { 
            if (item.ID !=0)
            {
                return _database.UpdateAsync(item);
            }
            else 
            {
                return _database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemsAsync(CalendarItem item)
        {
            return _database.DeleteAsync(item);
        }


    }
}
