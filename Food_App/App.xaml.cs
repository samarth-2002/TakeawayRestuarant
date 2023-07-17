using Food_App.Pages;

namespace Food_App;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        //MainPage = new NavigationPage(new Login());
        //var NavPage = new NavigationPage(new HomePage("Hello"));
        //MainPage = NavPage;

        //MainPage = new MainMenu();

        MainPage = new MainMenu();
    }
}
