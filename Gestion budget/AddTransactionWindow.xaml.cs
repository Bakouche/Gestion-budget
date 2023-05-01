using Gestion_budget;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Gestion_budget
{
    public partial class AddTransactionWindow : Window
    {
        public Transaction Transaction { get; private set; }
        private TransactionType _transactionType;

        public AddTransactionWindow(TransactionType transactionType)
        {
            InitializeComponent();
            _transactionType = transactionType;
            datePicker.SelectedDate = DateTime.Now;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(amountTextBox.Text, out decimal amount))
            {
                Transaction = new Transaction
                {
                    Date = datePicker.SelectedDate.Value,
                    Description = descriptionTextBox.Text,
                    Amount = _transactionType == TransactionType.Expense ? -amount : amount,
                    Type = _transactionType
                };

                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Montant invalide. Veuillez entrer un nombre décimal.");
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
