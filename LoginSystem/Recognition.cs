using System;
using System.Threading.Tasks;
using Android.App;
using Net.Doo.Snap.Process;
using Net.Doo.Snap.Persistence;
using Net.Doo.Snap.Blob;
using System.Collections.Generic;
using Net.Doo.Snap.Entity;
using Android.Graphics;
using Net.Doo.Snap.Util;
using ScanbotSDK.Xamarin.Android.Wrapper;


//Packages need to be downloaded manually. Download Scanbot.
//Class is not used because OCR works badly
namespace LoginSystem
{

    public class Recognition : ITextRecognition
    {

        private const string licenseKey = "QarRdq9Wq2yitCl2WG0aCme15JOLNb" +
      "cZmKpv/x7gxYuO6HkvY4+9IPff/xPH" +
      "C3lWm6if5r28+u/CofIkdEENrEE+T8" +
      "cvu1KJnajXYFOTIhyNnU0xwgWAZZ1Z" +
      "2JVf1ikji4zj+BW8RbcpJEeVqTbWDz" +
      "/dwAezx7BeHsrR/hEH93kJRjC1d8Jm" +
      "vf76p9aj0cNJ/oQ0erfYADQfH1uufH" +
      "hhsVhdqVlR88hUTGkkV5slFmAJJBtg" +
      "1OzyLcckycCO9Zo+bEaHDrkEDsqInJ" +
      "I79PlUfBOE1hTsBomFryQU0BZfseTQ" +
      "HxDgptU+JV8YHiLpQ+7bCMiCe9mMIw" +
      "oxSrWvtLN5rQ==\nU2NhbmJvdFNESw" +
      "ptaWYudnUuYmlsbHkKMTUxMjI1OTE5" +
      "OQo5NAoy\n";



        private static List<Language> ocrLanguages = new List<Language>();
        private PageFactory pageFactory;
        private ITextRecognition textRecognition;
        private BlobManager blobManager;
        private BlobFactory blobFactory;
        private Activity activity;


        /// <summary>
        /// Event to happen when the text is successfully detected
        /// </summary>
        private EventHandler<OCRInfo> OnOCRComplete;

        public void AddOnCompleteHandler(EventHandler<OCRInfo> action)
        {
            OnOCRComplete = action;
        }

        public ImageRecognitionScanbot(Activity activity)
        {

            // Initialize all the components needed for the SDK

            this.activity = activity;

            // Set recognition languages
            ocrLanguages.Add(Language.Lit); // OR ocrLanguages.Add(Language.Eng);
        


            var scanbotSDK = new Net.Doo.Snap.ScanbotSDK(activity);
            pageFactory = scanbotSDK.PageFactory();
            textRecognition = scanbotSDK.TextRecognition();
            blobManager = scanbotSDK.BlobManager();
            blobFactory = scanbotSDK.BlobFactory();
            FetchOcrBlobFiles();
        }

        private List<Blob> OcrBlobs()
        {
            // Create a collection of required OCR blobs:
            var blobs = new List<Blob>();

            // Language detector blobs of the Scanbot SDK.
            foreach (var b in blobFactory.LanguageDetectorBlobs())
            {
                blobs.Add(b);
            }

            // OCR blobs of languages (see "ocr_blobs_path" in AndroidManifest.xml!)
            foreach (var lng in ocrLanguages)
            {
                foreach (var b in blobFactory.OcrLanguageBlobs(lng))
                {
                    blobs.Add(b);
                }
            }

            return blobs;
        }


        private void FetchOcrBlobFiles()
        {
            // Fetch OCR blob files (should be defined in Android.xml manifest, but not used right now because OCR works badly)
            Task.Run(() =>
            {
                try
                {
                    foreach (var blob in OcrBlobs())
                    {
                        if (!blobManager.IsBlobAvailable(blob))
                        {
                            System.Diagnostics.Debug.WriteLine("Fetching OCR blob file: " + blob);
                            blobManager.Fetch(blob, false);
                        }
                    }
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("Error fetching OCR blob files", e);
                }
            });
        }

        /// <summary>
        /// Perform OCR and get text from the given image
        /// </summary>
        /// <param name="image">Text from the image</param>
        public void GetTextFromImage(Bitmap image)
        {
            try
            {
                // Turn image into Page (needed for OCR)
                TempImageStorage storage = new TempImageStorage();
                storage.AddImage(image);
                var images = storage.GetImages();

                var path = FileChooserUtils.GetPath(activity, images[0]);
                var imageFile = new Java.IO.File(path);
                var pages = new List<Page>();
                var page = pageFactory.BuildPage(imageFile);
                pages.Add(page);

                // Result of the whole recognition
                var fullOcrResult = textRecognition.WithoutPDF(ocrLanguages, pages).Recognize();

                // Call the event in the case of success
                if (OnOCRComplete != null)
                {
                    // Save the recognized text in the event argument
                    activity.RunOnUiThread(() => OnOCRComplete(this, new OCRInfo(fullOcrResult.RecognizedText)));

                }

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Error performing OCR" + e.Message);
            }
        }



    }
}