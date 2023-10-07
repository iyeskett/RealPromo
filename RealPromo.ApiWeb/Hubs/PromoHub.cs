using Microsoft.AspNetCore.SignalR;
using RealPromo.ApiWeb.Models;

namespace RealPromo.ApiWeb.Hubs
{
    // RPC
    public class PromoHub : Hub
    {
        public async Task CadastrarPromocao(Promocao promocao)
        {
            await Clients.Others.SendAsync("ReceberPromocao", promocao).ConfigureAwait(false); // Notificar outros usuários sobre a promoção
            await Clients.Caller.SendAsync("CadastroRealizado"); // Notificar Caller -> "Cadastro realizado com sucesso."
        }
    }
}