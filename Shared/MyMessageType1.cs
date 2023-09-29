using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class MyMessageType1 : MyMessageBase
    {
        public MyMessageType1(string myString1)
        {
            base.MessageType = 1;
            MyString1 = myString1;
        }

        public string MyString1 { get; set; }
    }
}
