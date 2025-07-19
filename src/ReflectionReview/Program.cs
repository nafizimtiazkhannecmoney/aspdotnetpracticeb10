using ReflectionReview;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Reflection;
Console.WriteLine("------------------------------------------------------------------------------");

var path = "D:\\ASPdotNet Practice\\aspdotnetpracticeb10\\src\\DemoLib\\bin\\Debug\\net8.0\\DemoLib.dll";

Assembly a = Assembly.LoadFile(path);
//Assembly a = Assembly.GetExecutingAssembly();

Type[] t2 = a.GetTypes();       //Taking type from assembly
for (int i = 0; i < t2.Length; i++)
    Console.WriteLine(t2[i].Name);
Console.WriteLine("-------------------------------Methods t3-----------------------------------------------");


Type t = typeof(List<string>);          //Taking Type from class name

//Type t2 = a.GetTypes().First();       //Taking type from assembly

List<int> list = new List<int>();       //Taking type form Variable 
Type t3 = list.GetType();

MethodInfo[] x =  t3.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);     // Filtering members/methods t3.GetMethods/t3.GetMembers
foreach (var x2 in x)
{
    Console.Write(x2.Name);                    // Getting Method Name
    Console.Write(" (");
    ParameterInfo[] parameters = x2.GetParameters();
    foreach (var p in parameters)
    {
        
        Console.Write(p.ParameterType.Name + "--" + p.Name);                 // Getting Parameter Type and Name
        Console.Write(",");
    }
    Console.WriteLine(")");
}
Console.WriteLine("------------------------------------------------------------------------------");

Fruits f = Fruits.Banana | Fruits.Mango | Fruits.Apple;
Console.WriteLine((int)f);
Console.WriteLine("------------------------------------------------------------------------------");

 

var gen = t3.GetGenericArguments();               // Gets the generec parameter type that was used in that class, here List<int>
foreach (var x3 in gen)
{
    Console.WriteLine(x3.Name);
}

foreach (var intr in t3.GetInterfaces())         // Gets the list of interfaces used there(ICollection`1 means there is 1 generic parameter)
{
    Console.WriteLine(intr.Name);
    foreach (var arguments in intr.GetGenericArguments())
    {
        Console.WriteLine(arguments.Name);
       
    }
}
Console.WriteLine("----------------Instance Creating--------------------------------------------------------------");


//We will get the base class of Camera, t2 has array of types, so we are looking for the camera type
foreach (var product in t2)
{
    if (product.Name == "Camera")
    {
        Console.WriteLine(product.BaseType.Name);

        double price = 2000;
        double discount = 15;

        foreach (var item in product.GetMethods())
        {
            Console.WriteLine(item.Name);
        }

        ConstructorInfo constructor = product.GetConstructor(new Type[] { });
        object camera = constructor.Invoke(new Type[] { });
        MethodInfo method = product.GetMethod("GetDiscount", new Type[] { typeof(double), typeof(double) });
        object result = method.Invoke(camera, new object[] { price, discount });
        Console.WriteLine(result);
        object rtrn = method.ReturnType;
        Console.WriteLine(rtrn);
    }
}
Console.WriteLine("------------------------+++------------------------------------------------------");
//foreach (var t2 in t.Name)
//{
//    Console.WriteLine($"{t.Name}");
//}
//Type[] tk = a.GetTypes();

foreach (var storage in t2)
{
    if (storage.Name == "Camera")
    {
        Console.WriteLine(storage.BaseType.Name);
    
    //foreach (var item in storage.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
    //{
    //    Console.WriteLine(item.Name);
    //}

    int first = 30; int second = 80;

    //ConstructorInfo constructor = storage.GetConstructor(new Type[] { });
    //object camera = constructor.Invoke(new Type[] { });
    //MethodInfo methodInfo = storage.GetMethod("additionFunc", new Type[] { typeof(int), typeof(int) });
    //object result = methodInfo.Invoke(camera, new object[] { first, second});
    //Console.WriteLine(result);



    ConstructorInfo constructor2 = storage.GetConstructor(new Type[] { });
    object camera2 = constructor2.Invoke(new Type[] { });
    MethodInfo method2 = storage.GetMethod("additionFunc", new Type[] { typeof(int), typeof(int) });
    if (method2 != null)
    {
        object result = method2.Invoke(camera2, new object[] { first, second });
        Console.WriteLine(result);
            object rtrn = method2.ReturnType;
            Console.WriteLine(rtrn);

    }
    else
    {
        Console.WriteLine("Method Not Found");
    }

    }
}