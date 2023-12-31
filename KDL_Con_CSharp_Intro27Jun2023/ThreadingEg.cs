﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace KDL_Con_CSharp_Intro27Jun2023
{
    public class ThreadingEg
    {

        static void Main()
        {
            Worker worker = new Worker();

            Thread th = new Thread(worker.DoWork);
            th.Name = "S1";
            th.Start();



            Thread th1 = new Thread(worker.DoAnotherWork);
            th1.Name = "S2";
            
            th1.Start();

            //for (int cnt = 0; cnt < 100; cnt++)
            //{
            //    Console.WriteLine($"Managed Thread Id : {Thread.CurrentThread.ManagedThreadId} , Thread Name :{Thread.CurrentThread.Name} , Inc Value : {cnt}  ");
            //    Thread.Sleep(100);

            //}
            Console.WriteLine("Press any key to continue....");

            Console.ReadKey();
        
        }
    }


   public  class Worker
    {
        int inc=-1;

        public void DoWork()
        {


            lock (this)
            {
                for (int i = 0; i < 100; i++)
                {
                    inc++;

                    Console.WriteLine($"Managed Thread Id : {Thread.CurrentThread.ManagedThreadId} , Thread Name :{Thread.CurrentThread.Name} , Inc Value : {inc}  ");
                    Thread.Sleep(300);

                } 
            }
        
        }

  public void DoAnotherWork()
        {

            lock (this)
            {



                for (int i = 0; i < 100; i++)
                {
                    inc++;

                    Console.WriteLine($"Managed Thread Id : {Thread.CurrentThread.ManagedThreadId} , Thread Name :{Thread.CurrentThread.Name} , Inc Value : {inc}  ");
                    Thread.Sleep(300);

                } 
            }
        
        }


    }


}
