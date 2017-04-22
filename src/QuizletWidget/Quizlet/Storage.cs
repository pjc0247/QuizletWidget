using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QuizletNet;
using QuizletNet.Models;

namespace QuizletWidget
{
    class Storage
    {
        public static SingleSet[] Sets;

        public static SingleTerm[] Flatten()
        {
            var list = new List<SingleTerm>();
            foreach(var set in Sets)
                list.AddRange(set.terms);
            return list.ToArray();
        }
    }
}
