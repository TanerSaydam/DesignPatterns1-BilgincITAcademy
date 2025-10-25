using Polly;
using Polly.Registry;
using Polly.Retry;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();

builder.Services.AddResiliencePipeline("my-pipeline", x =>
{
    x.AddRetry(new RetryStrategyOptions()
    {
        MaxRetryAttempts = 3,
        Delay = TimeSpan.FromSeconds(5),
        BackoffType = DelayBackoffType.Constant,
    });
    x.AddTimeout(TimeSpan.FromSeconds(30));
});

var app = builder.Build();

app.MapGet("/", async (ResiliencePipelineProvider<string> resiliencePipelineProvider, HttpClient htttpClient) =>
{
    var pipeline = resiliencePipelineProvider.GetPipeline("my-pipeline");
    List<object>? res = await pipeline.Execute(async c =>
    {
        //hazýlýk

        return await htttpClient.GetFromJsonAsync<List<object>>("");
    });

    return res;
});

app.Run();
