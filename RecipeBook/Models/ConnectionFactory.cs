using PCLExt.FileStorage.Folders;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeBook.Models
{
    public class ConnectionFactory
    {
        public SQLiteConnection connection;
        public ConnectionFactory()
        {
            var folder = new LocalRootFolder();
            var file = folder.CreateFile("recipeBook", PCLExt.FileStorage.CreationCollisionOption.OpenIfExists);
            connection = new SQLiteConnection(file.Path);
            connection.CreateTable<RecipeModel>();
        }
        public void insert<T>(T model)
        {
            connection.Insert(model);
        }
        public void update<T>(T model)
        {
            connection.Update(model);
        }
        public void dnsert<T>(T model)
        {
            connection.Delete(model);
        }
    }
}
