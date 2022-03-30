using System;
using System.Windows.Forms;

namespace TokenHelper
{
    public partial class Form1 : Form
    {
        private ExtractJwtBearerTokenService _tokenService;

        public Form1()
        {
            InitializeComponent();
            _tokenService = new ExtractJwtBearerTokenService();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ExtractTokenStripMenuItem_Click(object sender, EventArgs e)
        {
            var idat = Clipboard.GetDataObject();
            var text = idat.GetData(DataFormats.Text) as string;

            _tokenService.Input = text;

            try
            {
                _tokenService.Extract();
                Clipboard.SetText(_tokenService.Output);
            }
            catch (TokenExtractionException ex)
            {
                DisplayErrorMessage("The text in the clipboard does not contain any recognizable token");
            }

            //-------------------------------------------------------------------------

            void DisplayErrorMessage(string message)
            {
                MessageBox.Show(
                   message,
                   "Extraction failed",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Exclamation,
                   MessageBoxDefaultButton.Button1
                );
            }
        }
    }
}