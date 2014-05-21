using System;

namespace Raiz.Modulo1
{
    /// <summary>
    /// This class contains the entry point for a very simple program
    /// that will illustrate the StackOverflowException.  The exception
    /// will be thrown from inside the function call but will keep
    /// traversing up the stack until we catch it inside Main.
    /// </summary>
    class StackOverflowExample
    {

        //entry point for the sample
       public static void Run()
        {
            //attempt to call an infinitely recursive function
            try
            {
                Recurse.InfiniteRecurse();
            }

            //this will fire when the recursion went too deep
            catch (System.StackOverflowException overFlowExcept)
            {
                Console.WriteLine(overFlowExcept.Message);
                Console.WriteLine("Program will now end.");
                return;
            }

            Console.WriteLine("This line will never execute");

        }	//end of main							 
    }	//end of class Stackoverflow

    /// <summary>
    /// Recurse contains one static member designed to recurse forever.
    /// We could try to catch it inside this function and deal with it 
    /// here, but it's hard to do much without any stack left.
    /// </summary>
    class Recurse
    {

        //keeps calling itself forever until it
        //overflows the stack and throws a exception
        static public void InfiniteRecurse()
        {
            InfiniteRecurse();
            return;
        }

    }	//end of class Recurse
}	//end of StackOverFlowSpace Namespace