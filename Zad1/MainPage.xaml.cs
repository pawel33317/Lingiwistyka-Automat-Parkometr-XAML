using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Zad1
{
    public sealed partial class MainPage : Page
    {
        List<int> accepted = new List<int>();
        int currentState = 0;
        int currentCoin = 0;
        int nexState = 0;

        public MainPage()
        {
            this.InitializeComponent();
            accepted.Add(7); accepted.Add(8); accepted.Add(9); accepted.Add(10); accepted.Add(11);
        }
        int[,] stateTab = new int[,] {
                {1,2,5},//0
                {2,3,6},//1
                {3,4,7},
                {4,5,8},
                {5,6,9},
                {6,7,10},
                {7,8,11},
                {8,0,0},
                {9,0,0},
                {10,0,0},
                {11,0,0}
        };

        string[] reszta = { "Brak reszty", "Wydaję 1 zł reszty", "Wydaję 2 zł reszty", "Wydaję 3 zł reszty", "Wydaję 4 zł reszty" };

        public void changeState(int coin) {
            nexState = coin;
            currentState = stateTab[currentState, nexState];
            bool spt = accepted.Contains(currentState);
            tb_state.Text = "Stan: " + currentState + " zł";
            if (spt)
            {
                tb_info.Text = "Wydaję bilet...";
                tb_reszta.Text = reszta[(currentState - 7)];
                bm1.IsEnabled = false;
                bm2.IsEnabled = false;
                bm5.IsEnabled = false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            changeState(0);
            lbhistory.Items.Add("Wrzucono monetę: 1zł");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            changeState(1);
            lbhistory.Items.Add("Wrzucono monetę: 2zł");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            changeState(2);
            lbhistory.Items.Add("Wrzucono monetę: 5zł");
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            bm1.IsEnabled = true;
            bm2.IsEnabled = true;
            bm5.IsEnabled = true;
            currentState = 0;
            currentCoin = 0;
            nexState = 0;
            tb_info.Text = "Wrzuć monetę";
            tb_state.Text = "Stan: 0 zł";
            tb_reszta.Text = "Reszta"; 
            lbhistory.Items.Clear();
        }
    }
}
