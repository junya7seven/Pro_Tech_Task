namespace Swagger.Limit
{
    public class RequestLimit
    {
        private readonly RequestDelegate _next;
        private readonly SemaphoreSlim _semaphore;
        private readonly int _parallelLimit;

        private int _currentRequests = 0;

        public RequestLimit(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _parallelLimit = configuration.GetValue<int>("Settings:Limit");
            _semaphore = new SemaphoreSlim(_parallelLimit, _parallelLimit);
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                if (IsLimitReached())
                {
                    context.Response.StatusCode = 503;
                    await context.Response.WriteAsync($"HTTP ошибка 503 Service Unavailable. Достигнут лимит одновременных запросов {_parallelLimit}.");
                    return;
                }

                await _semaphore.WaitAsync();

                Interlocked.Increment(ref _currentRequests);

                await _next(context);
            }
            finally
            {
                _semaphore.Release();
                Interlocked.Decrement(ref _currentRequests);
            }
        }

        private bool IsLimitReached() => _currentRequests > _parallelLimit;
    }
}
