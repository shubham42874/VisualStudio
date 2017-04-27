using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace Medical_Store
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            table();
        }

        void table()
        {
            string connetionString = "datasource=localhost;port=3306;username=shubham;password=shubham96";
            MySqlConnection cnn = new MySqlConnection(connetionString);
            MySqlCommand SelectCommand = new MySqlCommand(" select * from stock.stock; ", cnn);
            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = SelectCommand;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                dataGridView1.DataSource = bSource;
                sda.Update(dbdataset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
