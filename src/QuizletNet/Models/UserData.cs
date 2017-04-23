using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizletNet.Models
{
    public class UserData
    {
        public string username;
        public string account_type;
        public long sign_up_date;
        public string profile_image;

        public UserStaistics statistics;

        public class UserStaistics
        {
            public int study_session_count;
            public int total_answer_count;
            public int public_sets_created;
            public int public_terms_entered;
            public int total_sets_created;
            public int total_terms_entered;
        }
    }
}
