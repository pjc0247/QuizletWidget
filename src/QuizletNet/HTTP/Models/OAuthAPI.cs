using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizletNet.HTTP.Models
{
    class OAuthTokenResponse
    {
        public string access_token;
        public string token_type;
        public int expires_in;
        public string scope;
        public string user_id;
    }
}
