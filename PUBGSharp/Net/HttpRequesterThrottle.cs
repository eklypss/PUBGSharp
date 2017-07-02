using System;
using System.Threading;
using System.Threading.Tasks;
using PUBGSharp.Net.Model;

namespace PUBGSharp.Net
{
    public class HttpRequesterThrottle : HttpRequester
    {
        private readonly Semaphore _queue;

        private DateTime _lastRequest;

        public HttpRequesterThrottle(string apiKey) : base(apiKey)
        {
            _queue = new Semaphore(1, 1);
        }

        public override async Task<StatsResponse> RequestAsync(string playerName, string region)
        {
            try
            {
                _queue.WaitOne();

                var diff = DateTime.UtcNow - _lastRequest;
                if (diff < TimeSpan.FromSeconds(1))
                {
                    await Task.Delay(TimeSpan.FromSeconds(1) - TimeSpan.FromMilliseconds(diff.TotalMilliseconds));
                }
                
                var response =  await base.RequestAsync(playerName, region);

                _lastRequest = DateTime.UtcNow;

                return response;
            }
            finally
            {
                _queue.Release();
            }
        }
    }
}
