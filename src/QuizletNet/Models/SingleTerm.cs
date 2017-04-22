using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizletNet.Models
{
    public class TermImage
    {
        public string url;
        public int width;
        public int height;
    }

    public class SingleTerm
    {
        public long id;
        public string term;
        public string definition;
        public TermImage image;
    }
}
