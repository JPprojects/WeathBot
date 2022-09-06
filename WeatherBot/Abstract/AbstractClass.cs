namespace WeatherBot.Abstract
{
    public class AbstractClass
    {
        //Abstract class: is a restricted class that cannot be used to create objects (to access it, it must be inherited from another class).
        //abstraction can also be acheived via an interface 
        //You can not create an instance of the abstract class
        abstract class SoftwareEngineer
        {
            // Abstract method (does not have a body)
            //Abstract methods are just a base that be overridden but applies to all that in herit it
            public abstract void Code();
            // Regular method
            public void sleep()
            {
                Console.WriteLine("Zzz");
            }
        }

        class Junior : SoftwareEngineer
        {
            public override void Code()
            {
                // The body of Code() is provided here
                Console.WriteLine("Junior is coding");
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                Junior myJunior = new Junior(); // Create a Junior here
                myJunior.Code();  // Call the abstract method
                myJunior.sleep();  // Call the regular method
            }
        }
    }
}
