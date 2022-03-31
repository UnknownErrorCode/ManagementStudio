using System.Windows.Forms.DataVisualization.Charting;

namespace ServerFrameworkRes.Network.ServerBody
{
    public class ISeries : Series
    {
        #region Constructors

        public ISeries(string textName, string realName, int YBindings)
        {
            TextName = textName;
            RealName = realName;
            LegendText = TextName;
            Name = RealName;
            AxisLabel = TextName;
            Color = System.Drawing.Color.LawnGreen;
            IsVisibleInLegend = true;
            IsXValueIndexed = true;
            ChartType = SeriesChartType.Line;
            Tag = TextName;
            CurrentYValue = YBindings;
        }

        #endregion Constructors

        #region Properties

        public int CurrentYValue { get; set; }
        public string RealName { get; set; }
        public string TextName { get; set; }

        #endregion Properties
    }
}