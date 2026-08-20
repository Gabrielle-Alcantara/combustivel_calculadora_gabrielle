using Microsoft.Maui.Graphics.Text;

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

            
            
            

            //Consumo em km/L 
            double distancia = kmfinal - kminicial;
            double consumo = distancia / litrosabastecidos;

            if (kminicial > kmfinal)
            {
                DisplayAlert("Erro", "A quilometragem inicial deve ser menor que a final", "Ok");
                return;
            }

            //Km rodado com gasolina
            double custogasolina = precogasolina / consumo;

            //Km rodado com etanol
            double custoetanol = precoetanol / consumo;



            //Regra dos 70%
            double indice = precoetanol / precogasolina;
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
                
                Resultlabel.Text = $"Consumo médio: {consumo} km/L \n \n Distância percorrida: {distancia} Km \n \nCusto por Km rodado abastecendo com etanol: R$ {custoetanol} " +
                $"\n \nCusto por Km rodado abastecendo com gasolina: R$ {custogasolina}\n \nO combustível mais vantajoso é o Etanol \n \n Regra dos 70%: {indice70}";
            }
            else
            {
                Resultlabel.Text = $"Consumo médio em km/L: {consumo} \n \n Distância percorrida: {distancia} Km \n \nCusto por Km rodado por gasolina: {custogasolina} " +
                $" \n \nCusto por Km rodado por álcool: {custoetanol} \n \nO combustível mais vantajoso é a gasolina \n \n Regra dos 70%: {indice70}";
            }

        
    }

       
    }

}
