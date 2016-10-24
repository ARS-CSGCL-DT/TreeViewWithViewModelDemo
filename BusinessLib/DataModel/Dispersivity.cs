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


           readonly List<Parameter> _parameters = new List<Parameter>();
            public List<Parameter> Parameters
            {
                get { return _parameters; }
            }
        
    }

    public class Parameter
    {
        public Parameter()
        {
        }

        public string texturecl { get; set; }
        public double alpha { get; set;}

    }


}
