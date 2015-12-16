using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using RemoteDemo;

namespace RemoteDemoClient
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpChannel channel = new TcpChannel();
            ChannelServices.RegisterChannel(channel, false);

            //ServerRemoteObject.ServerObject serverObj = (ServerRemoteObject.ServerObject)Activator.GetObject(
            //  typeof(ServerRemoteObject.ServerObject), "tcp://localhost:8080/ServiceMessage");

            ServerObject serObj = (ServerObject)Activator.GetObject(typeof(ServerObject), @"tcp://localhost:5000/ServiceMessage");
            Person p = serObj.GetPerson("Tom", 10);
            Console.WriteLine(p.Name + " " + p.Age);

            Console.WriteLine("按任意键退出！");
            Console.ReadKey();
        }
    }
}
