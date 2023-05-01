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
using System.Collections.ObjectModel;
using LiveCharts;
using LiveCharts.Wpf;

namespace Gestion_budget
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Transaction> Transactions { get; set; }
        public ObservableCollection<FixedExpense> FixedExpenses { get; set; }
        public ObservableCollection<AmortizedPurchase> AmortizedPurchases { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            // Exemple de données pour tester l'interface utilisateur
            Transactions = new ObservableCollection<Transaction>
            {
                new Transaction { Date = DateTime.Now, Description = "Salaire", Amount = 3000, Type = TransactionType.Income },
                new Transaction { Date = DateTime.Now, Description = "Achat de nourriture", Amount = -100, Type = TransactionType.Expense }
            };
            dataGridTransactions.ItemsSource = Transactions;

            FixedExpenses = new ObservableCollection<FixedExpense>
            {
                new FixedExpense { Description = "Loyer", Amount = 1200, DueDate = DateTime.Now.AddMonths(1) }
            };
            dataGridFixedExpenses.ItemsSource = FixedExpenses;

            AmortizedPurchases = new ObservableCollection<AmortizedPurchase>
            {
                new AmortizedPurchase { Description = "Ordinateur", Amount = 1500, PurchaseDate = DateTime.Now, AmortizationPeriod = 12 }
            };
            dataGridAmortizedPurchases.ItemsSource = AmortizedPurchases;
        }

        private void AddIncome_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddTransactionWindow(TransactionType.Income);
            if (window.ShowDialog() == true)
            {
                Transactions.Add(window.Transaction);
            }
        }

        private void AddExpense_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddTransactionWindow(TransactionType.Expense);
            if (window.ShowDialog() == true)
            {
                Transactions.Add(window.Transaction);
            }
        }

        private void GenerateCharts_Click(object sender, RoutedEventArgs e)
        {
            var window = new ChartWindow(Transactions);
            window.Show();
        }

        private void ShowStatistics_Click(object sender, RoutedEventArgs e)
        {
            var window = new StatisticsWindow(Transactions);
            window.Show();
        }
    }

    public class Transaction
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public TransactionType Type { get; set; }
    }

    public enum TransactionType
    {
        Income,
        Expense
    }

    public class FixedExpense
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime DueDate { get; set; }
    }

    public class AmortizedPurchase
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int AmortizationPeriod { get; set; }
    }
}
