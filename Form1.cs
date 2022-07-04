using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace trabalho1
{
    public partial class formulario : Form
    {
        public formulario()
        {
            InitializeComponent();
        }
        Random randomizer = new Random();
        int addend1;
        int addend2;

        int minuend;
        int subtrahend;

        
        int multiplicand;
        int multiplier;

       
        int dividend;
        int divisor;

        int timeLeft;

        public void StartTheQuiz()
        {
           
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

           
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            
            soma.Value = 0;
            

           
            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            menosLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            diferenca.Value = 0;

            
            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            produto.Value = 0;

            
            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quociente.Value = 0;

            timeLeft = 80;
            timeLabel.Text = "80 seconds";
            timer1.Start();

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }
        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == soma.Value)
                && (minuend - subtrahend == diferenca.Value)
                && (multiplicand * multiplier == produto.Value)
                && (dividend / divisor == quociente.Value))
                return true;
            else
                return false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
              
                timer1.Stop();
                MessageBox.Show("Parabens voce ganhou!",
                                "Parabens!");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
               
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " seconds";
            }
            else
            {
                
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("voce perdeu.", "Desculpa!");
                soma.Value = addend1 + addend2;
                diferenca.Value = minuend - subtrahend;
                produto.Value = multiplicand * multiplier;
                quociente.Value = dividend / divisor;
                startButton.Enabled = true;
            }
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }
    }
}
//Neste código:

//A primeira linha declara o método. Ele inclui um parâmetro chamado sender. Em C#, o parâmetro é object sender. Em Visual Basic, ésender As System.Object. Este parâmetro refere-se ao objeto cujo evento é acionando, que é conhecido como o remetente. Nesse caso, o objeto remetente é o controle NumericUpDown.
//A primeira linha dentro do método converte ou converte o remetente de um objeto genérico para um controle NumericUpDown. Essa linha também atribui o nome answerBox ao controle NumericUpDown. Todos os controles NumericUpDown no formulário usarão esse método, não apenas o controle do problema de adição.
//A próxima linha verifica se o answerBox foi convertido com êxito como um controle NumericUpDown.
//A primeira linha dentro da if instrução determina o comprimento da resposta que está atualmente no controle NumericUpDown.
//A segunda linha dentro da if instrução usa o comprimento da resposta para selecionar o valor atual no controle.