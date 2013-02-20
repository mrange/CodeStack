// ----------------------------------------------------------------------------------------------
// Copyright (c) Mårten Rånge.
// ----------------------------------------------------------------------------------------------
// This source code is subject to terms and conditions of the Microsoft Public License. A 
// copy of the license can be found in the License.html file at the root of this distribution. 
// If you cannot locate the  Microsoft Public License, please send an email to 
// dlr@microsoft.com. By using this source code in any fashion, you are agreeing to be bound 
//  by the terms of the Microsoft Public License.
// ----------------------------------------------------------------------------------------------
// You must not remove this notice, or any other, from this software.
// ----------------------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Windows.Data;

namespace AutoFetching
{
    delegate void PrefetchRequestDelegate(object sender, EventArgs e);

    class PrefetchingCollectionView : CollectionView
    {
        int m_cutoff;

        public PrefetchingCollectionView(int cutoff, IList collection) : base(collection)
        {
            m_cutoff = cutoff;
        }

        public override object GetItemAt(int index)
        {
            if (Count < m_cutoff + index)
            {
                OnPrefetchRequest();
            }

            return base.GetItemAt(index);
        }

        public event PrefetchRequestDelegate PrefetchRequest;

        protected virtual void OnPrefetchRequest()
        {
            var handler = PrefetchRequest;
            if (handler != null) handler(this, EventArgs.Empty);
        }
    }
}