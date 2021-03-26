using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OrderWebApi.Services
{
    public class TimedHostedService : IHostedService, IDisposable
    {
        private Dictionary<string, iServiceProc> sysytems = new Dictionary<string, iServiceProc>()
        {
            { "talabat", new Talabat(new AppContext())},
            { "zomato", new Zomato(new AppContext())},
            { "uber", new Uber(new AppContext())}
        };

        private readonly object sycnRoot = new object();
        private Timer _timer;
        private readonly AppContext _context;
        private readonly LogService _logger;

        public TimedHostedService(LogService logger) 
        {
            _logger = logger;
            _context = new AppContext();
            _logger.Counter = 0;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(5));

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            if (Monitor.TryEnter(sycnRoot))
            {
                foreach (var order in _context.Orders.Where(x => string.IsNullOrEmpty(x.CovertedOrder)).OrderBy(x => x.CreatedAt).ToList())
                {
                    try
                    {
                        var service = sysytems[order.SystemType];
                        service.Process(order.SourceOrder);
                    }
                    catch (Exception ex)
                    {
                        Task writeErr = Task.Run(() =>
                        {
                            _logger.SetError(ex.Message);
                        });
                        _logger.Counter++;
                    }
                }
                Monitor.Exit(sycnRoot);
            }
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
