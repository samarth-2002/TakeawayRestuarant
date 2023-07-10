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





		
	}
}