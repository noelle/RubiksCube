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

namespace RubiksGUI
{
    public partial class MainView : UserControl
    {
        private System.Windows.Shapes.Rectangle activeRectangle;

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

            this.HistoryControl.ItemsSource = solver.Cube.History;
        }
    }
}