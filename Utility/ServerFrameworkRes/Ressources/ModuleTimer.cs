﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ServerFrameworkRes.Ressources
{
    public class ModuleTimer
    {
        #region Enums

        private enum NoBody
        {
            GlobalManagerServerBody,
            MachineManagerServerBody,
            DownloadServerServerBody,
            GatewayServerServerBody,
            AgentServerServerBody,
        }

        #endregion Enums

        #region Properties

        public Timer MTimer { get; set; }

        private Chart _chart { get; set; }

        private NoBody BodySwitch { get; }

        #endregion Properties

        #region Methods

        private void InitializeMTimer(Chart Charter)
        {
            _chart = Charter;
            MTimer = new Timer()
            { Interval = 1000 };
            MTimer.Tick += MTimer_Tick;
        }

        private void MTimer_Tick(object sender, EventArgs e)
        {
            foreach (Series item in _chart.Series)
            {
                if (item.Points.Count >= 60)
                {
                    item.Points.RemoveAt(0);
                }
                KeyValuePair<int, string> SeriesInfo = new KeyValuePair<int, string>();

                //Adding Pointer
                item.Points.AddXY(DateTime.Now.ToString("hh:mm:ss"), SeriesInfo.Key);

                //LegendeUpdate
                string legendText = $"({SeriesInfo.Key}) {item.Tag} {SeriesInfo.Value}";

                item.LegendText = legendText;
            }
        }

        #endregion Methods
    }
}