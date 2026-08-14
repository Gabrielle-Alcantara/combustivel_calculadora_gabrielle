namespace combustivel_calculadora_gabrielle
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterCalc(object sender, EventArgs e)
        {
            if (!double.TryParse(entrykminicial.Text, out double kminicial) ||
        !double.TryParse(entrykmfinal.Text, out double kmfinal) ||
        !double.TryParse(entrylitrosabastecidos.Text, out double litrosabastecidos) ||
        !double.TryParse(entryetanol.Text, out double precoetanol) ||
        !double.TryParse(entrygasolina.Text, out double precogasolina))

            {
                DisplayAlert("Erro", "Preencha todos os campos", "Ok");
                return;
            }

            double distancia = 0;
            double consumo = 0;
            double kmetanol = 0;
            double kmgasolina = 0;
            double consumogasolina = 0;
            double consumoetanol = 0;
            double indice = 0;

            //Consumo em km/L 
            distancia = kmfinal - kminicial;
            consumo = distancia / litrosabastecidos;

            //Km rodado com gasolina
            double custogasolina = precogasolina / consumogasolina;

            //Km rodado com etanol
            double custoetanol = precoetanol / consumoetanol;



            //Regra dos 70%
            indice = precoetanol / precogasolina;
            string indice70;
            if (indice <= 0.70)
            {
                indice70 = "Nesse cenário compensa abastecer com Etanol.";
            }
            else
            {
                indice70 = "Nesse cenário compensa abastecer com gasolina.";
            }

            //qual combustivel compensa mais
            if (custoetanol < custogasolina)
            {
                Resultlabel.Text = $"Consumo médio: {consumo} km/L \n Distância percorrida: {distancia} Km \nCusto por Km rodado abastecendo com etanol: R$ {custoetanol} " +
                $"\nCusto por Km rodado abastecendo com gasolina: R$ {custogasolina} \nO combuntível mais vantajoso é o Etanol \n Regra dos 70%: {indice} \n {indice70}";
            }
            else
            {
                Resultlabel.Text = $"Consumo médio em km/L: {consumo}\n Distância percorrida: {distancia} Km \nCusto por Km rodado por gasoolina: {kmgasolina} " +
                $"\nCusto por Km rodado por álcool: {kmetanol} \nO combuntível mais vantajoso é a gasolina \n Regra dos 70%: {indice} \n {indice70}";
            }

        
    }

       
    }

}
