using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizletNet.Models
{
    public class SingleSet
    {
        public long id;
        public string url;
        public string title;
        public string created_by;
        public int term_count;
        public long created_date;
        public long modified_date;
        public bool has_images;
        public string visibility;

        public string description;

        public SingleTerm[] terms;
    }
}
