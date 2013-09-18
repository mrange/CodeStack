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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    static class Program
    {
        static void Main(string[] args)
        {
            var vp = new ValidPercent (50M);
            Percent p = vp;

            Console.WriteLine (vp);
            Console.WriteLine (p);

            try
            {
                var vp2 = new ValidPercent (101M);
            }
            catch (ArgumentException exc)
            {
                Console.WriteLine ("Caught excepted exception: {0}", exc.Message);
            }


        }
    }
}
