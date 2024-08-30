using System.Collections.Generic;
using System.Threading.Tasks;
using bpkbAPI.Models; 

public interface IStorageLocationService
{
    Task<IEnumerable<ms_storage_location>> getAllDataLocation();
}