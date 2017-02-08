using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace DiscountCut
{
    public class Program
    {
        Random RNG = new Random();
        object LockObject = new object();
        object LockObject2 = new object();

        static void Main(string[] args)
        {
            Program program = new Program();
            program.Run();
            Console.ReadLine();
        }
        public void Run()
        {
            Scissor ScissorAB = new Scissor() { ScissorName = "AB",isAvailable = true };
            Scissor ScissorBC = new Scissor() { ScissorName = "BC", isAvailable = true };
            Scissor ScissorCD = new Scissor() { ScissorName = "CD", isAvailable = true };
            Scissor ScissorDE = new Scissor() { ScissorName = "DE", isAvailable = true };
            Scissor ScissorEF = new Scissor() { ScissorName = "EF", isAvailable = true };
            Scissor ScissorFA = new Scissor() { ScissorName = "FA", isAvailable = true };

            Chair A = new Chair(ScissorAB, ScissorFA, "A");
            Chair B = new Chair(ScissorBC, ScissorAB, "B");
            Chair C = new Chair(ScissorCD, ScissorBC, "C");
            Chair D = new Chair(ScissorDE, ScissorCD, "D");
            Chair E = new Chair(ScissorEF, ScissorDE, "E");
            Chair F = new Chair(ScissorFA, ScissorEF, "F");

            Thread ThreadA = new Thread(ChairThread);
            Thread ThreadB = new Thread(ChairThread2);
            Thread ThreadC = new Thread(ChairThread);
            Thread ThreadD = new Thread(ChairThread2);
            Thread ThreadE = new Thread(ChairThread);
            Thread ThreadF = new Thread(ChairThread2);
        
            Console.WriteLine("A day started at Discount Cut...");

            ThreadA.Start(A);
            ThreadB.Start(B);
            ThreadC.Start(C);
            ThreadD.Start(D);
            ThreadE.Start(E);
            ThreadF.Start(F);

            Console.ReadLine();
        }

        public void ChairThread(Object c)
        {
            Chair chair = (Chair)c;
            while (chair._sessionsLeft > 0)
            {
                if (chair._leftScissor.isAvailable == true && chair._rightScissor.isAvailable == true)
                {
                    lock (LockObject)
                    {
                        if (chair._leftScissor.isAvailable == true && chair._rightScissor.isAvailable == true)
                        {
                        ChairOccupied(chair);
                        chair._sessionsLeft--;
                        ChairResting(chair);
                        }
                        else
                        {
                         ChairWaiting(chair);
                        }
                    }

                    
                }
                

                
            }
        }
        public void ChairThread2(Object c)
        {
            Chair chair = (Chair)c;
            while (chair._sessionsLeft > 0)
            {
                if (chair._leftScissor.isAvailable == true && chair._rightScissor.isAvailable == true)
                {
                    lock (LockObject2)
                    {
                        if (chair._leftScissor.isAvailable == true && chair._rightScissor.isAvailable == true)
                        {
                            ChairOccupied(chair);
                            chair._sessionsLeft--;
                            ChairResting(chair);
                        }
                        else
                        {
                            ChairWaiting(chair);
                        }
                    }


                }



            }
        }



        public void ChairOccupied(Chair chair)
        {
            Console.WriteLine($"Hairdresser {chair.ChairName} is cutting the customer.");
            chair._leftScissor.isAvailable = false;
            chair._rightScissor.isAvailable = false;
            Thread.Sleep(RNG.Next(100, 600));
            chair._leftScissor.isAvailable = true;
            chair._rightScissor.isAvailable = true;
        }
        public void ChairWaiting(Chair chair)
        {
            Console.WriteLine($"Hairdesser {chair.ChairName} is waiting.");
            Thread.Sleep(RNG.Next(100, 600));
        }
        public void ChairResting(Chair chair)
        {
            Console.WriteLine($"Hairdresser {chair.ChairName} is taking a break.");
            Thread.Sleep(RNG.Next(100, 600));
        }

    }
}
