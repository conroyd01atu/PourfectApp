using SQLite;
using PourfectApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PourfectApp.Services
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseService()
        {
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "pourfect.db3");
            _database = new SQLiteAsyncConnection(dbPath);

            // Create tables
            _database.CreateTableAsync<Brew>().Wait();
            _database.CreateTableAsync<Recipe>().Wait();
        }

        // Brew methods
        public Task<List<Brew>> GetBrewsAsync()
        {
            return _database.Table<Brew>().ToListAsync();
        }

        public Task<List<Brew>> GetBrewsByUserAsync(string username)
        {
            return _database.Table<Brew>()
                .Where(b => b.Username == username)
                .OrderByDescending(b => b.BrewDate)
                .ToListAsync();
        }

        public Task<Brew> GetBrewAsync(int id)
        {
            return _database.GetAsync<Brew>(id);
        }

        public Task<int> SaveBrewAsync(Brew brew)
        {
            if (brew.Id != 0)
            {
                return _database.UpdateAsync(brew);
            }
            else
            {
                return _database.InsertAsync(brew);
            }
        }

        public Task<int> DeleteBrewAsync(Brew brew)
        {
            return _database.DeleteAsync(brew);
        }

        // Recipe methods
        public Task<List<Recipe>> GetRecipesAsync()
        {
            return _database.Table<Recipe>()
                .OrderByDescending(r => r.IsFavorite)
                .ThenBy(r => r.Name)
                .ToListAsync();
        }

        public Task<Recipe> GetRecipeAsync(int id)
        {
            return _database.GetAsync<Recipe>(id);
        }

        public Task<int> SaveRecipeAsync(Recipe recipe)
        {
            if (recipe.Id != 0)
            {
                return _database.UpdateAsync(recipe);
            }
            else
            {
                return _database.InsertAsync(recipe);
            }
        }

        public Task<int> DeleteRecipeAsync(Recipe recipe)
        {
            return _database.DeleteAsync(recipe);
        }
    }
}