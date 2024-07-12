using System.Threading.Channels;
using System.Threading;
namespace FrameworkExamples
{
    /*
     * Events:
     * Actions performed on the object is called as Events. 
     * Click, Press, Move are some of the events that are handled at the UI level on UI components.
     * Events in C# classes will be like callback functions that are invoked when a certain condition or an operation is done.
     * All Events are objects(instances) of delegates in C#. They are declared using a keyword event. You shall invoke the instance at the approprite condition of the program execution. 
     * We can use the .NET provided delegates called Action<T> and Func<T>. These delegates are template based and can accomodate any no(16) of parameters. 
     * Func<T> is used for Functions that return value and Action is used for void Functions. 
     */

    class AlarmClock
    {
        public event Action OnAlarmTime;
        private readonly DateTime alarmTime;
        public AlarmClock(DateTime alarmTime)
        {
            this.alarmTime = alarmTime;
        }

        public void DisplayClock()
        {
            if (DateTime.Now.Minute == alarmTime.Minute)
            {
                //Raise the event...
                if (OnAlarmTime != null)
                    OnAlarmTime();
                else
                    Console.WriteLine("Event handler is not set");
            }
            Console.WriteLine(DateTime.Now.ToLongTimeString());
        }
    }
    class EventsExample
    {
        static void testFunc()
        {
            Console.WriteLine("Test Func");
        }
        static void Main(string[] args)
        {
            //ActionExample();
            ClockExample();
        }

        private static void ClockExample()
        {
            AlarmClock clock = new AlarmClock(DateTime.Now.AddMinutes(1));
            clock.OnAlarmTime += Clock_OnAlarmTime;
            do
            {
                clock.DisplayClock();
                Thread.Sleep(1000);//1 sec stopage....
                Console.Clear();
            } while (true);
        }

        private static void Clock_OnAlarmTime()
        {
            Console.WriteLine("Time for break!!!");
        }

        //private static void onAlarmRaised()
        //{

        //}

        private static void ActionExample()
        {
            Action example = () => Console.WriteLine("Using Anonymous methods");

            example();
        }
    }
}