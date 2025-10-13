using Matemagicas.Application.Utils.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Matemagicas.Application.Utils.Mappings;

public static class PagedResultMappingConfigurations
{
    public static async Task<PagedResult<T>> MapToPagedResult<T>(this IQueryable<T> query, int pageNumber, int pageSize) where T : class
    {
        if (pageNumber <= 0) pageNumber = 1;
        if (pageSize <= 0) pageSize = 10;

        int totalItems = await query.CountAsync();

        List<T> items = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PagedResult<T>(items, totalItems, pageNumber, pageSize);
    }
}