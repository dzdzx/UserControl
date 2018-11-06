using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyGauge3
{
    /// <summary>
    /// GaugeCon.xaml 的交互逻辑
    /// </summary>
    public partial class GaugeCon : UserControl
    {

        #region Dependency Properties
        public static DependencyProperty StartAngleProperty = DependencyProperty.Register("StartAngle", typeof(double), typeof(GaugeCon));
        public static DependencyProperty EndAngleProperty = DependencyProperty.Register("EndAngle", typeof(double), typeof(GaugeCon));
        public static DependencyProperty MaxValueProperty = DependencyProperty.Register("MaxValue", typeof(double), typeof(GaugeCon));

        public double StartAngle
        {
            get { return (double)base.GetValue(StartAngleProperty); }
            set { base.SetValue(StartAngleProperty, value); }
        }
        public double EndAngle
        {
            get { return (double)base.GetValue(EndAngleProperty); }
            set { base.SetValue(EndAngleProperty, value); }
        }
        public double MaxValue
        {
            get { return (double)base.GetValue(MaxValueProperty); }
            set { base.SetValue(MaxValueProperty, value); }
        }
        #endregion Dependency Properties
        public GaugeCon()
        {
            InitializeComponent();
            double a = StartAngle;
            double e = a;
        }
    }
}
