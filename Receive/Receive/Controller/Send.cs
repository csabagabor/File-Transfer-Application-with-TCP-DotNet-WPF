using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Threading;

namespace Receive.Controller
{
    class Send
    {
        private const int BufferSize = 1024;
        private WindowSendFile window;
        private readonly Dispatcher disp = Dispatcher.CurrentDispatcher;

        public Send(WindowSendFile window)
        {
            this.window = window;
        }

        
        private void SetLabelMmsg(string msg)
        {
            disp.Invoke(
                () => { window.GetLabelMsg().Content = msg; }
            );
        }

        private void UpdateProgressBar(double value)
        {
            disp.Invoke(
                () => { window.GetProgressBar().Value = value; }
            );
        }

        private void SetmaxmimumProgressBar(double max)
        {
            disp.Invoke(
                () => { window.GetProgressBar().Maximum = max; }
            );
        }

        public void SendTCP(string sendingFilePath, string ip, Int32 portNumber)
        {
            new Thread(() =>
            {
                SetLabelMmsg("");
                UpdateProgressBar(0);
                using (TcpClient client = new TcpClient(ip, portNumber))
                using (NetworkStream netstream = client.GetStream())
                {
                    SetLabelMmsg("Connected to the Server..." + Environment.NewLine);
                    FileStream fs = new FileStream(sendingFilePath, FileMode.Open, FileAccess.Read);
                    int nrPackets =
                        Convert.ToInt32(Math.Ceiling(Convert.ToDouble(fs.Length) / Convert.ToDouble(BufferSize)));
                    SetmaxmimumProgressBar(nrPackets);
                    Console.WriteLine("nr packets=" + nrPackets);
                    int totalLength = (int)fs.Length;

                    string ext = Path.GetFileName(sendingFilePath);
                    var buffer = BitConverter.GetBytes(ext.Length);
                    netstream.Write(buffer, 0, (int)buffer.Length);
                    buffer = Encoding.ASCII.GetBytes(ext);
                    netstream.Write(buffer, 0, (int)buffer.Length);
                    //send size of file
                    buffer = BitConverter.GetBytes(totalLength);
                    netstream.Write(buffer, 0, (int)buffer.Length);
                    buffer = new byte[BufferSize];

                    int db = 0, howOftenToUpdate = nrPackets / 15;

                    for (int i = 1; i < nrPackets; i++)
                    {
                        fs.Read(buffer, 0, BufferSize);
                        netstream.Write(buffer, 0, BufferSize);

                        db++;
                        if (db > howOftenToUpdate)
                        {
                            db = 0;
                            UpdateProgressBar(i);
                        }
                    }

                    var sizeRemaining = totalLength % BufferSize;//remaining data size to send
                    fs.Read(buffer, 0, sizeRemaining);
                    netstream.Write(buffer, 0, sizeRemaining);

                    UpdateProgressBar(nrPackets);
                    SetLabelMmsg("Sent " + fs.Length + " bytes to the server");
                    fs.Close();

                }
            }).Start();
        }
    }
}
