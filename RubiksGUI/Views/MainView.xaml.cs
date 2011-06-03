using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Xml;
using System.Collections.Generic;

namespace RubiksGUI
{
    public partial class MainView : UserControl
    {
        private System.Windows.Shapes.Rectangle activeRectangle;
        private int actualHistoryItem;
        private ObservableCollection<RubiksCube.Model.HistoryItem> listHistoryItems = new ObservableCollection<RubiksCube.Model.HistoryItem>();

        public MainView()
        {
            // Required to initialize variables
            InitializeComponent();
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Shapes.Rectangle obj = (System.Windows.Shapes.Rectangle)sender;
            if (obj != null && activeRectangle != null)
            {
                obj.Fill = activeRectangle.Fill;
            }
            //else melden dass keine Farbe gewählt ist!
        }

        private void Color_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (activeRectangle != null)
            {
                activeRectangle.StrokeThickness = 1;
            }
            System.Windows.Shapes.Rectangle obj = (System.Windows.Shapes.Rectangle)sender;
            obj.StrokeThickness = 3;

            this.activeRectangle = obj;

        }

        private void solveButton_Click(object sender, RoutedEventArgs e)
        {
            // History leeren
            this.listHistoryItems.Clear();
           
            // Refactoring und schönerer Code nötig :)
            // Validierung nötig!!
            MainViewModel cube = this.LayoutRoot.DataContext as MainViewModel;
            RubiksCube.Controller.CubeSolver solver = new RubiksCube.Controller.CubeSolver(cube);
            solver.solve();

            this.LayoutRoot.DataContext = null;
            this.LayoutRoot.DataContext = solver.Cube as MainViewModel;

            // Upcasting Cube
            foreach (RubiksCube.Model.HistoryItem item in solver.Cube.History)
            {
                item.Cube = new MainViewModel(item.Cube);
            }

            this.actualHistoryItem = 0;
            this.listHistoryItems = solver.Cube.History;

            setButtons();

            this.HistoryControl.ItemsSource = this.listHistoryItems;
            if (this.listHistoryItems.Count > 0)
            {
                this.GridOneByOne.DataContext = this.listHistoryItems[actualHistoryItem];
            }
        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            actualHistoryItem--;
            this.GridOneByOne.DataContext = this.listHistoryItems[actualHistoryItem];
            setButtons();
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            actualHistoryItem++;
            this.GridOneByOne.DataContext = this.listHistoryItems[actualHistoryItem];
            setButtons();
        }

        protected void setButtons()
        {
            if (this.actualHistoryItem == (this.listHistoryItems.Count-1))
            {
                this.btnNext.IsEnabled = false;
            }
            else
            {
                this.btnNext.IsEnabled = true;
            }

            if (this.actualHistoryItem == 0)
            {
                this.btnPrevious.IsEnabled = false;
            }
            else
            {
                this.btnPrevious.IsEnabled = true;
            }
        }
    }
}