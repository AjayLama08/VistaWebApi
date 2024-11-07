using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json; // JSON serialization and deserialization.
using Vista.Web.Dtos; // Namespace that contains the Data Transfer Object (DTO) definitions.
namespace Vista.Web.Services
{
    public class CategoryService
    {
        // Base URL for the API service.
        const string ServiceBaseUrl = "https://localhost:7161/api";

        // Endpoint for the categories resource.
        const string CategoryEndPoint = "/categories";
        private readonly HttpClient _httpClient; // Private property for the HttpClient object.

        // Constructor that accepts an HttpClient instance via dependency injection.
        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient; // Initialise the HttpClient property.
        }
        JsonSerializerOptions jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        // Asynchronous method to fetch category items.
        public async Task<List<CategoryDto>> GetCategoryItemsAsync()
        {
            // Sending a GET request to the categories endpoint.
            var response = await _httpClient.GetAsync(ServiceBaseUrl + CategoryEndPoint);

            // Ensuring the response indicates success (status code 200-299).
            response.EnsureSuccessStatusCode();

            // Reading the response content as a string.
            var jsonResponse = await response.Content.ReadAsStringAsync();

            // Deserializing the JSON response into a list of CategoryDto objects.
            var items = JsonSerializer.Deserialize<List<CategoryDto>>(jsonResponse, jsonOptions);
            if (items == null) // Checking if the deserialised list is null.
            {
                // Throwing an exception if the list is null.
                throw new ArgumentNullException(nameof(response), "The Category response is null.");
            }
            return items; // Returning the list of category items.
        }

        // Asynchronous method to fetch category select list items.
        public async Task<List<SelectListItem>> GetCategorySelectListAsync()
        {
            var categories = await GetCategoryItemsAsync();
            // Convert SelectListItem List
            var selList = new List<SelectListItem>();
            if (categories != null)
            {
                selList = categories.Select(c => new SelectListItem
                {
                    Value = c.CategoryCode,
                    Text = c.CategoryName
                }).ToList();
            }
            return selList;
        }
    }
}


