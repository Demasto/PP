using System;
using System.Collections.Generic;
using System.Threading;

namespace Философы
{


    public class Program
    {
        static List<Fork> fork = new List<Fork>(); // создаем список вилок

        static List<Philosopher> ph =
            new List<Philosopher>(); // создаем список философов 

        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
                fork.Add(new Fork());
            for (int i = 0; i < 5; i++)
                ph.Add(new Philosopher(i + 1, i));
            Thread t1 = new Thread(ph[0].Run);
            Thread t2 = new Thread(ph[1].Run);
            Thread t3 = new Thread(ph[2].Run);
            Thread t4 = new Thread(ph[3].Run);
            Thread t5 = new Thread(ph[4].Run);

            t1.Start(fork);
            t2.Start(fork);
            t3.Start(fork);
            t4.Start(fork);
            t5.Start(fork);
        }
    }

}