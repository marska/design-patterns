using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerProducer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var productsCollection = new BlockingCollection<Product>(1);

            var tasks = new List<Task>()
            {
                new Task(() => Producer.Produce(productsCollection, 1000000)),
                new Task(() => Consumer.Consume(productsCollection)),
                new Task(() => Consumer.Consume(productsCollection)),
                new Task(() => Consumer.Consume(productsCollection)),
                new Task(() => Consumer.Consume(productsCollection))
            };

            tasks.ForEach(t => t.Start());

            Task.WaitAll(tasks.ToArray());
        }
    }
}
