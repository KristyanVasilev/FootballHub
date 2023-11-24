namespace FootballHub.Application.Services
{
    using Microsoft.Extensions.Hosting;

    public abstract class BackgroundServiceBase : IHostedService, IDisposable
    {
        private Timer _timer;
        protected abstract TimeSpan Interval { get; }

        public Task StartAsync(CancellationToken cancellationToken)
        {

            _timer = new Timer(async state => await DoWork(cancellationToken), null, TimeSpan.Zero,
                Interval);

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

        protected abstract Task DoWork(CancellationToken cancellationToken);
    }
}
