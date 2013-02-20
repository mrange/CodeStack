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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AutoFetching
{
    public partial class MainWindow
    {
        ObservableCollection<CustomerViewModel> m_customers = new ObservableCollection<CustomerViewModel>();
        PrefetchingCollectionView m_prefetchingCollectionView;

        public MainWindow()
        {
            InitializeComponent();

            AddCustomers(GenerateCustomers(0).Take(10).ToArray());

            m_prefetchingCollectionView = new PrefetchingCollectionView(10, m_customers);
            m_prefetchingCollectionView.PrefetchRequest += prefetchingCollectionView_PrefetchRequest;
            Items.ItemsSource = m_prefetchingCollectionView;
        }

        void prefetchingCollectionView_PrefetchRequest(object sender, EventArgs e)
        {
            var customers = GenerateCustomers(m_customers.Count).Take(10).ToArray();
            AddCustomers(customers);
        }

        void AddCustomers(CustomerViewModel[] customers)
        {
            foreach (var customer in customers)
            {
                m_customers.Add(customer);
            }
        }

        static string GetRandomString(Random random, int length)
        {
            var bytes = new byte[length];
            random.NextBytes(bytes);

            return new string (bytes.Select(b => (char) ((b%25) + 'A')).ToArray());
        }

        static IEnumerable<CustomerViewModel> GenerateCustomers(int idSeed)
        {
            var random = new Random();
            while (true)
            {
                yield return new CustomerViewModel
                                 {
                                     Id = idSeed++,
                                     FirstName = GetRandomString(random, 10),
                                     LastName = GetRandomString(random, 10),
                                 };
            }
        }
    }
}
