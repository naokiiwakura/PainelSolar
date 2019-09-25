using CrossSolar.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrossSolar.Repository
{
    public class AnalyticsRepository : GenericRepository<OneHourElectricity>, IAnalyticsRepository
    {
        public AnalyticsRepository(CrossSolarDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<OneHourElectricity>> ReturnOneHourElectricity(string serial)
        {
            return await _dbContext.OneHourElectricitys.Where(x => x.PanelId.Equals(serial, StringComparison.CurrentCultureIgnoreCase)).ToListAsync();                
        }

        public async Task<List<OneHourElectricity>> DayResults(string panelId)
        {
            return await _dbContext.OneHourElectricitys.Where(x => x.PanelId.Equals(panelId, StringComparison.CurrentCultureIgnoreCase)).ToListAsync();
        }
    }
}