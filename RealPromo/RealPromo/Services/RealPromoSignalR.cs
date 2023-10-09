using Microsoft.AspNetCore.SignalR.Client;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace RealPromo.Services
{
    internal class RealPromoSignalR
    {
        public RealPromoSignalR(ObservableCollection<Promocao> lista)
        {
            Task.Run(async () => await ConfigurarSignalRAsync(lista));
        }

        private async Task ConfigurarSignalRAsync(ObservableCollection<Promocao> lista)
        {
            var connection = new HubConnectionBuilder().WithUrl("https://realpromoapiweb2023.azurewebsites.net/PromoHub").Build();

            connection.On<Promocao>("ReceberPromocao", (promocao) =>
            {
                Xamarin.Forms.Device.InvokeOnMainThreadAsync(() =>
                {
                    lista.Add(promocao);
                });
            });

            await connection.StartAsync();
        }
    }
}