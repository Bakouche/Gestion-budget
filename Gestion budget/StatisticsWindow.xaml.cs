using Gestion_budget;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;

namespace Gestion_budget
{
    public partial class StatisticsWindow : Window
    {
        public StatisticsWindow(ObservableCollection<Transaction> transactions)
        {
            InitializeComponent();

            decimal totalIncome = transactions.Where(t => t.Type == TransactionType.Income).Sum(t => t.Amount);
            decimal totalExpense = transactions.Where(t => t.Type == TransactionType.Expense).Sum(t => t.Amount);
            decimal balance = totalIncome + totalExpense;

            TotalIncomeTextBlock.Text = totalIncome.ToString("C", CultureInfo.CurrentCulture);
            TotalExpenseTextBlock.Text = totalExpense.ToString("C", CultureInfo.CurrentCulture);
            BalanceTextBlock.Text = balance.ToString("C", CultureInfo.CurrentCulture);
        }
    }
}
