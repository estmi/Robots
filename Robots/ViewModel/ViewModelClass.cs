using Robots.Infrastructure;
using Robots.Model;
using System;

namespace Robots.ViewModel
{
    public class ViewModelClass
    {
        public ViewModelClass()
        {
            Esc = new(10, 10);
            Esc.ShowGridLines = true;
            CicleCommand = new(o => Esc.Cicle());
        }

        public Escenari Esc { get; set; }
        public RelayCommand CicleCommand { get; private set; }
    }
}
