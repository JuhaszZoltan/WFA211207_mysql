using System;
using System.Windows.Forms;
// NuGet Package Manager -> MySQL.Data
using MySql.Data.MySqlClient;

namespace WFA211207_mysql
{
    public partial class FrmMain : Form
    {
        public string ConnectionString { get; set; }
        public FrmMain()
        {
            //https://www.connectionstrings.com/ -ról inspirálódva
            ConnectionString =
                "Server = winsql.verebely.dc; " +
                "Database = diak6; " +
                "Uid = diak6; " +
                "Pwd = jI50aR;";
            //nem, SOHA, SEMMILYEN körülmények között nem hardcode-oljuk be a jelszavunkat így...
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            using (var connection = new MySqlConnection(ConnectionString))
            {
                connection.Open();
                var command = new MySqlCommand("SELECT * FROM tabla;", connection);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    rtb.Text += $"{reader.GetString(1)}\n";
                }

                //csak a biztonság kedvéért, de a using úgyis lezárja:
                reader.Close();
                connection.Close();
            }
        }
    }
}
