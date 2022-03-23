namespace AIDesktop.Forms
{
    public partial class AiFunctionsForm : Form
    {
        private FormAIDesktop _parentForm;
        private IAiDesktopService _aiDesktopService;

        public AiFunctionsForm(FormAIDesktop parentForm, IAiDesktopService aiDesktopService)
        {
            InitializeComponent();
            _parentForm = parentForm;
            _aiDesktopService = aiDesktopService;
        }

        private void buttonReadTextFromImage_Click(object sender, EventArgs e)
        {
            _aiDesktopService.ReadTextFromSelectedRegionImage();
        }
    }
}
