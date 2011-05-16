using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

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
            this.HistoryGrid.Children.Clear();

            // Refactoring und schönerer Code nötig :)
            // Validierung nötig!!
            MainViewModel cube = this.LayoutRoot.DataContext as MainViewModel;
            RubiksCube.Controller.CubeSolver solver = new RubiksCube.Controller.CubeSolver(cube);
            solver.solve();
            this.LayoutRoot.DataContext = null;
            this.LayoutRoot.DataContext = solver.Cube as MainViewModel;

            // Test
            foreach (RubiksCube.Model.HistoryItem item in solver.Cube.History)
            {
                Brush alternatingBrush = (item.Order % 2 == 0) ? Brushes.Silver : Brushes.Gainsboro;
                Grid grid = new Grid() { Height = 80, ToolTip = item.Order, Background = alternatingBrush };
                grid.Children.Add(new Label() {Content = item.MoveTextual});
                this.HistoryGrid.Children.Add(grid);
            }
        }
    }
}