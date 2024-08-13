using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArecaIPIS.Classes
{
    public class Server
    {
        private static TcpListener _server;
        private static bool _isRunning;
        public static ConcurrentDictionary<string, TcpClient> _connectedClients = new ConcurrentDictionary<string, TcpClient>();
        public static string ipAdress;
        public static int SerialNumber = 0;
        public static byte[] GetReceivedBytes = new byte[0];

        public static List<string> AgdbIpAdress = new List<string>();
        public static List<string> PfdbIpAdress = new List<string>();
        public static List<string> MldbIpAdress = new List<string>();
        public static List<string> OvdIpAdress  = new List<string>();
        public static List<string> IvdIpAdress  = new List<string>();     
        
        public static void StartServer()
        {
            try
            {
                ipAdress = GetLocalIPAddress();
                int port = 25000;
                _server = new TcpListener(IPAddress.Parse(ipAdress), port);
                _server.Start();
                _isRunning = true;
              //  DataPacket($"Server started at {ipAdress}:{port}");

                Thread acceptThread = new Thread(AcceptClients);
                acceptThread.Start();
            }
            catch (Exception ex)
            {
                LogError($"Error: {ex.Message}");
            }
        }
        public static List<string> AllIpadress = new List<string>();
        public static void getBoardsIpAdress()
        {
            AllIpadress.Clear();
            MldbIpAdress.Clear();
            PfdbIpAdress.Clear();
            AgdbIpAdress.Clear();
            OvdIpAdress.Clear();
            IvdIpAdress.Clear();

            foreach (var kvp in _connectedClients)
            {
                string key = kvp.Key;
                TcpClient client = kvp.Value;
                AllIpadress.Add(key);
            }
            if (AllIpadress.Count > 0)
            {
                foreach (var ipadress in AllIpadress)
                {
                    if (TryGetLastOctet(ipadress, out int lastOctet))
                    {
                        if (lastOctet >= 40 && lastOctet <= 70)
                        {
                            OvdIpAdress.Add(ipadress);
                        }
                        else if (lastOctet >= 71 && lastOctet <= 100)
                        {
                            IvdIpAdress.Add(ipadress);
                        }
                        else if (lastOctet >= 101 && lastOctet <= 130)
                        {
                            MldbIpAdress.Add(ipadress);
                        }
                        else if(lastOctet >= 131 && lastOctet <= 160)
                        {
                            AgdbIpAdress.Add(ipadress);
                        }
                        else if(lastOctet >= 161 && lastOctet <= 190)
                        {
                            PfdbIpAdress.Add(ipadress);
                        }
                    }
                }
            }

        }
        private static bool TryGetLastOctet(string ipAddress, out int lastOctet)
        {
            lastOctet = -1;
            try
            {
                var ip = IPAddress.Parse(ipAddress);
                var bytes = ip.GetAddressBytes();
                if (bytes.Length == 4)
                {
                    lastOctet = bytes[3]; // Last octet
                    return true;
                }
            }
            catch (FormatException)
            {
                // Handle parsing error
            }
            return false;
        }

        public static void StopServer()
        {
            try
            {
                if (_isRunning)
                {
                    _isRunning = false;
                    _server.Stop();
                    foreach (var client in _connectedClients.Values)
                    {
                        client.Close();
                    }
                    _connectedClients.Clear();
                    LogError("Server stopped.");
                }
                else
                {
                    LogError("Server is not running.");
                }
            }
            catch (Exception ex)
            {
                LogError($"Error stopping server: {ex.Message}");
            }
        }

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork &&
                    (ip.ToString() == "192.168.0.254" || ip.ToString() == "192.168.0.253"))
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system matching 192.168.0.254 or 192.168.0.253!");
        }


        private static void AcceptClients()
        {
            while (_isRunning)
            {
                try
                {
                    TcpClient client = _server.AcceptTcpClient();
                    string clientIP = ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString();
                    _connectedClients[clientIP] = client;
                  //  DataPacket($"Client connected: {clientIP}");

                    Thread clientThread = new Thread(() => HandleClient(client, clientIP));
                    clientThread.Start();
                }
                catch (Exception ex)
                {
                    if (_isRunning)
                    {

                        LogError($"Accept client error: {ex.Message}");
                    }
                }
            }
        }

        public static void SendMessageToClient(string clientIP, byte[] message)
        {
            try
            {
                if (_connectedClients.TryGetValue(clientIP,out TcpClient client))
                {
                    GetReceivedBytes = new byte[0];
                    NetworkStream stream = client.GetStream();
                    stream.Flush();
                    stream.Write(message, 0, message.Length);                 
                    string hexString = ByteArrayToHexString(message);
                    DataPacket(message);
                }   
                else
                {
                    LogError($"Client {clientIP} not connected.");
                }
            }
            catch (Exception ex)
            {
                LogError($"Error sending message to client {clientIP}: {ex.Message}");
            }
        }
        public static byte[] CheckSum(byte[] buffer)
        {
            byte[] checkValue = new byte[2];
            //Its a common function for calculating crc 
            try
            {
                byte[] values = new byte[buffer.Length - 18];
                //3 for STX,2 for Site ID,2 for CRC and 3 for ETX=3+2+2+3=8 bytes removing
                Array.Copy(buffer, 9, values, 0, values.Length);
                ushort crc16CCITT = CRcTool.crc.CalcCRCITT(values);
                checkValue[0] = Convert.ToByte(crc16CCITT >> 8 & 0xff);
                checkValue[1] = Convert.ToByte(crc16CCITT & 0xff);
            }
            catch (Exception ex)
            {

                // ARECAIPISSystems.logfile.ErrorFormat("Error :" + ex.Message);
            }

            return checkValue;
        }


        private static void HandleClient(TcpClient client, string clientIP)
        {
            try
            {
                NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[1024];

                while (_isRunning)
                {
                    if (!client.Connected)
                    {
                        _connectedClients.TryRemove(clientIP, out _);
                        LogError($"Client disconnected: {clientIP}");
                        break;
                    }

                    if (stream.DataAvailable)
                    {
                        int bytesRead = stream.Read(buffer, 0, buffer.Length);
                        if (bytesRead == 0)
                        {
                            break; // Client disconnected
                        }

                        byte[] receivedBytes = new byte[bytesRead];
                        Array.Copy(buffer, 0, receivedBytes, 0, bytesRead);
                        DataPacket(receivedBytes);
                       // DataPacket($"Received from {clientIP}: {BitConverter.ToString(receivedBytes).Replace("-", " ")}");
                        Array.Resize(ref GetReceivedBytes, receivedBytes.Length);
                        GetReceivedBytes = receivedBytes;
                        // Optionally, process the received data here
                        string receivedDataString = Encoding.ASCII.GetString(receivedBytes);
                        //Console.WriteLine($"Received from {clientIP}: {receivedDataString}");
                        string hexString = ByteArrayToHexString(receivedBytes);
                    }

                    Thread.Sleep(100);
                }
            }
            catch (Exception ex)
            {
                LogError($"Client handling error: {ex.Message}");
            }
            finally
            {
                _connectedClients.TryRemove(clientIP, out _);
                client.Close();
                //Console.WriteLine($"Client handling finished: {clientIP}");
            }
        }
        public static string ByteArrayToHexString(byte[] data)
        {
            StringBuilder hex = new StringBuilder(data.Length * 2);
            foreach (byte b in data)
            {
                hex.AppendFormat("{0:x2} ", b);
            }
            return hex.ToString();
        }
        //public static void LogError(string message)
        //{
        //    string logFilePath = @"D:\LogError.txt";
        //    try
        //    {
        //        using (StreamWriter writer = new StreamWriter(logFilePath, true))
        //        {
        //            writer.WriteLine($"{DateTime.Now}: {message}");
        //        }
        //        //MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Error logging message: {ex.Message}", "Logging Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        public static async Task LogError(string message)
        {
            string logFilePath = @"D:\LogError.txt";
            int retryCount = 3;    // Number of retries
            int delay = 1000;      // Delay between retries in milliseconds

            for (int i = 0; i < retryCount; i++)
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(new FileStream(logFilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite)))
                    {
                        await writer.WriteLineAsync($"{DateTime.Now}: {message}");
                        await writer.FlushAsync();  // Ensure all data is written to the file immediately
                    }
                    break; // Exit loop if successful
                }
                catch (IOException ex) when (i < retryCount - 1)
                {
                    // Wait before retrying
                    await Task.Delay(delay);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error logging message: {ex.Message}", "Logging Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }
        }
        //public static void DataPacket(string message)
        //{
        //    string logFilePath = @"D:\DataPacket.txt"; // You can specify your log file path here
        //    try 
        //    {
        //        using (StreamWriter writer = new StreamWriter(logFilePath, true))
        //        {
        //            writer.WriteLine($"{DateTime.Now}: {message}");
        //        }
        //       // MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Error logging message: {ex.Message}", "Logging Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}


             public static async Task DataPacket(byte[] data)
             {
                  string logFilePath = @"D:\DataPacket.txt"; // Specify your log file path here
                  int retryCount = 3;
                  int delay = 1000; // Delay in milliseconds

                  for (int i = 0; i < retryCount; i++)
                  {
                  try
                  {
                  using (StreamWriter writer = new StreamWriter(new FileStream(logFilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite)))
                  {
                        string hexString = ByteArrayToHexString(data);
                        await writer.WriteLineAsync($"{DateTime.Now}: {hexString}");
                        await writer.FlushAsync();  // Ensure all data is written to the file immediately
                  }
                   // MessageBox.Show("Data packet logged successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   break; // Exit loop if successful
                  }
                  catch (IOException ex) when (i < retryCount - 1)
                  {
                // Wait before retrying
                   await Task.Delay(delay);
                  }
                  catch (Exception ex)
                  {
                   MessageBox.Show($"Error logging data packet: {ex.Message}", "Logging Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   break;
                  }
                  }
             }

}
}
