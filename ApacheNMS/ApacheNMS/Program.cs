using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Apache.NMS;

namespace ApacheNMS
{
    class Program
    {
        public static int globalColourValue = 0; 
        static void Main(string[] args)
        {
            IConnectionFactory factory = new NMSConnectionFactory(new Uri("stomp:tcp://datafeeds.networkrail.co.uk:61618"));

            IConnection connection = factory.CreateConnection("jordan.atkinson3@gmail.com", "password");
            ISession session = connection.CreateSession();

            IDestination destination = session.GetDestination("topic://TRAIN_MVT_EM_TOC");
            IMessageConsumer consumer = session.CreateConsumer(destination);

            connection.Start();
            consumer.Listener += new MessageListener(OnMessage);
            Console.WriteLine("Consumer started, waiting for messages... (Press ENTER to stop.)");


            Console.ReadLine();

            connection.Close();
        }

        private static void OnMessage(IMessage message)
        {
            try
            {

                Console.WriteLine("Median-Server (.NET): Message received");

                ITextMessage msg = (ITextMessage)message;
                message.Acknowledge();



                if (globalColourValue == 0)
                {
                    Console.WriteLine("if (colourValue == 0) - Colour Value: " + globalColourValue.ToString());
                    Console.WriteLine(msg.Text);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    globalColourValue = 1;
                    Console.WriteLine("TRAINLINE NEW DATA FEED ENDED");
                }
                else if (globalColourValue == 1)
                {
                    Console.WriteLine("else if (colourValue == 1) - Colour Value: " + globalColourValue.ToString());
                    Console.WriteLine(msg.Text);
                    Console.WriteLine("TRAINLINE NEW DATA FEED STARTED");
                    Console.ForegroundColor = ConsoleColor.White;
                    globalColourValue = 0;
                    Console.WriteLine("TRAINLINE NEW DATA FEED ENDED");
                }
                
               Console.WriteLine(msg.Text);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("---");
                Console.WriteLine(ex.InnerException);
                Console.WriteLine("---");
                Console.WriteLine(ex.InnerException.Message);
            }

        }

    }

}