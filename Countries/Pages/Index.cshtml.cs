using Countries.GraphQL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StrawberryShake;

namespace Countries.Pages;

public class IndexModel : PageModel
{
    private readonly ICountriesClient _countriesClient;
    private readonly ILogger<IndexModel> _logger;

    public IReadOnlyCollection<IListCountries_Countries> Countries { get; set; }

    public IndexModel(ICountriesClient countriesClient, ILogger<IndexModel> logger)
    {
        _countriesClient = countriesClient;
        _logger = logger;
    }

    public async Task OnGet()
    {
        var countries = await _countriesClient.ListCountries.ExecuteAsync();
        if (countries.IsErrorResult())
        {
            // ...
        }

        Countries = countries.Data?.Countries ?? new List<IListCountries_Countries>(0);
    }
}