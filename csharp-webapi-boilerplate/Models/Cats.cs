namespace csharp_webapi_boilerplate.Models
{
    public record Cats
    {
        public string Name { get; init; }
        public bool IsFavorite { get; init; }
        public DateTime Updated { get; init; }
    }
}