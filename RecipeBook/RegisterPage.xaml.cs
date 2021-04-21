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
    public partial class RegisterPage : ContentPage
    {
        public ObservableCollection<Ingredient> ingredients;
        public RegisterPage()
        {
            InitializeComponent();
            
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

        private void add_ingredient(object sender, EventArgs e)
        {

            if (ingredients == null)
            {
                Console.WriteLine("null");
                ingredients = new ObservableCollection<Ingredient>()
                {
                    new Ingredient()
                    {
                        Name = ingName.Text,
                        Uom = ingUom.Text
                    }
                };
            } else {
                Console.WriteLine("not null");

                ingredients.Add(new Ingredient()
                {
                    Name = ingName.Text,
                    Uom = ingUom.Text
                });
            
            }
            lvIngredients.ItemsSource = ingredients;

        }

        private async void create_Clicked(object sender, EventArgs e)
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
                    Title = txtTitle.Text,
                    Description = txtDesc.Text,    
                };
                
                
                await ConnectionFactory.InsertRecipe(recipe);
                
                foreach(Ingredient ingredient in ingredients)
                {
                    ingredient.RecipeId = recipe.Id;
                    await ConnectionFactory.InsertIngredient(ingredient);
                }
                


                await DisplayAlert("Success", "Inserido com sucesso", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message , "OK");
            }
            
        }
    }
}