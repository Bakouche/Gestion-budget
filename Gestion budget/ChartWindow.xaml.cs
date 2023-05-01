using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using Gestion_budget;
using LiveCharts;

namespace Gestion_budget
{
    public partial class ChartWindow : Window
    {
        public ChartWindow(ObservableCollection<Transaction> transactions)
        {
            InitializeComponent();

            var incomeData = transactions
                .Where(t => t.Type == TransactionType.Income)
                .GroupBy(t => t.Date.ToString("MM/yyyy"))
                .Select(g => new { MonthYear = g.Key, Amount = g.Sum(t => t.Amount) })
                .OrderBy(d => d.MonthYear);

            var expenseData = transactions
                .Where(t => t.Type == TransactionType.Expense)
                .GroupBy(t => t.Date.ToString("MM/yyyy"))
                .Select(g => new { MonthYear = g.Key, Amount = -g.Sum(t => t.Amount) })
                .OrderBy(d => d.MonthYear);

            IncomeSeries.Values = new ChartValues<decimal>(incomeData.Select(d => d.Amount));
            ExpenseSeries.Values = new ChartValues<decimal>(expenseData.Select(d => d.Amount));
            IncomeChart.AxisX[0].Labels = incomeData.Select(d => d.MonthYear).ToList();
            ExpenseChart.AxisX[0].Labels = expenseData.Select(d => d.MonthYear).ToList();
        }
    }
}
