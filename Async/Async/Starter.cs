using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Async
{
    internal class Starter
    {
        public static void Run()
        {
            MessageBox messageBox = new MessageBox();
            messageBox.Open();
            messageBox.Check();
        }
    }
}
