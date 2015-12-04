using System;
using System.Collections.Concurrent;
using System.Threading;

namespace ConsumerProducer
{
    internal class Consumer
    {
        public static void Consume(BlockingCollection<Product> products)
        {
            while (!products.IsCompleted)
            {
                Product product = null;

                try
                {
                    product = products.Take();
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("Adding was compeleted!");
                    break;
                }

                Console.WriteLine("Consumed product id:{0} ", product.Id);

                Thread.SpinWait(100000);
            }
        }
    }
}