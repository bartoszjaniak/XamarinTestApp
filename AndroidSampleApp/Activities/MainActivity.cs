using Android.App;
using Android.Widget;
using Android.OS;
using AndroidSampleApp.Fragments;
using Android.Support.V7.App;

namespace AndroidSampleApp
{
    [Activity(Label = "AndroidSampleApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Ustawienie widoku activity do acriviry
            SetContentView (Resource.Layout.MainActivity);

            //Zlokalizowanie paska toolbar
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);

            //Ustawienie tytułu paska toolbar
            toolbar.Title = "Haloł from Xamarin Android";

            //Ustawienie naszego paska jako głównego
            SetSupportActionBar(toolbar);

            //CZy mamy wyświetlać strzałkę powrotu na naszym pasku toolbar
            SupportActionBar.SetDisplayHomeAsUpEnabled(false);

            //Akcja jaka się wykona po naciśnięciu strzałki powrotu
            toolbar.NavigationClick += (s,e) => {
                OnBackPressed();
            };

            //wyświetlenie listy (fragmentu na naszej Activity)
            FragmentTransaction fragmentTransaction = FragmentManager.BeginTransaction();
            MainFragment mainFragment = new MainFragment();
            fragmentTransaction.Add(Resource.Id.fragment_container, mainFragment, "MAIN_FRAGMENT");
            fragmentTransaction.AddToBackStack("MAIN_FRAGMENT");
            fragmentTransaction.Commit();

            //Ukrycie bądź pokazanie strzałki powrotu
            FragmentManager.BackStackChanged += (s, e) =>
            {
                if (FragmentManager.BackStackEntryCount > 0)
                    SupportActionBar.SetDisplayHomeAsUpEnabled(true);
                else
                    SupportActionBar.SetDisplayHomeAsUpEnabled(false);
            };

        }
    }
}

