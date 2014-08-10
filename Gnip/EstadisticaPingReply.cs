using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gnip
{
    class EstadisticaPingReply
    {
        private List<PingReply> lpr;

        private long lastMin, lastAvg, lastMax;        

        /* Condiciones para banderas */
        private long LAG = 100; // Todo ping mayor que esto se considerara lag
        private int BROWSE = 2; // Maximo numero de pings de LAG consecutivos para considerar como una pag web
        private int YOUTUBE = 5; // Maximo numero de pings de LAG consecutivos para considerar como youtube
        private int DOWNLOAD = 10; // Maximo numero de pings de LAG consecutivos para considerar como una descarga
        private int RANGE_TO_CHECK = 11;

        /* Banderas */
        private bool BROWSING = false;
        private bool YOUTUBING = false;
        private bool DOWNLOADING = false;

        /* Llevas control de los tiempos en que ocurrio cada cosa */        
        private ListViewItem lastAction = null;
        
        public EstadisticaPingReply(List<PingReply> lpr)
        {
            this.lpr = lpr;
        }

        public void calculate()
        {
            resetFlags();
            lastAction = null;

            lastMin = lpr.ElementAt(0).RoundtripTime;
            long total = 0;
            lastMax = lpr.ElementAt(0).RoundtripTime;

            int consecutiveLag = 0;
            string action = "None";

            for (int i = 0; i < lpr.Count; i++)            
            {
                PingReply pr = lpr.ElementAt(i);

                if (pr.RoundtripTime < lastMin)
                    lastMin = pr.RoundtripTime;

                total += pr.RoundtripTime;

                if (pr.RoundtripTime > lastMax)
                    lastMax = pr.RoundtripTime;

                // Si entra aqui es porque esta en el rango para chequear los datos
                // Para asi solo tomar en cuenta la informacion de ultimo momento
                if (i + RANGE_TO_CHECK >= lpr.Count)
                {
                    if (pr.RoundtripTime > LAG)
                        consecutiveLag++;
                    else
                        consecutiveLag = 0;
                    
                    
                    // Banderas                    
                    if (consecutiveLag >= DOWNLOAD && !DOWNLOADING)
                    {
                        DOWNLOADING = true;
                        action = "Descargando";
                    }

                    if (consecutiveLag >= YOUTUBE && !YOUTUBING)
                    {
                        YOUTUBING = true;
                        action = "Youtube";
                    }

                    if (consecutiveLag >= BROWSE && !BROWSING)
                    {
                        BROWSING = true;
                        action = "Navegando";
                    }
                }

            }

            if (action != "None")
            {
                lastAction = new ListViewItem(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString());
                lastAction.SubItems.Add(action);
            }

            lastAvg = total / lpr.Count;
        }

        public long getMin()
        {            
            return lastMin;
        }

        public long getAvg()
        {
            return lastAvg;
        }

        public long getMax()
        {
            return lastMax;
        }

        private void resetFlags()
        {
            this.DOWNLOADING = false;
            this.BROWSING = false;
            this.YOUTUBING = false;
        }

        public bool isYoutubing()
        {
            return YOUTUBING;
        }

        public bool isBrowsing()
        {
            return BROWSING;
        }

        public bool isDownloading()
        {
            return DOWNLOADING;
        }

        public ListViewItem getLastAction()
        {
            return lastAction;
        }
    }
}
