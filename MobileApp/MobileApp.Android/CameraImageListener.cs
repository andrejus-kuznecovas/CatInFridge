using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MobileApp.Droid
{
    class CameraImageListener : Java.Lang.Object, TextureView.ISurfaceTextureListener
    {
        Android.Hardware.Camera _camera;
                
        public void OnSurfaceTextureAvailable(
       Android.Graphics.SurfaceTexture surface, int w, int h)
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
                Console.WriteLine(ex.Message);
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

            _camera.StartPreview();
        }
        
    }
}