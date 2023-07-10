using Food_App.Pages;

namespace Food_App;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		//MainPage = new NavigationPage(new Login());

        MainPage = new HomePage("Hello");
    }
}
