namespace ParkingSystem;

public class Service
{
    public ParkingSlot[] CreateParkingSlots(int size)
    {
        var parkingSlots = new ParkingSlot[size];
        for (var i = 0; i < parkingSlots.Length; i++)
        {
            parkingSlots[i] = new ParkingSlot { Slot = i + 1 };
        }
        Console.WriteLine("created a parking lot with " + size + " slots");
        return parkingSlots;
    }

    public ParkingSlot[] Park(ParkingSlot[] slots, string type, string registNo, string color)
    {
        var index = 0;
        while (slots[index].Occupied)
        {
            index++;
            if (index >= slots.Length)
            {
                Console.WriteLine("Sorry, parking lot is full");
                return slots;
            }
        }

        slots[index].Occupied = true;
        slots[index].Type = type;
        slots[index].RegistrationNumber = registNo;
        slots[index].Colour = color;
        slots[index].CheckInTime = DateTime.Now;
        
        Console.WriteLine("Allocated slot number: " + slots[index].Slot);
        Console.WriteLine("Check-in time: " + slots[index].CheckInTime);

        return slots;
    }

    public ParkingSlot[] Leave(ParkingSlot[] slots, int slotNumber)
    {
        var duration = DateTime.Now - slots[slotNumber - 1].CheckInTime;
        Console.WriteLine("Parking duration: " + duration);
        slots[slotNumber - 1] = new ParkingSlot { Slot = slotNumber };
        Console.WriteLine("Slot number " + slotNumber + " is free");
        return slots;
    }
    
    public void PrintParkingSlots(ParkingSlot[] slots)
    {
        // Table header
        Console.WriteLine("{0,-10} {1,-20} {2,-15} {3,-15}", "Slot", "Color", "Vehicle Type", "Registration No");
        Console.WriteLine(new string('-', 70)); // Separator line

        // Print each slot details
        foreach (var slot in slots)
        {
            if(!slot.Occupied) continue;
            Console.WriteLine("{0,-10} {1,-20} {2,-15} {3,-15}",
                slot.Slot, slot.Colour, slot.Type, slot.RegistrationNumber);
        }
    }

    public int countBasedOnType(ParkingSlot[] slots, string type)
    {
        var temp = slots.Where(slot => slot.Occupied).Count(slot => slot.Type.Equals(type, StringComparison.OrdinalIgnoreCase));
        return temp;
    }

    public void RegistrationNumberType(ParkingSlot[] slots, string type)
    {
        foreach (var slot in slots)
        {
            if (!slot.Occupied) continue;
            var strings = slot.RegistrationNumber.Split('-');
            var number = int.Parse(strings[1]);
            if ((type == "odd" && number % 2 == 1) || (type == "even" && number % 2 == 0))
            {
                Console.Write(slot.RegistrationNumber + " ");
            }
        }
        Console.WriteLine("");
    }

    public void RegistrationNumberBasedOnColor(ParkingSlot[] slots, string color)
    {
        foreach (var slot in slots)
        {
            if (slot.Colour == color)
            {
                Console.Write(slot.RegistrationNumber + " ");
            }
        }
    }
    
    public void SlotNumberBasedOnColor(ParkingSlot[] slots, string color)
    {
        foreach (var slot in slots)
        {
            if (slot.Colour == color)
            {
                Console.Write(slot.Slot + " ");
            }
        }
    }

    public void SlotNumberBasedOnRegistNo(ParkingSlot[] slots, string registNo)
    {
        var found = false;
        foreach (var slot in slots)
        {
            if (slot.RegistrationNumber != registNo) continue;
            Console.WriteLine(slot.Slot);
            found = true;
        }

        if (!found)
        {
            Console.WriteLine("Not Found");
        }
    }

}