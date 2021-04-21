using RecipeBook.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RecipeBook
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdatePage : ContentPage
    {
        static RecipeModel recipeModel;
        public ObservableCollection<Ingredient> ingredients;
        public UpdatePage(RecipeModel recipe)
        {
            InitializeComponent();
            recipeModel = recipe;
            txtTitle.Text = recipe.Title;
            txtDesc.Text = recipe.Description;
        }

        protected override async void OnAppearing()
        {
            List<Ingredient> ings = await ConnectionFactory.GetIngredientsById(recipeModel.Id);

            ingredients = new ObservableCollection<Ingredient>(ings);

            lvIngredients.ItemsSource = ingredients;
        }

        private async void addFile_Clicked(object sender, EventArgs e)
        {
            try
            {
                var file = await FilePicker.PickAsync();

                if (file == null) return;
                string path = file.FileName;
            }
            catch (Exception)
            {
            }
        }

        private async void add_ingredient(object sender, EventArgs e)
        {

            Ingredient ingredient = new Ingredient()
            {
                Name = ingName.Text,
                Uom = ingUom.Text
            };

            if (ingredients == null)
            {

                ingredients = new ObservableCollection<Ingredient>()
                {
                    ingredient
                };
            }
            else
            {

                ingredients.Add(ingredient);

            }

            ingredient.RecipeId = recipeModel.Id;
            await ConnectionFactory.InsertIngredient(ingredient);

            lvIngredients.ItemsSource = ingredients;

        }
        private async void Delete_Ingredient(object sender, EventArgs e)
        {
            var ingName = (Button)sender;
            
            Ingredient ingredient = (from ing in ingredients where ing.Name == ingName.CommandParameter.ToString() select ing).FirstOrDefault();
            
            try
            {

                ingredients.Remove(ingredient);
                ConnectionFactory.Delete_Ingredient(ingredient);
            }
            catch
            {
                await DisplayAlert("Error", "Um Erro Ocorreu", "OK");
            }
        }

        private async void edited_Clicked(object sender, EventArgs e)
        {

            try
            {
                if (string.IsNullOrEmpty(txtTitle.Text))
                {
                    await DisplayAlert("Error", "Insira o titulo", "OK");
                }
                if (string.IsNullOrEmpty(txtDesc.Text))
                {
                    await DisplayAlert("Error", "Insira o descrição", "OK");
                }

                RecipeModel recipe = new RecipeModel()
                {
                    Id = recipeModel.Id,
                    Title = txtTitle.Text,
                    Description = txtDesc.Text,
                };


                await ConnectionFactory.Update_RecipeModel(recipe);


                await DisplayAlert("Success", "Atualizado com sucesso", "OK");

                await Navigation.PushAsync(new DetailPageCustom(recipe));

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }

        }
    }
}