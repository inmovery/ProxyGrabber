using ProxyGrabber.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Data;
using Newtonsoft.Json;
using System.Net.Http;
using System;
using ProxyGrabber.ViewModels;
using System.Linq;
using System.Reflection;

namespace ProxyGrabber {

    /// <summary>
    /// The View Model for the custom flat window
    /// </summary>
    public class MainViewModel : BaseViewModel {

        #region Private Member

        /// <summary>
        /// The Window this view model controls
        /// </summary>
        private Window mWindow;

        /// <summary>
        /// The margin around the window to allow for a drop shadow
        /// </summary>
        private int mOuterMarginSize = 5;

        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        private int mWindowRadius = 0; // 3

        /// <summary>
        /// 
        /// </summary>
        private ICommand mChangeSettings { get; set; }

        #endregion Private Member

        #region Window Toolbar

        /// <summary>
        /// The smallest width the window can go to
        /// </summary>
        public double WindowMinimumWidth { get; set; } = 800;

        /// <summary>
        /// The smallest height the window can go to
        /// </summary>
        public double WindowMinimumHeight { get; set; } = 500;

        /// <summary>
        /// The size of the resize border around the window
        /// </summary>
        public int ResizeBorder { get; set; } = 6;

        /// <summary>
        /// The size of the resize border, taking into account the outer margin
        /// </summary>
        public Thickness ResizeBorderThickness {
            get {
                return new Thickness(ResizeBorder + OuterMarginSize);
            }
        }

        /// <summary>
        /// The padding of the inner content of the main window
        /// </summary>
        public Thickness InnerContentPadding {
            get {
                return new Thickness(ResizeBorder);
            }
        }

        /// <summary>
        /// The margin around the window to allow for a drop shadow
        /// </summary>
        public int OuterMarginSize {
            get {
                return mWindow.WindowState == WindowState.Maximized ? 0 : mOuterMarginSize;
            }
            set {
                mOuterMarginSize = value;
            }
        }

        /// <summary>
        /// The margin around the window to allow for a drop shadow
        /// </summary>
        public Thickness OuterMarginSizeThickness {
            get {
                return new Thickness(OuterMarginSize);
            }
        }

        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        public int WindowRadius {
            get {
                return mWindow.WindowState == WindowState.Maximized ? 0 : mWindowRadius;
            }
            set {
                mWindowRadius = value;
            }
        }

        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        public CornerRadius WindowCornerRadius {
            get {
                return new CornerRadius(WindowRadius);
            }
        }

        /// <summary>
        /// The height of the title bar / caption of the window
        /// </summary>
        public int TitleHeight { get; set; } = 40;

        /// <summary>
        /// The height of the title bar / caption of the window
        /// </summary>
        public GridLength TitleHeightGridLength {
            get {
                return new GridLength(TitleHeight + ResizeBorder);
            }
        }

        #endregion

        #region General variables

        /// <summary>
        /// The collection of sensors for live updating items
        /// </summary>
        public ObservableCollection<Proxy> Proxies { get; set; }

        /// <summary>
        /// The collection of sensors to display items for
        /// </summary>
        public ICollectionView ProxiesView { get; set; }

        #endregion

        #region Commands for Controls

        /// <summary>
        /// The command to minimize the window
        /// </summary>
        public ICommand MinimizeCommand { get; set; }

        /// <summary>
        /// The command to maximize the window
        /// </summary>
        public ICommand MaximizeCommand { get; set; }

        /// <summary>
        /// The command to close the window
        /// </summary>
        public ICommand CloseCommand { get; set; }

        /// <summary>
        /// The command to show system menu of the window
        /// </summary>
        public ICommand MenuCommand { get; set; }

        #endregion Commands for Controls

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="window"></param>
        public MainViewModel(Window window) {
            mWindow = window;

            // Listen out for the window resizing
            mWindow.StateChanged += (sender, e) => {
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(OuterMarginSizeThickness));
                OnPropertyChanged(nameof(WindowRadius));
                OnPropertyChanged(nameof(WindowCornerRadius));

                OnPropertyChanged(nameof(WindowMinimumWidth));
                OnPropertyChanged(nameof(WindowMinimumHeight));

            };

            // Create commands for controls
            MinimizeCommand = new RelayCommand(() => mWindow.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand(() => mWindow.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => mWindow.Close());
            MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(mWindow, getMousePosition()));

            // Fix window resize issue
            var resizer = new WindowResizer(mWindow);

            // Load proxy data
            List<Proxy> test = new List<Proxy>();

            Proxies = new ObservableCollection<Proxy>(test);

            Proxies.CollectionChanged += (s, e) => {
                File.WriteAllText("ProxiesData.json", JsonConvert.SerializeObject(Proxies));
            };
            BindingOperations.EnableCollectionSynchronization(Proxies, new object());
            ProxiesView = CollectionViewSource.GetDefaultView(Proxies);

            //string json = JsonConvert.SerializeObject(SensorsView, Formatting.Indented);
            //MessageBox.Show(json);

        }

        #endregion

        #region Command handlers

        public ICommand ChangeSettings {
            get {
                if (mChangeSettings == null)
                    mChangeSettings = new RelayCommand(SettingsWindow);
                return mChangeSettings;
            }
        }

        private void SettingsWindow() {
            //var SettingsWindow = new SettingsWindow();
            //var SettingsViewModel = new SettingsViewModel(SettingsWindow);
            //SettingsWindow.DataContext = SettingsViewModel;
            //SettingsWindow.Show();
        }

        #endregion

        #region Private Helpers

        /// <summary>
        /// Gets the current mouse position on the screen
        /// </summary>
        /// <returns></returns>
        private Point getMousePosition() {
            // Position of the mouse relative to the window
            var position = Mouse.GetPosition(mWindow);

            // Add the  window position
            return new Point(position.X + mWindow.Left, position.Y + mWindow.Top);
        }

        #endregion



    }
}
