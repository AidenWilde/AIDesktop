namespace AIDesktop
{
    public partial class FormAIDesktop : Form
    {
        private IAiDesktopService _aiDesktopService;
        private Screen _selectedDisplay;

        public FormAIDesktop()
        {
            InitializeComponent();
            _aiDesktopService = new AiDesktopService();
        }

        private void FormAIDesktop_Load(object sender, EventArgs e)
        {
            foreach(var screen in Screen.AllScreens)
            {
                listBoxDisplays.Items.Add($"{screen.DeviceName}");// || {screen.Bounds.Width} {screen.Bounds.Height}");
            }
        }

        private void buttonSelectRegion_Click(object sender, EventArgs e)
        {
            if (_selectedDisplay == null)
            {
                MessageBox.Show("Please select a display first.");
                return;
            }

            _aiDesktopService.CaptureScreen(_selectedDisplay, @$"C:\Users\Aiden\Desktop\AIDesktop Screenshots\Capture{Guid.NewGuid()}.jpg"); // change directory to selectable path eventually
        }

        private void buttonLookup_Click(object sender, EventArgs e)
        {

        }

        private void listBoxDisplays_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxDisplays.SelectedIndex == -1 || listBoxDisplays.SelectedIndex == null)
                return;

            var selectedDisplayName = listBoxDisplays.SelectedItem?.ToString();
            _selectedDisplay = FindDisplayByName(selectedDisplayName);
        }

        private Screen FindDisplayByName(string displayName)
        {
            return Screen.AllScreens.First(x => x.DeviceName == displayName);
        }
    }
}