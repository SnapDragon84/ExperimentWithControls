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

namespace ExperimentWithControls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void numberTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            number.Text = numberTextBox.Text;   //an exception will be thrown here if the TextBlock is not initialized prior to running app
        }                                       //make sure TextBlock appears before TextBox in Xaml code

        private void numberTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !int.TryParse(e.Text, out int result);
        }

        private void smallSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            number.Text = smallSlider.Value.ToString("0"); //the value of the Slider control is a fractional member with a decimal point. "0" converts it to a whole number

        }

        private void bigSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            number.Text = bigSlider.Value.ToString("000-000-0000"); //the zeros & hyphens cause the method to formatmany 10-digit number to a US phone number
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if(sender is RadioButton radioButton)   //we did not give it a name initially, so we are calling it "radioButton" here as a local variable within this method
            {
                number.Text = radioButton.Content.ToString();
            }
        }

        private void myListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (myListBox.SelectedItem is ListBoxItem listBoxItem) //giving ListBoxItem a local variable name "listBoxItem"
            {
                number.Text = listBoxItem.Content.ToString();
            }
        }

        private void readOnlyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (readOnlyComboBox.SelectedItem is ListBoxItem listBoxItem)
            {
                number.Text = listBoxItem.Content.ToString();
            }
        }

        private void editableComboBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is ComboBox comboBox)
            {
                number.Text = comboBox.Text;
            }
        }
    }
}
