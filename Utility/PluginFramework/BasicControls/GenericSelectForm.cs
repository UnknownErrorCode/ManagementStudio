using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PluginFramework.BasicControls
{
    public interface IGenericSelectObject
    {
        string Name { get; set; }
        Object Object { get; set; }
    }

    public partial class GenericSelectForm : Form
    {
        public static List<IGenericSelectObject> Collection = new List<IGenericSelectObject>();
        public Object SelectedPosition;
        public bool isSelected = false;

        public GenericSelectForm()
        {
            InitializeComponent();
        }

        public static bool SelectObjStruct<T>(Dictionary<string, T> dic, out T sel) where T : struct
        {
            using (var selecter = new GenericSelectForm())
            {
                selecter.InitializeStruct<T>(dic);
                selecter.ShowDialog();
                if (selecter.isSelected)
                {
                    sel = (T)selecter.SelectedPosition;
                    return true;
                }
                sel = default(T);
                return false;
            }
        }

        public static bool SelectObjStruct<T>(ConcurrentDictionary<string, T> dic, out T sel) where T : struct
        {
            using (var selecter = new GenericSelectForm())
            {
                selecter.InitializeStruct<T>(dic);
                selecter.ShowDialog();
                if (selecter.isSelected)
                {
                    sel = (T)selecter.SelectedPosition;
                    return true;
                }
                sel = default(T);
                return false;
            }
        }

        public static bool SelectObjStruct<T>(Dictionary<int, T> dic, out T sel) where T : struct
        {
            using (var selecter = new GenericSelectForm())
            {
                selecter.InitializeStruct<T>(dic);
                selecter.ShowDialog();
                if (selecter.isSelected)
                {
                    sel = (T)selecter.SelectedPosition;
                    return true;
                }
                sel = default(T);
                return false;
            }
        }

        public static bool SelectObjStruct<T>(ConcurrentDictionary<int, T> dic, out T sel) where T : struct
        {
            using (var selecter = new GenericSelectForm())
            {
                selecter.InitializeStruct<T>(dic);
                selecter.ShowDialog();
                if (selecter.isSelected)
                {
                    sel = (T)selecter.SelectedPosition;
                    return true;
                }
                sel = default(T);
                return false;
            }
        }

        public static bool SelectObjClass<T>(Dictionary<string, T> dic, out T sel) where T : class
        {
            using (var selecter = new GenericSelectForm())
            {
                selecter.InitializeClass<T>(dic);
                selecter.ShowDialog();
                if (selecter.isSelected)
                {
                    sel = (T)selecter.SelectedPosition;
                    return true;
                }
                sel = default(T);
                return false;
            }
        }

        public static bool SelectObjClass<T>(Dictionary<int, T> dic, out T sel) where T : class
        {
            using (var selecter = new GenericSelectForm())
            {
                selecter.InitializeClass<T>(dic);
                selecter.ShowDialog();
                if (selecter.isSelected)
                {
                    sel = (T)selecter.SelectedPosition;
                    return true;
                }
                sel = default(T);
                return false;
            }
        }

        public static bool SelectObjClass<T>(ConcurrentDictionary<int, T> dic, out T sel) where T : class
        {
            using (var selecter = new GenericSelectForm())
            {
                selecter.InitializeClass<T>(dic);
                selecter.ShowDialog();
                if (selecter.isSelected)
                {
                    sel = (T)selecter.SelectedPosition;
                    return true;
                }
                sel = default(T);
                return false;
            }
        }

        public void InitializeStruct<T>(Dictionary<string, T> objects) where T : struct
        {
            foreach (var item in objects)
                AddStructStringT(item);
        }

        public void InitializeStruct<T>(ConcurrentDictionary<string, T> objects) where T : struct
        {
            foreach (var item in objects)
                AddStructStringT(item);
        }

        public void InitializeStruct<T>(Dictionary<int, T> objects) where T : struct
        {
            foreach (var item in objects)
                AddStructIntT(item);
        }

        public void InitializeStruct<T>(ConcurrentDictionary<int, T> objects) where T : struct
        {
            foreach (var item in objects)
                AddStructIntT(item);
        }

        private void AddStructStringT<T>(KeyValuePair<string, T> item) where T : struct
        {
            ListViewItem i = new ListViewItem(item.Key) { Tag = item.Value };
            listView1.Items.Add(i);
            IGenericSelectObject defau = new GenericSelectObject();
            defau.Name = item.Key;
            defau.Object = item.Value;
            Collection.Add(defau);
        }

        private void InitializeClass<T>(Dictionary<string, T> dic) where T : class
        {
            foreach (var item in dic)
            {
                AddClassStringT(item);
            }
        }

        private void InitializeClass<T>(ConcurrentDictionary<string, T> dic) where T : class
        {
            foreach (var item in dic)
            {
                AddClassStringT(item);
            }
        }

        private void AddClassStringT<T>(KeyValuePair<string, T> item) where T : class
        {
            ListViewItem i = new ListViewItem(item.Key) { Tag = item.Value };
            listView1.Items.Add(i);
            IGenericSelectObject defau = new GenericSelectObject();
            defau.Name = item.Key;
            defau.Object = item.Value;
            Collection.Add(defau);
        }

        private void InitializeClass<T>(Dictionary<int, T> dic) where T : class
        {
            foreach (var item in dic)
            {
                AddClassIntT(item);
            }
        }

        private void InitializeClass<T>(ConcurrentDictionary<int, T> dic) where T : class
        {
            foreach (var item in dic)
            {
                AddClassIntT(item);
            }
        }

        private void AddStructIntT<T>(KeyValuePair<int, T> item) where T : struct
        {
            ListViewItem i = new ListViewItem(item.Key.ToString()) { Tag = item.Value };
            listView1.Items.Add(i);
            IGenericSelectObject defau = new GenericSelectObject();
            defau.Name = item.Key.ToString();
            defau.Object = item.Value;
            Collection.Add(defau);
        }

        private void AddClassIntT<T>(KeyValuePair<int, T> item) where T : class
        {
            ListViewItem i = new ListViewItem(item.Key.ToString()) { Tag = item.Value };
            listView1.Items.Add(i);
            IGenericSelectObject defau = new GenericSelectObject();
            defau.Name = item.Key.ToString();
            defau.Object = item.Value;
            Collection.Add(defau);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                propertyGrid1.SelectedObject = listView1.SelectedItems[0].Tag;
                buttonSelect.Enabled = true;
                buttonDelete.Enabled = true;
            }
            else
            {
                propertyGrid1.SelectedObject = null;
                buttonSelect.Enabled = false;
                buttonDelete.Enabled = false;
            }
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            SelectedPosition = listView1.SelectedItems[0].Tag;
            isSelected = true;
            this.Close();
        }
    }

    internal class GenericSelectObject : IGenericSelectObject
    {
        public string Name { get; set; }
        public object Object { get; set; }
    }
}