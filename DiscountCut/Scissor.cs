using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountCut
{
    public class Scissor
    {
        public bool isAvailable { get; set; }
        public string ScissorName { get; set; }

        public Scissor()
        {
            isAvailable = true;
        }

    }
}
