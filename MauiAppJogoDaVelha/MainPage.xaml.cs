namespace MauiAppJogoDaVelha
{
    public partial class MainPage : ContentPage
    {
        string vez = "X";
        bool seVencedor = false; //verificação se houve vencedor para a mensagem de empate
        int jogadas = 0; //Contador de jogadas para Verificar empate e não exibir a mensagem de empate antes do fim do jogo

        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.IsEnabled = false;

            jogadas++; // Contador de jogadas

            if (vez == "X")
            {
                btn.Text = "X";
                btn.TextColor = Colors.Red; // X em vermelho
                vez = "O";
            }
            else
            {
                btn.Text = "O";
                btn.TextColor = Colors.Blue; // O em azul
                vez = "X";
            }

            seVencedor = false;

            // Verifica o Vencedor
            VerificaVencedor("X");
            VerificaVencedor("O");

            // Verifica empate após 9 jogadas e se ninguém venceu
            if (!seVencedor && jogadas == 9)
            {
                DisplayAlert("FIM DE JOGO!", "Empate! Nenhum Jogador ganhou!", "Jogar novamente");
                Zerar();
            }
        }

        void VerificaVencedor(string jogador)
        {
            // Verifica as linhas, colunas e diagonais
            if ( //linhas
                (btn10.Text == jogador && btn11.Text == jogador && btn12.Text == jogador) ||
                (btn20.Text == jogador && btn21.Text == jogador && btn22.Text == jogador) ||
                (btn30.Text == jogador && btn31.Text == jogador && btn32.Text == jogador) ||

                //colunas
                (btn10.Text == jogador && btn20.Text == jogador && btn30.Text == jogador) ||
                (btn11.Text == jogador && btn21.Text == jogador && btn31.Text == jogador) ||
                (btn12.Text == jogador && btn22.Text == jogador && btn32.Text == jogador) ||

                //diagonais
                (btn10.Text == jogador && btn21.Text == jogador && btn32.Text == jogador) ||
                (btn12.Text == jogador && btn21.Text == jogador && btn30.Text == jogador)
               )
            {
                seVencedor = true;
                DisplayAlert("FIM DE JOGO!", $"O {jogador} ganhou!", "Jogar novamente");
                Zerar();
            }
        }

        void Zerar()
        {
            btn10.Text = "";
            btn11.Text = "";
            btn12.Text = "";

            btn20.Text = "";
            btn21.Text = "";
            btn22.Text = "";

            btn30.Text = "";
            btn31.Text = "";
            btn32.Text = "";

            btn10.IsEnabled = true;
            btn11.IsEnabled = true;
            btn12.IsEnabled = true;

            btn20.IsEnabled = true;
            btn21.IsEnabled = true;
            btn22.IsEnabled = true;

            btn30.IsEnabled = true;
            btn31.IsEnabled = true;
            btn32.IsEnabled = true;

            vez = "X";
            jogadas = 0;
        }
    }
}
