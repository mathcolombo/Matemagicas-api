using Matemagicas.Application.Utils.ValueObjects;

namespace Matemagicas.Application.Utils.Mappings;

public static class PagedResultMappings
{
    public static PagedResult<T> MapToPagedResult<T>(this IQueryable<T> query, int pageNumber, int pageSize) where T : class
    {
        if (pageNumber <= 0) pageNumber = 1;
        if (pageSize <= 0) pageSize = 10;

        var totalItems = query.Count();

        var items = query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        return new PagedResult<T>(items, totalItems, pageNumber, pageSize);
    }
    
    public static PagedResult<TDestination> MapToPagedResult<TSource, TDestination>(this IQueryable<TSource> query,
                                                                                    Func<TSource, TDestination> mapper,
                                                                                    int pageNumber,
                                                                                    int pageSize) where TSource : class where TDestination : class
    {
        if (pageNumber <= 0) pageNumber = 1;
        if (pageSize <= 0) pageSize = 10;

        var totalItems = query.Count();

        var sourceItems = query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();
        
        var destinationItems = sourceItems.Select(mapper).ToList();

        return new PagedResult<TDestination>(destinationItems, totalItems, pageNumber, pageSize);
    }
}