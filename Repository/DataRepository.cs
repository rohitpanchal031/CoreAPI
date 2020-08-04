using InsuranceCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceCore.Repository
{
    public class DataRepository : IDataRepository
    {
        TestDBContext db;
        public DataRepository(TestDBContext _db)
        {
            db = _db;
        }
        public async Task<List<Contracts>> GetContracts()
        {
            if (db != null)
            {
                return await db.Contracts.ToListAsync();
            }

            return null;
        }
        public Task<Contracts> AddContracts(Contracts contracts)
        {
            if (db != null && !string.IsNullOrEmpty(contracts.Name) && !string.IsNullOrEmpty(contracts.Address) && !string.IsNullOrEmpty(contracts.Country))
            {
                //get plan
                CoveragePlan  coveragePlan = db.CoveragePlan.Where(x => x.EligibilityCountry == contracts.Country).FirstOrDefault();

                //find Age from DOB
                int dboyear = contracts.Dob.Value.Year;
                int Age = DateTime.Today.Year - contracts.Dob.Value.Year;
                string converageAge = string.Empty;
                if(Age<40)
                {
                    converageAge = "<= 40";
                }
                else
                {
                    converageAge = ">40";
                }
                RateChart rateChart = db.RateChart.Where(x => x.Gender == contracts.Gender && x.CoveragePlan == coveragePlan.Plan && x.Age == converageAge).FirstOrDefault();
                if(rateChart != null)
                {
                    //insert to Contracts table
                    contracts.CoveragePlan = coveragePlan.Plan;
                    contracts.NetPrice = rateChart.NetPrice;
                    contracts.SaleDate = DateTime.Now;
                    db.Contracts.Add(contracts);
                    db.SaveChanges();
                }
                return Task.FromResult(contracts);
            }

            return null;
        }

        public Task<Contracts> DeleteContracts(int? CustomerId)
        {
            if (db != null)
            {
                Contracts contracts = db.Contracts.Where(x => x.CustomerId == CustomerId).FirstOrDefault();
                db.Contracts.Remove(contracts);
                db.SaveChanges();
                return Task.FromResult(contracts);
            }

            return null;
        }
        public Task UpdateContracts(Contracts contracts)
        {
            throw new NotImplementedException();
        }
    }
}
