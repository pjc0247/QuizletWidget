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

namespace QuizletWidget.Views.Main.Components
{
    public partial class SetItemComponent : UserControl
    {
        public delegate void ValueChangedDelegate(bool value);
        public delegate void SelectedDelegate();

        public string Caption { get; set; } = "Name";

        public event ValueChangedDelegate OnValueChanged;
        public event SelectedDelegate OnSelected;

        public SetItemComponent()
        {
            InitializeComponent();

            DataContext = this;
        }

        private void EnableCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            OnValueChanged?.Invoke(true);
        }
        private void EnableCheckbox_Unchecked(object sender, RoutedEventArgs e)
        {
            OnValueChanged?.Invoke(false);
        }

        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OnSelected?.Invoke();
        }
    }
}
