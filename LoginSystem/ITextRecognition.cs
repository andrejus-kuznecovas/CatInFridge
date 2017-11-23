using Android.Graphics;
using System;

namespace LoginSystem
{
    public interface ITextRecognition
    {
        void GetTextFromImage(Bitmap image);

        void AddOnCompleteHandler(EventHandler<OCRInfo> action);
    }
}