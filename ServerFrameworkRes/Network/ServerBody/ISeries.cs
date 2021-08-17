using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace ServerFrameworkRes.Network.ServerBody
{
    public class ISeries : Series
    {
        public string TextName { get; set; }
        public string RealName { get; set; }
        public int CurrentYValue { get; set; }

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
    }
}
