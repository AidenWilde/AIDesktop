using AIDesktop.Forms;

namespace AIDesktop
{
    public partial class FormAIDesktop : Form
    {
        private IAiDesktopService _aiDesktopService;
        private Screen _selectedDisplay;

        public FormAIDesktop()
        {
            InitializeComponent();
            _aiDesktopService = new AiDesktopService(this);
        }

        private void FormAIDesktop_Load(object sender, EventArgs e)
        {
            foreach(var screen in Screen.AllScreens)
            {
                listBoxDisplays.Items.Add($"{screen.DeviceName}");// || {screen.Bounds.Width} {screen.Bounds.Height}");
            }

            pictureBoxScreenshotSection.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void buttonSelectRegion_Click(object sender, EventArgs e)
        {
            if (_selectedDisplay == null)
            {
                MessageBox.Show("Please select a display first");
                return;
            }

            _aiDesktopService.CaptureScreen(_selectedDisplay); // change directory to selectable path eventually
            _aiDesktopService.CreateNewSelectableArea();
        }

        public void DisplayImage(Bitmap bitmap)
        {
            pictureBoxScreenshotSection.Image = bitmap;
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

        private void buttonSaveImage_Click(object sender, EventArgs e)
        {
            if (_aiDesktopService.SaveImage() is false)
                MessageBox.Show("Please select an area to save first using Select Region");
            else 
                MessageBox.Show("Successfully saved image");
        }

        private void buttonShowAiFunctions_Click(object sender, EventArgs e)
        {
            var aiFunctionsForm = new AiFunctionsForm(this, _aiDesktopService);
            aiFunctionsForm.Show();
        }
    }
}