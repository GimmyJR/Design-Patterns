using System.Threading;
using System;
using static SingletonDesignPattern.Program;

namespace SingletonDesignPattern
{
    internal class Program
    {

        //1-using eager initialzation
        public class EagerInitilazedSingleton
        {
            private static EagerInitilazedSingleton instance = new EagerInitilazedSingleton();
            private EagerInitilazedSingleton() { }
            public static EagerInitilazedSingleton GetInstance()
            {
                return instance;
            }
        }
        //2-using lazy initialzation
        public class LazyInitilazedSingleton
        {
            private static LazyInitilazedSingleton instance;
            private LazyInitilazedSingleton() { }
            public static LazyInitilazedSingleton GetInstance()
            {
                if (instance == null)
                    instance = new LazyInitilazedSingleton();
                return instance;
            }

        }


        //3-using thread initialzation :less performance
        public class ThreadInitializedSingleton1
        {
            private static ThreadInitializedSingleton1 instance;
            private static readonly object _lock = new object();

            private ThreadInitializedSingleton1() { }

            public static ThreadInitializedSingleton1 GetInstance()
            {
                lock (_lock)
                {
                    if(instance == null)
                        instance = new ThreadInitializedSingleton1();
                }
                return instance;
            }
        }

        //4-using thread initialzation
        public class ThreadInitializedSingleton2
        {
            private static ThreadInitializedSingleton2 instance;
            private static readonly object _lock = new object();

            private ThreadInitializedSingleton2() { }

            public static ThreadInitializedSingleton2 GetInstance()
            {
                if (instance == null)
                {
                    lock (_lock)
                    {
                            instance = new ThreadInitializedSingleton2();
                    }
                }
                return instance;
            }
        }




        //5-using thread initialzation with double checked locking
        public class ThreadInitializedSingleton3
        {
            private static ThreadInitializedSingleton3 instance;
            private static readonly object _lock = new object();

            private ThreadInitializedSingleton3() { }

            public static ThreadInitializedSingleton3 GetInstance()
            {
                if (instance == null)
                {
                    lock (_lock)
                    {
                        if (instance == null)
                        {
                            instance = new ThreadInitializedSingleton3();
                        }
                    }
                }
                return instance;
            }
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
