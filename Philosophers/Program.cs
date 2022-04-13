using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Philosophers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Stick>   sticks = new List<Stick>();
            List<Philosopher> philosophers = new List<Philosopher>();
            // посадка философов и выделение посуды
            Random rn = new Random();
            for (int i=0; i<5; i++) sticks.Add(new Stick());
            // сервировка
            for (int i = 0; i < 5; i++)
            {
                if(i!=4) philosophers.Add(new Philosopher(rn, sticks[i], sticks[i + 1]));
                else     philosophers.Add(new Philosopher(rn, sticks[i], sticks.First()));
            }
            string c;

            foreach(Philosopher p in philosophers)
                Console.WriteLine(p.Message + "   " + p.State + "   ");
            c = Console.ReadLine();
            //алгоритм
            while (true)
            {
                
                Console.Clear();
                for (int i = 0; i < philosophers.Count; i++)
                {
                    switch (philosophers[i].State)
                    {
                        case 0: 
                            if(!sticks[i].IsUsing)
                                philosophers[i].TakeLeftStick(); 
                            else
                                philosophers[i].GoThinking();
                            break;
                        case 1:
                            if (!sticks[(i == 4) ? 0 : i+1].IsUsing)
                                philosophers[i].TakeRightStick();
                            else
                                philosophers[i].PutLeftStick();
                            break;
                        case 2: philosophers[i].GoEating(); break;
                        case 3: philosophers[i].StopEating(); break;
                        case 4: philosophers[i].PutRightStick(); break;
                        case 5: philosophers[i].PutLeftStick(); break;
                        case 6: philosophers[i].GoThinking(); break;
                    }

                    //вывод информации об итерации в текущий момент
                    Console.WriteLine(philosophers[i].Message + "   " + philosophers[i].State + "   " + sticks[i].IsUsing);
                }
                c = Console.ReadLine();
            }

        }
    }
}
