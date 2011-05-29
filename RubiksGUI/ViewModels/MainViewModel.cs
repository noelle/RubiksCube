using System;
using System.ComponentModel;
using RubiksCube.Model;
using System.Windows.Media;

namespace RubiksGUI
{
    public class MainViewModel : RubiksCube.Model.Cube, INotifyPropertyChanged
    {
        public SolidColorBrush TopBottomLeftCorner
        {
            get
            {
                return Helper.getBrush(this.getCubie(-1, -1, 1).ColZ);
            }
            set
            {
                this.getCubie(-1, -1, 1).ColZ = Helper.getColor(value);
                this.NotifyPropertyChanged("TopBottomLeftCorner");
            }
        }
        public SolidColorBrush TopLeftEdge
        {
            get
            {
                return Helper.getBrush(this.getCubie(0, -1, 1).ColZ);
            }
            set
            {
                this.getCubie(0, -1, 1).ColZ = Helper.getColor(value);
                this.NotifyPropertyChanged("TopLeftEdge");
            }
        }
        public SolidColorBrush TopTopLeftCorner
        {
            get
            {
                return Helper.getBrush(this.getCubie(1, -1, 1).ColZ);
            }
            set
            {
                this.getCubie(1, -1, 1).ColZ = Helper.getColor(value);
                this.NotifyPropertyChanged("TopTopLeftCorner");
            }
        }
        public SolidColorBrush TopBottomEdge
        {
            get
            {
                return Helper.getBrush(this.getCubie(-1, 0, 1).ColZ);
            }
            set
            {
                this.getCubie(-1, 0, 1).ColZ = Helper.getColor(value);
                this.NotifyPropertyChanged("TopBottomEdge");
            }
        }
        public SolidColorBrush TopCenter
        {
            get
            {
                return Helper.getBrush(this.getCubie(0, 0, 1).ColZ);
            }
            set
            {
                this.getCubie(0, 0, 1).ColZ = Helper.getColor(value);
                this.NotifyPropertyChanged("TopCenter");
            }
        }
        public SolidColorBrush TopTopEdge
        {
            get
            {
                return Helper.getBrush(this.getCubie(1, 0, 1).ColZ);
            }
            set
            {
                this.getCubie(1, 0, 1).ColZ = Helper.getColor(value);
                this.NotifyPropertyChanged("TopTopEdge");
            }
        }
        public SolidColorBrush TopBottomRightCorner
        {
            get
            {
                return Helper.getBrush(this.getCubie(-1, 1, 1).ColZ);
            }
            set
            {
                this.getCubie(-1, 1, 1).ColZ = Helper.getColor(value);
                this.NotifyPropertyChanged("TopBottomRightCorner");
            }
        }
        public SolidColorBrush TopRightEdge
        {
            get
            {
                return Helper.getBrush(this.getCubie(0, 1, 1).ColZ);
            }
            set
            {
                this.getCubie(0, 1, 1).ColZ = Helper.getColor(value);
                this.NotifyPropertyChanged("TopRightEdge");
            }
        }
        public SolidColorBrush TopTopRightCorner
        {
            get
            {
                return Helper.getBrush(this.getCubie(1, 1, 1).ColZ);
            }
            set
            {
                this.getCubie(1, 1, 1).ColZ = Helper.getColor(value);
                this.NotifyPropertyChanged("TopTopRightCorner");
            }
        }
        public SolidColorBrush LeftTopLeftCorner
        {
            get
            {
                return Helper.getBrush(this.getCubie(-1, -1, 1).ColY);
            }
            set
            {
                this.getCubie(-1, -1, 1).ColY = Helper.getColor(value);
                this.NotifyPropertyChanged("LeftTopLeftCorner");
            }
        }
        public SolidColorBrush LeftLeftEdge
        {
            get
            {
                return Helper.getBrush(this.getCubie(-1, -1, 0).ColY);
            }
            set
            {
                this.getCubie(-1, -1, 0).ColY = Helper.getColor(value);
                this.NotifyPropertyChanged("LeftLeftEdge");
            }
        }
        public SolidColorBrush LeftBottomLeftCorner
        {
            get
            {
                return Helper.getBrush(this.getCubie(-1, -1, -1).ColY);
            }
            set
            {
                this.getCubie(-1, -1, -1).ColY = Helper.getColor(value);
                this.NotifyPropertyChanged("LeftBottomLeftCorner");
            }
        }
        public SolidColorBrush LeftTopEdge
        {
            get
            {
                return Helper.getBrush(this.getCubie(0, -1, 1).ColY);
            }
            set
            {
                this.getCubie(0, -1, 1).ColY = Helper.getColor(value);
                this.NotifyPropertyChanged("LeftTopEdge");
            }
        }
        public SolidColorBrush LeftCenter
        {
            get
            {
                return Helper.getBrush(this.getCubie(0, -1, 0).ColY);
            }
            set
            {
                this.getCubie(0, -1, 0).ColY = Helper.getColor(value);
                this.NotifyPropertyChanged("LeftCenter");
            }
        }
        public SolidColorBrush LeftBottomEdge
        {
            get
            {
                return Helper.getBrush(this.getCubie(0, -1, -1).ColY);
            }
            set
            {
                this.getCubie(0, -1, -1).ColY = Helper.getColor(value);
                this.NotifyPropertyChanged("LeftBottomEdge");
            }
        }
        public SolidColorBrush LeftTopRightCorner
        {
            get
            {
                return Helper.getBrush(this.getCubie(1, -1, 1).ColY);
            }
            set
            {
                this.getCubie(1, -1, 1).ColY = Helper.getColor(value);
                this.NotifyPropertyChanged("LeftTopRightCorner");
            }
        }
        public SolidColorBrush LeftRightEdge
        {
            get
            {
                return Helper.getBrush(this.getCubie(1, -1, 0).ColY);
            }
            set
            {
                this.getCubie(1, -1, 0).ColY = Helper.getColor(value);
                this.NotifyPropertyChanged("LeftRightEdge");
            }
        }
        public SolidColorBrush LeftBottomRightCorner
        {
            get
            {
                return Helper.getBrush(this.getCubie(1, -1, -1).ColY);
            }
            set
            {
                this.getCubie(1, -1, -1).ColY = Helper.getColor(value);
                this.NotifyPropertyChanged("LeftBottomRightCorner");
            }
        }
        public SolidColorBrush FrontTopLeftCorner
        {
            get
            {
                return Helper.getBrush(this.getCubie(1, -1, 1).ColX);
            }
            set
            {
                this.getCubie(1, -1, 1).ColX = Helper.getColor(value);
                this.NotifyPropertyChanged("FrontTopLeftCorner");
            }
        }
        public SolidColorBrush FrontLeftEdge
        {
            get
            {
                return Helper.getBrush(this.getCubie(1, -1, 0).ColX);
            }
            set
            {
                this.getCubie(1, -1, 0).ColX = Helper.getColor(value);
                this.NotifyPropertyChanged("FrontLeftEdge");
            }
        }
        public SolidColorBrush FrontBottomLeftCorner
        {
            get
            {
                return Helper.getBrush(this.getCubie(1, -1, -1).ColX);
            }
            set
            {
                this.getCubie(1, -1, -1).ColX = Helper.getColor(value);
                this.NotifyPropertyChanged("FrontBottomLeftCorner");
            }
        }
        public SolidColorBrush FrontTopEdge
        {
            get
            {
                return Helper.getBrush(this.getCubie(1, 0, 1).ColX);
            }
            set
            {
                this.getCubie(1, 0, 1).ColX = Helper.getColor(value);
                this.NotifyPropertyChanged("FrontTopEdge");
            }
        }
        public SolidColorBrush FrontCenter
        {
            get
            {
                return Helper.getBrush(this.getCubie(1, 0, 0).ColX);
            }
            set
            {
                this.getCubie(1, 0, 0).ColX = Helper.getColor(value);
                this.NotifyPropertyChanged("FrontCenter");
            }
        }
        public SolidColorBrush FrontBottomEdge
        {
            get
            {
                return Helper.getBrush(this.getCubie(1, 0, -1).ColX);
            }
            set
            {
                this.getCubie(1, 0, -1).ColX = Helper.getColor(value);
                this.NotifyPropertyChanged("FrontBottomEdge");
            }
        }
        public SolidColorBrush FrontTopRightCorner
        {
            get
            {
                return Helper.getBrush(this.getCubie(1, 1, 1).ColX);
            }
            set
            {
                this.getCubie(1, 1, 1).ColX = Helper.getColor(value);
                this.NotifyPropertyChanged("FrontTopRightCorner");
            }
        }
        public SolidColorBrush FrontRightEdge
        {
            get
            {
                return Helper.getBrush(this.getCubie(1, 1, 0).ColX);
            }
            set
            {
                this.getCubie(1, 1, 0).ColX = Helper.getColor(value);
                this.NotifyPropertyChanged("FrontRightEdge");
            }
        }
        public SolidColorBrush FrontBottomRightCorner
        {
            get
            {
                return Helper.getBrush(this.getCubie(1, 1, -1).ColX);
            }
            set
            {
                this.getCubie(1, 1, -1).ColX = Helper.getColor(value);
                this.NotifyPropertyChanged("FrontBottomRightCorner");
            }
        }
        public SolidColorBrush BottomTopLeftCorner
        {
            get
            {
                return Helper.getBrush(this.getCubie(1, -1, -1).ColZ);
            }
            set
            {
                this.getCubie(1, -1, -1).ColZ = Helper.getColor(value);
                this.NotifyPropertyChanged("BottomTopLeftCorner");
            }
        }
        public SolidColorBrush BottomLeftEdge
        {
            get
            {
                return Helper.getBrush(this.getCubie(0, -1, -1).ColZ);
            }
            set
            {
                this.getCubie(0, -1, -1).ColZ = Helper.getColor(value);
                this.NotifyPropertyChanged("BottomLeftEdge");
            }
        }
        public SolidColorBrush BottomBottomLeftCorner
        {
            get
            {
                return Helper.getBrush(this.getCubie(-1, -1, -1).ColZ);
            }
            set
            {
                this.getCubie(-1, -1, -1).ColZ = Helper.getColor(value);
                this.NotifyPropertyChanged("BottomBottomLeftCorner");
            }
        }
        public SolidColorBrush BottomTopEdge
        {
            get
            {
                return Helper.getBrush(this.getCubie(1, 0, -1).ColZ);
            }
            set
            {
                this.getCubie(1, 0, -1).ColZ = Helper.getColor(value);
                this.NotifyPropertyChanged("BottomTopEdge");
            }
        }
        public SolidColorBrush BottomCenter
        {
            get
            {
                return Helper.getBrush(this.getCubie(0, 0, -1).ColZ);
            }
            set
            {
                this.getCubie(0, 0, -1).ColZ = Helper.getColor(value);
                this.NotifyPropertyChanged("BottomCenter");
            }
        }
        public SolidColorBrush BottomBottomEdge
        {
            get
            {
                return Helper.getBrush(this.getCubie(-1, 0, -1).ColZ);
            }
            set
            {
                this.getCubie(-1, 0, -1).ColZ = Helper.getColor(value);
                this.NotifyPropertyChanged("BottomBottomEdge");
            }
        }
        public SolidColorBrush BottomTopRightCorner
        {
            get
            {
                return Helper.getBrush(this.getCubie(1, 1, -1).ColZ);
            }
            set
            {
                this.getCubie(1, 1, -1).ColZ = Helper.getColor(value);
                this.NotifyPropertyChanged("BottomTopRightCorner");
            }
        }
        public SolidColorBrush BottomRightEdge
        {
            get
            {
                return Helper.getBrush(this.getCubie(0, 1, -1).ColZ);
            }
            set
            {
                this.getCubie(0, 1, -1).ColZ = Helper.getColor(value);
                this.NotifyPropertyChanged("BottomRightEdge");
            }
        }
        public SolidColorBrush BottomBottomRightCorner
        {
            get
            {
                return Helper.getBrush(this.getCubie(-1, 1, -1).ColZ);
            }
            set
            {
                this.getCubie(-1, 1, -1).ColZ = Helper.getColor(value);
                this.NotifyPropertyChanged("BottomBottomRightCorner");
            }
        }
        public SolidColorBrush RightTopLeftCorner
        {
            get
            {
                return Helper.getBrush(this.getCubie(1, 1, 1).ColY);
            }
            set
            {
                this.getCubie(1, 1, 1).ColY = Helper.getColor(value);
                this.NotifyPropertyChanged("RightTopLeftCorner");
            }
        }
        public SolidColorBrush RightLeftEdge
        {
            get
            {
                return Helper.getBrush(this.getCubie(1, 1, 0).ColY);
            }
            set
            {
                this.getCubie(1, 1, 0).ColY = Helper.getColor(value);
                this.NotifyPropertyChanged("RightLeftEdge");
            }
        }
        public SolidColorBrush RightBottomLeftCorner
        {
            get
            {
                return Helper.getBrush(this.getCubie(1, 1, -1).ColY);
            }
            set
            {
                this.getCubie(1, 1, -1).ColY = Helper.getColor(value);
                this.NotifyPropertyChanged("RightBottomLeftCorner");
            }
        }
        public SolidColorBrush RightTopEdge
        {
            get
            {
                return Helper.getBrush(this.getCubie(0, 1, 1).ColY);
            }
            set
            {
                this.getCubie(0, 1, 1).ColY = Helper.getColor(value);
                this.NotifyPropertyChanged("RightTopEdge");
            }
        }
        public SolidColorBrush RightCenter
        {
            get
            {
                return Helper.getBrush(this.getCubie(0, 1, 0).ColY);
            }
            set
            {
                this.getCubie(0, 1, 0).ColY = Helper.getColor(value);
                this.NotifyPropertyChanged("RightCenter");
            }
        }
        public SolidColorBrush RightBottomEdge
        {
            get
            {
                return Helper.getBrush(this.getCubie(0, 1, -1).ColY);
            }
            set
            {
                this.getCubie(0, 1, -1).ColY = Helper.getColor(value);
                this.NotifyPropertyChanged("RightBottomEdge");
            }
        }
        public SolidColorBrush RightTopRightCorner
        {
            get
            {
                return Helper.getBrush(this.getCubie(-1, 1, 1).ColY);
            }
            set
            {
                this.getCubie(-1, 1, 1).ColY = Helper.getColor(value);
                this.NotifyPropertyChanged("RightTopRightCorner");
            }
        }
        public SolidColorBrush RightRightEdge
        {
            get
            {
                return Helper.getBrush(this.getCubie(-1, 1, 0).ColY);
            }
            set
            {
                this.getCubie(-1, 1, 0).ColY = Helper.getColor(value);
                this.NotifyPropertyChanged("RightRightEdge");
            }
        }
        public SolidColorBrush RightBottomRightCorner
        {
            get
            {
                return Helper.getBrush(this.getCubie(-1, 1, -1).ColY);
            }
            set
            {
                this.getCubie(-1, 1, -1).ColY = Helper.getColor(value);
                this.NotifyPropertyChanged("RightBottomRightCorner");
            }
        }
        public SolidColorBrush BackTopLeftCorner
        {
            get
            {
                return Helper.getBrush(this.getCubie(-1, 1, 1).ColX);
            }
            set
            {
                this.getCubie(-1, 1, 1).ColX = Helper.getColor(value);
                this.NotifyPropertyChanged("BackTopLeftCorner");
            }
        }
        public SolidColorBrush BackLeftEdge
        {
            get
            {
                return Helper.getBrush(this.getCubie(-1, 1, 0).ColX);
            }
            set
            {
                this.getCubie(-1, 1, 0).ColX = Helper.getColor(value);
                this.NotifyPropertyChanged("BackLeftEdge");
            }
        }
        public SolidColorBrush BackBottomLeftCorner
        {
            get
            {
                return Helper.getBrush(this.getCubie(-1, 1, -1).ColX);
            }
            set
            {
                this.getCubie(-1, 1, -1).ColX = Helper.getColor(value);
                this.NotifyPropertyChanged("BackBottomLeftCorner");
            }
        }
        public SolidColorBrush BackTopEdge
        {
            get
            {
                return Helper.getBrush(this.getCubie(-1, 0, 1).ColX);
            }
            set
            {
                this.getCubie(-1, 0, 1).ColX = Helper.getColor(value);
                this.NotifyPropertyChanged("BackTopEdge");
            }
        }
        public SolidColorBrush BackCenter
        {
            get
            {
                return Helper.getBrush(this.getCubie(-1, 0, 0).ColX);
            }
            set
            {
                this.getCubie(-1, 0, 0).ColX = Helper.getColor(value);
                this.NotifyPropertyChanged("BackCenter");
            }
        }
        public SolidColorBrush BackBottomEdge
        {
            get
            {
                return Helper.getBrush(this.getCubie(-1, 0, -1).ColX);
            }
            set
            {
                this.getCubie(-1, 0, -1).ColX = Helper.getColor(value);
                this.NotifyPropertyChanged("BackBottomEdge");
            }
        }
        public SolidColorBrush BackTopRightCorner
        {
            get
            {
                return Helper.getBrush(this.getCubie(-1, -1, 1).ColX);
            }
            set
            {
                this.getCubie(-1, -1, 1).ColX = Helper.getColor(value);
                this.NotifyPropertyChanged("BackTopRightCorner");
            }
        }
        public SolidColorBrush BackRightEdge
        {
            get
            {
                return Helper.getBrush(this.getCubie(-1, -1, 0).ColX);
            }
            set
            {
                this.getCubie(-1, -1, 0).ColX = Helper.getColor(value);
                this.NotifyPropertyChanged("BackRightEdge");
            }
        }
        public SolidColorBrush BackBottomRightCorner
        {
            get
            {
                return Helper.getBrush(this.getCubie(-1, -1, -1).ColX);
            }
            set
            {
                this.getCubie(-1, -1, -1).ColX = Helper.getColor(value);
                this.NotifyPropertyChanged("BackBottomRightCorner");
            }
        }

        public MainViewModel() { }

        public MainViewModel(Cube cube)
        {
            this.Cubies = cube.Cubies;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        #endregion

    }
}