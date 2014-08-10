using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gnip
{
    public partial class Form1 : Form
    {
        public static int MAX_PINGS_TO_KEEP = 20;

        private List<PingReply> pingReplies = new List<PingReply>();

        // Para el historial
        private int MAX_HISTORY = 1000;
        private double SECONDS_BETWEEN_ACTIONS = 7;
        private double lastTimeAction = 0;

        private void saveHistory(string time, string type)
        {
            string fecha = DateTime.Now.Date.Day.ToString() + "-" + DateTime.Now.Date.Month.ToString() + "-" + DateTime.Now.Date.Year.ToString();
            string ext = ".txt";
            string filename = fecha + ext;

            string archivoActual = type + " ~ " + time + Environment.NewLine;
            bool fileReaded = !File.Exists(filename);

            if (File.Exists(filename))
            {
                try
                {
                    StreamReader sr = new StreamReader(filename);
                    archivoActual += sr.ReadToEnd();
                    sr.Close();
                    fileReaded = true;
                }
                catch (Exception e)
                {
                }

            }

            if (fileReaded)
            {
                try
                {
                    System.IO.File.WriteAllText(@filename, archivoActual);
                }
                catch (Exception ex) { }
            }
        }

        public Form1()
        {
            InitializeComponent();            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timerPing_Tick(sender, e);            
        }
        
        private void timerPing_Tick(object sender, EventArgs e)
        {
            timerPing.Stop();

            Ping ping = new Ping();
            PingReply pr = null;

            try { pr = ping.Send("www.google.com"); }
            catch (Exception ex) { }

            bool quit = false;

            if (pr == null) quit = true;
            if (pr.Status != IPStatus.Success) quit = true;

            if (quit)
            {
                timerPing.Start();
                return;
            }


            label_ping.Text = pr.RoundtripTime.ToString() + " ms";                       

            if (pingReplies.Count == MAX_PINGS_TO_KEEP)
                pingReplies.RemoveAt(0);

            pingReplies.Add(pr);


            EstadisticaPingReply epr = new EstadisticaPingReply(pingReplies);
            epr.calculate();

            label_bajo.Text = epr.getMin().ToString() + " ms";
            label_medio.Text = epr.getAvg().ToString() + " ms";
            label_alto.Text = epr.getMax().ToString() + " ms";

            this.Text = "Gnip";
            this.Text += " (" + pr.RoundtripTime.ToString() + " ms)";

            if (epr.isDownloading())
                this.Text += " {Downloading}";
            else if (epr.isYoutubing())
                this.Text += " {Youtube}";
            else if (epr.isBrowsing())
                this.Text += " {Browsing}";
            

            // Obtenemos la ultima accion
            ListViewItem lastAction = epr.getLastAction();
            // Tiempo en segundos AHORA
            double now = DateTime.Now.TimeOfDay.TotalSeconds;

            if (lastAction != null && now - lastTimeAction > SECONDS_BETWEEN_ACTIONS)
            {
                // Actualizamos el archivo de historial
                saveHistory(lastAction.SubItems[0].Text, lastAction.SubItems[1].Text);

                // Guardamos el tiempo
                lastTimeAction = now;

                // Añadimos a la listview
                listView1.Items.Add(lastAction);
            }

            // Removemos los history extras
            if (listView1.Items.Count > MAX_HISTORY)
                listView1.Items.RemoveAt(0);

            timerPing.Start();
        }

        private void button_showHideHistory_Click(object sender, EventArgs e)
        {
            if (this.Size.Width == 475) // Entonces ocultar
            {
                this.Size = new Size(125, this.Size.Height);
                button_showHideHistory.Text = "--->";
            }
            else // Mostrar
            {
                this.Size = new Size(475, this.Size.Height);
                button_showHideHistory.Text = "<---";
            }
        }        
    }
}
