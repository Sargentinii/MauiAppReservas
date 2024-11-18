namespace MauiAppReservas.Pages
{
    public partial class Reserva : ContentPage
    {
        App PropriedadesApp;

        public Reserva()
        {
            InitializeComponent();

            PropriedadesApp = (App)Application.Current;
            pck_local.ItemsSource = PropriedadesApp.lista_locais;

            if (dt_ini != null)
            {
                dt_ini.MinimumDate = DateTime.Now;
                dt_ini.MaximumDate = DateTime.Now.AddMonths(3);

                dt_fim.MinimumDate = DateTime.Now;
                dt_fim.MaximumDate = dt_ini.Date.AddMonths(6);
            }
        }

        private void dt_ini_DateSelected(object sender, DateChangedEventArgs e)
        {
            DateTime data_selecionada_inicio = ((DatePicker)sender).Date;
            dt_fim.MaximumDate = data_selecionada_inicio.AddMonths(6);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                var localSelecionado = (App.Local)pck_local.SelectedItem;
                var h = new App.Local
                {
                    LocalEscolhido = localSelecionado,
                    QntPessoas = Convert.ToInt32(st_Npart.Value),
                    DataInicio = dt_ini.Date,
                    DataTermino = dt_fim.Date,
                };

                await Navigation.PushAsync(new Resumo
                {
                    BindingContext = h
                });
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");
            }
        }
    }
}
