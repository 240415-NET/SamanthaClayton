namespace InterfaceQuickDemo;


//Here is how I define a new interface, it's almost identical to creating a class
//The common convention is to  begin interface files and names with a 
// capital I so that we know we'r edealing wih an interface at a glance
public interface INoise 
{
        //Inside our interface we only care about method signatures
        // not defining what the method does {}, no logic is written in the interface
        // we care about 
        // access modifier, what you return, what its name is, and what it expects

    public void MakeGeneralNoise();
    /*public void MakeHappyNoise(string name);
    public void MakeHappyNoise(string name, int age);
    public void MakeAngryNoise(string name, int age);*/
    public void MakeSadNoise();
    

    //void - we're not going to return anything, just gonna console.writeline
    //we're just telling it that the class that implements this needs to 
    //have a MakeNoise method and define what it does.

    //Our interface can contain as many method signatures as needed as well as
    //account for overloads in the same method (so same name, but different arguments)

    //public bool isHappy();



}