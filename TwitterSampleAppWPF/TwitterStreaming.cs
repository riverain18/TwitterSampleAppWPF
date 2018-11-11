using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreTweet;
using CoreTweet.Streaming;

namespace TwitterSampleAppWPF
{
    class TwitterStreaming
    {
        public Tokens tokens;
        public int count = 10;
        public int length = 60;

        /*
         * Home TimeLineのツイートをコンソールに出力する関数
         */
        public void StreamingHomeTimeLine()
        {
            foreach (var status in this.tokens.Statuses.HomeTimeline(count => this.count).Where(x => x.Text.Length > this.length))
                Console.WriteLine("{0}: {1}", status.User.ScreenName, status.Text.Replace("\n", ""));
        }

        /*
         * 特定の単語を含むツイートを出力する関数
         */
        public void StreamingSearch(String word)
        {
            foreach (var m in this.tokens.Streaming.Filter(track: word)
                        .OfType<StatusMessage>()
                        .Select(x => x.Status)
                        .Take(this.count))
                Console.WriteLine(word + "を含むTweet {0}: {1}", m.User.ScreenName, m.Text.Replace("\n", ""));
        }
    }
}
