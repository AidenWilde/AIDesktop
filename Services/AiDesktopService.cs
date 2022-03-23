using AIDesktop.Web;
using System.Drawing.Imaging;

namespace AIDesktop
{
    public interface IAiDesktopService
    {
        public SelectableAreaForm CreateNewSelectableArea();
        public void CaptureScreen(Screen screenToCapture);
        public bool SaveImage();
        public string ReadTextFromSelectedRegionImage();
    }

    public class AiDesktopService : IAiDesktopService
    {
        public delegate void SaveBitmapDelegate(Bitmap bitmap);

        private IAzureApiClient _azureApiClient;

        private string _pathToSaveCapturesTo = @$"C:\Users\Aiden\Desktop\AIDesktop Screenshots\";
        private Bitmap _screenCapture;
        private FormAIDesktop _parentForm;

        private Bitmap _screenCaptureSelectedArea;
        private Bitmap _screenCaptureSelectedAreaCopy;

        public AiDesktopService(FormAIDesktop form)
        {
            _azureApiClient = new AzureApiClient();
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
        }

        public SelectableAreaForm CreateNewSelectableArea()
        {
            var selectableAreaForm = new SelectableAreaForm(_parentForm, _screenCapture, CallBackFunctionDisplayImage);
            selectableAreaForm.StartPosition = FormStartPosition.Manual;
            selectableAreaForm.Location = new Point(0, 0);
            selectableAreaForm.Show();
            return selectableAreaForm;
        }

        private void CallBackFunctionDisplayImage(Bitmap bitmap)
        {
            _screenCaptureSelectedArea = bitmap;
            _parentForm.DisplayImage(_screenCaptureSelectedArea);
        }

        public bool SaveImage()
        {
            if (_screenCaptureSelectedArea == null)
                return false;

            _screenCaptureSelectedArea.Save(_pathToSaveCapturesTo+@$"Capture-{Guid.NewGuid()}.jpg", ImageFormat.Jpeg);
            return true;
        }

        public string ReadTextFromSelectedRegionImage()
        {
            if (_screenCaptureSelectedArea is null)
            {
                MessageBox.Show("Please select a screen(shot) region first");
                return null;
            }

            _screenCaptureSelectedAreaCopy = _screenCaptureSelectedArea;
            var imageBytes = ImageToByteArray(_screenCaptureSelectedAreaCopy);

            var result = _azureApiClient.StartCognitiveServiceReadTextProcess(new Data.CognitiveServicesStartReadResultRequest
            {
                image = imageBytes
            });
            if (result is null)
                MessageBox.Show("Failed to analyse text using Azure Computer Vision Services");

            return result;
        }

        private byte[] ImageToByteArray(Bitmap bitmap)
        {
            using (var stream = new MemoryStream())
            {
                bitmap.Save(stream, ImageFormat.Jpeg);
                return stream.ToArray();
            }
        }

        private Bitmap ResizeBitmap(Bitmap image)
        {
            return new Bitmap(image, new Size(image.Width / 2, image.Height / 2));
        }
    }
}