using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Model
{
    public  class Robot:Posicio
    {
        public Robot(int fil,int col):base(fil:fil,col:col)
        {
             
        }
        public override bool EsBuida => false;
        public override bool EsRobot => true;
        public override bool EsTresor => false;

    }
}
