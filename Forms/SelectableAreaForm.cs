using static AIDesktop.AiDesktopService;

namespace AIDesktop
{
    public partial class SelectableAreaForm : Form
    {
        private Bitmap _image;
        
        private int _startX = 0;
        private int _startY = 0;
        private int _width = 0;
        private int _height = 0;

        private bool _isMovingMouse;

        private SaveBitmapDelegate _callBackSaveImage;

        private FormAIDesktop _parentForm;

        public SelectableAreaForm(FormAIDesktop parentForm, Bitmap image, SaveBitmapDelegate callBackSaveImage)
        {
            InitializeComponent();
            _parentForm = parentForm; 
            _image = image;
            _callBackSaveImage = callBackSaveImage;
        }

        private void SelectableAreaForm_Load(object sender, EventArgs e)
        {
            Width = _image.Width;
            Height = _image.Height;
            pictureBoxScreenshot.Width = _image.Width;
            pictureBoxScreenshot.Height = _image.Height;
            pictureBoxScreenshot.Image = _image;

            pictureBoxScreenshot.MouseDown += new MouseEventHandler(SelectableAreaForm_MouseDown);
            pictureBoxScreenshot.MouseUp += new MouseEventHandler(SelectableAreaForm_MouseUp);
            pictureBoxScreenshot.MouseMove += new MouseEventHandler(SelectableAreaForm_MouseMove);

            this.FormClosing += new FormClosingEventHandler(SelectableAreaForm_OnClose);
        }

        private void SelectableAreaForm_OnClose(object? sender, FormClosingEventArgs e)
        {
            // the parent form is hidden when this form loads, so want to show it again before we dispose of this form so that the user has something to interact with
            _parentForm.Show();
            this.Dispose();
        }

        private void SelectableAreaForm_MouseMove(object? sender, MouseEventArgs e)
        {
            if (_isMovingMouse)
            {
                _width = e.X - _startX;
                _height = e.Y - _startY;

                using (var graphics = pictureBoxScreenshot.CreateGraphics())
                {
                    var selectedRectangle = new Rectangle(_startX, _startY, _width, _height);
                    using (var pen = new Pen(Color.Red, 1))
                    {
                        pictureBoxScreenshot.Invalidate();
                        graphics.DrawRectangle(pen, selectedRectangle);
                    }
                }
            }
        }

        private void SelectableAreaForm_MouseDown(object? sender, MouseEventArgs @event)
        {
            _isMovingMouse = true;
            
            _startX = @event.X;
            _startY = @event.Y;
        }

        private void SelectableAreaForm_MouseUp(object? sender, MouseEventArgs @event)
        {
            _isMovingMouse = false;

            // All of the rectangles drawn while selecting the area are removed, so one has to be redrawn when the region selection ends
            using (var graphics = pictureBoxScreenshot.CreateGraphics())
            {
                var selectedRectangle = new Rectangle(_startX, _startY, _width, _height);
                using (var pen = new Pen(Color.Red, 1))
                {
                    graphics.DrawRectangle(pen, selectedRectangle);
                }
            }

            Rectangle selectedArea = new Rectangle(_startX, _startY, _width, _height);
            var areaSection = _image.Clone(selectedArea, _image.PixelFormat);

            _callBackSaveImage.Invoke(areaSection);
            this.Close();
        }
    }
}
