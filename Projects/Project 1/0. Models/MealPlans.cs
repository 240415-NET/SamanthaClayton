using System.Security.Principal;

namespace Project1.Models;

public class MealPlans
{
    public List<string>? mealList {get;set;}

    //public Guid mondayMealGuid {get; set;}

    public string? mondayMeal {get; set;} = "";
    //public Guid tuesdayMealGuid {get; set;}

    public string? tuesdayMeal {get; set;}= "";
    //public Guid wednesdayMealGuid {get; set;}
    public string? wednesdayMeal {get; set;}= "";

    //public Guid thursdayMealGuid {get; set;}

    

    public string? thursdayMeal {get; set;} = "";
    
    //public Guid fridayMealGuid {get; set;}

    public string? fridayMeal {get; set;} = "";

    public MealPlans(){}

/*
    public MealPlans(string _mondayMeal, string _tuesdayMeal, string _wednesdayMeal, string _thursdayMeal, string _fridayMeal,
                    Guid _mondayMealGuid, Guid _tuesdayMealGuid, Guid _wednesdayMealGuid, Guid _thursdayMealGuid, Guid _fridayMealGuid)
    
    {
    mealList = [_mondayMeal, tuesdayMeal, _wednesdayMeal, _thursdayMeal, fridayMeal];
    mondayMeal = _mondayMeal;
    tuesdayMeal = _tuesdayMeal;
    wednesdayMeal = _wednesdayMeal;
    thursdayMeal = _thursdayMeal;
    fridayMeal = _fridayMeal;
    mondayMealGuid = _mondayMealGuid;
    tuesdayMealGuid = _tuesdayMealGuid;
    wednesdayMealGuid = _wednesdayMealGuid;
    thursdayMealGuid = _thursdayMealGuid;
    fridayMealGuid = _fridayMealGuid

    }
*/

    public MealPlans(string _mondayMeal, string _tuesdayMeal, string _wednesdayMeal, string _thursdayMeal, string _fridayMeal)
    
    {
    mealList = [_mondayMeal, tuesdayMeal, _wednesdayMeal, _thursdayMeal, fridayMeal];
    mondayMeal = _mondayMeal;
    tuesdayMeal = _tuesdayMeal;
    wednesdayMeal = _wednesdayMeal;
    thursdayMeal = _thursdayMeal;
    fridayMeal = _fridayMeal;

    }
    public MealPlans(List<string> _mealList)
    {
    mealList = _mealList;
    mondayMeal = _mealList[0];
    tuesdayMeal = _mealList[1];
    wednesdayMeal = _mealList[2];
    thursdayMeal = _mealList[3];
    fridayMeal = _mealList[4];
    }

}