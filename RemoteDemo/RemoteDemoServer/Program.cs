using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting;
using RemoteDemo;

namespace RemoteDemoServer
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpChannel channel = new TcpChannel(5000);
            ChannelServices.RegisterChannel(channel, false);
            Console.WriteLine("Port:5000 注册成功");

            RemotingConfiguration.RegisterWellKnownServiceType(typeof(ServerObject), "ServiceMessage", WellKnownObjectMode.Singleton);

            //RemotingConfiguration.ApplicationName = "ServiceMessage";
            //RemotingConfiguration.RegisterActivatedServiceType(typeof(ServerObject));

            Console.WriteLine("按回车退出……");
            Console.ReadLine();

            IChannel[] channels = ChannelServices.RegisteredChannels;
            foreach (IChannel eachChannel in channels)
            {
                if (eachChannel.ChannelName.Equals("tcp"))
                {
                    TcpChannel myChannel = (TcpChannel)eachChannel;
                    myChannel.StopListening(null);
                    ChannelServices.UnregisterChannel(myChannel);
                }
            }
        }
    }
}
