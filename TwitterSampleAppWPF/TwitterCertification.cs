using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreTweet;

namespace TwitterSampleAppWPF
{
    class TwitterCertification
    {
        OAuth.OAuthSession session;
        public Tokens tokens;
        public String pin_code;

        private string ConsumerKey = ":xxxxxxxx";
        private string ConsumerSecret = "xxxxxxxx";
        private string AccessToken = "xxxxxxxx";
        private string AccessSecret = "xxxxxxxx";

        /*
         * OAuth認証を行う関数群
         * ・getPinCode() : PINコードを取得する関数
         * ・getTokens()  : トークンを取得する関数
         */

        /*
         * PINコードを取得する関数
         */
        public void getPinCode()
        {
            // PINを発行する
            session = CoreTweet.OAuth.Authorize(this.ConsumerKey, this.ConsumerSecret);

            // 認証URLを得る
            var url = session.AuthorizeUri;

            // 認証URLを既定のブラウザで開く
            System.Diagnostics.Process.Start(url.AbsoluteUri);
        }

        /*
         * トークンを取得する関数
         */
        public void getTokens()
        {
            // PINコードを用いてトークンを取得する
            this.tokens = OAuth.GetTokens(this.session, this.pin_code);
        }

        /*
         * 既に発行されたトークンを用いて認証を行う関数
         */
        public void createTokens()
        {
            // 既に発行されたトークンを取得する
            this.tokens = CoreTweet.Tokens.Create(this.ConsumerKey, this.ConsumerSecret, this.AccessToken, this.AccessSecret);
        }
    }
}
