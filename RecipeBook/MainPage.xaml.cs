using RecipeBook.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RecipeBook
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
           
        }    
     protected override async void OnAppearing()
        {
            BindingContext = await APIService.GetRecipes();
            
        }
        private async void Delete_AllIngredients(object sender, EventArgs e)
        {
            await ConnectionFactory.Delete_AllIngredients();
        }
        private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = e.CurrentSelection.FirstOrDefault();

            if (selectedItem != null)
            {
                await Navigation.PushAsync(new DetailPage(selectedItem as Recipe));
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
