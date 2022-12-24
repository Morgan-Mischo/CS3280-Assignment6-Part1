using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;

namespace _3280_Assignment_6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private clsDataAccess db = new clsDataAccess();

        private List<String> flights = new List<String>();

        public MainWindow()
        {
            InitializeComponent();
            flightLoad();
            passLoad();
        }

        /// <summary>
        /// Loads the flight into the combobox
        /// </summary>
        private void flightLoad()
        {
            try
            {
                //Create a DataSet to hold the data
                DataSet ds;

                //Number of return values
                int iRet = 0;

                //Execute the statement and get the data
                ds = db.ExecuteSQLStatement("SELECT * FROM flight", ref iRet);

                //Loop through all the values returned
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    //Add the flights to the combobox
                    choose_flight_cbox.Items.Add(ds.Tables[0].Rows[i][1].ToString() + " " + ds.Tables[0].Rows[i].ItemArray[2].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        private void passLoad()
        {
            try
            {
                //Create a DataSet to hold the data
                DataSet ds;

                //Number of return values
                int iRet = 0;

                //Execute the statement and get the data
                ds = db.ExecuteSQLStatement("SELECT * FROM passenger", ref iRet);

                //Loop through all the values returned
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    //Add the flights to the combobox
                    choose_pass_cbox.Items.Add(ds.Tables[0].Rows[i][1].ToString() + " " + ds.Tables[0].Rows[i].ItemArray[2].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        private void choose_flight_cbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                //Create a DataSet to hold the data
                DataSet ds;

                //Number of return values
                int iRet = 0;

                //Execute the statement and get the data
                ds = db.ExecuteSQLStatement("SELECT * FROM flight", ref iRet);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    //add to local list
                    flights.Add(ds.Tables[0].Rows[i].ItemArray[2].ToString() + " ");
                }
                string concat = String.Join("", flights.ToArray());
                test_txt.Text = concat;
            }
            catch (Exception ex)
            {
                MessageBox.Show(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}