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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyAgaue2
{
    /// <summary>
    /// GaugeControl.xaml 的交互逻辑
    /// </summary>
    public partial class GaugeControl : UserControl
    {
        public  double angelCurrent = 0;
        public  double angleNext = 0;
        public  RotateTransform rt = new RotateTransform();
        
        //public static double min = 0;
        //public static double max = 0;
        //public static double maxA = 0;
        //public static double minA = 0;
        
        /**控件新增依赖属性
         * **/
        #region NewProperty
        //StartAngle--刻度最小值在表盘的最小角度
        public static DependencyProperty StartAngleProperty = DependencyProperty.Register("StartAngle", typeof(double),typeof(GaugeControl),new PropertyMetadata(-30d, OnPropertyChange));
        //EndAngle--刻度最大值在表盘的最大角度
        public static DependencyProperty EndAngleProperty = DependencyProperty.Register("EndAngle",typeof(double),typeof(GaugeControl),new PropertyMetadata(210d, OnPropertyChange));
        //MaxValue--量程最大值
        public static DependencyProperty MaxValueProperty = DependencyProperty.Register("MaxValue", typeof(double), typeof(GaugeControl), new PropertyMetadata(100d, OnPropertyChange));
        //MinValue--量程最小值
        public static DependencyProperty MinValueProperty = DependencyProperty.Register("MinValue", typeof(double), typeof(GaugeControl), new PropertyMetadata(0.0d, OnPropertyChange));
        //MajorTickCount--大刻度分度
        public static DependencyProperty MajorTickCountProperty = DependencyProperty.Register("MajorTickCount", typeof(int), typeof(UserControl1), new PropertyMetadata(10, OnPropertyChange));
        //MinorTickCount--小刻度分度
        public static DependencyProperty MinorTickCountProperty = DependencyProperty.Register("MinorTickCount", typeof(int), typeof(UserControl1), new PropertyMetadata(4, OnPropertyChange));
        //Value--仪表示数值
        public static DependencyProperty ValuePropert = DependencyProperty.Register("Value", typeof(int), typeof(GaugeControl), new PropertyMetadata(0,OnValueChange));
        //预留------
        public static DependencyProperty NWidthPropert = DependencyProperty.Register("NWidth", typeof(double), typeof(GaugeControl));
        public static DependencyProperty NHeightPropert = DependencyProperty.Register("NHeight", typeof(double), typeof(GaugeControl));
        //ScaleMargin--表盘刻度标尺半径
        public static DependencyProperty ScaleMarginPropert = DependencyProperty.Register("ScaleMargin", typeof(double), typeof(GaugeControl),new PropertyMetadata(20d, OnPropertyChange));
        //ScaleLabelMargin--表盘刻度值半径
        public static DependencyProperty ScaleLabelMarginPropert = DependencyProperty.Register("ScaleLabelMargin", typeof(double), typeof(GaugeControl), new PropertyMetadata(35d, OnPropertyChange));
        //PointerL--表盘指针长度比例
        public static DependencyProperty PointerLPropert = DependencyProperty.Register("PointerL", typeof(double), typeof(GaugeControl), new PropertyMetadata(1d, OnPropertyChange));
        //VLMargin--表盘示数值
        public static DependencyProperty VLMarginPropert = DependencyProperty.Register("VLMargin",typeof(double),typeof(GaugeControl),new PropertyMetadata(0d,OnPropertyChange));
        //TickLabelStyle--刻度值样式
        public static DependencyProperty TickLabelStyleProperty = DependencyProperty.Register("TickLabelStyle", typeof(Style), typeof(GaugeControl));
        //ValueLabelStyle--示数值样式
        public static DependencyProperty ValueLabelStyleProperty = DependencyProperty.Register("ValueLabelStyle", typeof(Style), typeof(GaugeControl));
        //MajorTickMarkColor--表盘外边框样式
        public static DependencyProperty MajorTickMarkColorProperty = 
            DependencyProperty.Register("MajorTickMarkColor", typeof(Brush), typeof(GaugeControl), new PropertyMetadata(Brushes.White, OnPropertyChange));
        //MinorTickMarkColor--表盘样式
        public static DependencyProperty MinorTickMarkColorProperty =
            DependencyProperty.Register("MinorTickMarkColor", typeof(Brush), typeof(GaugeControl),new PropertyMetadata(Brushes.White, OnPropertyChange));


        #endregion NewProperty

        /**新增属性封装
         * **/
        //表盘指针动态变化
        public static void OnValueChange(DependencyObject d, DependencyPropertyChangedEventArgs e) {

            GaugeControl gauge = d as GaugeControl;
            gauge.angelCurrent = gauge.angleNext;
            double tempValue = (int)e.NewValue * 1.0 > gauge.MaxValue ? gauge.MaxValue : (int)e.NewValue * 1.0;
            tempValue = (int)e.NewValue * 1.0 < gauge.MinValue ? gauge.MinValue : (int)e.NewValue * 1.0;

            double valueInPercent = ( tempValue - gauge.MinValue) / (gauge.MaxValue - gauge.MinValue);

            var valueInDegrees = valueInPercent * (gauge.EndAngle- gauge.StartAngle) + gauge.StartAngle;

            gauge.angleNext = valueInDegrees;
            
            
            double timeAnimation = Math.Abs(gauge.angelCurrent - gauge.angleNext) * 10;
            System.Windows.Media.Animation.DoubleAnimation da = new System.Windows.Media.Animation.DoubleAnimation(gauge.angelCurrent, gauge.angleNext, new Duration(TimeSpan.FromMilliseconds(timeAnimation)));
            da.AccelerationRatio = 1;
            gauge.rt.BeginAnimation(RotateTransform.AngleProperty, da);

        }
        //表盘重绘
        public static void  OnPropertyChange(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            GaugeControl gauge = d as GaugeControl;
            gauge.UIupdate();
            System.Console.WriteLine();
        }

        #region Property Var
        public double StartAngle {
            get { return (double)base.GetValue(StartAngleProperty); }
            set { base.SetValue(StartAngleProperty,value); }
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
        public double MinValue
        {
            get { return (double)base.GetValue(MinValueProperty); }
            set { base.SetValue(MinValueProperty, value); }
        }
        public int MajorTickCount
        {
            get { return (int)base.GetValue(MajorTickCountProperty); }
            set { base.SetValue(MajorTickCountProperty, value); }
        }
        public int MinorTickCount
        {
            get { return (int)base.GetValue(MinorTickCountProperty); }
            set { base.SetValue(MinorTickCountProperty, value); }
        }
        public int Value {
            get { return (int)base.GetValue(ValuePropert); }
            set { base.SetValue(ValuePropert, value); }
        }
        public double NWidth {
            get { return (double)base.GetValue(NWidthPropert); }
            set { base.SetValue(NWidthPropert, value); }
        }
        public double NHeight
        {
            get { return (double)base.GetValue(NHeightPropert); }
            set { base.SetValue(NHeightPropert, value); }
        }
        public double ScaleMargin
        {
            get { return (double)base.GetValue(ScaleMarginPropert); }
            set { base.SetValue(ScaleMarginPropert, value); }
        }
        public double PointerL
        {
            get { return (double)base.GetValue(PointerLPropert); }
            set { base.SetValue(PointerLPropert, value); }
        }
        public double ScaleLabelMargin
        {
            get { return (double)base.GetValue(ScaleLabelMarginPropert); }
            set { base.SetValue(ScaleLabelMarginPropert, value); }
        }

        public Brush MajorTickMarkColor
        {
            get { return (Brush)base.GetValue(MajorTickMarkColorProperty); }
            set { base.SetValue(MajorTickMarkColorProperty, value); }
        }

        public Brush MinorTickMarkColor
        {
            get { return (Brush)base.GetValue(MinorTickMarkColorProperty); }
            set { base.SetValue(MinorTickMarkColorProperty, value); }
        }

        public double VLMargin
        {
            get { return (double)base.GetValue(VLMarginPropert); }
            set { base.SetValue(VLMarginPropert, value); }
        }

        public Style TickLabelStyle
        {
            get { return (Style)base.GetValue(TickLabelStyleProperty); }
            set { base.SetValue(TickLabelStyleProperty, value); }
        }

        public Style ValueLabelStyle
        {
            get { return (Style)base.GetValue(ValueLabelStyleProperty); }
            set { base.SetValue(ValueLabelStyleProperty, value); }
        }

        #endregion Property Var



        public GaugeControl()
        {
            this.SizeChanged += (s, e) => { UIupdate(); };
            InitializeComponent();
            angelCurrent = this.StartAngle;
            angleNext = this.StartAngle;
            UIupdate();

        }

        public void GreatInit() {
            //angelCurrent = this.StartAngle;
            //angleNext = this.StartAngle;
            rt.CenterX = this.Width / 2;
            rt.CenterY = this.Height / 2;
            rt.Angle = this.StartAngle;
            this.NeedlePointer.Transform = rt;
            //max = this.MaxValue;
           // min = this.MinValue;
            //maxA = this.EndAngle;
           // minA = this.StartAngle;
    }

        /**尺寸变化是更新指针值
         * **/
        public void DrawPointer() {
            
            double w = this.Width;
            double h = this.Height;
            double a = 0.5*w;
            double b = 0.5*h;
            double c = (60d / 300d)*this.PointerL * w;

            rt.CenterX = w/2;
            rt.CenterY = w/2;

            Point p1 = new Point(a,b);
            Point p2 = new Point(a-2d / 15d*a,b-1d/30d*b);
            Point p3 = new Point(c,a);
            Point p4 = new Point(a- 2d / 15d * a, b+ 1d / 30d * b);
            
            PathFigure pf = new PathFigure();
            pf.StartPoint = p1;
            pf.Segments.Add(new LineSegment(p2,true));
            pf.Segments.Add(new LineSegment(p3, true));
            pf.Segments.Add(new LineSegment(p4, true));
            this.NeedlePointer.Clear();
            this.NeedlePointer.Figures.Add(pf);
            

        }
        //重绘方法
        public void UIupdate() {
            GreatInit();
            DrawPointer();
            this.ScaleMarker.Children.Clear();//清除画板
            //计算尺度角
            var totalDegrees = this.EndAngle - this.StartAngle;
            var degreeIncrement = totalDegrees / (this.MajorTickCount);
            var labelIncrement = (this.MaxValue - this.MinValue) / (this.MajorTickCount);
            var smallDegreeIncrement = degreeIncrement / (this.MinorTickCount + 1);

            ScaleStyle majorStyle = new ScaleStyle();
            ScaleStyle minorStyle = new ScaleStyle();
        //绘画出大刻度
        List<DockPanel> listDP = new List<DockPanel>();
            for (int i = 0; i <= this.MajorTickCount; i++) {
                majorStyle.TickAngle = (i * degreeIncrement) + this.StartAngle;
                majorStyle.LineHeight = 15;
                majorStyle.TickStrokeTickness = 5;
                majorStyle.TickMargin = this.ScaleMargin;
                majorStyle.TickWidth = this.Width;
                majorStyle.TickHeight = this.Height;
                majorStyle.SLabelMargin = this.ScaleLabelMargin;
                String tempTxt = ((i * labelIncrement) + this.MinValue).ToString();
                this.ScaleMarker.Children.Add(DrawScale(majorStyle));
                this.ScaleMarker.Children.Add(DrawScaleLable(majorStyle, tempTxt));

                for (int j = 0; j<+ this.MinorTickCount; j++) {
                    if (i == this.MajorTickCount) break;
                    minorStyle.TickAngle = majorStyle.TickAngle + (j * smallDegreeIncrement) + smallDegreeIncrement;
                    minorStyle.TickStrokeTickness = 2;
                    minorStyle.LineHeight = 10;
                    minorStyle.TickMargin = this.ScaleMargin;
                    minorStyle.TickWidth = this.Width;
                    minorStyle.TickHeight = this.Height;
                    this.ScaleMarker.Children.Add(DrawScale(minorStyle));
                }
            }

            //绘画出数值框
            ValueLabel.Margin = new Thickness(0,0,0,VLMargin-80);
            ValueLabel.Style = ValueLabelStyle;
        }

        /**绘画刻度
         * **/
        public DockPanel DrawScale(ScaleStyle tStyle) {
            DockPanel ScalePanel = new DockPanel();
            ScalePanel.Width = tStyle.TickWidth;
            ScalePanel.RenderTransformOrigin = new Point(0.5,0.5);
            ScalePanel.RenderTransform = new RotateTransform(tStyle.TickAngle);
           
            Panel.SetZIndex(ScalePanel,2);
            ScalePanel.LastChildFill = false;
            
            ScalePanel.VerticalAlignment = VerticalAlignment.Center;
            Line ScaleLine = new Line();
            ScaleLine.X1 = 100;
            ScaleLine.Width = tStyle.LineHeight;
            ScaleLine.Margin = new Thickness(tStyle.TickMargin,0,0,0);
            ScaleLine.StrokeThickness = tStyle.TickStrokeTickness;
            ScaleLine.Stroke = new SolidColorBrush(Colors.Black);
            
            BlurEffect be = new BlurEffect();
            be.Radius = 3;
            ScaleLine.Effect = be;
            ScalePanel.Children.Add(ScaleLine);
            return ScalePanel;
        }


        /**绘画刻度值
         * **/
        public DockPanel DrawScaleLable(ScaleStyle tStyle, String labletxt) {
            DockPanel LablePanel = new DockPanel();
            LablePanel.Height = tStyle.TickHeight;
            LablePanel.Width = tStyle.TickWidth/3;
            LablePanel.LastChildFill = false;
            LablePanel.HorizontalAlignment = HorizontalAlignment.Center;
            LablePanel.VerticalAlignment = VerticalAlignment.Stretch;
            LablePanel.RenderTransformOrigin = new Point(0.5,0.5);
            LablePanel.RenderTransform = new RotateTransform(tStyle.TickAngle-90);
            Panel.SetZIndex(LablePanel, 2);

            TextBlock LableScale = new TextBlock();
            LableScale.Width = 100;
            LableScale.HorizontalAlignment = HorizontalAlignment.Center;
            LableScale.VerticalAlignment = VerticalAlignment.Top;
            LableScale.TextAlignment = TextAlignment.Center;
            LableScale.Margin = new Thickness(0,tStyle.SLabelMargin,0,0);
            LableScale.Text = labletxt;
            LableScale.Style = TickLabelStyle;
            LablePanel.Children.Add(LableScale);

            return LablePanel;
        }

    }
}
