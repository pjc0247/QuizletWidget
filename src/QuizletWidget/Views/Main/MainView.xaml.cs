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
    using QuizletWidget.Config;

    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();

            UpdateSets(Storage.Sets);
        }

        private void UpdateSets(SingleSet[] sets)
        {
            if (sets != null)
                SetList.UpdateSets(sets);
        }

        private void SetList_SetStatusChanged(long setId, bool enabled)
        {
            var excludes = AppConfig.GlobalConfig.TermsToExclude;
            var set = Storage.GetSetFromId(setId);

            foreach (var term in set.terms)
            {
                if (enabled)
                    excludes.Add(term.id);
                else
                    excludes.Remove(term.id);
            }

            AppConfig.Save();
        }
    }
}
