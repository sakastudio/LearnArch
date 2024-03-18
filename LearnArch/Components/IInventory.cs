namespace LearnArch.Components;

public interface IInventory
{
    public Item[] InputSlot { get; }
    public Item[] OutputSlot { get; }
}

public class MachineInventory : IInventory
{
    public Item[] InputSlot { get; } = new Item[2];
    public Item[] OutputSlot { get; } = new Item[2];
}

public class BeltConveyorInventory : IInventory
{
    public Item[] InputSlot => _items;
    public Item[] OutputSlot => _items;
    
    private readonly Item[] _items = new Item[1];
}