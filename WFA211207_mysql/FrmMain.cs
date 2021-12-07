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

namespace WFA211207_mysql
{
    public partial class FrmMain : Form
    {
        public string ConnectionString { get; set; }
        public FrmMain()
        {
            ConnectionString =
                "Server = winsql.verebely.dc; " +
                "Database = diak6; " +
                "Uid = diak6; " +
                "Pwd = jI50aR;";

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (var c = new MySqlConnection(ConnectionString))
            {
                c.Open();
                var command = new MySqlCommand("SELECT * FROM tabla;", c);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    rtb.Text += $"{reader.GetString(1)}\n";
                }
                reader.Close();
                c.Close();  
            }
        }
    }
}
