using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Collections;



namespace ObjectComparer
{
    public static class Comparer
    {
        public static bool AreSimilar<T>(T first, T second )
        {
            
            /// Add your implementation logic here. Feel free to add classes and types as required for your solution.

            // 1st Case
            if (first == null || second == null)
            {
                return false;
            }

            Type typeOfFirst = first.GetType();
            Type typeOfSecond = second.GetType();
            
            // 2nd Case
            if (!typeOfFirst.Equals(typeOfSecond))
            {
                return false;
            }

            // 3rd Case
            if(typeOfFirst.IsPrimitive || typeof(string).Equals(typeOfFirst))
            {
                return (first.Equals(second));
            }

            // 4th Case
            if(typeOfFirst.IsArray)
            {
                Array firstArray = first as Array;
                Array secondArray = second as Array;
                Array.Sort(firstArray);
                Array.Sort(secondArray);

                if (firstArray.Length != secondArray.Length)
                    return false;
                var en = firstArray.GetEnumerator();
                int i = 0;
                while (en.MoveNext())
                {
                    if (!AreSimilar(en.Current, secondArray.GetValue(i)))
                        return false;
                    i++;
                }
            }

            // 5th Case
            else
            {
                foreach (PropertyInfo propertyInfo in typeOfFirst.GetProperties())
                {
                    var firstValue = propertyInfo.GetValue(first);
                    var secondValue = propertyInfo.GetValue(second);
                    if (!AreSimilar(firstValue, secondValue))
                        return false;
                }
            }
            return true;            
        }       
    }
}