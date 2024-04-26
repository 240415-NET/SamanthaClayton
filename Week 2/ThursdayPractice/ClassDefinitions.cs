namespace ClassDefinitions;

// class Recipe
// {
//     public string RecipeName = "Default recipe name - something broke, man";
//     public int HowLongToCook = 9999999; //this is gonna take you foreverrrrr

//     public IngredientList 
// }


class IngredientList
{
    string Ingredient1;
    string Ingredient2;
    string Ingredient = "No ingredients here, pal";


}

class Ingredient
{
    public string IngredientName = "Default ingredient name - something broke, homie";
    public string OptionalIngredientNickname = "No nickname here, buddy";
    public bool PrepWork = false;
    public string TypeOfPrep = "N/A";

    public Ingredient(){}

    public Ingredient(string Name, string OptionalIngredientNickname, bool PrepWork, string TypeOfPrep)
    {
        this.IngredientName = Name;
        this.OptionalIngredientNickname = OptionalIngredientNickname;
        this.PrepWork = PrepWork;
        this.TypeOfPrep = TypeOfPrep;
    }

    public Ingredient (string Name)
    {
        this.IngredientName = Name;
    }

    public Ingredient (string Name, string OptionalIngredientNickname)
    {
        this.IngredientName = Name;
        this.OptionalIngredientNickname = OptionalIngredientNickname;
    }

    public override string ToString()
    {
        return  $"HERE'S YOUR INGREDIENT\n" +
                $"Item Name: {IngredientName}\n" +
                $"Optional Name: {OptionalIngredientNickname}\n" +
                $"Prep Work: {PrepWork}\n" +
                $"Type Of Prep Work: {TypeOfPrep}";
    }
}
class MeatProduct : Ingredient
    {
        
        string OptionalIngredientNickname = "default meat product optional nickname not provided";
        bool CookedBeforeStarting = false;

        public MeatProduct(string MeatName, string OptionalIngredientNickname, bool PrepWork, string TypeOfPrep, bool CookedBeforeStarting)
        {
        this.IngredientName = MeatName;
        this.OptionalIngredientNickname = OptionalIngredientNickname;
        this.PrepWork = PrepWork;
        this.TypeOfPrep = TypeOfPrep;
        this.CookedBeforeStarting = CookedBeforeStarting;
        }

        public MeatProduct(string MeatName)
        {
        this.IngredientName = MeatName;
        this.OptionalIngredientNickname = OptionalIngredientNickname;
        }

        public MeatProduct(string MeatName, string OptionalIngredientNickname)
        {
        this.IngredientName = MeatName;
        this.OptionalIngredientNickname = OptionalIngredientNickname;
        }

        public MeatProduct(string MeatName, string OptionalIngredientNickname, bool CookedBeforeStarting)
        {
        this.IngredientName = MeatName;
        this.OptionalIngredientNickname = OptionalIngredientNickname;
        this.CookedBeforeStarting = CookedBeforeStarting;
        }
    public override string ToString()
    {
        return  $"HERE'S YOUR MEAT PRODUCT:\n" +
                $"Item Name: {IngredientName}\n" +
                $"Optional Name: {OptionalIngredientNickname}\n" +
                $"Prep Work: {PrepWork}\n" +
                $"Type Of Prep Work: {TypeOfPrep}\n" +
                $"Cooked Before Starting: {CookedBeforeStarting}";
    }

}
