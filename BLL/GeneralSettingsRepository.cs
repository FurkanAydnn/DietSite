using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class GeneralSettingsRepository : BaseRepository<GeneralSettings>
    {
        DietContext _db;
        public GeneralSettingsRepository(DietContext db) : base(db)
        {
            _db = db;
        }

        public GeneralSettings GetSettings()
        {
            return _db.GeneralSettings.FirstOrDefault();
        }
    }
}
