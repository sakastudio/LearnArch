using Arch.Core;
using Arch.Core.Extensions;
using LearnArch.Components;

namespace LearnArch;

class Program
{
    static void Main(string[] args)
    {
        var world = World.Create();
        World.Destroy(world);
        
        var machine1 = CreateMachine(world);
        var machine2 = CreateMachine(world);
        var beltConveyor1 = CreateBeltConveyor(world);
        var beltConveyor2 = CreateBeltConveyor(world);

        machine1.TryGet<InventoryConnector>(out var machine1Connector);
        machine1Connector.ConnectInventories.Add(world.Reference(beltConveyor1));
        
        beltConveyor1.TryGet<InventoryConnector>(out var beltConveyor1Connector);
        beltConveyor1Connector.ConnectInventories.Add(world.Reference(machine2));
        
        machine2.TryGet<InventoryConnector>(out var machine2Connector);
        machine2Connector.ConnectInventories.Add(world.Reference(beltConveyor2));
        
        beltConveyor2.TryGet<InventoryConnector>(out var beltConveyor2Connector);
        beltConveyor2Connector.ConnectInventories.Add(world.Reference(machine1));


        var inventoryQuery = new QueryDescription().WithAll<IInventory, InventoryConnector>();
        
        world.Query(in inventoryQuery, (ref IInventory inventory, ref InventoryConnector connector) =>
        {
            
        });
    }
    
    static Entity CreateMachine(World world)
    {
        var entity = world.Create(
            (IInventory)new MachineInventory(),
            new InventoryConnector(),
            new Machine()
            );
        return entity;
    }
    
    static Entity CreateBeltConveyor(World world)
    {
        var entity = world.Create(
            (IInventory)new BeltConveyorInventory(),
            new InventoryConnector(),
            new BeltConveyor()
            );
        return entity;
    }
}