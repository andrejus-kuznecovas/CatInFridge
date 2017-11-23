using Android.Graphics;
using System;

namespace LoginSystem
{
    public class RecognitionBuilder 
    {
        private ITextRecognition _itextregonition;

        public RecognitionBuilder(ITextRecognition textRecognition, Bitmap image, EventHandler<OCRInfo> action)
        {
            this._itextregonition = textRecognition;
            textRecognition.GetTextFromImage(image);
            textRecognition.AddOnCompleteHandler(action);
        }
    }

}