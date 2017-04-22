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
using System.Windows.Shapes;

using QuizletNet;
using QuizletNet.Models;

namespace QuizletWidget.Views.Main
{
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();

            Quizlet.Initialize();
            LoadSets();
        }

        private async void LoadSets()
        {
            var sets = await Sets.QuerySets("quizlette10562");

            if (sets != null)
                setList.UpdateSets(sets);
        }
    }
}
