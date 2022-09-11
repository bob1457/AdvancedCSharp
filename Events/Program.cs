// See https://aka.ms/new-console-template for more information
using static Events.HeatSensor;

Console.WriteLine("Events");
Console.WriteLine();

Console.WriteLine("Press any key to run the device...");

IDevice device = new Device();

device.RunDevice();


 Console.ReadKey();
