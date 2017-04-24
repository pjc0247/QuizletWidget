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
    public partial class SetDetailsItemComponent : UserControl
    {
        public string TermText { get; set; } = "TERM";
        public string DefinitionText { get; set; } = "DEFINITION";

        public SetDetailsItemComponent()
        {
            InitializeComponent();

            DataContext = this;
        }

        public void Update()
        {

        }
    }
}
