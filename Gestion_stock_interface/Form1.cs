using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ProjetIGLIB;
using ManageSMS;

namespace ProjetIGWIN
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        Candidat c = new Candidat();
        Vote v = new Vote();
        Province p = new Province();
        VilleTeritoire vt = new VilleTeritoire();
        Centre ct = new Centre();
        Bureau b = new Bureau();

        private void Form1_Load(object sender, EventArgs e)
        {
            cmdConnect.Enabled = true;
            cmdDisconnect.Enabled = false;
            txtStatusReceiveMsg.Enabled = false;

            txtMsgSend.AppendText("Tout en douceur et parfait");
            try
            {
                foreach (string val in SMS.Instance.GetAllports())
                    cboPort.Items.Add(val);
                cboPort.SelectedIndex = 0;

                foreach (int val in SMS.Instance.LoadBaudPorts())
                    cboBaud.Items.Add(val);
                cboBaud.SelectedIndex = 0;

                foreach (int val in SMS.Instance.LoadTimeOut())
                    cboTimeOut.Items.Add(val);
                cboTimeOut.SelectedIndex = 0;        
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Erreur !! ");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //Console.WriteLine("==============================" + val);
            //try
            //{
                //Factory.Instance.doConnexion();
                //p.Id = 1;
                //p.Designation = "Nord kivu";
                //p.Enregistrer();

                //vt.Id = 1;
                //vt.Id_pronvince = 1;
                //vt.Designation = "Goma";
                //vt.Enregistrer();
                //ct.Id = 1;
                //ct.Id_villeTeritoire = 1;
                //ct.Numero_centre = "GC001";
                //ct.Designation = "Goma1";
                //ct.Enregistrer();
                //b.Id = 1;
                //b.Id_centre = 1;
                //b.Numero_bureau = "BG001";
                //b.Designation = "BGoma1";
                //b.Enregistrer();
                ////v.Modifier();
                ////v.Suprimmer();
                //MessageBox.Show("Enregistrement effectué");
                //dataGridView1.DataSource = Factory.Instance.getBureaux();

                //c.Id = 3;
                //c.Nom = "Samas";
                //c.PostNom = "Nk";
                //c.Prenom = "Josue";
                //c.Sexe = "F";
                //c.Numero = 4;
                //c.Photo = "C:\\Users\\T2_8Rgn_Mil\\Documents\\Scanned Documents\\Bienvenue.jpg";
                //c.Enregistrer();
                //c.Modifier();
                //c.Suprimmer();
            //dataGridView1.DataSource = Factory.Instance.GetCandidats();
                //v.Id = 6;
                //v.Id_bureau = 1;
                //v.Id_candidat = 1;
                //v.Voix = 100;
                //v.Datevote = Convert.ToDateTime(DateTime.Today.ToLongDateString());
                //v.Enregistrer();
                //v.Modifier();
                //v.Suprimmer();
                //MessageBox.Show("Enregistrement effectué");
            //dataGridView1.DataSource = Factory.Instance.getVotes();
            //}
            //catch (Exception e1)
            //{
            //    MessageBox.Show(e1.Message);
            //} 
        }

        private void comm_MessageReceived(object sender, GsmComm.GsmCommunication.MessageReceivedEventArgs e)
        {
            SMS.Instance.ReceiveSMS();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Image = Bitmap.FromStream(Factory.Instance.GetPhotoCandidat(c));
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
                pictureBox1.Image = null;
            } 
        }

        private void cmdConnect_Click(object sender, EventArgs e)
        {
            try
            {
                SMS.Instance.OpenConnection(SMS.Instance.RecupNumeroPort(cboPort.Text),Convert.ToInt32(cboBaud.Text),Convert.ToInt32(cboTimeOut.Text));

                cmdConnect.Enabled = false;
                if (cmdConnect.Enabled == true) cmdDisconnect.Enabled = false;
                else cmdDisconnect.Enabled = true;

                SMS.Instance.InstanceEcouteurReceptionSMS();

                MessageBox.Show("Connexion réussie", "Connexion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Connexion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cmdDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                SMS.Instance.CloseConnection();

                cmdDisconnect.Enabled = false;
                if (cmdDisconnect.Enabled == true) cmdConnect.Enabled = false;
                else cmdConnect.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Connexion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                SMS.Instance.CloseConnection();

                cmdDisconnect.Enabled = false;
                if (cmdDisconnect.Enabled == true) cmdConnect.Enabled = false;
                else cmdConnect.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Connexion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cmdSendMsg_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkMultiple.Checked) SMS.Instance.SendManySMS(1,txtMsgSend.Text, txtDestinataire.Text,"0991350532");
                else SMS.Instance.SendOneSMS(1,txtMsgSend.Text,txtDestinataire.Text,"0991350532");

                MessageBox.Show("Message envoyé", "Envoie SMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Envoie SMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //try
            //{
                SMS.Instance.insertData("B12,12,14,15|0970305688|12/12/2011");
                MessageBox.Show("Enregistrement effectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //catch (Exception e1)
            //{
            //    MessageBox.Show(e1.Message, "Envoie SMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}
            
        }

    }
}
