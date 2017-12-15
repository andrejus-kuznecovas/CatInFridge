using Android.App;
using Android.Content.PM;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V4.App;
using System.IO;
using Android.Graphics;
using Java.IO;

namespace MobileApp.Droid
{
    [Activity(Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FragmentActivity
    {
        TextureView _textureView;
        CameraImageListener listener;
        string PHOTO_PATH;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            Main.InitMain();

            listener = new CameraImageListener();
            _textureView = (TextureView)FindViewById(Resource.Id.textureView1);
            _textureView.SurfaceTextureListener = listener;

            Button photoBtn = (Button)FindViewById(Resource.Id.buttonTakePhoto);
            Button dismissBtn = (Button)FindViewById(Resource.Id.buttonDismissPhoto);
            Button nextBtn = (Button)FindViewById(Resource.Id.buttonNext);

            photoBtn.Click += delegate
            {
                listener.TakePhoto(CacheDir);

                photoBtn.Visibility = ViewStates.Invisible;
                dismissBtn.Visibility = ViewStates.Visible;
                nextBtn.Visibility = ViewStates.Visible;
            };

            dismissBtn.Click += delegate
            {
                listener.StartPreview();

                photoBtn.Visibility = ViewStates.Visible;
                dismissBtn.Visibility = ViewStates.Invisible;
                nextBtn.Visibility = ViewStates.Invisible;
            };

            nextBtn.Click += delegate
            {
                PHOTO_PATH = CacheDir + "/" + listener.FILE_NAME;

                Java.IO.File file = new Java.IO.File(PHOTO_PATH);
                bool a = file.Exists();

                Bitmap bitmap = BitmapFactory.DecodeFile(PHOTO_PATH);
                MemoryStream ms = new MemoryStream();
                bitmap.Compress(Bitmap.CompressFormat.Jpeg, 100, ms);
                byte[] bitmapBytes = ms.GetBuffer();
                Main.wcf.GetPricesAsync(bitmapBytes);

                StartActivity(typeof(EditActivity));
            };
        }        
    }
}