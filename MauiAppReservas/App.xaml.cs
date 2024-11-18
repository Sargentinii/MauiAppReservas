using Microsoft.Maui.Media;

namespace MauiAppReservas
{
    public partial class App : Application
    {
        public class Local
        {
            public string Descricao { get; set; }
            public double ValorDiaria { get; set; }
            public int CapMax { get; set; }
            public Local LocalEscolhido { get; set; }  // Propriedade para armazenar o local selecionado
            public int QntPessoas { get; set; }
            public DateTime DataInicio { get; set; }
            public DateTime DataTermino { get; set; }
        }

        // Lista de locais que será usada no Picker
        public List<Local> lista_locais = new List<Local>
        {
            new Local
            {
                Descricao = "Galpão",
                ValorDiaria = 2000,
                CapMax = 200
            },
            new Local
            {
                Descricao = "Salão",
                ValorDiaria = 1000,
                CapMax = 100
            },
        };

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new Pages.Reserva());
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = base.CreateWindow(activationState);
            window.Width = 400;
            window.Height = 600;
            return window;
        }
    }
}