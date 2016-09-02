using Android.App;
using Android.Widget;
using Android.OS;
using ZXing.Mobile;

namespace CheckInator
{
    [Activity(Label = "Checkinator", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            MobileBarcodeScanner.Initialize(Application);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            var button = FindViewById<ImageButton>(Resource.Id.btnScan);
            var results = FindViewById<TextView>(Resource.Id.Results);

            button.Click += async delegate
            {
                    var scanner = new MobileBarcodeScanner();
                    var result = await scanner.Scan();

                    if(result == null) return;

                    results.Text = result.Text;
            };
        }
    }
}


