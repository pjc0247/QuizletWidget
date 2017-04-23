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
        private static Dictionary<long, SingleSet> _Sets;
        public static SingleSet[] Sets
        {
            get => _Sets.Select(x => x.Value).ToArray();
            set
            {
                _Sets = value.ToDictionary(x => x.id, x => x);
                Terms = Flatten();
            }
        }

        public static SingleTerm[] Terms { get; private set; }

        public static SingleSet GetSetFromId(long setId)
        {
            return _Sets[setId];
        }

        private static SingleTerm[] Flatten()
        {
            var list = new List<SingleTerm>();
            foreach(var set in Sets)
                list.AddRange(set.terms);
            return list.ToArray();
        }
    }
}
