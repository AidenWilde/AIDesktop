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

        private SelectableAreaForm _selectableAreaForm;

        public AiDesktopService(Form form)
        {
            _parentForm = form;
        }

        public void CaptureScreen(Screen screenToCapture, string pathToSaveCapturesTo)
        {
            int bufferTimeForFormToHide = 250;
            _parentForm.Hide();
            Thread.Sleep(bufferTimeForFormToHide);

            var screenCapture = new Bitmap(screenToCapture.WorkingArea.Width, screenToCapture.WorkingArea.Height, PixelFormat.Format32bppArgb);

            var captureGraphics = Graphics.FromImage(screenCapture);
            captureGraphics.CopyFromScreen(screenToCapture.WorkingArea.Left, screenToCapture.WorkingArea.Top, 0, 0, screenToCapture.WorkingArea.Size);

            //captureBitmap.Save(pathToSaveCapturesTo, ImageFormat.Jpeg);

            // create new form, make it transparent with a border, with a button that says 'capture')
            // -- this can be edited later, but works for now

            
            _selectableAreaForm = new SelectableAreaForm(screenCapture);
            _selectableAreaForm.Show();


            _parentForm.Show();
        }

        private Bitmap ResizeBitmap(Bitmap image)
        {
            return new Bitmap(image, new Size(image.Width / 2, image.Height / 2));
        }
    }
}