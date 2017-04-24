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
using System.ComponentModel;

namespace QuizletWidget.Views.Main.Components
{
    using QuizletNet.Models;

    public partial class SetDetailsComponent : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public SingleSet Set { get; set; }
        public string Title { get; set; }
        public string CreatedBy { get; set; }

        public SetDetailsComponent()
        {
            InitializeComponent();

            DataContext = this;
        }

        public void Update()
        {
            if (Set == null) return;

            Title = Set.title;
            CreatedBy = Set.created_by;

            TermList.Children.Clear();
            foreach (var term in Set.terms)
            {
                var item = new SetDetailsItemComponent();
                item.TermText = term.term;
                item.DefinitionText = term.definition;
                TermList.Children.Add(item);
            }

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(""));
        }
    }
}
