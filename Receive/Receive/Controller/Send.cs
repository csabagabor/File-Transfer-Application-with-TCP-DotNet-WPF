using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Receive.Controller
{
    class Send
    {
        private const int BufferSize = 1024;
        private WindowSendFile window;

        public Send(WindowSendFile window)
        {
            this.window = window;
        }

        public void SendTCP(string sendingFilePath, string ip, Int32 portNumber)
        {
            var progressBar = window.GetProgressBar();
            var lblStatus = window.GetLabelMsg();
            //Console.WriteLine("SENDTCP=");
            TcpClient client = null;
            lblStatus.Content = "";
            NetworkStream netstream = null;
            try
            {
                client = new TcpClient(ip, portNumber);
                lblStatus.Content = "Connected to the Server..."+ Environment.NewLine;
                netstream = client.GetStream();
                FileStream fs = new FileStream(sendingFilePath, FileMode.Open, FileAccess.Read);
                int nrPackets = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(fs.Length) / Convert.ToDouble(BufferSize)));
                progressBar.Maximum = nrPackets;
                int totalLength = (int)fs.Length;
                int counter = 0;
                //send file typenrPackets

                //string ext = Path.GetExtension(M);
                string ext = Path.GetFileName(sendingFilePath);
                var buffer = BitConverter.GetBytes(ext.Length);
                netstream.Write(buffer, 0, (int)buffer.Length);
                buffer = Encoding.ASCII.GetBytes(ext);
                netstream.Write(buffer, 0, (int)buffer.Length);
                //send size of file
                buffer = BitConverter.GetBytes(totalLength);
                netstream.Write(buffer, 0, (int)buffer.Length);

                for (int i = 0; i < nrPackets; i++)
                {
                    int currentPacketLength;
                    if (totalLength > BufferSize)
                    {
                        currentPacketLength = BufferSize;
                        totalLength = totalLength - currentPacketLength;
                    }
                    else
                        currentPacketLength = totalLength;
                    buffer = new byte[currentPacketLength];
                    fs.Read(buffer, 0, currentPacketLength);
                    netstream.Write(buffer, 0, (int)buffer.Length);
                    if (progressBar.Value >= progressBar.Maximum)
                        progressBar.Value = progressBar.Minimum;
                    progressBar.Value++;
                }

                lblStatus.Content = lblStatus.Content + "Sent " + fs.Length + " bytes to the server";
                fs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                netstream.Close();
                client.Close();
            }
        }
    }
}
