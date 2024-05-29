// Pasting in code from the console app

namespace TrackMyStuff.API.Models; // Adding .API
public class Document : Item // Document class inherits from our Item class
{
    public string documentType {get; set;}
    public DateTime expirationDate {get; set;}

}