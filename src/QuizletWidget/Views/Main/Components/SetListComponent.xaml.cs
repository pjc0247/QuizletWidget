﻿using System;
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

using QuizletNet.Models;

namespace QuizletWidget.Views.Main.Components
{
    public partial class SetListComponent : UserControl
    {
        private SingleSet[] Sets { get; set; }

        public SetListComponent()
        {
            InitializeComponent();
        }

        public void UpdateSets(SingleSet[] sets)
        {
            itemList.Children.Clear();

            Sets = sets;
            foreach (var set in sets)
            {
                var item = new SetItemComponent();
                item.Caption = set.title;
                itemList.Children.Add(item);
            }
        }

        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            RootPanel.Height = e.NewSize.Height;
        }
    }
}