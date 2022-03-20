using static AIDesktop.AiDesktopService;

namespace AIDesktop
{
    public partial class SelectableAreaForm : Form
    {
        Bitmap _image;

        int _startX = 0;
        int _startY = 0;
        int _width = 0;
        int _height = 0;

        bool _isMovingMouse;

        private SaveBitmapDelegate _callBackSaveImage;

        public SelectableAreaForm(Bitmap image, SaveBitmapDelegate callBackSaveImage)
        {
            InitializeComponent();
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

            // add event handlers
            pictureBoxScreenshot.MouseDown += new MouseEventHandler(SelectableAreaForm_MouseDown);
            pictureBoxScreenshot.MouseUp += new MouseEventHandler(SelectableAreaForm_MouseUp);
            pictureBoxScreenshot.MouseMove += new MouseEventHandler(SelectableAreaForm_MouseMove);
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
            this.Dispose();
        }
    }
}
