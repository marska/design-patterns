using System;
using System.Collections.Concurrent;

namespace ConsumerProducer
{
    internal class Producer
    {
        public static void Produce(BlockingCollection<Product> productsCollection, int productsCount)
        {
            for (int i = 0; i < productsCount; i++)
            {
                var product = new Product(i, DateTime.Now.ToShortTimeString());

                productsCollection.Add(product);

                Console.WriteLine("Producer created new product id {0}", product.Id);
            }

            productsCollection.CompleteAdding();
        }
    }
}