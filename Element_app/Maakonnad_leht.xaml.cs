using System;
using System.Collections;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Element_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public static class Extensions
    {
        public static bool find<T>(this T[] array, T target)
        {
            T[] results = Array.FindAll(array, x => x.Equals(target));
            return results.Length > 0;
        }
    }
    public partial class Maakonnad_leht : ContentPage
    {
        ViewCell pickerid, kirjeldus;
        Picker maakond_pc, linn_pc;
        StackLayout stack, st;
        ImageCell ic;
        EntryCell ent;
        Label lbl;
        TableSection fotosection;
        TableView tableView;
        string[] maakonnad = new string[8] {
            "Harjumaa", "Tartumaa", "Pärnumaa", "Viljandimaa", "Lääne-Virumaa",
            "Raplamaa", "Järvamaa", "Ida-Virumaa"
        };
        string[] linnad = new string[8] {
            "Tallinn", "Tartu", "Pärnu", "Viljandi", "Rakvere", "Rapla",
            "Paide", "Narva"
        };
        string[] iseloomustus = new string[8] {
            "Ilus linn", "Tuntud ulikool", "Suve linn", "Vorts jarv", "Ordulinnus", "Kesk-Eesti",
            "Metsa matkad", "Vene piirine linn"
        };
        string[] pildid = new string[8]
        {
            "tallinn.jpeg", "tartu.jpeg", "parnu.jpeg", "viljandi.jpeg",
            "rakvere.jpeg", "rapla.jpeg", "paide.jpeg", "narva.jpeg"
        };
        public Maakonnad_leht()
        {
            
            maakond_pc = new Picker
            {
                Title = "Maakonnad"
            };
            linn_pc = new Picker
            {
                Title = "Linnad"
            };
            foreach (string maakondNimi in maakonnad)
            {
                maakond_pc.Items.Add(maakondNimi);
            }
            
            foreach (string linnNimi in linnad)
            {
                linn_pc.Items.Add(linnNimi);
                
            }
            maakond_pc.SelectedIndexChanged += Maakond_pc_SelectedIndexChanged;
            linn_pc.SelectedIndexChanged += Linn_pc_SelectedIndexChanged;
            stack = new StackLayout
            {
                Children = { maakond_pc, linn_pc },
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.CenterAndExpand
                
            };
            pickerid = new ViewCell();
            pickerid.View = stack;
            fotosection = new TableSection();
            ent = new EntryCell
            {
                Label = "Maakond:",
                Placeholder = "Sisesta maakond",
                Keyboard = Keyboard.Default
            };
            ent.Completed += Ent_Completed;
            lbl = new Label
            {
                Text = "Kirjeldus",
                TextTransform = TextTransform.Uppercase,
                FontSize=32
            };
            st = new StackLayout
            {
                Children = { lbl },
                HorizontalOptions = LayoutOptions.CenterAndExpand

            };
            kirjeldus = new ViewCell();
            kirjeldus.View = st;
            tableView = new TableView
            {
                RowHeight = 60,
                Intent = TableIntent.Form,
                Root = new TableRoot("Maakonnad")
                {
                    
                    new TableSection("Maakonnad ja linnad")
                    {
                        pickerid,
                        ent,
                        kirjeldus
                    },
                    fotosection
                }
            };
            Content = tableView;
        }

        private void Linn_pc_SelectedIndexChanged(object sender, EventArgs e)
        {
            maakond_pc.SelectedIndex = linn_pc.SelectedIndex;
            fotosection.Remove(ic);
            ic = new ImageCell
            {
                ImageSource = ImageSource.FromFile(pildid[linn_pc.SelectedIndex])
            };
            lbl.Text = iseloomustus[linn_pc.SelectedIndex];
            fotosection.Add(ic);
        }

        private void Maakond_pc_SelectedIndexChanged(object sender, EventArgs e)
        {
            linn_pc.SelectedIndex = maakond_pc.SelectedIndex;
        }
        private async void Ent_Completed(object sender, EventArgs e)
        {
            bool result = await DisplayAlert("Pop-up", "Kas soovid maakonna otsida?", "Yah", "Ei");
            if (result)
            {
                bool isExist = maakonnad.find(ent.Text);
                if (isExist)
                {
                    fotosection.Remove(ic);
                    ic = new ImageCell
                    {
                        ImageSource = ImageSource.FromFile(pildid[Array.IndexOf(maakonnad, ent.Text)])
                    };
                    lbl.Text = iseloomustus[Array.IndexOf(maakonnad, ent.Text)];
                    fotosection.Add(ic);
                }
                else
                {
                    await DisplayAlert("Error", "Maakonda pole listis", "OK");
                    ent.Text = "";
                }
            }
            else
                ent.Text = "";
        }
    }
}
