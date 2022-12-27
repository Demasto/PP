using System;
using System.Collections.Generic;
using System.Threading;

namespace Философы
{
    class Philosopher
    {
        Random rand = new Random(); // рандомная задержка между состояниями философов

        public enum State
        {
            Hunger,
            Eat,
            Think
        } // состояния философа

        public State CurrentState { get; set; } // текущее состояние
        public int Name { get; set; } // имя философа
        public int Count { get; set; } // порядковый номер

        public Philosopher(int name, int count) // конструктор 
        {
            Name = name;
            Count = count;
        }

        public void Run(object obj)
        {
            Start((List<Fork>)obj);
        }

        void Start(List<Fork> fork)
        {
            while (true)
            {
                CurrentState = State.Hunger;
                Console.WriteLine("Философ {0} голодный.", Name);
                int first = Count; // левая вилка
                int second = (Count == fork.Count - 1) ? 0 : Count + 1; // правая вилка
                fork[first].TakeFork(); // берем левую вилку
                fork[second].TakeFork(); // берем правую вилку
                CurrentState = State.Eat; // философ обедает
                Console.WriteLine("Философ {0} обедает.", Name);
                Console.WriteLine("Вилки с номерами {0} и {1} используются.", first + 1, second + 1);
                Thread.Sleep(rand.Next(3000, 8000)); // философ обедает              
                fork[first].PutFork(); // кладем левую вилку
                fork[second].PutFork(); // кладем правую вилку
                Console.WriteLine("Философ {0} пообедал.", Name);
                CurrentState = State.Think; // Философ думает!
                Console.WriteLine("Философ {0} думает.", Name);
                Thread.Sleep(rand.Next(5000, 8000));
            }
        }
    }
}
