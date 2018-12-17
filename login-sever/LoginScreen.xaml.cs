using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace login_sever
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source = NK-VOSTRO\SQLEXPRESS; Initial Catalog = Login Database; Integrated Security = True");
            try
            {
                if (sqlConnection.State == System.Data.ConnectionState.Closed)
                    sqlConnection.Open();
                String query = "SELECT * FROM [dbo].[User] WHERE Username=@username AND Password=@password";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                // sqlCommand.CommandType = System.Data.CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@username", SqlDbType.NVarChar).Value = txtUsername.Text;
                sqlCommand.Parameters.AddWithValue("@password", SqlDbType.NVarChar).Value = txtPassword.Text;

                int count = Convert.ToInt32(sqlCommand.ExecuteScalar());
                if (count == 1)
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Username or password incorrect.");
                    this.Close();
                }


            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }
    }
}
