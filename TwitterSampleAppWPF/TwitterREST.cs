using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreTweet;

namespace TwitterSampleAppWPF
{
    class TwitterREST
    {
        public Tokens tokens;
        public String text = "Test Tweet";

        /*
         * ツイートを投稿する関数
         */
        public void Tweet()
        {
            this.tokens.Statuses.Update(status => this.text);
        }
    }
}
