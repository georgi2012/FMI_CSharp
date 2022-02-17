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

namespace Problem4_Command
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            btnValidate.Command = InputValidatorCommand.Validate;
            btnValidate.CommandTarget = txtBox;
            btnValidate.Content = ((RoutedUICommand)(btnValidate.Command)).Text;//sets button text to descpt of command name

            CommandBinding binding = new CommandBinding();
            binding.Command = InputValidatorCommand.Validate;
            binding.Executed += Validation_Executed;
            binding.CanExecute += Validation_CanExecute;

            CommandBindings.Add(binding);
        }

        public void Validation_Executed(object sender, ExecutedRoutedEventArgs args)
        {
            if(txtBox.Text.Length>=8)
            {
                txtBox.Background = Brushes.Green;
            }
            else
            {
                txtBox.Background = Brushes.Red;
            }
        }

        public void Validation_CanExecute(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = txtBox.Text.Length >= 0;
        }
    }
}
