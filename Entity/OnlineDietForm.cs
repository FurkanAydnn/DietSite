using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class OnlineDietForm
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
        public DateTime BreakfastTime { get; set; }
        public string BreakfastLocation { get; set; }
        public DateTime LaunchTime { get; set; }
        public string LaunchLocation { get; set; }
        public DateTime DinnerTime { get; set; }
        public string DinnerLocation { get; set; }
        public string NutritionOrderURL { get; set; }
        public string IndespensableDishes { get; set; }
        public string NotConsumedDishes { get; set; }
        public string ChronicDiseases { get; set; }
        public string FamilyChronicDiseases { get; set; }
    }

    public enum Gender
    {
        Erkek,
        Kadın
    }

    public enum Consumption
    {
        [Description("Her Gün")] EveryDay = 1,
        [Description("Birkaç günde bir")] EveryFewDays = 2,
        [Description("Haftada bir")] OnceAWeek = 3,
        [Description("Çok nadir")] Rarely = 4,
        [Description("Hiç")] Never = 5
    }
}
