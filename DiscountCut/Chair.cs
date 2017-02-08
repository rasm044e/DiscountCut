using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountCut
{
    public class Chair
    {
        public string ChairName { get; set; }
        public Scissor _leftScissor { get; set; }
        public Scissor _rightScissor { get; set; }
        public int _sessionsLeft { get; set; }
        
        public Chair(Scissor left, Scissor right, string name)
        {
            _leftScissor = left;
            _rightScissor = right;
            _sessionsLeft = 10;
            ChairName = name;
            
        }
    }
}
