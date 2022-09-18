// See https://aka.ms/new-console-template for more information
using Events;
using static Events.HeatSensor;

Console.WriteLine("Events");
Console.WriteLine();

/*
Console.WriteLine("Press any key to run the device...");

IDevice device = new Device();

device.RunDevice();
*/

var order = new Order { Item = "Pizza with extra cheese"};

// Instantiate services
//
var orderingService = new FoodOrderingService();
var appService = new AppService();
var notificationService = new NotificationService();

// Subscribes to the event
//
orderingService.FoodPepared += appService.OnFoodPrepared;
orderingService.FoodPepared += notificationService.OnFoodPrepared;

// Start the process
orderingService.PrpareOrder(order);

Console.ReadKey();
