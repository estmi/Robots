using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.ViewModel
{
    public class ViewModelClass
    {
        public ViewModelClass()
        {
            esc.ShowGridLines = true;
        }

        public Escenari esc { get; set; } = new(10, 10);

    }
}
