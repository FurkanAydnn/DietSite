using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class OnlineDietForm : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int OverallWeight { get; set; }
        public int WaistLength { get; set; }
        public Consumption FruitConsumption { get; set; }
        public Consumption VegetableConsumption { get; set; }
        public bool LegumeConsumption { get; set; }
        public bool FoodCarriage { get; set; }
        public string BreakfastTime { get; set; }
        public Location BreakfastLocation { get; set; }
        public string LunchTime { get; set; }
        public Location LunchLocation { get; set; }
        public string DinnerTime { get; set; }
        public Location DinnerLocation { get; set; }
        public string NutritionOrder { get; set; }
        public string NutritionOrderURL { get; set; }
        public string IndespensableDishes { get; set; }
        public string NotConsumedDishes { get; set; }
        public string ChronicDiseases { get; set; }
        public string FamilyChronicDiseases { get; set; }

        public virtual List<ProductConsumption> ProductConsumptions { get; set; }

        public virtual List<HealthInfoResult> HealthInfoResults { get; set; }
    }

    public enum Gender
    {
        [Description("Erkek")] Man,
        [Description("Kadın")] Woman
    }

    public enum Consumption
    {
        [Description("Her Gün")] EveryDay,
        [Description("Birkaç günde bir")] EveryFewDays,
        [Description("Haftada bir")] OnceAWeek,
        [Description("Çok nadir")] Rarely,
        [Description("Hiç")] Never
    }

    public enum Location
    {
        [Description("Ev")] Home,
        [Description("İşyeri/Dışarıda")] Outside
    }
}
