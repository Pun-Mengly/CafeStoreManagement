
using CafeStoreManagement.Models;
using Radzen;
using System.Net.Http.Headers;


namespace CafeStoreWeb.Pages.Outlet
{
    public partial class CreateForm
    {
        public int StatusCode { get; set; }
        public CreateForm()
        {
        
        }
        public async Task OnSave(OutletModel model, NotificationMessage message)
        {
            string token = await sessionStorage.GetItemAsync<string>("Token");
            Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await Http.PostAsJsonAsync("api/Outlets", model);
            //show success alert 
            if ((int)response.StatusCode == 200)
            {
                NotificationService.Notify(message);
                Navigation.NavigateTo("outlet");
            }  
        }
    }
}
