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
        private System.Windows.Media.Brush activeColor;

		public MainView()
		{
			// Required to initialize variables
			InitializeComponent();
		}

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Shapes.Rectangle obj = (System.Windows.Shapes.Rectangle)sender;
            obj.Fill = activeColor;
        }

        private void Color_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Shapes.Rectangle obj = (System.Windows.Shapes.Rectangle)sender;
            this.activeColor = obj.Fill;
        }
	}
}