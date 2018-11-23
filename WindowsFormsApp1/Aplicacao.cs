using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using Validacao;
using PrintPF;

// Namespace
namespace WindowsFormsApp1

{   // Classe
    public partial class Aplicacao : Form
    {
        // vou declarar o DataSet no escopo global, aqui que eu guardo a variável da janela Documentos
        public DataSet LocalDB;
        // instanciar a janela (iniciar todos os componentes da classe)
        public Aplicacao()
        {
            InitializeComponent();

            // Instanciar o dataset para ele existir na memória
            // DataSet é um banco de dados na memória do programa
            LocalDB = new DataSet();

            // Instanciar o DataTable, que é Tabela, entidade vira tabela,
            DataTable Docs = new DataTable("Docs");

            // Adicionar ao DataSet a tabela Docs... Você cria a tabela depois adiciona ao DataSet
            // wtf né..
            LocalDB.Tables.Add("Docs");

            // Adicionar as colunas na tabela...
            LocalDB.Tables["Docs"].Columns.Add("Numero", typeof(string));
            LocalDB.Tables["Docs"].Columns.Add("DocDesc", typeof(string));
        }

        // Variáveis globais abaixo para guardar valores, vou declarar aqui para que
        // quando eu abra a janela "Sócio" eu consiga guardar os valores que venham de 
        // lá
        // Sócio
        string ssnome, ssrg, ssemissor, ssexpedicao, sscpf, ssmae, ssnacionalidade, sslogradouro, ssbairro, sscidade, ssuf, sscep, ssemail = " ";
        string cr = "X";
        string rr, ar, cancelamento, segvia = new string(' ', 1);

        // Verificar se botão pessoa jurídica foi pressionado, caso seja, habilitar grupos
        // de botões para sócio e campo pessoa jurídica
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Enabled = false;
            groupBox4.Enabled = false;
        }


        // Ao clicar no botão "REQUERIMENTO" ele roda os argumentos abaixo
        private void btn_req_Click(object sender, EventArgs e)
        {
            // NOVA CULTURA! Função utilizada para mudar os LOCALES
            CultureInfo culture = new CultureInfo("pt-BR");

            // A declaração acima usa um método CultureInfo para declarar o 
            // Locale que você quer usar no sistema, vamos usar isso para converter
            // DateTime dd/mm/aaaa para uma data por extenso do tipo
            // 1 de Maio de 2018
            DateTimeFormatInfo dtfi = culture.DateTimeFormat;

            // Passar para formato dia, mes e ano
            int dia = DateTime.Now.Day;
            int ano = DateTime.Now.Year;

            // invoco o método culture para transformar o mês em nome
            string mes = culture.TextInfo.ToTitleCase(dtfi.GetMonthName(DateTime.Now.Month));
            string data = dia + " de " + mes + " de " + ano;

            // Instanciar janela de impressão do requerimento com todos os valores na sequencia correta,
            // Aqui eu declaro que estou passando todos os valores preenchidos para a janela de impressão.
            //copiaDataSet.Tables["Docs"].Rows.Clear();
            //foreach (DataRow dr in LocalDB.Tables["Docs"].Rows)
            //{
            //    copiaDataSet.Tables["Docs"].Rows.Add(dr.ItemArray);
            //}

            PreviewReq PRRec = new PreviewReq(email.Text, crn.Text, outorgantecpf.Text, outorgantelogra.Text.ToUpper(), outorgantebairro.Text.ToUpper(), outorgantecep.Text, outorgantecidade.Text.ToUpper(),
                outorganteestado.Text.ToUpper(), outorganterg.Text, outorganteexpeditor.Text.ToUpper(), outorganteexpdata.Text, outorgantenacional.Text.ToUpper(), outorgantenome.Text.ToUpper(),
                outorganteempresa.Text.ToUpper(), outorgantecnpj.Text, outorgantelogcom.Text.ToUpper(), outorgantebairrocom.Text.ToUpper(), outorgantecepcom.Text.ToUpper(),
                outorgantecidadecom.Text.ToUpper(), outorganteufcom.Text.ToUpper(), data, cr, rr, ar, cancelamento, segvia, "Nome");
            PRRec.DataSource = LocalDB;

            //Mostrar a janela
            PRRec.Show();
        }
        

