using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLib.DataModel
{
    public class Dispersivity
    {
              
        
            public Dispersivity()
            {
                
            }


           readonly List<Parameters> _parameters = new List<Parameters>();
            public List<Parameters> Parameters
            {
                get { return _parameters; }
            }
        
    }

    public class Parameters
    {
        public Parameters()
        {
        }

        public string texturecl { get; set; }
        public double alpha { get; set;}

    }


}
