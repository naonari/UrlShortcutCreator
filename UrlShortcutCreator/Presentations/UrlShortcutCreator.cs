using System;
using System.IO;
using System.Windows.Forms;
using NexFx.Controls;
using UrlShortcutCreator.Services;
using UrlShortcutCreator.Resources;

namespace UrlShortcutCreator.Presentations
{
    public partial class UrlShortcutCreator : ExForm
    {
        /// <summary>
        /// コンストラクタ定義。
        /// </summary>
        public UrlShortcutCreator()
        {
            // 初期設定を行います。
            InitializeComponent();
        }

        /// <summary>
        /// 画面読込時の処理を行います。
        /// </summary>
        private void UrlShortcutCreator_Load(object sender, EventArgs e)
        {
            // 初期化処理を行います。
            this.UrlShortcutCreator_Initialize();
        }

        /// <summary>
        /// 初期化処理を行います。
        /// </summary>
        private void UrlShortcutCreator_Initialize()
        {
            // 各コントローラを初期化します。
            this.cbGetTitle.Checked = false;
            this.txtFileName.Clear();
            this.txtUrl.Clear();

            // 初期フォーカスを設定します。
            this.txtFileName.Focus();

            // サービスを取得します。
            var usss = UrlShortcutSingletonService.GetInstance();

            // クリップボード内のURLを取得します。
            this.txtUrl.Text = usss.GetUrlInClipboard();
        }

        // ショートカットの拡張子。
        private static readonly string SHOTCUT_EXTENSION = ".url";

        /// <summary>
        /// URL入力のフォーカス喪失時の処理を行います。
        /// </summary>
        private void txtUrl_Leave(object sender, EventArgs e)
        {
            // サービスを取得します。
            var usss = UrlShortcutSingletonService.GetInstance();

            // タイトル取得チェックボックスがチェック済、かつファイル名が未入力、かつURLの書式が正しいかを判定します。
            if (this.cbGetTitle.Checked && usss.UrlValidation(this.txtUrl.Text))
                // WEBページのタイトルを設定します。
                this.txtFileName.Text = usss.GetWebPageTitle(this.txtUrl.Text, true);
        }

        /// <summary>
        /// 実行ボタン押下時の処理を行います。
        /// </summary>
        private void btnExecute_Click(object sender, EventArgs e)
        {
            // ファイルパスを設定します。
            var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), this.txtFileName.Text.Trim() + SHOTCUT_EXTENSION);

            // サービスを取得します。
            var usss = UrlShortcutSingletonService.GetInstance();

            // URLが未入力かを判定します。
            if (string.IsNullOrWhiteSpace(this.txtUrl.Text))
            {
                // エラーメッセージを表示します。
                MessageBox.Show(Messages.E0001, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // URLの書式を判定します。
            if (!usss.UrlValidation(this.txtUrl.Text))
            {
                MessageBox.Show(Messages.E0002, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ファイル名が未入力かを判定します。
            if (string.IsNullOrWhiteSpace(this.txtFileName.Text))
            {
                // エラーメッセージを表示します。
                MessageBox.Show(Messages.E0003, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ファイル名に禁則文字が含まれているかを判定します。
            if (this.txtFileName.Text.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
            {
                // エラーメッセージを表示します。
                MessageBox.Show(Messages.E0004, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ファイルの存在確認を行います。
            if (File.Exists(filePath))
                // ファイルの上書き確認を行います。
                if (!DialogResult.Yes.Equals(MessageBox.Show(Messages.Q0001, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question))) return;

            try
            {
                // URLショートカットを作成します。
                usss.CreateUrlShortcut(this.txtUrl.Text, filePath);
            }
            catch (Exception ex)
            {
                // エラーメッセージを表示します。
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 初期化処理を行います。
            this.UrlShortcutCreator_Initialize();
        }

        /// <summary>
        /// キー押下時の処理を行います。
        /// </summary>
        private void UrlShortcutCreator_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
            {
                //アプリケーションを終了する。
                this.Close();

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
