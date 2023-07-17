using Food_App.Models;
using Food_App.Services;
using System.Xml;

namespace Food_App.Pages;

public partial class MainMenu : ContentPage
{

    readonly IProductCategoryRepository _category = new ProductCategoryService();
    readonly IProductTypeRepository _productcategory = new ProductTypeService();
    readonly IProductRepository _product = new ProductService();
    private string CategoryId = "1";
    private string selectedProductId = "10";



    public MainMenu()
	{
		InitializeComponent();
        CategoryInitialize();
        PickerInitialize();
	}

    private async void PickerInitialize()
    {
        List<ProductType> categoryInfo = await _productcategory.GetTypeCategoryList(CategoryId);
        itemtype.ItemsSource = categoryInfo.Select(manager => manager.ProductTypeName).ToList();
    }


    //public async void TabInitialize()
    //{

    //    List<ProductCategory> categoryInfo = await _category.GetCategoryList();

    //    var count = categoryInfo.Count;


    //    //List<List<string>> myList = new List<List<string>>();
    //    //myList.Add(new List<string> { "1", "Noodles" });
    //    //myList.Add(new List<string> { "2", "Rice" });
    //    //myList.Add(new List<string> { "3", "Chicken" });
    //    //myList.Add(new List<string> { "4", "Breads" });


    //    for (int i = 0; i < count; i++)
    //    {
    //        var categoryName = categoryInfo[i].ProductCategoryName;
    //        var newTab = new StackLayout()
    //        {

    //            Title = categoryName
    //        };

    //        TabControl.Children.Add(newTab);
    //    }

    //}


    public async Task CategoryInitialize()
    {
        List<ProductCategory> categoryInfo = await _category.GetCategoryList();

        StackLayout stackLayout = new StackLayout();

        foreach (ProductCategory category in categoryInfo)
        {
            var categoryName = category.productCategoryName;
            Button dynamicButton = new Button
            {
                Text = categoryName,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            // Add event handler for the button's click event
            dynamicButton.Clicked += (sender, e) => DynamicButton_Clicked(category.productCategoryID);

            // Add the button to the stack layout
            stackLayout.Children.Add(dynamicButton);
        }

        // Set the content of the page to the stack layout
        ((ContentPage)side).Content = stackLayout;
    }

    private async void DynamicButton_Clicked(string id)
    {
        CategoryId = id;
        List<ProductType> categoryInfo = await _productcategory.GetTypeCategoryList(id);
        itemtype.ItemsSource = categoryInfo.Select(manager => manager.ProductTypeName).ToList();

    }

    private async void itemtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<ProductType> categoryInfo = await _productcategory.GetTypeCategoryList(CategoryId);
        var selectedProductName = itemtype.SelectedItem as string;
        if (selectedProductName != null)
        {
            var selectedProduct = categoryInfo.FirstOrDefault(manager => manager.ProductTypeName == selectedProductName);
            if (selectedProduct != null)
            {
                selectedProductId = selectedProduct.ProductTypeID;
                // Use the selectedProductId as needed
            }
        }

        List<Product> productInfo = await _product.GetProductList(selectedProductId);
        foreach ( var product in productInfo ) 
        {
            var frame = new Frame
            {
                BackgroundColor = Colors.LightGray,
                Padding = new Thickness(10),
                Margin = new Thickness(0, 10, 0, 0) // Adjust margin as needed
            };

            var namelabel = new Label
            {
                Text = product.ProductName,
                FontSize = 16,
                TextColor = Colors.Black
            };
            var priceLabel = new Label
            {
                Text = $"Price: {product.Rate}",
                FontSize = 14,
                TextColor = Colors.DarkGray
            };

            var image = new Image
            {
                Source = product.ProductImage,
                Aspect = Aspect.AspectFit,
                HeightRequest = 70 // Adjust image height as needed
            };

            var stackLayout = new StackLayout
            {
                Spacing = 5,
                Orientation = StackOrientation.Vertical,
                Children = { namelabel, priceLabel, image }
            };

            frame.Content = stackLayout;

            // Add the Frame to the StackLayout within the ScrollView
            detail.Children.Add(frame);


        }

    }
}