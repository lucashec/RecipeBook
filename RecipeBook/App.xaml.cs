using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RecipeBook
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Sharpnado.MaterialFrame.Initializer.Initialize(true, true);
            MainPage = new NavigationPage(new MainPage());
        }
        
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
