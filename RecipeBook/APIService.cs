using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RecipeBook.Models;

namespace RecipeBook
{
    public static class APIService
    {
        static HttpClient httpClient;
        //static List<Recipe> Recipes;

        const string Url = "https://api.spoonacular.com/recipes/search/?query=pasta&apiKey=f639c84d524542179da437ba201a775e";

        public static async Task<List<Recipe>> GetRecipes()
        {
            //if (recipes != null) return recipes;
            if(httpClient == null)
            {
                httpClient = new HttpClient();
            }
            string rescontent = await httpClient.GetStringAsync(Url);


            Response response = JsonConvert.DeserializeObject<Response>(rescontent);

            foreach (Recipe r in response.Results)
            {

                string url = "https://spoonacular.com/recipeImages/" + r.Image;
                r.Image = url;
            }
            

            return response.Results;
            
            //var result = await httpClient.GetAsync("https://www.thewissen.io/pancakes.json");
            //var resultAsString = await result.Content.ReadAsStringAsync();
            //return JsonConvert.DeserializeObject<List<Recipe>>(resultAsString);
        }
    }
}
