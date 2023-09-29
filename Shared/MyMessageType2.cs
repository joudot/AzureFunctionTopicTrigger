using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class MyMessageType2 : MyMessageBase
    {
        public MyMessageType2(int myInt2)
        {
            base.MessageType = 2;
            MyInt2 = myInt2;        
        }

        public int MyInt2 { get; set; }
    }
}
