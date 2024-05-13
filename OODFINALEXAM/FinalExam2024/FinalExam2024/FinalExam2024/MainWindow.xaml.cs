using System;
using System.Data;
using System.Data.Sql;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Data.Common;
//using System.Data.Entity;

namespace FinalExam2024
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }
        public class Booking
        {
            public int BookingID { get; set; }
            public DateTime BookingDate { get; set; }
            public int NumberOfParticipants { get; set; }
        }
        public class Customer
        {
            public int CustomerID { get; set; }
            public string Name { get; set; }
            public string ContactNumber { get; set; }

            public ObservableCollection<Booking> Bookings { get; set; } = new ObservableCollection<Booking>();


            // Example method to retrieve customer data

        }
        // ViewModel class
        public class MainViewModel : INotifyPropertyChanged
        {
            private ObservableCollection<Customer> customers;

            public ObservableCollection<Customer> Customers
            {
                get { return customers; }
                set
                {
                    customers = value;
                    OnPropertyChanged(nameof(Customers));
                }
            }

            // Load customers and bookings data
            public MainViewModel()
            {
                // Example: Load customers from a data source
                Customers = new ObservableCollection<Customer>
        {
            new Customer
            {
                CustomerID = 1,
                Name = "John Doe",
                Bookings = new ObservableCollection<Booking>
                {
                    new Booking { BookingID = 101, BookingDate = DateTime.Now.AddDays(1) },
                    new Booking { BookingID = 102, BookingDate = DateTime.Now.AddDays(2) }
                }
            },
            new Customer
            {
                CustomerID = 2,
                Name = "Jane Smith",
                Bookings = new ObservableCollection<Booking>
                {
                    new Booking { BookingID = 201, BookingDate = DateTime.Now.AddDays(3) }
                }
            }
        };
            }

            // Implementation of INotifyPropertyChanged interface
            public event PropertyChangedEventHandler PropertyChanged;
            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        /*public class RestaurantData : DbContext
        {
            public RestaurantData() : base("name=OODExam_RobertCarleton")
            {

            }
        }*/

    }

}
