using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTSpbkk.Models;

namespace UTSpbkk.Services
{
    public class KontakService : IKontakService 
    {
        private SQLiteAsyncConnection _dbConnection;

        private async Task SetUpDb()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Kontak.db3");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<KontakModel>();

            }

        }
        public async Task<int> AddKontak(KontakModel kontakModel)
        {
            await SetUpDb();
            return await _dbConnection.InsertAsync(kontakModel);
        }

        public async Task<int> DeleteKontak(KontakModel kontakModel)
        {
            await SetUpDb();
            return await _dbConnection.DeleteAsync(kontakModel);
        }

        public async Task<List<KontakModel>> GetKontakList()
        {
            await SetUpDb();
            var kontakList = await _dbConnection.Table<KontakModel>().ToListAsync();
            return kontakList;
        }

        public async Task<int> UpdateKontak(KontakModel kontakModel)
        {
            await SetUpDb();
            return await _dbConnection.UpdateAsync(kontakModel);
        }
    }
}
