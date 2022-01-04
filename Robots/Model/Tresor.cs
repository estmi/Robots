using System.Windows.Media.Imaging;

namespace Robots.Model
{
    public class Tresor : Posicio
    {
        public Tresor(int fil, int col) : base(fil: fil, col: col)
        {
            Icona = (BitmapImage)FindResource("imgPokeballKey");
        }
        public override bool EsBuida => false;
        public override bool EsRobot => false;
        public override bool EsTresor => true;
        public override Direccio OnVaig(Escenari esc)
        {

            return Direccio.Quiet;
        }
    }
}
