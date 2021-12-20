using Robots.Model;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Robots
{
    public class Escenari : Grid
    {

        Random _random = new();
        /// <summary>
        /// Crea un escenari donades unes mides
        /// </summary>
        /// <param name="files">Número de files de l'escenari</param>
        /// <param name="columnes">Número de columnes de l'escenari</param>
        public Escenari(int files, int columnes) : base()
        {
            for (int i = 0; i < files; i++)
            {
                RowDefinitions.Add(new());
            }
            for (int i = 0; i < columnes; i++)
            {
                ColumnDefinitions.Add(new());
            }

            Files = files;
            Columnes = columnes;
            Tauler = new Posicio[Files, Columnes];
            for (int i = 0; i < Tauler.GetLength(0); i++)
            {
                for (int j = 0; j < Tauler.GetLength(1); j++)
                {
                    Tauler[i, j] = new(i, j);
                    PosaPosicio(Tauler[i, j]);
                }
            }
            CreaTresor();
            CreaRobot();

        }

        private void CreaRobot()
        {
            List<Posicio> l = LlistaPosicionsBuides;
            Posicio p = l[_random.Next(l.Count)];
            Buida(p.Fila, p.Columna);
            Robot r = new(p.Fila, p.Columna);
            posicios[0] = r;
            Posa(r);
        }

        private void CreaTresor()
        {
            List<Posicio> l = LlistaPosicionsBuides;
            Posicio p = l[_random.Next(l.Count)];
            Buida(p.Fila, p.Columna);
            Tresor t = new(p.Fila, p.Columna);
            posicios[1] = t;
            Posa(t);
        }

        /// <summary>
        /// Retorna el número de files de l'escenari
        /// </summary>
        public int Files { get; }
        /// <summary>
        /// Retorna el número de columnes de l'escenari
        /// </summary>
        public int Columnes { get; }

        /// <summary>
        /// Obte una matriu de tot l'escenari
        /// </summary>
        public Posicio[,] Tauler { get; }
        /// <summary>
        /// Mou una persona de (filOrig, colOrig) fins a la posicio (filDesti, colDesti)
        /// Es suposa que les coordenades són vàlides, que hi ha una persona a l'origen i que
        /// el destí està buit.
        /// </summary>
        /// <param name="filOrig">Fila de la coordenada d'origen</param>
        /// <param name="colOrig">Columna de la coordenada d'origen</param>
        /// <param name="filDesti">Fila de la coordenada de destí</param>
        /// <param name="colDesti">Columna de la coordenada de destí</param>
        private void Mou(int filOrig, int colOrig, int filDesti, int colDesti)
        {
            Posicio p = Tauler[filOrig, colOrig];
            Tauler[filDesti, colDesti] = p;
            Tauler[filOrig, colOrig] = new(filOrig, colOrig);
            SetRow(p, filDesti);
            SetColumn(p, colDesti);
        }
        /// <summary>
        /// Retorna la Posició que hi ha en una coordenada donada
        /// </summary>
        public Posicio this[int fila, int col] => Tauler[fila, col];
        /// <summary>
        /// Mira si una coordenada es correcte per ser destí d'una persona
        /// </summary>
        /// <param name="fil">fila de la coordenada</param>
        /// <param name="col">columna de la coordenada</param>
        /// <returns>retorna si la coordenada és vàlida i està buida</returns>
        public bool DestiValid(int fil, int col)
        {
            if (0 <= fil && fil < Files && 0 <= col && col < Columnes)
            {
                return Tauler[fil, col].EsBuida;
            }
            return false;
        }

        /// <summary>
        /// Elimina una persona de l'escenari i de la taula de persones
        /// </summary>
        /// <param name="fil">Fila on està la persona</param>
        /// <param name="col">Columna on està la persona</param>
        public void Buida(int fil, int col)
        {
            if (!Tauler[fil, col].EsBuida)
            {
                Children.Remove(Tauler[fil, col]);
                Tauler[fil, col] = new(fil, col);
            }
        }
        /// <summary>
        /// Obte una llista amb posicions buides
        /// </summary>
        public List<Posicio> LlistaPosicionsBuides
        {
            get
            {
                List<Posicio> llista = new();
                for (int i = 0; i < Tauler.GetLength(0); i++)
                {
                    for (int j = 0; j < Tauler.GetLength(1); j++)
                    {
                        Posicio p = Tauler[i, j];
                        if (p.EsBuida)
                            llista.Add(p);
                    }
                }
                return llista;
            }

        }
        #region Creació i posicionament de persones
        /// <summary>
        /// Posa una Persona dins de l'escenari i a la taula de persones
        /// Si la posició de la persona ja està ocupada, genera una excepció
        /// </summary>
        /// <param name="pers">Persona a afegir</param>
        public void Posa(Posicio pers)
        {
            if (!DestiValid(pers.Fila, pers.Columna))
                throw new ArgumentException("Posicio No valida");
            SetColumn(pers, pers.Columna);
            SetRow(pers, pers.Fila);
            Children.Add(pers);
            Tauler[pers.Fila, pers.Columna] = pers;
        }
        /// <summary>
        /// Coloca una posicio dins del grid, fent les assignacions que pertoquen
        /// </summary>
        /// <param name="p"></param>
        private void PosaPosicio(Posicio p)
        {
            SetColumn(p, p.Columna);
            SetRow(p, p.Fila);
            Children.Add(p);
        }
        /// <summary>
        /// Elimina una persona del taulell
        /// </summary>
        /// <param name="pers">Persona a eliminar</param>
        public void Elimina(Posicio pers)
        {
            Buida(pers.Fila, pers.Columna);
        }

        #endregion

        public Posicio[] posicios { get; set; } = new Posicio[2];
        /// <summary>
        /// Fa que totes les persones facin un moviment
        /// </summary>
        public void Cicle()
        {
            foreach (Posicio kvp in posicios)
            {
                if (kvp.EsRobot)
                {
                    Direccio direccio = kvp.OnVaig(this);
                    switch (direccio)
                    {
                        case Direccio.Nord:
                            Mou(kvp.Fila, kvp.Columna, kvp.Fila - 1, kvp.Columna);
                            break;
                        case Direccio.Nordest:
                            Mou(kvp.Fila, kvp.Columna, kvp.Fila - 1, kvp.Columna + 1);
                            break;
                        case Direccio.Est:
                            Mou(kvp.Fila, kvp.Columna, kvp.Fila, kvp.Columna + 1);
                            break;
                        case Direccio.Sudest:
                            Mou(kvp.Fila, kvp.Columna, kvp.Fila + 1, kvp.Columna + 1);
                            break;
                        case Direccio.Sud:
                            Mou(kvp.Fila, kvp.Columna, kvp.Fila + 1, kvp.Columna);
                            break;
                        case Direccio.Sudoest:
                            Mou(kvp.Fila, kvp.Columna, kvp.Fila + 1, kvp.Columna - 1);
                            break;
                        case Direccio.Oest:
                            Mou(kvp.Fila, kvp.Columna, kvp.Fila, kvp.Columna - 1);
                            break;
                        case Direccio.Noroest:
                            Mou(kvp.Fila, kvp.Columna, kvp.Fila - 1, kvp.Columna - 1);
                            break;
                        default:
                            break;
                    }
                }
            }

        }
    }
}