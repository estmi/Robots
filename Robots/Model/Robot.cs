using System.Collections.Generic;
using System.Windows.Media.Imaging;

namespace Robots.Model
{
    public class Robot : Posicio
    {
        public Robot(int fil, int col) : base(fil: fil, col: col)
        {
            object data = FindResource("imgPickachuKey");
            Icona = (BitmapImage)data;
        }
        public override bool EsBuida => false;
        public override bool EsRobot => true;
        public override bool EsTresor => false;

        public override Direccio OnVaig(Escenari esc)
       {
            List<Direccio> llista = new() { Direccio };
            
            if (esc.DestiValid(Fila - 1, Columna) && this.Direccio != Direccio.Sud)
            {
                //Nord
                llista.Add(Direccio.Nord);
            }

            if (esc.DestiValid(Fila, Columna + 1) && this.Direccio != Direccio.Oest)
            {
                llista.Add(Direccio.Est);
            }

            if (esc.DestiValid(Fila + 1, Columna) && this.Direccio != Direccio.Nord)
            {
                llista.Add(Direccio.Sud);
            }

            if (esc.DestiValid(Fila, Columna - 1) && this.Direccio != Direccio.Est)
            {
                llista.Add(Direccio.Oest);
            }

            Direccio novaDireccio = llista[random.Next(llista.Count)];

            if (novaDireccio == this.Direccio)
            {
                return novaDireccio;
            }
            else
            {
                Direccio = novaDireccio;
                return Direccio.Quiet;
            }


        }
        public override double Interes(Posicio p)
        {
            if (p.EsTresor)
                return 1;
            return 0;
        }
    }
}
