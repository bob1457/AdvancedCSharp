// See https://aka.ms/new-console-template for more information
using Generics;
using WarehouseApi;

const int BatchSize = 5;

Console.WriteLine("Generics - Delegate and Events - Realtime Warehouse Management System");

CustomQueue<HardwareItem> hardwareItemQueue = new CustomQueue<HardwareItem>();

hardwareItemQueue.CustomQueueEvent += CustomQueue_CustomQueueEvent;

AddHardwareItems(hardwareItemQueue);

Console.ReadKey();

void CustomQueue_CustomQueueEvent(CustomQueue<HardwareItem> sender, QueueEventArgs eventArgs)
{
    Console.Clear();

    if (sender.QueueLength > 0)
    {
        WriteValuesInQueueToScreen(sender);
        if(sender.QueueLength  == BatchSize)
        {
            ProcessItems(sender);
        }
    }
    else
    {
        Console.WriteLine($"Status: All items have been processed");
    }
}

static void ProcessItems(CustomQueue<HardwareItem> customQueue)
{
    while(customQueue.QueueLength > 0)
    {
        Thread.Sleep(5000);
        HardwareItem hardwareItem = customQueue.GetItem();
    }
}

static void WriteValuesInQueueToScreen(CustomQueue<HardwareItem> hardwareItems)
{
    foreach (var item in hardwareItems)
    {
        Console.WriteLine($"{item.Id,-6}{item.Name,-15}{item.Type,-20}{item.Quantity,10}{item.UnitValue,10}");
    }
}

static void AddHardwareItems(CustomQueue<HardwareItem> hardwareItemQueue)
{
    Thread.Sleep(2000);

    //comes into stock - device scans a bar code or QR code
    hardwareItemQueue.AddItem(new Drill { Id = 1, Name = "Drill 1", Type = "Drill", UnitValue = 20.00m, Quantity = 10 });

    Thread.Sleep(1000);

    hardwareItemQueue.AddItem(new Drill { Id = 2, Name = "Drill 2", Type = "Drill", UnitValue = 30.00m, Quantity = 20 });

    Thread.Sleep(2000);

    hardwareItemQueue.AddItem(new Ladder { Id = 3, Name = "Ladder 1", Type = "Ladder", UnitValue = 100.00m, Quantity = 5 });

    Thread.Sleep(1000);

    hardwareItemQueue.AddItem(new Hammer { Id = 4, Name = "Hammer 1", Type = "Hammer", UnitValue = 10.00m, Quantity = 80 });
    Thread.Sleep(3000);

    hardwareItemQueue.AddItem(new Brush { Id = 5, Name = "Paint Brush 1", Type = "PaintBrush", UnitValue = 5.00m, Quantity = 100 });
    Thread.Sleep(3000);

    hardwareItemQueue.AddItem(new Brush { Id = 6, Name = "Paint Brush 2", Type = "PaintBrush", UnitValue = 5.00m, Quantity = 100 });
    Thread.Sleep(3000);

    hardwareItemQueue.AddItem(new Brush { Id = 7, Name = "Paint Brush 3", Type = "PaintBrush", UnitValue = 5.00m, Quantity = 100 });
    Thread.Sleep(3000);

    hardwareItemQueue.AddItem(new Hammer { Id = 8, Name = "Hammer 2", Type = "Hammer", UnitValue = 11.00m, Quantity = 80 });
    Thread.Sleep(3000);

    hardwareItemQueue.AddItem(new Hammer { Id = 9, Name = "Hammer 3", Type = "Hammer", UnitValue = 13.00m, Quantity = 80 });
    Thread.Sleep(3000);

    hardwareItemQueue.AddItem(new Hammer { Id = 10, Name = "Hammer 4", Type = "Hammer", UnitValue = 14.00m, Quantity = 80 });
    Thread.Sleep(3000);
}