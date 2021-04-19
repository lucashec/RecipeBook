using RecipeBook.Models;
using System;
using System.Collections.Generic;
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
        public ConnectionFactory connection;
        public RegisterPage()
        {
            InitializeComponent();
            connection = new ConnectionFactory(); 
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

        private void create_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtTitle.Text))
                {
                    DisplayAlert("Error", "Insira o titulo", "OK");
                }
                if (string.IsNullOrEmpty(txtDesc.Text))
                {
                    DisplayAlert("Error", "Insira o descrição", "OK");
                }
                if (string.IsNullOrEmpty(txtIng1.Text))
                {
                    DisplayAlert("Error", "Insira o ingrediente 1", "OK");
                }
                if (string.IsNullOrEmpty(txtIng2.Text))
                {
                    DisplayAlert("Error", "Insira o ingrediente 2", "OK");
                }
                if (string.IsNullOrEmpty(txtIng3.Text))
                {
                    DisplayAlert("Error", "Insira o ingrediente 3", "OK");
                }
                RecipeModel recipe = new RecipeModel()
                {
                    title = txtTitle.Text,
                    description = txtDesc.Text,
                    ing1 = txtIng1.Text,
                    ing2 = txtIng2.Text,
                    ing3 = txtIng3.Text,
                };
                connection.insert(recipe);
                DisplayAlert("Success", "Inserido com sucesso", "OK");
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", ex.Message , "OK");
            }
        }
    }
}