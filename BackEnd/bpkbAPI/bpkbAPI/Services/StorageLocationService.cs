using Microsoft.AspNetCore.Mvc;
using bpkbAPI.Data;
using bpkbAPI.Models;
using Microsoft.EntityFrameworkCore;

public class StorageLocationService : IStorageLocationService
{
    private readonly AppDbContext _context;

    public StorageLocationService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ms_storage_location>> getAllDataLocation()
    {
        return await _context.ms_storage_location.ToListAsync();
    }

}
