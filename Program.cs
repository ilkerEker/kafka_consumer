using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace kafka_consumer
{
    public class Program
    {
        static void Main(string[] args)
        {
           
                process(); 
            
        }

        public async static void process()
        {
            var config = new ConsumerConfig
            {
                GroupId = "test-consumer-group",
                BootstrapServers = "10.1.10.36:9092",
                EnableAutoCommit = false
            };
            using (var c = new ConsumerBuilder<Ignore, string>(config).Build())
            {
                c.Subscribe("message");

                while (1==1)
                {
                    var consumeResult = c.Consume(new TimeSpan(100));
                    if (consumeResult != null) { 
                       Console.WriteLine("Gelen Mesaj:"+consumeResult.Message.Value);
                        if (consumeResult.Message.Value == "quit") { break; }
                    }
                }

                

            }
        }
    }
}
