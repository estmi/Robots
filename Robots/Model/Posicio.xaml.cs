using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Robots
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
        public Posicio(string nom = "", int fil = 0, int col = 0)
        {
            InitializeComponent();
            Nom = nom;
            Columna = col;
            Fila = fil;
            dock.Children.Add(imgIcona);
            AllowDrop = true;
            DragEnter += Posicio_DragEnter;

        }


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
        /// Obté o assigna el nom de la posició
        /// </summary>
        public string Nom { get; set; }
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



    }
}
