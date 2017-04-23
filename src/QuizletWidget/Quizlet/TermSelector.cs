using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QuizletNet;
using QuizletNet.Models;

namespace QuizletWidget
{
    using QuizletWidget.Config;

    class TermSelector
    {
        private static Random Rd;
        private static Queue<long> RecentlySelected;

        static TermSelector()
        {
            Rd = new Random();
            RecentlySelected = new Queue<long>();
        }

        public static SingleTerm GetTerm()
        {
            if (Storage.Sets == null)
                return null;

            var allTerms = Storage.Terms;

            ReRand:
            var idx = Rd.Next(0, allTerms.Length - 1);
            var selected = allTerms[idx];
            if (RecentlySelected.Contains(selected.id))
                goto ReRand;
            if (AppConfig.GlobalConfig.TermsToExclude.Contains(selected.id))
                goto ReRand;

            RecentlySelected.Enqueue(selected.id);
            if (RecentlySelected.Count >= 10)
                RecentlySelected.Dequeue();

            return selected;
        }
    }
}
