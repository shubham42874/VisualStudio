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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            fillcombo();
        }
        void fillcombo()
        {
            
                string cnn = "datasource=localhost;port=3306;username=shubham;password=shubham96";
                string querry = " select * from stock.stock ";

                MySqlConnection connection = new MySqlConnection(cnn);
                

                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                MySqlCommand SelectCommand = new MySqlCommand(querry, connection);
                MySqlDataReader myReader;
            try
            {
                connection.Open();
                myReader = SelectCommand.ExecuteReader();

                while (myReader.Read())
                {
                    string sName = myReader.GetString("Medicine_Name");
                    
                    comboBox2.Items.Add(sName);
                }


                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string connetionString = "datasource=localhost;port=3306;username=shubham;password=shubham96"; 
                MySqlConnection cnn = new MySqlConnection(connetionString);

                string querry = " insert into stock.try (medicine) values ( '" + this.textBox3.Text + "')";

                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                //MySqlCommand SelectCommand = new MySqlCommand(" insert into stock.stock (Medicine_Name,Product_ID,Quantity,Cost) values ( '" + this.textBox3.Text + "' ,'" + this.textBox2.Text + "' ,'" + this.textBox4.Text + "' , '" + this.textBox1.Text + "' ;  insert into stock.try (medicine) values ( '" + this.textBox3.Text + "');  ", cnn);
                //MySqlCommand SelectCommand1 = new MySqlCommand(" insert into stock.try (medicine) values ( '" + this.textBox3.Text + "'); ", cnn);
                MySqlCommand SelectCommand = new MySqlCommand(querry, cnn);
                MySqlDataReader myReader;

                cnn.Open();
                myReader = SelectCommand.ExecuteReader();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();

                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 f4=new Form4();
            f4.Show();
            


        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string connetionString = "datasource=localhost;port=3306;username=shubham;password=shubham96";
                MySqlConnection cnn = new MySqlConnection(connetionString);

                MySqlCommand SelectCommand = new MySqlCommand("UPDATE stock.stock SET Quantity = Quantity + '" + this.textBox5.Text + "' WHERE Medicine_Name='" + this.comboBox2.Text + "' ", cnn);

                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();

                MySqlDataReader myReader;

                cnn.Open();
                myReader = SelectCommand.ExecuteReader();


                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string connetionString = "datasource=localhost;port=3306;username=shubham;password=shubham96";
                MySqlConnection cnn = new MySqlConnection(connetionString);

                //string querry = " insert into stock.try (medicine) values ( '" + this.textBox3.Text + "')";

                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                MySqlCommand SelectCommand = new MySqlCommand("UPDATE stock.stock SET Quantity = Quantity + '" + this.textBox3.Text + "' WHERE Product_ID='" + this.textBox2.Text + "' ", cnn);
                //MySqlCommand SelectCommand1 = new MySqlCommand(" insert into stock.try (medicine) values ( '" + this.textBox3.Text + "'); ", cnn);
                //MySqlCommand SelectCommand = new MySqlCommand(querry, cnn);
                MySqlDataReader myReader;

                cnn.Open();
                myReader = SelectCommand.ExecuteReader();


                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
