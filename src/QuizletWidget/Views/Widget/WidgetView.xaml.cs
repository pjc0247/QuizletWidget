using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QuizletWidget.Views.Widget
{
    using QuizletWidget.Utils;
    using System.Windows.Threading;

    public partial class WidgetView : Window
    {
        private DispatcherTimer MouseTrackingTimer;

        public WidgetView()
        {
            InitializeComponent();

            SetWindowLocation();
        }

        private void Window_MouseEnter(object sender, MouseEventArgs e)
        {
            EnableTransparency();
        }

        private void SetWindowLocation()
        {
            var width = SystemParameters.WorkArea.Width;
            var height = SystemParameters.WorkArea.Height;
            Left = width - Width - 10;
            Top = height - Height - 26;
        }

        #region MOUSE_TRACKING
        private void EnableTransparency()
        {
            Opacity = 0.1;
            StartMouseTracking();

            var hWndMe = new WindowInteropHelper(this).Handle;
            Win32API.SetWindowExTransparent(hWndMe);
        }
        private void DisableTransparency()
        {
            StopMouseTracking();
            Opacity = 1.0;

            var hWndMe = new WindowInteropHelper(this).Handle;
            Win32API.UnsetWindowExTransparent(hWndMe);
        }

        private void StartMouseTracking()
        {
            MouseTrackingTimer = new DispatcherTimer();
            MouseTrackingTimer.Tick += new EventHandler(OnQueryMouseTimer);
            MouseTrackingTimer.Interval = TimeSpan.FromMilliseconds(100);
            MouseTrackingTimer.Start();
        }
        private void StopMouseTracking()
        {
            if (MouseTrackingTimer != null)
                MouseTrackingTimer.Stop();
            MouseTrackingTimer = null;
        }
        private void OnQueryMouseTimer(object sender, EventArgs e)
        {
            var mouse = Win32API.GetMousePosition();

            if (!(mouse.X >= Left && mouse.X <= Left + Width &&
                mouse.Y >= Top && mouse.Y <= Top + Height))
            {
                DisableTransparency();
            }
        }
        #endregion
    }
}