        // Abaixo fiz um set de funções para mudar o valor das variáveis e passar pra impressão
        // para colocar o X no Objeto do requerimento...
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            // preencher o campo relativo ao botão com o X
            cr = "X";
            // passar espaços em branco para os campos que não serão preenchidos
            string rr, ar, cancelamento, segvia = " ";
        }

        // Idem
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            rr = "X";
            string cr, ar, cancelamento, segvia = " ";
        }

        // Idem
        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            ar = "X";
            string cr , rr, canc, segvia = " ";
        }

        // Idem
        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            cancelamento = "X";
            string cr, rr, ar, segvia = " ";
        }

        // Item
        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            segvia = "X";
            string cr, rr, ar, canc = " ";
        }

        // Verificar se o botão pessoa jurídica foi pressionado, caso sim, ativar as caixas 
        // do grupo Pessoa Juridica e Dados do Sócio
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Enabled = true;
            groupBox4.Enabled = true;
        }

        // Ao sair do campo do CPF, rodar a função para verificar os dígitos
        private void cpf_Leave(object sender, EventArgs e)
        {
            // excluir pontos e traços, uso o método MaskFormat para 
            // passar a string excluir Prompts e Literals
            outorgantecpf.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            // variável chars para guardar o tamanho do cpf contabilizando todos os chars
            int chars = outorgantecpf.Text.Length;

            // Se não preencher o CPF não faça nada
            if (chars == 0)
            {
            }

            // se preencher com 11, rodar a função para verificar
            else if (chars == 11)
            {
                // Criei uma classe ValidaCPF para confirmar se o CPF é verdadeiro ou falso
                if (Validacao.ValidaCPF.IsCpf(outorgantecpf.Text))
                {
                }
                else
                {
                    MessageBox.Show("Corrija o campo e tente novamente.", "O número é um CPF Inválido !");
                    outorgantecpf.Focus();
                }
            }

            // E caso o if acima não valide para 11 caracteres, ele dá uma janela de erro e não deixa
            // sair da caixa até que o tamanho do CPF seja corrigido: Ou a pessoa apaga tudo e consegue
            // sair ou ela acerta o CPF ou verifica se tem algo errado
            else
            {
                MessageBox.Show("O CPF deve possuir 11 números !", "Corrija o campo e tente novamente.");
                outorgantecpf.Focus();
            }
        }

        // Se parar o mouse no botão ele abre um popup com a descrição das iniciais
        private void radioButton3_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(radioButton3, "Concessão de Registro");
        }
        private void radioButton4_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(radioButton4, "Revalidação de Registro");
        }
        private void radioButton5_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(radioButton5, "Apostilamento de Registro");
        }
        private void radioButton6_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(radioButton6, "Cancelamento");
        }
        private void radioButton7_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(radioButton7, "Segunda via de Registro");
        }

        private void btn_procura_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                // função pra converter DateTime para formato nacional  (de novo)
                CultureInfo culture = new CultureInfo("pt-BR");
                DateTimeFormatInfo dtfi = culture.DateTimeFormat;

                // Passar para form dia, mes e ano(blablabla)
                int dia = DateTime.Now.Day;
                int ano = DateTime.Now.Year;
                string mes = culture.TextInfo.ToTitleCase(dtfi.GetMonthName(DateTime.Now.Month));
                string data = dia + " de " + mes + " de " + ano;

                // de novo
                PrintPreviewPF ProcPF = new PrintPreviewPF (outorgantecpf.Text, outorgantelogra.Text.ToUpper(), outorgantebairro.Text.ToUpper(), outorgantecep.Text, outorgantecidade.Text.ToUpper(), 
                    outorganteestado.Text.ToUpper(), outorganterg.Text, outorganteexpeditor.Text.ToUpper(), outorganteexpdata.Text, outorgantenacional.Text.ToUpper(), outorgantenome.Text.ToUpper(), data);
                ProcPF.Show();
            }
            else
            {
                CultureInfo culture = new CultureInfo("pt-BR");
                DateTimeFormatInfo dtfi = culture.DateTimeFormat;

                int dia = DateTime.Now.Day;
                int ano = DateTime.Now.Year;
                string mes = culture.TextInfo.ToTitleCase(dtfi.GetMonthName(DateTime.Now.Month));
                string data = dia + " de " + mes + " de " + ano;
                PrintPreviewPJ ProcPJ = new PrintPreviewPJ (outorgantecpf.Text, outorgantelogra.Text.ToUpper(), outorgantebairro.Text.ToUpper(), outorgantecep.Text, outorgantecidade.Text.ToUpper(), outorganteestado.Text.ToUpper(), outorganterg.Text, outorganteexpeditor.Text.ToUpper(), outorganteexpdata.Text, outorgantenacional.Text.ToUpper(), outorgantenome.Text.ToUpper(), outorganteempresa.Text.ToUpper(), outorgantecnpj.Text.ToUpper(), outorgantelogcom.Text.ToUpper(), outorgantebairrocom.Text.ToUpper(), outorgantecepcom.Text.ToUpper(), outorgantecidadecom.Text.ToUpper(), outorganteufcom.Text.ToUpper(), data);
                ProcPJ.Show();
            }
        }

        //abre janela dos dados do sócio
        private void dadossocio_Click(object sender, EventArgs e)
        {
            Socio f1 = new Socio();
            f1.ShowDialog();
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            dadossocio.Enabled = false;
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            dadossocio.Enabled = true;
        }

        // Abre janela dos documentos, com uma ressalva:
        private void button1_Click(object sender, EventArgs e)
        {
            Documentos f2 = new Documentos();
            // ressalva: passar para avariável "DataSource" dentro desse outro form
            // a relação com uma variável desse form chamada LocalDB, assim tudo o que eu fizer lá
            // cai no meu LocalDB e vice versa...
            f2.DataSource = LocalDB;
            f2.ShowDialog();
        }
    }
 }