using System;
using DevExpress.XtraSplashScreen;

namespace GUI
{
    public partial class SplashScreen2 : SplashScreen
    {
        public enum SplashScreenCommand
        {
        }

        public SplashScreen2()
        {
            InitializeComponent();
        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion
    }
}