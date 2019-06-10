using casino;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace gui.Utils
{
    public class DataGridSelectedItems : Behavior<DataGrid>
    {
        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register("SelectedItems", typeof(IList<Gambler>),
            typeof(DataGridSelectedItems),
            new FrameworkPropertyMetadata(null)
            {
                BindsTwoWayByDefault = true
            });

        public IList<Gambler> SelectedItems
        {
            get
            {
                return (IList<Gambler>)GetValue(SelectedItemProperty);
            }
            set
            {
                SetValue(SelectedItemProperty, value);
            }
        }

        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.SelectionChanged += OnSelectionChanged;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            if (AssociatedObject != null)
            {
                AssociatedObject.SelectionChanged -= OnSelectionChanged;
            }
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems != null && e.AddedItems.Count > 0 && SelectedItems != null)
            {
                foreach (Gambler obj in e.AddedItems)
                {
                    SelectedItems.Add(obj);
                }
            }

            if (e.RemovedItems != null && e.RemovedItems.Count > 0 && SelectedItems != null)
            {
                foreach (Gambler obj in e.RemovedItems)
                {
                    SelectedItems.Remove(obj);
                }
            }
        }
    }
}
