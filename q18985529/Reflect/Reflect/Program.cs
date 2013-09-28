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
using System.Reflection;

namespace Reflect
{
    class Program
    {
        static void Main(string[] args)
        {
            var assembly = Assembly.ReflectionOnlyLoad ("X64");

            var types = assembly.GetTypes ();

            foreach (var type in types)
            {
                Console.WriteLine (type.FullName);

                foreach (var field in type.GetFields ())
                {
                    Console.WriteLine ("  {0} {1}", field.FieldType, field.Name);
                }

                foreach (var property in type.GetProperties ())
                {
                    Console.WriteLine ("  {0} {1}", property.PropertyType, property.Name);
                }

            }

        }
    }
}
