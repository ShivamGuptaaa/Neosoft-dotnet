using System;
namespace PetLib
{
    public class Cat : Pet
    {
        public CatType CatType { get; set; } = CatType.Abyssian; //autonomous property
        public double Weight { get; set; } = 7.0; // C# 7.0 and above allows initializing properties not earlier versions allows it.
        /// <summary>
        /// This method is shadowing its parent's method by hiding its implementation. With new keyword we hide the implwmwntation of the base class, this is why we call it as method hiding
        /// </summary>
        /// <returns>string format</returns>
        public new string GetDetails(){
            string result = base.GetDetails();
            return result + $" \nCat type: {CatType} \n Cat Weight: {Weight} pounds";
        }
        public override void GetMeal(Gender gender)
        {
           if(CatType == CatType.Himalayan && gender == Gender.Female)
                Console.WriteLine("\n 250 gms of wet food");
           else if(CatType == CatType.Himalayan && gender == Gender.Male)
                Console.WriteLine("\n 350 gms of wet food");
                 else if(gender == Gender.Male)
                Console.WriteLine("\n 200 gms of wet food");
            else
                Console.WriteLine("\n 150 gms of wet food");
            
        }
    }
    public enum CatType{
        Abyssian, Persian, Himalayan, American_Bobtail, Balinese_Javanese, Bengal, Bombay,British_Shorthair
    }
    public enum FurType
    {
        Long, Short, Medium, NoFur
    }
}