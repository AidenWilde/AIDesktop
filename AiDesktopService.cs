using System.Drawing.Imaging;

namespace AIDesktop
{
    public interface IAiDesktopService
    {
        public void CaptureScreen(Screen screenToCapture, string pathToSaveCapturesTo);
    }

    public class AiDesktopService : IAiDesktopService
    {
        private Form _parentForm;

        public AiDesktopService(Form form)
        {
            _parentForm = form;
        }

        public void CaptureScreen(Screen screenToCapture, string pathToSaveCapturesTo)
        {
            _parentForm.Hide();
            Thread.Sleep(250);

            var captureBitmap = new Bitmap(screenToCapture.WorkingArea.Width, screenToCapture.WorkingArea.Height, PixelFormat.Format32bppArgb);
            var captureGraphics = Graphics.FromImage(captureBitmap);

            captureGraphics.CopyFromScreen(screenToCapture.WorkingArea.Left, screenToCapture.WorkingArea.Top, 0, 0, screenToCapture.WorkingArea.Size);
            captureBitmap.Save(pathToSaveCapturesTo, ImageFormat.Jpeg);

            // TODO: test

            _parentForm.Show();
        }
    }
}