using DesignPattern.AbstractFactory;
using DesignPattern.Builder;
using DesignPattern.Prototype;
using DesignPattern.Singleton;


// Here we get different Instances
//Logger logger1 = new Logger();
//Logger logger2 = new Logger();


// But in here using Singleton we get the same instances
//Logger logger1 = Logger.Instance;
//Logger logger2 = Logger.Instance;

//if (logger1 == logger2)
//    Console.WriteLine("Same value");


// Connection String builder for Builder Pattern
//ConnectionStringBuilder connectionStringBuilder = new ConnectionStringBuilder("LOCALhost");
//connectionStringBuilder.AddUsernamePassword("Nafi", "123");
//connectionStringBuilder.AddTrustedCertificate("True");

//ConnectionString connectionString = connectionStringBuilder.GetConnectionString();

//Console.WriteLine(connectionString.ConnectionStrinItem.ToString());


// Prototype Pattern | or We can use copy constructor
Product product = new Product()
{
    Name = "as",
    Price = 12,
    Color = "ER",
    Description = "FR"
};

Product copiedp = product.Copy();

Console.WriteLine(copiedp.Description);



FighterJetFactory  factory = new MigFactory();
FighterJet jet1 = factory.GetJet();
Weapon weapon1 = factory.GetWeapon();


FighterJetFactory factory2 = new F16Factory();
FighterJet jet2 = factory2.GetJet();
Weapon weapon2  = factory2.GetWeapon();
