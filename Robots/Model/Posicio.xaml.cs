using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Robots.Model
{
    /// <summary>Classe base per a totes les caselles de l'escenari.</summary>
    public partial class Posicio : UserControl
    {
        public static Random random = new Random();
        private Image imgIcona = new();

        /// <summary>
        /// Crea una nova posició
        /// </summary>
        /// <param name="fil">Fila de la Posició</param>
        /// <param name="col">Columna de la Posició</param>
        public Posicio(int fil = 0, int col = 0)
        {
            InitializeComponent();
            
            Columna = col;
            Fila = fil;
            dock.Children.Add(imgIcona);
            AllowDrop = true;
            DragEnter += Posicio_DragEnter;

        }
        public static double Distancia(Posicio pos1, Posicio pos2) =>
            Math.Sqrt(
                Math.Pow(
                    Math.Abs(pos1.Columna - pos2.Columna),
                    2) +
                Math.Pow(
                    Math.Abs(pos1.Fila - pos2.Fila),
                    2)
                );

        private void Posicio_DragEnter(object sender, System.Windows.DragEventArgs e)
        {
            if (e.Data.GetDataPresent("PERSONA"))
            {

            }
            else if (e.Data.GetDataPresent("PERSONATIPUS"))
            {

            }
            else e.Effects = DragDropEffects.None;
        }
        /// <summary>
        /// Assigna o obté la columna de la posicio
        /// </summary>
        public int Columna { get; set; }
        /// <summary>
        /// Assigna o obté la fila de la posicio
        /// </summary>
        public int Fila { get; set; }
        /// <summary>
        /// Retorna si la posició està o no buida
        /// </summary>
        public virtual bool EsBuida => true;
        public virtual bool EsRobot => false;
        public virtual bool EsTresor => false;
        /// <summary>
        /// Dóna accés al control Image incrustat
        /// </summary>
        public ImageSource Icona
        {
            get { return imgIcona.Source; }
            set { imgIcona.Source = value; }

        }
        public virtual double Interes(Posicio p) => 0;
        public virtual Direccio OnVaig(Escenari esc) => 0;
        protected double Atraccio(int fil, int col, Escenari esc)
        {
            double atraccio = 0;
            foreach (Posicio p in esc.posicios)
            {

                if (p.Columna != col && p.Fila != fil)
                    atraccio += Interes(p) / Distancia(esc[fil, col], p);
            }
            //return Interes(esc[fil, col]) / Distancia(this, new("", fil, col));
            return atraccio;
        }


    }
}
