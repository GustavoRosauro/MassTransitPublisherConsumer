using MassTransit;
using SharedModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Consumer.Api
{
    public class OrderConsumer : 
        IConsumer<Order>
    {
        public async Task Consume(ConsumeContext<Order> context)
        {
            var data = context.Message;
            using (var writter = new StreamWriter(@"C:\log\rabbit.txt",true))
            {
                writter.WriteLine($"Nome: {data.ProductName} Quantidade: {data.Qtd}");
            }

            await Task.CompletedTask;
        }
    }
}
