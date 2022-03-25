using UnitTestingLegacyContext;
using UnitTestingLegacyContext.SomeNewFunctionality;

Console.WriteLine("Hello, World!");

var ctx = new DbContextSimulator();
Console.WriteLine(ctx.Users.FirstOrDefault().Name);

Console.WriteLine("Some new functionality:");
var service = new DataOperations();
Console.WriteLine($"Id = {service.GetUser(1).Id}; Name = {service.GetUser(1).Name}");
