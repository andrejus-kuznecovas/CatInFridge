using System;

namespace Login.Source.Controllers.OCR
{
    /// <summary>
    /// Event Args that have Recognition text in it
    /// </summary>
    public class OCRInfo : EventArgs
    {
        public string text;

        public OCRInfo(string text)
        {
            this.text = text;
        }

    }
}