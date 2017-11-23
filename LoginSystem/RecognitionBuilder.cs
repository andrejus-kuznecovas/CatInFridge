using Android.Graphics;
using System;

namespace LoginSystem
{
    public class RecognitionBuilder 
    {
        private ITextRecognition _itextregonition;

        public RecognitionBuilder(ITextRecognition textRecognition)
        {
            textRecognition = new RecognitionTesseract();
            textRecognition = new Recognition();

          /*this._itextregonition = textRecognition;
            textRecognition.GetTextFromImage(image);
            textRecognition.AddOnCompleteHandler(action);*/
           /* , Bitmap image, EventHandler< OCRInfo > action*/
        }
    }

}