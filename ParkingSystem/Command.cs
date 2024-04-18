namespace ParkingSystem;

// var availableCommands = new[]
// {
//     "create_parking_lot", "park", "leave", "status", "type_of_vehicles",
//     "registration_number_for_vehicle_with_odd_plate",
//     "registration_number_for_vehicle_with_even_plate",
//     "registration_number_for_vehicle_with_colour",
//     "slot_number_for_vehicles_with_colour",
//     "slot_number_for_registration_number"
// };

public class Command
{
    private static Service _service = new Service();
    public bool Created = false;
    
    public ParkingSlot[] Create(string input)
    {
        int number;
        if (!int.TryParse(input, out number))
        {
            throw new Exception("Invalid input");
        }
        Created = true;
        return _service.CreateParkingSlots(number);
    }
    
    public void CommandProcessor(int command, string input, ParkingSlot[] slots)
    {
        switch (command)
        {
            case 1:
                var parameters = input.Split(' ');
                if (parameters.Length != 3)
                {
                    throw new Exception("Invalid input");
                }

                _service.Park(slots, parameters[0], parameters[1], parameters[2]);
                break;
            case 2:
                int number;
                if (!int.TryParse(input, out number))
                {
                    throw new Exception("Invalid input");
                }
                _service.Leave(slots, number);
                break;
            case 3:
                _service.PrintParkingSlots(slots);
                break;
            case 4:
                if (input.Length != 1)
                {
                    throw new Exception("Invalid input");
                }
                _service.countBasedOnType(slots, input);
                break;
            case 5:
                _service.RegistrationNumberType(slots, "odd");
                break;
            case 6:
                _service.RegistrationNumberType(slots, "even");
                break;
            case 7:
                if (input.Length != 1)
                {
                    throw new Exception("Invalid input");
                }
                _service.RegistrationNumberBasedOnColor(slots, input);
                break;
            case 8:
                if (input.Length != 1)
                {
                    throw new Exception("Invalid input");
                }
                _service.SlotNumberBasedOnColor(slots, input);
                break;
            case 9:
                if (input.Length != 1)
                {
                    throw new Exception("Invalid input");
                }
                _service.SlotNumberBasedOnRegistNo(slots, input);
                break;
            case 10:
                break;
            default:
                Console.WriteLine("Available Commands");
                Console.WriteLine("- create_parking_slots number");
                Console.WriteLine("- park vehicle_type regist_no color");
                Console.WriteLine("- leave slot_number");
                Console.WriteLine("- type_of_vehicles type");
                Console.WriteLine("- registration_number_for_vehicle_with_odd_plate");
                Console.WriteLine("- registration_number_for_vehicle_with_even_plate");
                Console.WriteLine("- registration_number_for_vehicle_with_colour colour");
                Console.WriteLine("- slot_number_for_vehicles_with_colour colour");
                Console.WriteLine("- slot_number_for_registration_number number");
                break;
        };
    }
}