using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidSampleApp.Model;
using AndroidSampleApp.Adapters;

namespace AndroidSampleApp.Fragments
{
    public class MainFragment : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            //Pobranie utworzonego wcześniej widoku do fragmentu
            var mainView = inflater.Inflate(Resource.Layout.MainFragment, container, false);

            //Pobranie listy
            var productsListView = mainView.FindViewById<ListView>(Resource.Id.ProductsListView);

            var products = CreateProductList();
            ProductsListAdapter adapter = new ProductsListAdapter(Activity, products);
            productsListView.Adapter = adapter;

            productsListView.ItemClick += (s, e) =>
            {
                var selectedProduct = products[e.Position];
                FragmentTransaction fragmentTransaction = FragmentManager.BeginTransaction();
                DetailsFragment detailsFragment = new DetailsFragment();
                detailsFragment.SelectedProduct = selectedProduct;
                fragmentTransaction.Replace(Resource.Id.fragment_container, detailsFragment, "DETAILS_FRAGMENT");
                //fragmentTransaction.AddToBackStack("MAIN_FRAGMENT");
                fragmentTransaction.Commit();
            };
            return mainView;           
        }

        private IList<Product> CreateProductList()
        {
            return new List<Product>() {
                    new Product()
                    {
                        Name = "Nowy produkt 1",
                        Image= "pika"
                    },
                    new Product()
                    {
                        Name = "Nowy produkt 2",
                        Image= "pika"
                    },
                    new Product()
                    {
                        Name = "Nowy produkt 3",
                        Image= "pika"
                    }
            };

        }
    }
}