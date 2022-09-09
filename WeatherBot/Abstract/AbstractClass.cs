namespace WeatherBot.Abstract
{
    public class AbstractClass
    {
        //Abstract class: is a restricted class that cannot be used to create objects (to access it, it must be inherited from another class).
        //abstraction can also be acheived via an interface 
        //You can not create an instance of the abstract class
        public abstract class SoftwareEngineer
        {
            // Abstract method (does not have a body)
            //Abstract methods are just a base that be overridden but applies to all that in herit it
            public abstract void Code();
            // Regular method
            public void sleep()
            {
                Console.WriteLine("Zzz");
            }

            //Virtual method does not need to be redefined in a derived class
            //Normally used when there is shared functionality but there needs to be a extended
            public virtual void Drink()
            {
                Console.WriteLine("I'm drinking");
            }
        }

        public class Junior : SoftwareEngineer
        {
            public override void Code()
            {
                // The body of Code() is provided here
                Console.WriteLine("Junior is coding");
            }
        }

        //add another clase that has the virtual method override
        public class Mid : SoftwareEngineer
        {
            public override void Code()
            {
                Console.WriteLine("Mid is coding");
            }

            //Difference between mid and junior this class does not need to be called but mid was drinking a specific drink
            public override void Drink()
            {
                Console.WriteLine("I'm drinking coffee");
            }
        }


        public class Program
        {
            static void Main(string[] args)
            {
                var myJunior = new Junior(); // Create a Junior here
                myJunior.Code();  // Call the abstract method
                myJunior.sleep();  // Call the regular method
                myJunior.Drink();   //Can still call the virtual method even though not overridden

                var myMid = new Mid();
                myMid.Code();
                myMid.sleep();
                myMid.Drink();
            }
        }
    }
}
