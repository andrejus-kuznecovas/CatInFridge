using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V4.App;
using System.Threading;

namespace MobileApp.Droid
{
    [Activity(Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FragmentActivity
    {
        TextureView _textureView;
        ImageView _imageView;
        CameraImageListener listener;
        string PHOTO_PATH;

        Button photoBtn;
        Button dismissBtn;
        Button nextBtn;
        Button galleryBtn;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            //Main.InitMain();

            listener = new CameraImageListener();
            _textureView = (TextureView)FindViewById(Resource.Id.textureView1);
            _textureView.SurfaceTextureListener = listener;

            _imageView = (ImageView)FindViewById(Resource.Id.imageView1);

            photoBtn = (Button)FindViewById(Resource.Id.buttonTakePhoto);
            dismissBtn = (Button)FindViewById(Resource.Id.buttonDismissPhoto);
            nextBtn = (Button)FindViewById(Resource.Id.buttonNext);
            galleryBtn = (Button)FindViewById(Resource.Id.buttonGallery);


            photoBtn.Click += delegate
            {
                PHOTO_PATH = CacheDir + "/" + listener.TakePhoto(CacheDir);

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
                StartActivity(typeof(EditActivity));
            };

            galleryBtn.Click += delegate
            {
                Intent galleryIntent = new Intent();
                galleryIntent.SetType("image/*");
                galleryIntent.SetAction(Intent.ActionGetContent);
                StartActivityForResult(Intent.CreateChooser(galleryIntent, "Select photo"), 0);
            };

        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            _imageView.SetImageURI(data.Data);
            _textureView.Visibility = ViewStates.Invisible;
            _imageView.Visibility = ViewStates.Visible;

            photoBtn.Visibility = ViewStates.Invisible;
            dismissBtn.Visibility = ViewStates.Visible;
            nextBtn.Visibility = ViewStates.Visible;

            PHOTO_PATH = data.Data.ToString();
        }

        
    }
}