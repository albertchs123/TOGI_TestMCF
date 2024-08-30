using Microsoft.AspNetCore.Mvc;
using bpkbAPI.Data;
using bpkbAPI.Models;
using Microsoft.EntityFrameworkCore;

public class BpkbServices : IBpkbServices
{
    private readonly AppDbContext _context;

    public BpkbServices(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<tr_bpkb>> getAllData()
    {
        return await _context.tr_bpkb.ToListAsync();
    }

    public async Task<ReturnStatus> SaveOrUpdateBpkb(bpkb bpkb)
    {
        if (string.IsNullOrEmpty(bpkb.agreement_number))
        {
            return new ReturnStatus
            {
                IsSuccess = false,
                Message = "agreement_number wajib diisi!"
            };
        }

        try
        {
            var findData = _context.tr_bpkb.Find(bpkb.agreement_number);

            if (findData == null)
            {
                _context.tr_bpkb.Add(new tr_bpkb
                {
                    agreement_number = bpkb.agreement_number,
                    bpkb_no = bpkb.bpkb_no,
                    branch_id = bpkb.branch_id,
                    bpkb_date = bpkb.bpkb_date,
                    faktur_no = bpkb.faktur_no,
                    faktur_date = bpkb.faktur_date,
                    location_id = bpkb.location_id,
                    police_no = bpkb.police_no,
                    bpkb_date_in = bpkb.bpkb_date_in,
                    created_by = bpkb.user,
                    created_on = DateTime.Now,
                    last_updated_by = bpkb.user,
                    last_updated_on = DateTime.Now,
                });
            }
            else
            {
                findData.bpkb_no = bpkb.bpkb_no;
                findData.branch_id = bpkb.branch_id;
                findData.bpkb_date = bpkb.bpkb_date;
                findData.faktur_no = bpkb.faktur_no;
                findData.faktur_date = bpkb.faktur_date;
                findData.location_id = bpkb.location_id;
                findData.police_no = bpkb.police_no;
                findData.bpkb_date_in = bpkb.bpkb_date_in;
                findData.last_updated_by = bpkb.user;
                findData.last_updated_on = DateTime.Now;
            }
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ReturnStatus
            {
                IsSuccess = false,
                Message = "Insert Error!"
            };
        }

        return new ReturnStatus
        {
            IsSuccess = true,
            Message = "Save Success!"
        };
    }

    public async Task<ReturnStatus> DeleteBpkb(string agreement_number)
    {
        var bpkb = await _context.tr_bpkb.FindAsync(agreement_number);
        if (bpkb == null)
        {
            return new ReturnStatus
            {
                IsSuccess = false,
                Message = "Data not found."
            };
        }

        _context.tr_bpkb.Remove(bpkb);
        await _context.SaveChangesAsync();

        return new ReturnStatus
        {
            IsSuccess = true,
            Message = "Delete Success!"
        };
    }

}
