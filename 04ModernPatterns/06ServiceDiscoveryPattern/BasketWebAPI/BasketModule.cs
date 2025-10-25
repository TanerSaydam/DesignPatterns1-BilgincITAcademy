using Steeltoe.Common.Discovery;
using TS.Endpoints;

namespace BasketWebAPI;

public class BasketModule : IEndpoint
{
    public void AddRoutes(IEndpointRouteBuilder builder)
    {
        var app = builder.MapGroup("baskets").WithTags("Baskets");

        app.MapGet("/getall", async (
            IHttpClientFactory httpClientFactory,
            IDiscoveryClient discoveryClient,
            CancellationToken cancellationToken
            ) =>
        {
            using var httpClient = httpClientFactory.CreateClient();

            var serviceIntances = await discoveryClient.GetInstancesAsync("ProductWebAPI", cancellationToken);

            var firstInstance = serviceIntances.FirstOrDefault();
            if (firstInstance is null)
            {
                return Results.BadRequest(new { Message = "We couldn't reach the product web api url" });
            }

            var productNames = await httpClient
                    .GetFromJsonAsync<List<string>>($"{firstInstance.Uri}getall");
            return Results.Ok(productNames);
        });
    }
}
