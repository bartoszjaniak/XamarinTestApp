using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidSampleApp.Model;

namespace AndroidSampleApp.Adapters
{
    public class ProductsListAdapter : BaseAdapter<Product>
    {
        private IList<Product> _productList;
        private Activity _context;

        public ProductsListAdapter(Activity context, IList<Product> productList)
        {
            _context = context;
            _productList = productList;
        }

        //Zwraca produkt na podanym indeksie
        public override Product this[int position] => _productList[position];

        //Zwraca ilość produktó na liście
        public override int Count => _productList.Count;

        //Zwraca pozycje danego elementu na liście
        public override long GetItemId(int position)
        {
            return position;
        }

        //widok
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            ProductViewHolder holder;
            var product = _productList[position];

            //Jeśli wiersz nie był stworzony to tworzymy
            if (convertView == null)
            {
                //widok dla wiersza;
                convertView = _context.LayoutInflater.Inflate(Resource.Layout.ProductRow, null);
                //odnalezienie naszych dwóch kontrolek i zapisanie ich w holderze
                holder = new ProductViewHolder(convertView.FindViewById<TextView>(Resource.Id.ProductNameTextView), convertView.FindViewById<ImageView>(Resource.Id.ProductPictureImageView));
                convertView.Tag = holder;
            }
            else
                holder = (ProductViewHolder)convertView.Tag;

            holder.ProductNameTextView.Text = product.Name;
            int imageResourceId = _context.Resources.GetIdentifier(product.Image, "drawable", _context.PackageName);
            holder.ProductPictureImageView.SetImageResource(imageResourceId);

            return convertView;

        }
    }

    //Klasa stworzona na potrzebę optymalizacji - przechowuje załadowane już pozycje, żeby nie trzeba było przeładowywać ich jeszcze raz
    public class ProductViewHolder: Java.Lang.Object
    {
        public TextView ProductNameTextView;
        public ImageView ProductPictureImageView;

        public ProductViewHolder(TextView productNameTextView, ImageView productPictureImageView)
        {
            ProductNameTextView = productNameTextView;
            ProductPictureImageView = productPictureImageView;
        }
        
    }
}