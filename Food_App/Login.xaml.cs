using Food_App.Models;
using Food_App.Pages;
using Food_App.Services;

namespace Food_App;

public partial class Login : ContentPage
{

	readonly ILoginRepository _loginRepository = new LoginService();
	readonly IManagerService _managerService = new ManagerService();

   
    public Login()
	{
		InitializeComponent();
		PickerInitialize();
    }

	private async void Login_Clicked(object sender, EventArgs e)
	{
		string username = operators.SelectedItem.ToString();
		string password = txtPassword.Text;
		if (username ==null || password ==null)
		{
			await DisplayAlert("Warning", "Please Input Username & Password", "OK");
			return;
		}

		UserInfo userInfo = await _loginRepository.Login(username, password);
		if(userInfo != null)
		{
			await Navigation.PushAsync(new HomePage(username));
		}
		else
		{
            await DisplayAlert("Warning", "Password is not correct", "OK");
        }

    }

	public async void PickerInitialize()
	{

		List<ManagerInfo> managerInfo = await _managerService.GetManagerList();
		operators.ItemsSource = managerInfo;

    }

   
}