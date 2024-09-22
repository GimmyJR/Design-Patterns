using System;
using System.Collections.Generic;
using static Program;

public class Program
{
    //before
    //public static void SortIntegers(List<int> numbers, string sortOrder)
    //{
    //    if (sortOrder == "asc")
    //    {
    //        numbers.Sort();
    //    }
    //    else if (sortOrder == "desc")
    //    {
    //        numbers.Sort();
    //        numbers.Reverse();
    //    }
    //}

    //public static void SortStrings(List<string> words, string sortOrder)
    //{
    //    if (sortOrder == "alpha")
    //    {
    //        words.Sort();
    //    }
    //    else if (sortOrder == "length")
    //    {
    //        words.Sort((x, y) => x.Length.CompareTo(y.Length));
    //    }
    //}

    //public static void Main(string[] args)
    //{
    //    List<int> numbers = new List<int> { 5, 2, 8, 3, 1 };
    //    SortIntegers(numbers, "asc");
    //    Console.WriteLine("Sorted Integers: " + string.Join(", ", numbers));

    //    List<string> words = new List<string> { "apple", "dog", "banana", "cat" };
    //    SortStrings(words, "length");
    //    Console.WriteLine("Sorted Strings: " + string.Join(", ", words));
    //}

    //after

    public interface ISortStrategy<T>
    {
        void Sort(List<T> items);
    }
    public class SortNumbersAsc : ISortStrategy<int>
    {
        public void Sort(List<int> items)
        {
            items.Sort();
        }
    }
    public class SortNumbersDes : ISortStrategy<int>
    {
        public void Sort(List<int> items)
        {
             items.Sort();
            items.Reverse();
        }
    }
    public class SortStringsAlpha : ISortStrategy<string>
    {
        public void Sort(List<string> items)
        {
            items.Sort();
        }
    }
    public class SortStringslength : ISortStrategy<string>
{
        public void Sort(List<string> items)
        {
            items.Sort((x, y) => x.Length.CompareTo(y.Length));
        }
    }
    public class SortContext<T>
    {
        private ISortStrategy<T> _sortStrategy;

        public SortContext(ISortStrategy<T> sortStrategy)
        {
            this._sortStrategy = sortStrategy;
        }
        public void SetStrategy(ISortStrategy<T> strategy)
        {
            _sortStrategy = strategy;
        }
        public void Sort(List<T> items) 
        {
            _sortStrategy.Sort(items);
        }
        
    }
    public static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 5, 2, 8, 3, 1 };
            SortContext<int> intsortContext = new SortContext<int>(new SortNumbersAsc());
            intsortContext.Sort(numbers);
            Console.WriteLine("Sorted Integers (Ascending): " + string.Join(", ", numbers));

            intsortContext.SetStrategy(new SortNumbersDes());
            intsortContext.Sort(numbers);
            Console.WriteLine("Sorted Integers (Descending): " + string.Join(", ", numbers));

            List<string> words = new List<string> { "apple", "dog", "banana", "cat" };
            SortContext<string> stringsortContext = new SortContext<string>(new SortStringsAlpha());
            stringsortContext.Sort(words);
            Console.WriteLine("Sorted Strings (Alphabetical): " + string.Join(", ", words));

            stringsortContext.SetStrategy(new SortStringslength());
            stringsortContext.Sort(words);
            Console.WriteLine("Sorted Strings (By Length): " + string.Join(", ", words));
        }

}
