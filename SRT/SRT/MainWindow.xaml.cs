using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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

namespace SRT
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            using (var context = GetContext())
            {
                ApartmentDataGrid.ItemsSource = context.Apartment.ToList();
                PaymentDataGrid.ItemsSource = context.Payment.ToList();
                ServiceDataGrid.ItemsSource = context.Service.ToList();
            }
        }
        private void RefreshData()
        {
            using (var context = GetContext())
            {
                // Очищаем старые данные
                ApartmentDataGrid.ItemsSource = null;
                PaymentDataGrid.ItemsSource = null;
                ServiceDataGrid.ItemsSource = null;

                // Загружаем новые данные
                ApartmentDataGrid.ItemsSource = context.Apartment.ToList();
                PaymentDataGrid.ItemsSource = context.Payment.ToList();
                ServiceDataGrid.ItemsSource = context.Service.ToList();
            }
        }

        private static SRTEntities _content;

        public static SRTEntities GetContext()
        {
            if (_content == null)
                _content = new SRTEntities();
            return _content;
        }
        
    }
}
