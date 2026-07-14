
using System.Text.Json;
using Microsoft.Net.Http.Headers;

namespace API;

public static class HttpExtensions
{
    //we're going to add pagination header to http response
  public static void AddPaginationHeader(this HttpResponse response, PaginationMetaData metadata)
    {
        var options = new JsonSerializerOptions{PropertyNamingPolicy = JsonNamingPolicy.CamelCase};

        response.Headers.Append("Pagination", JsonSerializer.Serialize(metadata, options));
        response.Headers.Append(HeaderNames.AccessControlExposeHeaders, "Pagination");
    }

}