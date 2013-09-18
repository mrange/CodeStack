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
    partial struct ValidPercent 
    {
        public static implicit operator Percent(ValidPercent vp)
        {
            return new Percent (vp.Value);
        }

        static partial void Partial_ValidateValue(decimal value)
        {
            if (value < 0M || value > 100M)
            {
                throw new ArgumentException ("value", "value is expected to be in the range 0..100");
            }
        }
    }
}
