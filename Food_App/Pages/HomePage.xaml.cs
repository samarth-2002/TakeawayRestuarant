using Microsoft.Maui.Controls;

namespace Food_App.Pages;

public partial class HomePage : ContentPage
{

	public string username;
	public HomePage(string username)
	{
		InitializeComponent();
		this.username = username;
		label1.Text = username;
        NavigationPage.SetHasNavigationBar(this, false);






    }

    private void Button_Clicked(object sender, EventArgs e)
    {

        Navigation.PushAsync(new OrderDashboard());

    }
}