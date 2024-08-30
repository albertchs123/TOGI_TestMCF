using System.Collections.Generic;
using System.Threading.Tasks;
using bpkbAPI.Models; 

public interface IBpkbServices
{
    Task<IEnumerable<tr_bpkb>> getAllData();
    Task<ReturnStatus> SaveOrUpdateBpkb(bpkb bpkb);
    Task<ReturnStatus> DeleteBpkb(string agreement_number);
}