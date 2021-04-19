using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace RecipeBook.Models
{
    class RecipeModel
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string ing1 { get; set; }
        public string ing2 { get; set; }
        public string ing3 { get; set; }
        public string image { get; set; }
    }
}
