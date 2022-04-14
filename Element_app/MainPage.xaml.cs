using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Element_app
{
    public partial class MainPage : ContentPage
    {
        Button maakonnad_btn, horoskop_btn;
        public MainPage()
        {
            maakonnad_btn = new Button
            {
                Text = "Maakonnad leht",
                BackgroundColor = Color.ForestGreen
            };
            horoskop_btn = new Button
            {
                Text = "Horoskop leht",
                BackgroundColor = Color.BlueViolet
            };
            StackLayout st = new StackLayout
            {
                Children = { maakonnad_btn, horoskop_btn }
            };
            st.BackgroundColor = Color.Aqua;
            Content = st;

            maakonnad_btn.Clicked += Start_Pages;
            horoskop_btn.Clicked += Start_Pages;

        }

        private async void Start_Pages(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (sender == maakonnad_btn)
            {
                await Navigation.PushAsync(new Maakonnad_leht());
            }
            else if (sender == horoskop_btn)
            {
                await Navigation.PushAsync(new Horoskop_leht());
            }
        }
    }
}
