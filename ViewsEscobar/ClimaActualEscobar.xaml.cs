using EscobarAPILocal.ModelEscobar;
using Microsoft.Maui.Controls;
using System.Text.Json.Serialization;

namespace EscobarAPILocal.ViewsEscobar;

public partial class ClimaActualEscobar : ContentPage
{
	public ClimaActualEscobar()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)

    {
        string latitud = lat.Text;
        string longitud = lon.Text;

        if (Connectivity.NetworkAccess==NetworkAccess.Internet)
        {

            using (var client = new HttpClient())
            {
                string url = $"https://api.openweathermap.org/data/2.5/weather?lat="+latitud+"&lon="+longitud+"appid=e8991159063d8c32d55663f7c92e3865";

                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var clima = JsonConverter.DeserializeObject<Rootobject>(json);

                    weatherLabel.Text = clima.weather[0].main;
                    cityLabel.Text = clima.city[0].main;
                    countryLabel.Text = clima.country[0].main;

                }

            }
        }
    }
}