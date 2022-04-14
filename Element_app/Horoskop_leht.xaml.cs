using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Element_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public static class Laiendused
    {
        public static bool otsi<T>(this T[] array, T target)
        {
            T[] results = Array.FindAll(array, x => x.Equals(target));
            return results.Length > 0;
        }
    }
    public partial class Horoskop_leht : ContentPage
    {
        ViewCell pickerimage, description;
        DatePicker dpicker;
        StackLayout stack, st;
        Image ic;
        EntryCell ent;
        Label lbl;
        TableView tableView;
        string[] horoskop = new string[12]
        {
            "jäär", "sõnn", "kaksikud", "vähk", "lõvi", "neitsi", "kaalud",
            "skorpion", "ambur", "kaljukits", "veevalaja", "kalad"
        };
        string[] onnenumber = new string[12]
        {
            "Õnnenumber: 1", "Õnnenumber: 6", "Õnnenumber: 7", "Õnnenumber: 2",
            "Õnnenumber: 19", "Õnnenumber: 14", "Õnnenumber: 13","Õnnenumber: 8",
            "Õnnenumber: 21", "Õnnenumber: 4", "Õnnenumber: 22", "Õnnenumber: 12"
        };
        string[] pildid = new string[12]
        {
            "jaar.jpeg", "sonn.jpeg", "kaksikud.jpeg", "vahk.jpeg", "lovi.jpeg",
            "neitsi.jpeg", "kaalud.jpeg", "skorpion.jpeg", "ambur.jpeg",
            "kaljukits.jpeg", "veevalaja.jpeg", "kalad.jpeg"
        };
        public Horoskop_leht()
        {
            dpicker = new DatePicker
            {
                Format="D",
                MinimumDate = new DateTime(2022, 1, 1),
                MaximumDate = new DateTime(2022, 12, 31),
                Date = new DateTime(2022, 4, 13)
            };
            dpicker.DateSelected += Dpicker_DateSelected;
            ic = new Image {};
            stack = new StackLayout
            {
                Children = { dpicker, ic },
                Orientation = StackOrientation.Horizontal

            };
            pickerimage = new ViewCell();
            pickerimage.View = stack;
            ent = new EntryCell
            {
                Label = "Horoskoop",
                Placeholder = "Sisesta tähtkuju nimetus",
                Keyboard = Keyboard.Default
            };
            ent.Completed += Ent_Completed;
            lbl = new Label
            {
                Text = "Õnnenumber",
                TextTransform = TextTransform.Uppercase,
                FontSize = 32
            };
            st = new StackLayout
            {
                Children = { lbl },
                HorizontalOptions = LayoutOptions.CenterAndExpand

            };
            description = new ViewCell();
            description.View = st;
            tableView = new TableView
            {
                RowHeight = 60,
                Intent = TableIntent.Form,
                Root = new TableRoot("Horoskoop")
                {

                    new TableSection("Horoskoop")
                    {
                        pickerimage,
                        ent,
                        description
                    }
                }
            };
            Content = tableView;
        }

        private async void Ent_Completed(object sender, EventArgs e)
        {
            bool result = await DisplayAlert("Pop-up", "Kas soovid tähtkuju otsida?", "Yah", "Ei");
            if (result)
            {
                bool isExist = horoskop.find(ent.Text);
                if (isExist)
                {
                    ic.Source = ImageSource.FromFile(pildid[Array.IndexOf(horoskop, ent.Text)]);
                    lbl.Text = onnenumber[Array.IndexOf(horoskop, ent.Text)];
                }
                else
                {
                    await DisplayAlert("Error", "Valesti sisestatud", "OK");
                    ent.Text = "";
                }
            }
            else
                ent.Text = "";
        }
        private void Dpicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            var m = e.NewDate.Month;
            var d = e.NewDate.Day;
            if (m == 4 && d >= 1 && d <= 20 || m == 3 && d >= 21)
            {
                ent.Text = "jäär";
                lbl.Text = "Õnnenumber: 1";
                ic.Source = "jaar.jpeg" ;
            }
            else if (m == 5 && d >= 1 && d <= 20 || m == 4 && d >= 21)
            {
                ent.Text = "sõnn";
                lbl.Text = "Õnnenumber: 6";
                ic.Source = "sonn.jpeg";
            }
            else if (m == 6 && d >= 1 && d <= 21 || m == 5 && d >= 21)
            {
                ent.Text = "kaksikud";
                lbl.Text = "Õnnenumber: 7";
                ic.Source = "kaksikud.jpeg" ;
            }
            else if (m == 7 && d >= 1 && d <= 22 || m == 6 && d >= 22)
            {
                ent.Text = "vähk";
                lbl.Text = "Õnnenumber: 2";
                ic.Source = "vahk.jpeg" ;
            }
            else if (m == 8 && d >= 1 && d <= 22 || m == 7 && d >= 23)
            {
                ent.Text = "lõvi";
                lbl.Text = "Õnnenumber: 19";
                ic.Source = "lovi.jpeg" ;
            }
            else if (m == 9 && d >= 1 && d <= 22 || m == 8 && d >= 23)
            {
                ent.Text = "neitsi";
                lbl.Text = "Õnnenumber: 14";
                ic.Source = "neitsi.jpeg" ;
            }
            else if (m == 10 && d >= 1 && d <= 23 || m == 9 && d >= 23)
            {
                ent.Text = "kaalud";
                lbl.Text = "Õnnenumber: 13";
                ic.Source = "kaalud.jpeg" ;
            }
            else if (m == 11 && d >= 1 && d <= 22 || m == 10 && d >= 24)
            {
                ent.Text = "skorpion";
                lbl.Text = "Õnnenumber: 8";
                ic.Source = "skorpion.jpeg" ;
            }
            else if (m == 12 && d >= 1 && d <= 21 || m == 11 && d >= 23)
            {
                ent.Text = "ambur";
                lbl.Text = "Õnnenumber: 21";
                ic.Source = "ambur.jpeg" ;
            }
            else if (m==1 && d>=1 && d<=20 || m==12 && d>=22)
            {
                ent.Text = "kaljukits";
                lbl.Text = "Õnnenumber: 4";
                ic.Source = "kaljukits.jpeg" ;
            }
            else if (m == 2 && d >= 1 && d <= 18 || m == 1 && d >= 21)
            {
                ent.Text = "veevalaja";
                lbl.Text = "Õnnenumber: 22";
                ic.Source = "veevalaja.jpeg" ;
            }
            else if (m == 3 && d >= 1 && d <= 20 || m == 2 && d >= 19)
            {
                ent.Text = "kalad";
                lbl.Text = "Õnnenumber: 12";
                ic.Source = "kalad.jpeg" ;
            }
        }
    }
}
