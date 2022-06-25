using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Async
{
    internal class MessageBox
    {
        public MessageBox()
        {
            MessageEvent = (Enums.State state) => Console.WriteLine("Event for closed window");
        }

        public event Action<Enums.State> MessageEvent;

        public Enums.State State { get; set; }

        public async void Open()
        {
            Console.WriteLine("Window is open");
            Thread.Sleep(3000);
            Console.WriteLine("Window is closed by user");
            MessageEvent.Invoke(RandomEnum());
            await Task.Run(() => Console.WriteLine("Line only in order to await the method..."));
        }

        public void Check()
        {
            if (State == Enums.State.Ok)
            {
                Console.WriteLine("Operation was confirmed");
            }
            else if (State == Enums.State.Cancel)
            {
                Console.WriteLine("Operation was declined");
            }
            else
            {
                Console.WriteLine("Something went wrong");
            }
        }

        private Enums.State RandomEnum()
        {
            Array values = Enum.GetValues(typeof(Enums.State));
            Random random = new Random();
            Enums.State randomState = (Enums.State)values.GetValue(random.Next(values.Length));
            State = randomState;
            return randomState;
        }
    }
}
