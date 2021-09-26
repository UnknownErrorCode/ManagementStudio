using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorldMapSpawnEditor._2dMapViewer.Forms
{
    public partial class SpawnEditor : Form
    {
        public SingleSpawn CurrentSpawn { get; set; }
        internal SpawnEditor(SingleSpawn spawn)
        {
            InitializeComponent();
            CurrentSpawn = spawn;
            propertyGrid1.SelectedObject = CurrentSpawn.Nest;
            propertyGrid2.SelectedObject = CurrentSpawn.Hive;
            propertyGrid3.SelectedObject = CurrentSpawn.Tactics;
            propertyGrid4.SelectedObject = CurrentSpawn.ObjCommon;
            propertyGrid5.SelectedObject = CurrentSpawn.ObjChar;
            propertyGrid1.Refresh();
            propertyGrid2.Refresh();
            propertyGrid3.Refresh();
            propertyGrid4.Refresh();
            propertyGrid5.Refresh();
        }

        internal void InitializeSpawn()
        {

        }
    }
}
