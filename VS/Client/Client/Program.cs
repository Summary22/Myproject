using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;

namespace Client
{
    class Program
    {
        #region Key event handler
        delegate bool ConsoleCtrlDelegate(int dwCtrlType);

        [DllImport("kernel32.dll")]
        static extern bool SetConsoleCtrlHandler(ConsoleCtrlDelegate handlerRoutine, bool add);

        private const int CtrlCEvent = 0;//CTRL_C_EVENT = 0;//一个Ctrl+C的信号被接收，该信号或来自键盘，或来自GenerateConsoleCtrlEvent    函数   

        private const int CtrlBreakEvent = 1;//CTRL_BREAK_EVENT = 1;//一个Ctrl+Break信号被接收，该信号或来自键盘，或来自GenerateConsoleCtrlEvent    函数  

        private const int CtrlCloseEvent = 2;//CTRL_CLOSE_EVENT = 2;//当用户系统关闭Console时，系统会发送此信号到此   

        private const int CtrlLogoffEvent = 5;//CTRL_LOGOFF_EVENT = 5;//当用户退出系统时系统会发送这个信号给所有的Console程序。该信号不能显示是哪个用户退出。   

        private const int CtrlShutdownEvent = 6;//CTRL_SHUTDOWN_EVENT = 6;//当系统将要关闭时会发送此信号到所有Console程序   

        static bool HandlerRoutine(int ctrlType)
        {
            switch (ctrlType)
            {
                case CtrlCEvent:
                    System.Console.WriteLine("Ctrl+C keydown");
                    return true;

                case CtrlBreakEvent: System.Console.WriteLine("Ctrl+Break keydown"); break;

                case CtrlCloseEvent: System.Console.WriteLine("window closed"); break;

                case CtrlLogoffEvent: System.Console.WriteLine("log off or shut down"); break;

                case CtrlShutdownEvent: System.Console.WriteLine("system shut down"); break;

                default: System.Console.WriteLine(ctrlType.ToString()); break;
            }

            return false;
        }

        static void SetKeyHandler()
        {
            if (SetConsoleCtrlHandler(new ConsoleCtrlDelegate(HandlerRoutine), true))
            {
                Debug.WriteLine("Set    SetConsoleCtrlHandler    success!!");
            }
            else
            {
                Debug.WriteLine("Set    SetConsoleCtrlHandler    Error!!");
            }
        } 
        #endregion


        static TcpClient tcpClient;
        static string ip = string.Empty;
        static IPAddress iPAddress;


        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("Client");

            SetKeyHandler();
            
            // 新建客户端套接字
            tcpClient = new TcpClient();

            loop:
            {
                Console.Write("Input ip address: ");
                ip = Console.ReadLine();
            }

            try
            {
                iPAddress = IPAddress.Parse(ip);  // 把IP地址转换为IPAddress的实例

                // 连接服务器
                tcpClient.Connect(iPAddress, 8888);
                Console.WriteLine("Connected");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Format");
                goto loop;
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Argument should not be null");
                goto loop;
            }

            // 得到客户端的流
            Stream stream = tcpClient.GetStream();
           
            while (tcpClient.Connected)
            {
                //发送数据
                try
                {
                    //ASCIIEncoding encoding = new ASCIIEncoding();
                    byte[] sendBuffer = ASCIIEncoding.UTF8.GetBytes(Console.ReadLine());
                    stream.Write(sendBuffer, 0, sendBuffer.Length);
                    stream.Flush();
                }
                catch (Exception)
                { 
                    throw;
                }
            }

            // 接收从服务器返回的信息
            //while (tcpClient.Connected)
            //{
            //    byte[] bb = new byte[100];
            //    int k = stream.Read(bb, 0, 100);

            //    string a = null;
            //    for (int i = 0; i < k; i++)
            //    {
            //        a += Convert.ToChar(bb[i]);
            //    }
            //    switch (a)
            //    {
            //        case "time":
            //            ASCIIEncoding asen = new ASCIIEncoding();
            //            byte[] ba = asen.GetBytes(DateTime.Now.TimeOfDay.ToString());
            //            stream.Write(ba, 0, ba.Length);
            //            stream.Flush();
            //            break;
            //        default:
            //            break;
            //    }
            //}
        }

        static void SendKey(string keyCode)
        {
            
        }

        static void GetFrequency()
        {

        }

        static void CloseTcpClient()
        {
            if (tcpClient == null || !tcpClient.Connected)
            {
                return;
            }

            try
            {
                tcpClient.Close();
            }
            catch
            {

            }
        }

    }
}
