using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Project1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            Class2 db = new Class2();

            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            int res = 0;

            string loginUser = loginField.Text;
            string passUser = passField.Text;

            string queryS = "select count(*) login, password from users where login= '" + loginField.Text + "' and password= '" + passField.Text + "';";

            /*
            MySqlCommand query = new MySqlCommand("select login, password from users where login=@uL and password=@uP");
            query.Parameters.Add("@uL", MySqlDbType.VarChar).Value=loginUser;
            query.Parameters.Add("@uP", MySqlDbType.VarChar).Value = passUser;
            */
            MySqlConnection conn = Class2.GetDbConnection();

            MySqlCommand cmDB = new MySqlCommand(queryS, conn);
            cmDB.CommandTimeout = 60;
            try
            {
                conn.Open();
                res = Convert.ToInt32(cmDB.ExecuteScalar());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




            if (res > 0)
            {
                this.Hide();
                MainForm mainForm = new MainForm();
                mainForm.Show();
            }
            else
                MessageBox.Show("Ошибка! Нeверный пароль или логин");

        }


    }
}
