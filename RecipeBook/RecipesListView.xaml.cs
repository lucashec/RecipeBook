using System;
using System.Collections.Generic;
using System.Linq;
using RecipeBook.Models;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RecipeBook
{
    public partial class RecipesListView : ContentPage
    {
        public RecipesListView()
        {
            InitializeComponent();

        }
        protected override async void OnAppearing()
        {

            BindingContext = await ConnectionFactory.GetRecipes();
        }
        private async void Delete_AllIngredients(object sender, EventArgs e)
        {
            await ConnectionFactory.Delete_AllIngredients();
        }
        private async void Go_Home(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
        private async void Delete_AllRecipeModel(object sender, EventArgs e)
        {

            await ConnectionFactory.Delete_AllRecipeModel();

        }

        private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = e.CurrentSelection.FirstOrDefault();

            if (selectedItem != null)
            {
                await Navigation.PushAsync(new DetailPageCustom(selectedItem as RecipeModel));
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }
        private async void Recipes_ListView(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RecipesListView());
        }
    }
}
