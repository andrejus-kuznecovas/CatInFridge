using System;
using Android.App;
using System.Threading.Tasks;
using Tesseract.Droid;
using Android.Graphics;
using System.IO;

namespace LoginSystem
{
    public class RecognitionTest : ITextRecognition
    {
        // Event to be called after the recognition is done
        private EventHandler<OCRInfo> OnOCRCompleteTest;

        public void AddOnCompleteHandler(EventHandler<OCRInfo> action)
        {
            OnOCRCompleteTest = action;
        }


        public void GetTextFromImage(Bitmap image)
        {
                
        }
    }
 }
