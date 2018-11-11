using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TwitterSampleAppWPF
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        // OAuth認証のクラス
        TwitterCertification twitter_certification = new TwitterCertification();

        // Streaming APIのクラス
        TwitterStreaming twitter_streaming = new TwitterStreaming();

        // REST APIのクラス
        TwitterREST twitter_rest = new TwitterREST();


        public MainWindow()
        {
            InitializeComponent();
        }

        /*
         * OAuth認証のPINコード取得を行うイベントハンドラ
         */
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            twitter_certification.getPinCode();
        }

        /*
         * OAuth認証のトークン取得を行うイベントハンドラ
         */
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            twitter_certification.pin_code = textBox.Text;
            twitter_certification.getTokens();
        }

        /*
         * 既に発行されたトークンで認証するイベントハンドラ
         */
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            twitter_certification.createTokens();
        }

        /*
         * ツイートの投稿を行うイベントハンドラ
         */
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (twitter_certification.tokens != null)
            {
                twitter_rest.tokens = twitter_certification.tokens;
                twitter_rest.Tweet();
            }
        }

        /*
         * タイムラインを取得するイベントハンドラ
         */
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (twitter_certification.tokens != null)
            {
                twitter_streaming.tokens = twitter_certification.tokens;
                twitter_streaming.StreamingHomeTimeLine();
            }
        }

        /*
         * 特定の単語を含むツイートを取得するイベントハンドラ
         */
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (twitter_certification.tokens != null)
            {
                twitter_streaming.tokens = twitter_certification.tokens;
                var word = textBox_word.Text;
                twitter_streaming.StreamingSearch(word);
            }
        }
    }
}
