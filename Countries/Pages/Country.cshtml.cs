using Countries.GraphQL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StrawberryShake;

namespace Countries.Pages;

public class CountryModel : PageModel
{
    private readonly ICountriesClient _countriesClient;
    private readonly ILogger<CountryModel> _logger;

    public IGetCountry_Country Country { get; set; }

    public CountryModel(ICountriesClient countriesClient, ILogger<CountryModel> logger)
    {
        _countriesClient = countriesClient;
        _logger = logger;
    }

    public async Task<IActionResult> OnGet(string countryCode)
    {
        var country = await _countriesClient.GetCountry.ExecuteAsync(countryCode);
        if (country.IsErrorResult())
        {
            // ...
        }

        if (country.Data?.Country == null)
        {
            return NotFound();
        }

        Country = country.Data!.Country;

        return Page();
    }
}