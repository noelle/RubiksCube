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
            //this.HistoryGrid.Children.Clear();

            // Refactoring und schönerer Code nötig :)
            // Validierung nötig!!
            MainViewModel cube = this.LayoutRoot.DataContext as MainViewModel;
            RubiksCube.Controller.CubeSolver solver = new RubiksCube.Controller.CubeSolver(cube);
            solver.solve();
            this.LayoutRoot.DataContext = null;
            this.LayoutRoot.DataContext = solver.Cube as MainViewModel;
            this.HistoryControl.DataContext = solver.Cube.History;


            // Test
            //foreach (RubiksCube.Model.HistoryItem item in solver.Cube.History)
            //{
            //    Brush alternatingBrush = (item.Order % 2 == 0) ? Brushes.Silver : Brushes.Gainsboro;
            //    Grid grid = new Grid() { Height = 80, ToolTip = item.Order, Background = alternatingBrush };

            //    for (int i = 0; i < 14; i++)
            //    {
            //        grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(7) });
            //    }

            //    for (int i = 0; i < 12; i++)
            //    {
            //        grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(7) });
            //    }

            //    grid.Children.Add(new Label() {Content = item.MoveTextual});
 
            //    // instance of cube in history
            //    Grid gridCube = new Grid();
    
            //    MainViewModel cubeHistory = new MainViewModel(item.Cube);
            //    //gridCube.DataContext = item.Cube as MainViewModel;
            //    Thickness thickness = new Thickness(5);

            //    gridCube.Children.Add(new Rectangle() { Fill = cubeHistory.TopBottomLeftCorner, HorizontalAlignment = System.Windows.HorizontalAlignment.Left, Height = 5, VerticalAlignment = System.Windows.VerticalAlignment.Top, Width = 5, Margin = thickness });
            //    gridCube.Children.Add(new Rectangle() { Fill = cubeHistory.TopLeftEdge, HorizontalAlignment = System.Windows.HorizontalAlignment.Left, Height = 5, VerticalAlignment = System.Windows.VerticalAlignment.Top, Width = 5, Margin = thickness });
            //    gridCube.Children.Add(new Rectangle() { Fill = cubeHistory.TopTopLeftCorner, HorizontalAlignment = System.Windows.HorizontalAlignment.Left, Height = 5, VerticalAlignment = System.Windows.VerticalAlignment.Top, Width = 5, Margin = thickness });
            //    gridCube.Children.Add(new Rectangle() { Fill = cubeHistory.TopBottomEdge, HorizontalAlignment = System.Windows.HorizontalAlignment.Left, Height = 5, VerticalAlignment = System.Windows.VerticalAlignment.Top, Width = 5, Margin = thickness });
            //    gridCube.Children.Add(new Rectangle() { Fill = cubeHistory.TopCenter, HorizontalAlignment = System.Windows.HorizontalAlignment.Left, Height = 5, VerticalAlignment = System.Windows.VerticalAlignment.Top, Width = 5, Margin = thickness });
            //    gridCube.Children.Add(new Rectangle() { Fill = cubeHistory.TopTopEdge, HorizontalAlignment = System.Windows.HorizontalAlignment.Left, Height = 5, VerticalAlignment = System.Windows.VerticalAlignment.Top, Width = 5, Margin = thickness });
            //    gridCube.Children.Add(new Rectangle() { Fill = cubeHistory.TopBottomRightCorner, HorizontalAlignment = System.Windows.HorizontalAlignment.Left, Height = 5, VerticalAlignment = System.Windows.VerticalAlignment.Top, Width = 5, Margin = thickness });
            //    gridCube.Children.Add(new Rectangle() { Fill = cubeHistory.TopRightEdge, HorizontalAlignment = System.Windows.HorizontalAlignment.Left, Height = 5, VerticalAlignment = System.Windows.VerticalAlignment.Top, Width = 5, Margin = thickness });
            //    gridCube.Children.Add(new Rectangle() { Fill = cubeHistory.TopTopRightCorner, HorizontalAlignment = System.Windows.HorizontalAlignment.Left, Height = 5, VerticalAlignment = System.Windows.VerticalAlignment.Top, Width = 5, Margin = thickness });


            //    this.HistoryGrid.Children.Add(grid);
            //    this.HistoryGrid.Children.Add(gridCube);
            //}
        }
    }
}