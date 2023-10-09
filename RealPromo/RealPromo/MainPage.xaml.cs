using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RealPromo
{
    public partial class MainPage : ContentPage
    {
        private readonly ObservableCollection<Promocao> lista = new ObservableCollection<Promocao>();

        public MainPage()
        {
            InitializeComponent();
            GetPromocoes();
            ListViewPromocao.ItemsSource = lista;

            Device.StartTimer(TimeSpan.FromSeconds(10), () =>
            {
                lista.Add(new Promocao() { Empresa = "Carrefour", Chamada = $"Celulares em promoção - {DateTime.Now}", Regras = "10 unidades", EnderecoURL = "https://www.carrefrour.com.br" });
                return true;
            });
        }

        private void GetPromocoes()
        {
            lista.Add(new Promocao() { Empresa = "Carrefour", Chamada = "TVs em promoção", Regras = "20 unidades", EnderecoURL = "https://www.carrefrour.com.br" });
            lista.Add(new Promocao() { Empresa = "Carrefour", Chamada = "Celulares em promoção", Regras = "10 unidades", EnderecoURL = "https://www.carrefrour.com.br" });
        }
    }
}