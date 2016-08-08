using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace UrlShortcutCreator.Services
{
    public class UrlShortcutSingletonService
    {
        // 単一のインスタンス。
        public static UrlShortcutSingletonService _singleton = new UrlShortcutSingletonService();

        /// <summary>
        /// 単一のインスタンスを取得します。
        /// </summary>
        /// <returns>単一のインスタンスを返します。</returns>
        public static UrlShortcutSingletonService GetInstance()
        {
            return _singleton;
        }

        /// <summary>
        /// インスタンス化禁止。
        /// </summary>
        private UrlShortcutSingletonService()
        {
        }

        /// <summary>
        /// URLの妥当性を検証します。
        /// </summary>
        /// <param name="url">検証対象のURL</param>
        /// <returns>検証結果を返します。</returns>
        public bool UrlValidation(string url)
        {
            return Regex.IsMatch(url, "^s?https?://[-_.!~*'()a-zA-Z0-9;/?:@&=+$,%#]+$");
        }

        /// <summary>
        /// クリップボード内のURLを取得します。
        /// </summary>
        /// <returns>取得したURLを返します。</returns>
        public string GetUrlInClipboard()
        {
            // 結果値用の変数。
            var result = string.Empty;

            // クリップボードからデータを取得します。
            IDataObject clipboardData = Clipboard.GetDataObject();

            // クリップボードのデータが存在するかを判定します。
            if (clipboardData.GetDataPresent(DataFormats.Text))
            {
                // クリップボードのデータを文字列として取得します。
                var str = (string)clipboardData.GetData(DataFormats.Text);
                str = str.Trim();

                // URLの書式の場合はURLテキストボックスに値を設定します。
                if (this.UrlValidation(str)) result = str;
            }

            return result;
        }

        // ショートカット文字列。
        private static readonly string SHOTCUT_STRING = "[InternetShortcut]";

        // URL文字列。
        private static readonly string URL_STRING_TMP = "URL={0}";

        /// <summary>
        /// URLショートカットを作成します。
        /// </summary>
        /// <param name="url">ショートカットを作成するURL。</param>
        /// <param name="path">ショートカットを作成するファイルパス。</param>
        public void CreateUrlShortcut(string url, string path)
        {
            // 文字列生成クラスのインスタンスを取得します。
            var sb = new StringBuilder();

            // ショートカット文字列を生成します。
            sb.AppendLine(SHOTCUT_STRING);
            sb.AppendFormat(URL_STRING_TMP,url);

            // ファイル出力用のストリームを作成します。
            using (var sw = new StreamWriter(path))
            {
                try
                {
                    // ファイルを書き込みます。
                    sw.Write(sb.ToString());
                }
                finally
                {
                    // ストリームを閉じます。
                    sw.Close();
                }
            }
        }

        // UTF8を示すキャクターセット文字列。
        private static readonly string CHARSET_UTF_LOWER = "utf-8";

        // shift_jisを示すキャクターセット文字列。
        private static readonly string CHARSET_SHIFT_JIS_LOWER = "shift";

        // タイトル開始タグの文字列。
        private static readonly string START_TITLE_TAG_STRING = "<title>";

        // タイトル終了タグの文字列。
        private static readonly string END_TITLE_TAG_STRING = "</title>";

        // スペースを表す文字列。
        private static readonly string SPACE_STRING = "&nbsp;";

        /// <summary>
        /// WEBページのタイトルを取得します。
        /// </summary>
        /// <param name="url">対象のWEBページのURL。</param>
        /// <param name="removeInvalidFileNameChars">ファイルに使用出来ない文字を取り除くかを判定します。(省略可)</param>
        /// <returns>タイトルを返します。</returns>
        public string GetWebPageTitle(string url, bool removeInvalidFileNameChars = false)
        {
            try
            {
                // HTMLソース格納用変数。
                string source;

                // WebClientをインスタンス化します。
                using (var wc = new WebClient())
                {
                    // Content-Typeを取得します。
                    wc.DownloadData(new Uri(url));
                    var contentTypes = wc.ResponseHeaders.GetValues("Content-Type");

                    // Content-Typeが存在しない場合は空文字を返します。
                    if (contentTypes.Length == 0) return string.Empty;

                    // Content-Typeを小文字化して取得します。
                    var ct = contentTypes[0].ToLower();

                    // エンコード用の変数。
                    Encoding enc;

                    // UTF文字列が含まれるか判定します。
                    if (ct.IndexOf(CHARSET_UTF_LOWER) > 1)
                        // エンコードにUTF8を設定します。
                        enc = Encoding.UTF8;
                    // shift文字列が含まれるか判定します。
                    else if (ct.IndexOf(CHARSET_SHIFT_JIS_LOWER) > 1)
                        // エンコードにShift-JISを設定します。
                        enc = Encoding.GetEncoding(932);
                    else
                        // エンコードが見つからない場合は空文字を返します。
                        return string.Empty;

                    // WebClientにエンコードを設定します。
                    wc.Encoding = enc;

                    // 対象のWEBページのHTMLソースを取得します。
                    source = wc.DownloadString(new Uri(url));
                }

                // 正規表現パターンとオプションを指定してRegexオブジェクトを作成します。
                MatchCollection mc = Regex.Matches(source, START_TITLE_TAG_STRING + ".*" + END_TITLE_TAG_STRING, RegexOptions.IgnoreCase | RegexOptions.Singleline);

                // タイトルタグを取り除いた文字列を取得します。
                var result = mc[0].Groups[0].Value.Replace(START_TITLE_TAG_STRING, string.Empty).Replace(END_TITLE_TAG_STRING, string.Empty);

                // スペースを表す文字列が含まれるかを判定します。
                if (result.Contains(SPACE_STRING))
                    // スペースを表す文字列を取り除きます。
                    result = result.Replace(SPACE_STRING, "_");

                // ファイル名に使用できない文字を取り除くかを判定します。
                if (removeInvalidFileNameChars)
                    // ファイル名に使用できない文字を取り除きます。
                    result = this.ReplaceChar(result, '_', Path.GetInvalidFileNameChars());

                return result;
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 文字を置換します。
        /// </summary>
        /// <param name="str">置換対象の文字列。</param>
        /// <param name="replaceChar">置換する文字。</param>
        /// <param name="replacedChars">置換される文字。</param>
        /// <returns>置換した文字列を返します。</returns>
        public string ReplaceChar(string str, char replaceChar, params char[] replacedChars)
        {
            // 結果値用の変数。
            var result = str;

            // 禁則文字を置換します。
            Array.ForEach(replacedChars, c => { result = result.Replace(c, replaceChar); });

            return result;
        }
    }
}
