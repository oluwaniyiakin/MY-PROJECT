using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "Rexburg", "ID", "USA");
        Address address2 = new Address("456 Elm St", "Salt Lake City", "UT", "USA");
        Address address3 = new Address("789 Pine St", "Provo", "UT", "USA");

        Event lecture = new Lecture("Lecture on AI", "An in-depth lecture on artificial intelligence.", "10/01/2024", "10:00 AM", address1, "John Doe", 100);
        Event reception = new Reception("Networking Event", "A reception for professionals to network.", "11/01/2024", "6:00 PM", address2, "rsvp@example.com");
        Event outdoorGathering = new OutdoorGathering("Picnic in the Park", "A community picnic with games and activities.", "12/01/2024", "1:00 PM", address3, "Sunny with a chance of rain");

        List<Event> events = new List<Event> { lecture, reception, outdoorGathering };

        foreach (Event ev in events)
        {
            Console.WriteLine(ev.GetStandardDetails());
            Console.WriteLine();
            Console.WriteLine(ev.GetFullDetails());
            Console.WriteLine();
            Console.WriteLine(ev.GetShortDescription());
            Console.WriteLine();
        }
    }
}
