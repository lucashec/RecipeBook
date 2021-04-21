using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeBook.Models
{
    public partial class Recipe
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("origin")]
        public string Origin { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("imageUrl")]
        public Uri ImageUrl { get; set; }

        [JsonProperty("ingredients", NullValueHandling = NullValueHandling.Ignore)]
        public Ingredient[] Ingredients { get; set; }

        [JsonProperty("steps", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Steps { get; set; }
    }

    public partial class Ingredient
    {
        [JsonProperty("id"), PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [JsonProperty("uom")]
        public string Uom { get; set; }

        [JsonProperty("ingredient")]
        public string Name { get; set; }
        [JsonProperty("recipe")]
        public int RecipeId { get; set; }
    }


}
