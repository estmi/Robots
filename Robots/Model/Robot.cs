using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Robots.Model
{
    public  class Robot:Posicio
    {
        public Robot(int fil,int col):base(fil:fil,col:col)
        {
            object data = FindResource("imgPickachuKey");
            Icona = (BitmapImage)data;
        }
        public override bool EsBuida => false;
        public override bool EsRobot => true;
        public override bool EsTresor => false;
        
        public override Direccio OnVaig(Escenari esc)
        {
            List<Direccio> llista = new() { Direccio.Quiet };
            double gran = Atraccio(Fila, Columna, esc);
            Dictionary<Direccio, Double> onAnire = new();
            if (esc.DestiValid(Fila - 1, Columna))
            {
                //Nord
                double atracAct = Atraccio(Fila - 1, Columna, esc);

                if (atracAct > gran) llista = new() { Direccio.Nord };
                else if (atracAct == gran) llista.Add(Direccio.Nord);
            }

            if (esc.DestiValid(Fila - 1, Columna + 1))
            {
                double atracAct = Atraccio(Fila - 1, Columna + 1, esc);

                if (atracAct > gran) llista = new() { Direccio.Nordest };
                else if (atracAct == gran) llista.Add(Direccio.Nordest);
            }

            if (esc.DestiValid(Fila, Columna + 1))
            {
                double atracAct = Atraccio(Fila, Columna + 1, esc);

                if (atracAct > gran) llista = new() { Direccio.Est };
                else if (atracAct == gran) llista.Add(Direccio.Est);
            }

            if (esc.DestiValid(Fila + 1, Columna + 1))
            {
                double atracAct = Atraccio(Fila + 1, Columna + 1, esc);

                if (atracAct > gran) llista = new() { Direccio.Sudest };
                else if (atracAct == gran) llista.Add(Direccio.Sudest);
            }


            if (esc.DestiValid(Fila + 1, Columna))
            {
                double atracAct = Atraccio(Fila + 1, Columna, esc);

                if (atracAct > gran) llista = new() { Direccio.Sud };
                else if (atracAct == gran) llista.Add(Direccio.Sud);
            }


            if (esc.DestiValid(Fila + 1, Columna - 1))
            {
                double atracAct = Atraccio(Fila + 1, Columna - 1, esc);

                if (atracAct > gran) llista = new() { Direccio.Sudoest };
                else if (atracAct == gran) llista.Add(Direccio.Sudoest);
            }


            if (esc.DestiValid(Fila, Columna - 1))
            {
                double atracAct = Atraccio(Fila, Columna - 1, esc);

                if (atracAct > gran) llista = new() { Direccio.Oest };
                else if (atracAct == gran) llista.Add(Direccio.Oest);
            }


            if (esc.DestiValid(Fila - 1, Columna - 1))
            {
                double atracAct = Atraccio(Fila - 1, Columna - 1, esc);

                if (atracAct > gran) llista = new() { Direccio.Noroest };
                else if (atracAct == gran) llista.Add(Direccio.Noroest);
            }

            return llista[random.Next(llista.Count)];
        }
        public override double Interes(Posicio p)
        {
            if (p.EsTresor)
                return 1;
            return 0;
        }
    }
}
