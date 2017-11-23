using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Hardware;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.IO;
using Android.Text.Format;

namespace MobileApp.Droid
{
    class CameraImageListener : Java.Lang.Object, TextureView.ISurfaceTextureListener, Android.Hardware.Camera.IPictureCallback
    {
        Android.Hardware.Camera _camera;
        string FILE_NAME = "temp.jpg";
        File cacheDir;

        public void OnPictureTaken(byte[] data, Android.Hardware.Camera camera)
        {
            _camera.StopPreview();

            Time now = new Time();
            now.SetToNow();
            FILE_NAME = now.ToMillis(true).ToString();

            FileOutputStream outStream = null;
            if (data != null)
            {
                try
                {
                    outStream = new FileOutputStream(cacheDir + "/" + FILE_NAME);
                    outStream.Write(data);
                    outStream.Close();
                }
                catch (FileNotFoundException e)
                {
                    System.Console.Out.WriteLine(e.Message);
                }
                catch (IOException ie)
                {
                    System.Console.Out.WriteLine(ie.Message);
                }
            }
        }

        public void OnSurfaceTextureAvailable(SurfaceTexture surface, int w, int h)
        {
            _camera = Android.Hardware.Camera.Open();
            _camera.SetDisplayOrientation(90);            

            try
            {
                _camera.SetPreviewTexture(surface);
                _camera.StartPreview();

            }
            catch (Java.IO.IOException ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }

        public bool OnSurfaceTextureDestroyed(
               Android.Graphics.SurfaceTexture surface)
        {
            _camera.StopPreview();
            _camera.Release();

            return true;
        }

        public void OnSurfaceTextureSizeChanged(SurfaceTexture surface, int width, int height)
        {
        }

        public void OnSurfaceTextureUpdated(SurfaceTexture surface)
        {
            Android.Hardware.Camera.Parameters mParameters = _camera.GetParameters();
            mParameters.FocusMode = Android.Hardware.Camera.Parameters.FocusModeContinuousPicture;
            _camera.SetParameters(mParameters);
            
        }

        public string TakePhoto(File cacheDir)
        {
            this.cacheDir = cacheDir;
            Android.Hardware.Camera.Parameters p = _camera.GetParameters();
            p.PictureFormat = ImageFormatType.Jpeg;
            _camera.SetParameters(p);
            _camera.TakePicture(null, null, this);

            //_camera.StopPreview();

            return FILE_NAME;
        }

        public void StartPreview()
        {
            _camera.StartPreview();
        }
        
    }
}