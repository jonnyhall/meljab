using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    public sealed class Singleton
    {
        private static Singleton instance = null;
        private static readonly object padlock = new object();
        private int instanceCount = 0;

        Singleton()
        {
            instanceCount++;
        }

        public void SayHi()
        {
            Console.WriteLine(instanceCount);
            Console.ReadLine();
        }

        public static Singleton Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Singleton();
                    }
                    return instance;
                }
            }
        }
    }
}
