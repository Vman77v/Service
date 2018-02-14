using System;
using System.Collections;
using System.Collections.Generic;

namespace PokingAroun
{
    class Program
    {
        static void Main()
        {
            Example example = new Example(
                new string[] { "cat", "dog", "bird" });
            // The foreach-loop calls the generic GetEnumerator method.
            // ... It then uses the List's Enumerator.
            foreach (string element in example)
            {
                Console.WriteLine(element);
            }
        }
    }



    class Example : IEnumerable<string>
    {
        List<string> _elements;

        public Example(string[] array)
        {
            _elements = new List<string>(array);
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator<string> IEnumerable<string>.GetEnumerator()
        {
            Console.WriteLine("HERE");
            return _elements.GetEnumerator();
        }

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return _elements.GetEnumerator();
        //}
    }



}
