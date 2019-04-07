using DAL;
using Entity;
using System;

namespace BLL
{
    public class UnitOfWork
    {
        public DietContext db;

        public UnitOfWork()
        {
            object x = "";
            if (db == null)
            {
                lock (x)
                {
                    if (db == null)
                        db = new DietContext();
                }
            }

            Articles = new BaseRepository<Article>(db);
            DietLists = new BaseRepository<DietList>(db);
            HealthInfos = new BaseRepository<HealthInfo>(db);
            HealthInfoResults = new BaseRepository<HealthInfoResult>(db);
            Images = new BaseRepository<Image>(db);
            OnlineDietForms = new BaseRepository<OnlineDietForm>(db);
            Products = new BaseRepository<Product>(db);
            ProductTypes = new BaseRepository<ProductType>(db);
            ProductConsumptions = new BaseRepository<ProductConsumption>(db);
            GeneralSettings = new GeneralSettingsRepository(db);
        }

        public static DietContext Create()
        {
            return new DietContext();
        }

        public bool Complete()
        {
            try
            {
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public BaseRepository<Article> Articles;
        public BaseRepository<DietList> DietLists;
        public BaseRepository<HealthInfo> HealthInfos;
        public BaseRepository<HealthInfoResult> HealthInfoResults;
        public BaseRepository<Image> Images;
        public BaseRepository<OnlineDietForm> OnlineDietForms;
        public BaseRepository<Product> Products;
        public BaseRepository<ProductType> ProductTypes;
        public BaseRepository<ProductConsumption> ProductConsumptions;
        public GeneralSettingsRepository GeneralSettings;

    }
}
