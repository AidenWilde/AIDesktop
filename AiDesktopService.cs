using System.Drawing.Imaging;

namespace AIDesktop
{
    public interface IAiDesktopService
    {
        public void CaptureScreen(Screen screenToCapture, string pathToSaveCapturesTo);
    }

    public class AiDesktopService : IAiDesktopService
    {
        public AiDesktopService()
        {
        }

        public void CaptureScreen(Screen screenToCapture, string pathToSaveCapturesTo)
        {
            var captureBitmap = new Bitmap(screenToCapture.WorkingArea.Width, screenToCapture.WorkingArea.Height, PixelFormat.Format32bppArgb);
            var captureGraphics = Graphics.FromImage(captureBitmap);

            captureGraphics.CopyFromScreen(screenToCapture.WorkingArea.Left, screenToCapture.WorkingArea.Top, 0, 0, screenToCapture.WorkingArea.Size);
            captureBitmap.Save(pathToSaveCapturesTo, ImageFormat.Jpeg);
        }
    }
}