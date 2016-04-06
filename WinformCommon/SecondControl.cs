using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformCommon
{

    public class SecondControl:Collection<ColumnHeader>
    {
        public event EventHandler<CollectionChangeEventArgs> ItemChanged;

        public SecondControl()
        {

        }

        protected override void InsertItem(int index, ColumnHeader item)
        {
            base.InsertItem(index, item);
            ItemChanged(this, new CollectionChangeEventArgs(CollectionChangeAction.Add, item));
        }

        protected override void ClearItems()
        {
            base.ClearItems();
            ItemChanged(this, new CollectionChangeEventArgs(CollectionChangeAction.Refresh, null));
        }

        protected override void RemoveItem(int index)
        {
            base.RemoveItem(index);
            ItemChanged(this, new CollectionChangeEventArgs(CollectionChangeAction.Remove, this[index]));
        }

        protected override void SetItem(int index, ColumnHeader item)
        {
            base.SetItem(index, item);
            ItemChanged(this, new CollectionChangeEventArgs(CollectionChangeAction.Refresh, null));
        }

        private void OnItemPropertyChanged(Object sender)
        {
            ItemChanged(sender, null);
        }

        //在需要使用的地方就可以
        //protected virtual void OnCollectionPropertyChanged(CollectionChangeEventArgs e)
        //{
        //    EventHandler<CollectionChangeEventArgs> handler=ItemChanged;
        //    if(handler!=null)
        //    {
        //         handler(this,e);
        //     }
        //}

        //private SecondControl headers = new SecondControl();
        //headers.ItemChanged+=new CollectionChangeEventHandler(OnCollectionPropertyChanged);
    }
}
