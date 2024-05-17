using Project1.DataAccessLayer;
using Project1.Models;
using Project1.LogicLayer;
namespace Project1.Tests;

public class Project1UnitTest1
{
    private static IMealsStorageRepo _mealsData = new JsonMealsStorage();

    [Fact]
    public void GetStoredMeals_PassedNothing_Returns7()
    {
        // Arrange
        //List<Recipes> testList = _mealsData.RetrieveStoredMeals();
       List<Recipes> testList = MealsLogic.GetStoredMeals();
        int countOfTestList = testList.Count();

        // Act
        bool result;
        if (countOfTestList == 7)
        {
            result = true;
        }
        else
        {
            result = false;
        }

        //Assert
        Assert.True(result);
    }
}