using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4_Properties_Static_Keyword_IMplementation
{
    //Intrilly we used to create fields to store data in a class.
    //Properties are special class members which are used to store data.

    class student //without property implementation
    {
        //fields
        private int id;
        private string name;
        //methods to set and get field values
        public void SetId(int id)
        {
            this.id = id;
        }
        public int GetId()
        {
            return id;
        }
        public void SetName(string name)
        {
            this.name = name;
        }
        public string GetName()
        {
            return name;
        }
    }

    class student1 //with property implementation
    {
        //fields
        private int id;
        private string name;
        //properties: so properties are special class members which are used to store data.
        public int Id
        {
            get { return id; }
            set { id = value; }
            //get and set accessors are behaving like methods
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }

    //Another beneifit of properties is we can implement validation logic inside set accessor.

    class student2
    {
        //fields
        private int id;
        private string name;
        //properties: so properties are special class members which are used to store data.
        public int Id
        {
            get { return id; }
            set
            {
                //validation logic
                if (value <= 0)
                {
                    Console.WriteLine("Invalid Id");
                }
                else
                {
                    id = value;
                }
            }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }

    //we can also create readonly and writeonly properties ex from ecommerce application

    class Product
    {
        //fields
        private int id;
        private string name;
        private double price;
        //readonly property
        public int Id
        {
            get { return id; } //no set accessor
        }
        //writeonly property
        public string Name
        {
            set { name = value; } //no get accessor
        }
        //readwrite property
        public double Price
        {
            get { return price; }
            set { price = value; }
        }
        //constructor to initialize fields
        public Product(int id, string name, double price)
        {
            this.id = id;
            this.name = name;
            this.price = price;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //Why main method is static in C#?
            //Main method is static so that it can be called without creating an instance of the class.
            //only static methods can call other static methods directly.
            //example: Console.WriteLine() is a static method of Console class.
            //If main method is not static we have to create an instance of Program class to call main method.




            //Here for static variable example we dont have to create object of Counter class to access static variable count

            Counter.count = 10; //accessing static variable using class name
            //here we are not using new keyword to create object of Counter class as static variable is shared among all the instances of a class.
            //displaying static variable

            Console.WriteLine("Static variable count: " + Counter.count);

            //another example of static variable here we will create 3 objects of Counter class and display the value of static variable count
            Counter c1 = new Counter();
            Counter c2 = new Counter();
            Counter c3 = new Counter();
            Console.WriteLine("Value of static variable count after creating 3 objects: " + Counter.count);


            ///creating object of MathUtilities class to call static methods with the help of class name
            ///no need to create object of MathUtilities class

            int sum = MathUtilities.Add(10, 20);
            int difference = MathUtilities.Subtract(30, 15);
            Console.WriteLine("Sum is " + sum);
            Console.WriteLine("Differnce of two no is " + difference);

        }
    }
}



//Follwing are the feaures of Properties in C# 
//1. Properties are special class members which are used to store data.
//2. Properties are implemented using get and set accessors.
//3. Properties can have validation logic inside set accessor.
//4. Properties can be readonly, writeonly or readwrite.
//5. Properties provide a way to access private fields of a class from outside the class.
//6. Properties can be used to implement data binding in applications.
//7. Properties can be used to implement computed properties which are not stored in fields but are calculated on the fly.
//example:  
//public int Age which cab be calcuted from DateOfBirth field.
//8. Properties can be auto-implemented properties where the compiler creates a hidden backing field.
//example: public int Age { get; set; }  it was introduuces in c# 3.0
//9. Properties can be used in interfaces to define a contract for classes implementing the interface.
//example: public interface IPerson { int Age { get; set; } }
//example: public class Employee : IPerson { public int Age { get; set; } }

//Ex from ecommerce application with Interface implementation which act as a comntract for Product class
public interface IProduct
{// These property behaves like methods in interface which are by default public and abstract and any class 
    //implementing this interface must provide implementation for these properties.( mandatory contract)
    int Id { get; } //readonly property
    string Name { set; } //writeonly property
    double Price { get; set; } //readwrite property
}
//Creating a Product class implementing IProduct interface
public class Product1 : IProduct
//there can not be a single product without implementing these properties
{
    //fields
    private int id;
    private string name;
    private double price;
    //readonly property
    public int Id
    {
        get { return id; } //no set accessor
    }
    //writeonly property
    public string Name
    {
        set { name = value; } //no get accessor
    }
    //readwrite property
    public double Price
    {
        get { return price; }
        set { price = value; }
    }
    //constructor to initialize fields
    public Product1(int id, string name, double price)
    {
        this.id = id;
        this.name = name;
        this.price = price;
    }
}

//In c3 we have special keyword that is Static : 
//Static variables, methods and classes
//Static keyword is used to declare static members in a class.
//example: static variables, static methods and static classes.
//static variable is shared among all the instances of a class. One momory location is created for  diff static variable.
//example:
public class Counter
{
    //non static variable
    public int instanceCount = 0; // Each object of Counter class will have its own copy of instanceCount variable
    //static variable
    public static int count = 0; // Any point of time we can access this static variable using class name Counter.count
    //constructor
    public Counter()
    {
        count++;//post increment- if we rement count value using any object of Counter class it will be reflected in all other objects
    }

    //non static method which can access both static and non static variables
    public void DisplayCount()
    {
        Console.WriteLine("Count: " + count);
    }
    //static method
    public static void StaticDisplayCount() // static method can access only static variables
    {
        Console.WriteLine("Static Count: " + count);
    }

}


//Apart from static variable we also have static methods and static classes in C#
//Static method is a method which belongs to the class rather than to any specific object.
//ex main method is static method in C# so that it can be called without creating an instance of the class.
//Static class is a class which can not be instantiated and can contain only static members.
public static class MathUtilities
{
    //static method
    public static int Add(int a, int b)
    {
        return a + b;
    }
    //static method
    public static int Subtract(int a, int b)
    {
        return a - b;
    }
}

//Static classes are used to group related utility methods together. so that we can call them without creating an instance of the class.
//example: Math class in System namespace is a static class which contains various mathematical utility methods.
//we can call static methods using class name
//example: int sum = Math.Add(10, 20);

//Common ex of static classes ecommerce application or banking application where we have utility methods for calculations
//like interest calculation, tax calculation etc which can be grouped in a static class.




// for employee management system we can have static class for utility methods like calculating salary, bonus etc.
public static class EmployeeUtilities //utility siffix is used to indicate that this class contains utility methods
{
    //static method to calculate salary
    public static double CalculateSalary(double basicSalary, double hra, double da)
    {
        return basicSalary + hra + da;
    }
    //static method to calculate bonus
    public static double CalculateBonus(double salary, double bonusPercentage)
    {
        return (salary * bonusPercentage) / 100;
    }
}

//gamedevelopment application we can have static class for utility
public static class GameUtilities
{
    //static method to calculate score
    public static int CalculateScore(int kills, int assists, int deaths)
    {
        return (kills * 100) + (assists * 50) - (deaths * 25);
    }
    //static method to calculate level
    public static int CalculateLevel(int score)
    {
        return score / 1000;
    }
}

//Static class we have all methods as static methods and we can not create object of static class
// so if we have non static method in static class it will give compile time error: Beacuse static class 'StaticClassExample' cannot contain instance members
public static class StaticClassExample
{
    //static method
    public static void StaticMethod()
    {
        Console.WriteLine("This is a static method.");
    }
    //non static method - this will give compile time error because static class cannot contain instance members
    //public void NonStaticMethod()
    //{
    //    Console.WriteLine("This is a non-static method.");
    //}
}

//inside static keyword ecosysytem we also have static constructor so that everything is initialized before accessing any static members
//static variable. class or method all of them can have static constructor any non static class can have static constructor
public class StaticConstructorExample
{
    //static variable
    public static int staticValue;
    //static constructor
    static StaticConstructorExample()
    {
        staticValue = 100; //initializing static variable
        Console.WriteLine("Static constructor called. Static value initialized to " + staticValue);
    }
    //static method
    public static void DisplayStaticValue()
    {
        Console.WriteLine("Static Value: " + staticValue);
    }
}

//below are the advantages of static keyword in C#
//1. Memory Efficiency: Static members are shared among all instances of a class, reducing memory overhead.
//2. Utility Functions: Static classes can group related utility methods, making them easily accessible without instantiation.
//3. Global State Management: Static variables can maintain global state across different parts of an application.
//4. Performance: Accessing static members is generally faster than instance members since they are resolved at compile time.
//5. Initialization Control: Static constructors allow for controlled initialization of static members before they are accessed.
//6. Simplified Code: Static methods can simplify code by eliminating the need for object creation when only class-level functionality is required.
//7. Consistency: Static members ensure consistent behavior across all instances of a class since they share the same data.