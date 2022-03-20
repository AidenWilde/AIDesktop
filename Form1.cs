namespace AIDesktop
{
    public partial class FormAIDesktop : Form
    {
        private IAiDesktopService _aiDesktopService;

        public FormAIDesktop()
        {
            InitializeComponent();
            _aiDesktopService = new AiDesktopService();
        }

        private void FormAIDesktop_Load(object sender, EventArgs e)
        {

        }

        private void buttonSelectRegion_Click(object sender, EventArgs e)
        {
            var screenToCapture = Screen.FromPoint(this.Location);
            _aiDesktopService.CaptureScreen(screenToCapture, @$"C:\Users\Aiden\Desktop\AIDesktop Screenshots\Capture{Guid.NewGuid()}.jpg"); // change directory to selectable path eventually
        }

        private void buttonLookup_Click(object sender, EventArgs e)
        {

        }
    }
}