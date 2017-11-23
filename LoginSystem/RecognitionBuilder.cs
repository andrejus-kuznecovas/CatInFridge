using Android.Graphics;
using System;

namespace LoginSystem
{
    public class RecognitionBuilder 
    {
        private ITextRecognition _itextregonition;

        public RecognitionBuilder(ITextRecognition textRecognition, Bitmap image)
        {
            this._itextregonition = textRecognition;
            textRecognition.GetTextFromImage(image);
        }
    }

}