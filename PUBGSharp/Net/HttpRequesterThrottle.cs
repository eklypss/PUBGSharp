using System;
using System.Threading;
using System.Threading.Tasks;
using PUBGSharp.Data;
using PUBGSharp.Net.Model;
using PUBGSharp.Helpers;

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

        public override async Task<StatsResponse> RequestAsyncS(string playerName, Region region, Mode mode)
        {
            try
            {
                _queue.WaitOne();
                var diff = DateTime.UtcNow - _lastRequest;
                if (diff < TimeSpan.FromSeconds(1))
                {
                    await Task.Delay(TimeSpan.FromSeconds(1) - TimeSpan.FromMilliseconds(diff.TotalMilliseconds));
                }
                var response = await base.RequestAsyncS(playerName, region, mode).ConfigureAwait(false);
                _lastRequest = DateTime.UtcNow;
                return response;
            }
            finally
            {
                _queue.Release();
            }
        }

        public override async Task<StatModel> RequestAsyncV(string playerName, Region region, Mode mode, string value)
        {
            try
            {
                _queue.WaitOne();
                var diff = DateTime.UtcNow - _lastRequest;
                if (diff < TimeSpan.FromSeconds(1))
                {
                    await Task.Delay(TimeSpan.FromSeconds(1) - TimeSpan.FromMilliseconds(diff.TotalMilliseconds));
                }
                var response = await base.RequestAsyncV(playerName, region, mode, value).ConfigureAwait(false);
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