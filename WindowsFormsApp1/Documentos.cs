using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Documentos : Form
    {
        private DataSet DocDB;
        int counter;
        public Documentos()
        {
            InitializeComponent();
            listView1.Columns.Add("#", 50);
            listView1.Columns.Add("Documento");
            listView1.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            listView1.FullRowSelect = true;
            listView1.HideSelection = false;
        }
        public DataSet DataSource
        {
            set
            {
                DocDB = value;
            }
            get
            {
                return DocDB;
            }
        }
        void CarregaLista()
        {
            if (DocDB != null && DocDB.Tables["Docs"] != null && DocDB.Tables["Docs"].Rows.Count > 0)
            {
                foreach (DataRow row in DocDB.Tables["Docs"].Rows)
                {
                    //ListViewItem item = new ListViewItem(row[0].ToString());
                    //for (int i=1; i< DocDB.Tables["Docs"].Columns.Count; i++)
                    //{
                    //    item.SubItems.Add(row[i].ToString());
                    //}
                    //listView1.Items.Add(item);
                    Adicionarlista(row["Numero"].ToString(), row["DocDesc"].ToString());
                }
                if (listView1.Items.Count > 0)
                {
                    button1.Enabled = true;
                    button2.Enabled = true;
                    button3.Enabled = true;
                    button4.Enabled = true;
                }
            }
        }
        // Função pra adicionar linha na listview
        private void Adicionarlista(string numero, string documento)
        {
            // Usar array para passar valores
            String[] row = { numero, documento };


            ListViewItem item = new ListViewItem(row);

            // Adicionar o array na ordem passada (numero -> nome)

            listView1.Items.Add(item);
        }
        // Função para atualizar números da lista
        private void atualizalista(ListView listView, int row, int column, string novonumero)
        {
            if (column >= listView.Columns.Count)
                throw new InvalidOperationException("não é possível atualizar valores fora dos limites das colunas");
            ListViewItem item;
            if (row < listView.Items.Count)
                item = listView.Items[row];
            else
            {
                item = new ListViewItem();
                for (int i = 1; i < listView.Columns.Count; ++i)
                    item.SubItems.Add(new ListViewItem.ListViewSubItem());
                listView.Items.Add(item);
            }
            item.SubItems[column].Text = novonumero;
        }
        
        // Checar alterações na ComboBox e verificar se já existe na lista.
        // Caso exista, gerar aviso e não fazer nada, do contrário, adicionar e 
        // incluir um número de linha à esquerda.
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListViewItem contem = listView1.FindItemWithText(comboBox1.Text.ToString());
            if (contem != null)
            {
                MessageBox.Show("O Valor já foi inserido!", "Aviso");
            }
            else
            {
                counter = listView1.Items.Count + 1;
                Adicionarlista(counter.ToString(),comboBox1.Text.ToString());
            }
            if (listView1.Items.Count > 0)
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
            }
            else { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem itemsel in listView1.SelectedItems)
            {
                listView1.Items.Remove(itemsel);
            }

            int j = 1;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                j = i + 1;
                atualizalista(listView1, i, 0, j.ToString());
            }
            if (listView1.Items.Count > 0)
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in listView1.SelectedItems)
            {
                if (lvi.Index > 0)
                {
                    int index = lvi.Index - 1;
                    listView1.Items.RemoveAt(lvi.Index);
                    listView1.Items.Insert(index, lvi);
                }
            }
            int j = 1;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                j = i + 1;
                atualizalista(listView1, i, 0, j.ToString());
            }
            listView1.Focus();
            if (listView1.Items.Count > 0)
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in listView1.SelectedItems)
            {
                if (lvi.Index < listView1.Items.Count - 1)
                {
                    int index = lvi.Index + 1;
                    listView1.Items.RemoveAt(lvi.Index);
                    listView1.Items.Insert(index, lvi);
                }
            }
            int j = 1;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                j = i + 1;
                atualizalista(listView1, i, 0, j.ToString());
            }
            listView1.Focus();
            if (listView1.Items.Count > 0)
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Você tem certeza que deseja excluir todos os documentos inseridos?", "Aviso", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                listView1.Items.Clear();
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DocDB.Tables["Docs"].Rows.Clear();
            for (int i=0; i < listView1.Items.Count; i++)
            {
                DataRow _docs = DocDB.Tables["Docs"].NewRow();
                _docs["Numero"] = listView1.Items[i].SubItems[0].Text.ToString();
                _docs["DocDesc"] = listView1.Items[i].SubItems[1].Text.ToString();
                DocDB.Tables["Docs"].Rows.Add(_docs);
            }
            Close();
        }

        private void Documentos_Load(object sender, EventArgs e)
        {
            CarregaLista();
        }
    }
}
