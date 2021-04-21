using RecipeBook.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RecipeBook
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPageCustom : ContentPage
    {
        public static RecipeModel recipe;
        public ObservableCollection<Ingredient> ingredients;
        public DetailPageCustom(RecipeModel selectItem)
        {

            InitializeComponent();

            recipe = selectItem;
            BindingContext = selectItem;

        }

        private async void Delete_RecipeModel(object sender, EventArgs e)
        {

            await ConnectionFactory.Delete_RecipeModel(recipe);

            foreach(Ingredient ingredient in ingredients)
            {
                ConnectionFactory.Delete_Ingredient(ingredient);
            }

            await Navigation.PushAsync(new RecipesListView());


        }
        private async void Update_RecipeModel(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new UpdatePage(recipe));

        }
        protected override async void OnAppearing()

        {

            List<Ingredient> ings = await ConnectionFactory.GetIngredientsById(recipe.Id);

            
            if (ings != null)
            {

                ingredients = new ObservableCollection<Ingredient>(ings);

                slIngredients.ItemsSource = ingredients;
            
            }
            
        }
    }
}