using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace SimpleHeartBeatService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var exitCode = HostFactory.Run(x =>
            {
                x.Service<HeartBeat>(s =>
                {
                    s.ConstructUsing(heartbeat => new HeartBeat());
                    s.WhenStarted(heartbeat=>heartbeat.Start());
                    s.WhenStopped(heartbeat => heartbeat.Start());

                });
                x.RunAsLocalService();
                x.SetServiceName("HeartbeatServices");
                x.SetDisplayName("Heartbeat Service");
                x.SetDescription("This is the sample heartbeat services used in a demo.");
                

            });
            int exitCodeValue=(int)Convert.ChangeType(exitCode, exitCode.GetTypeCode());
            Environment.ExitCode= exitCodeValue;
        }

    }
}
