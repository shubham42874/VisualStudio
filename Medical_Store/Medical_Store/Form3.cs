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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            fillprodnum();
            fillcombo();
            
            
        }
        void fillprod()
        {
            string cnn = "datasource=localhost;port=3306;username=shubham;password=shubham96";
            string querry = " select Product_ID,Cost from stock.stock where Medicine_Name='" +this.comboBox1.Text+"' ; ";

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
                    //string sName = myReader.GetString("Medicine_Name");
                    string tName = myReader.GetString("Product_ID");
                    string uName = myReader.GetString("Cost");
                    textBox2.Text = tName;
                    textBox4.Text = uName;
                    Int32 val1 = Convert.ToInt32(textBox3.Text);
                    Int32 val2 = Convert.ToInt32(textBox4.Text);
                    Int32 val3 = val1 * val2;
                    textBox6.Text = val3.ToString();
                   
                }


                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void fillprodnum()
        {
            string cnn = "datasource=localhost;port=3306;username=shubham;password=shubham96";
            string querry = " select max(Order_no) AS Order_no from stock.order ";

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
                    //string sName = myReader.GetString("Medicine_Name");
                    string tName = myReader.GetString("Order_no");
                    //string uName = myReader.GetString("Cost");
                    textBox7.Text = tName;
                    //textBox4.Text = uName;
                    Int32 val1 = Convert.ToInt32(textBox7.Text);
                    //Int32 val2 = Convert.ToInt32(textBox4.Text);
                    Int32 val3 = val1 + 1;
                    textBox7.Text = val3.ToString();

                }


                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                    string tName = myReader.GetString("Product_ID");

                    comboBox1.Items.Add(sName);
                                       
                }


                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            fillprod();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string connetionString = "datasource=localhost;port=3306;username=shubham;password=shubham96";
                MySqlConnection cnn = new MySqlConnection(connetionString);

                //string querry = " insert into stock.try (medicine) values ( '" + this.textBox3.Text + "')";

                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                MySqlCommand SelectCommand = new MySqlCommand(" insert into stock.order (Order_no,Customer_name,Medicine_Name,Product_ID,Quantity,Total,Bill) values ( '" + this.textBox7.Text + "' ,'" + this.textBox1.Text + "' ,'" + this.comboBox1.Text + "' , '" + this.textBox2.Text + "' ,'" + this.textBox3.Text + "','" + this.textBox6.Text + "','" + this.textBox5.Text + "');", cnn);
                //MySqlCommand SelectCommand1 = new MySqlCommand(" UPDATE stock.order SET Bill = Bill + '"+this.textBox6.Text+"' WHERE Order_no='" + this.textBox7.Text + "'; ", cnn);
                MySqlCommand SelectCommand1 = new MySqlCommand("UPDATE stock.stock SET Quantity = Quantity - '" + this.textBox3.Text + "' WHERE Product_ID='" + this.textBox2.Text + "' ", cnn);
                //MySqlCommand SelectCommand = new MySqlCommand(querry, cnn);
                MySqlCommand SelectCommand2 = new MySqlCommand("UPDATE stock.order SET Bill = Bill + '" + this.textBox6.Text + "' WHERE Order_no='" + this.textBox7.Text + "' ", cnn);
                MySqlDataReader myReader;

                cnn.Open();
                myReader = SelectCommand1.ExecuteReader();
                cnn.Close();
                cnn.Open();
                myReader = SelectCommand.ExecuteReader();
               

                cnn.Close();
                cnn.Open();
                myReader = SelectCommand2.ExecuteReader();
                cnn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string connetionString = "datasource=localhost;port=3306;username=shubham;password=shubham96";
                MySqlConnection cnn = new MySqlConnection(connetionString);

                //MySqlCommand SelectCommand = new MySqlCommand("UPDATE stock.order SET Bill = Bill + '"+this.textBox6.Text+"' WHERE Order_no='" + this.textBox7.Text + "' ", cnn);
               // MySqlCommand SelectCommand1 = new MySqlCommand("select max(Bill) AS Bill from stock.order WHERE Order_no='" + this.textBox7.Text + "'", cnn);
                string querry = " select max(Bill) AS Bill from stock.order WHERE Order_no='" + this.textBox7.Text + "' ";
                MySqlCommand SelectCommand1 = new MySqlCommand(querry, cnn);
                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                
                MySqlDataReader myReader;

                //cnn.Open();
                //myReader = SelectCommand.ExecuteReader();
                //cnn.Close();
                


                cnn.Open();
                myReader = SelectCommand1.ExecuteReader();

                while (myReader.Read())
                {
                    string sName = myReader.GetString("Bill");



                    textBox5.Text = sName;
                }


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
                MySqlCommand SelectCommand = new MySqlCommand("UPDATE stock.stock SET Quantity = Quantity - '"+this.textBox3.Text+"' WHERE Product_ID='"+this.textBox2.Text+"' ", cnn);
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

        private void button6_Click(object sender, EventArgs e)
        {
            string cnn = "datasource=localhost;port=3306;username=shubham;password=shubham96";
            string querry = " select max(Bill) AS Bill from stock.order WHERE Order_no='"+this.textBox7.Text+"' ";

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
                    string sName = myReader.GetString("Bill");
                    


                    textBox5.Text = sName;
                }


                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            fillprodnum();
        }

        
    }
}
