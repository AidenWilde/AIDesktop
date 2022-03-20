using System.Drawing.Imaging;

namespace AIDesktop
{
    public interface IAiDesktopService
    {
        public void CaptureScreen(Screen screenToCapture);
    }

    public class AiDesktopService : IAiDesktopService
    {
        public delegate void SaveBitmapDelegate(Bitmap bitmap);

        private string _pathToSaveCapturesTo = @$"C:\Users\Aiden\Desktop\AIDesktop Screenshots\";
        private Bitmap _screenCapture;
        private Form _parentForm;

        private SelectableAreaForm _selectableAreaForm;

        public AiDesktopService(Form form)
        {
            _parentForm = form;
        }

        public void CaptureScreen(Screen screenToCapture)
        {
            int bufferTimeForFormToHide = 250;
            _parentForm.Hide();
            Thread.Sleep(bufferTimeForFormToHide);

            _screenCapture = new Bitmap(screenToCapture.WorkingArea.Width, screenToCapture.WorkingArea.Height, PixelFormat.Format32bppArgb);

            var captureGraphics = Graphics.FromImage(_screenCapture);
            captureGraphics.CopyFromScreen(screenToCapture.WorkingArea.Left, screenToCapture.WorkingArea.Top, 0, 0, screenToCapture.WorkingArea.Size);

            _selectableAreaForm = new SelectableAreaForm(_screenCapture, CallBackSaveImage);
            _selectableAreaForm.Show();

            _parentForm.Show();
        }

        public void CallBackSaveImage(Bitmap bitmap)
        {
            bitmap.Save(_pathToSaveCapturesTo + $"Capture{Guid.NewGuid()}.jpg", ImageFormat.Jpeg);
        }

        private Bitmap ResizeBitmap(Bitmap image)
        {
            return new Bitmap(image, new Size(image.Width / 2, image.Height / 2));
        }
    }
}