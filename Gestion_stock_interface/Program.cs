using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GestionClinic_WIN
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //try
            //{
                Application.Run(new Principal());
            //}
            //catch (System.Runtime.InteropServices.ExternalException)
            //{
            //    MessageBox.Show("Impossible de charger le fichier, l'application va se fermer", "Photo invalide", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    Application.Exit();
            //}
        }
    }
}
