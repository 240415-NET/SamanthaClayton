using System.Runtime.InteropServices;

namespace ClassBasics.TodoList
{
    public class Todoitem
    {

        //these are the fields that will make up the shape of my object
        private string Description = "Default description";
        private int EstimatedTime = 60; // int as minutes
        private string DueDate = "4/24/2024";
        private bool Status = false; //false is incomplete

        //public Todoitem(){}

        public Todoitem(string Description)
        {
            this.Description = Description;
        }


        //Constuctor.WriteLine(new TodoItem("Sharpen my pencil", 5, "5/25/2025"));
        public Todoitem(string Description, int EstimatedTime, string DueDate) : this(Description)
        {
            this.EstimatedTime = EstimatedTime;
            this.DueDate = DueDate;
        }


        //Constuctor.WriteLine(new TodoItem("Sharpen my pencil", 5, "5/25/2025", true));
        public Todoitem(string Description, int EstimatedTime, string DueDate, bool Status) : this(Description, EstimatedTime,DueDate)
        {
            // this.Description = Description;
            // this.EstimatedTime = EstimatedTime;
            // this.DueDate = DueDate;
            this.Status = Status;
        }
        
        
        //my methods are how I will interact with the objects
        //& how the objects will interact with each other
        public string GetDescription(){
            return this.Description;}

        public void setDescription(string Description){
            this.Description = Description;
        }

        public bool GetStatus(){
            return this.Status;}

        public void SetStatus(bool Status){
            this.Status = Status;
        }

        public int GetEstimatedTime(){
            return this.EstimatedTime;
    
    }
        public void SetEstimatedTime(int EstimatedTime){
            this.EstimatedTime=EstimatedTime;
        }

        public string GetDueDate(){
            return  this.DueDate;
        }

        public void SetDueDate(string DueDate){
            this.DueDate = DueDate;
        }


        //Override the ToString:  The default ToString will print out the class
        //it won't provide any details about what the object looks like
        //it's for the user experience

        public override string ToString()
        {
         //get rid of this
         //   return base.ToString();

         //I do not want to put a raw boolean
         //in ToString, so we create our own string representing
         //the status of the boolean.  It will default to false, showing
         //Incomplete.  If the to do item field Status is set to be true,
         //then this if statement will evaluate and update the CurrentStatus string to Complete

         string CurrentStatus = "Incomplete";
         if(Status)
            {CurrentStatus = "Complete";
            }
            return $"{Description} - {DueDate}\nEstimated Time: {EstimatedTime}\nStatus:{CurrentStatus}";
            
        }


        public static void Main(string[] args){
            // Todoitem item1 = new Todoitem();

            // Console.WriteLine(item1);

            // Todoitem item2 = new Todoitem("Get Milk", 60, "4/25/2024", false);

            // Console.WriteLine(item2);
            List<Todoitem> todoItems = new List<Todoitem>();
            for (int i = 0; i<5; i++)
            {
            Console.WriteLine("Type Description:");
            string description = Console.ReadLine();

            Console.WriteLine("Estimated Time:");
            int estimatedTime = int.Parse(Console.ReadLine());

            Console.WriteLine("Due Date:");
            string dueDate = Console.ReadLine();

            Todoitem newItem = new Todoitem(description, estimatedTime, dueDate, false);
           // Console.WriteLine(newItem);
            todoItems.Add(newItem);

         }

        foreach (var item in todoItems){
            Console.WriteLine(item);

        }

        //Organizing my UI into a class
        //Adding validation and checks for user input & saving to my object
        //Adding a way to add items individually instead of 6 at a time

    }
}}