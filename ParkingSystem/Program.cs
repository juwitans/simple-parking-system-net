namespace ParkingSystem;

class Program
{
    public static void Main(string[] args)
    {
        var commandPrompt = new Command();
        
        Console.WriteLine("Welcome to Mall A Parking System");
        Console.Write("Enter command (or 'help' for options): ");
        while (true)
        {
            var input = Console.ReadLine().Trim();
        
            if (string.IsNullOrEmpty(input))
            {
                continue;
            }
        
            var parts = input.Split(' ', 2);
            var command = parts[0].ToLower();
            var parameter = parts[1];

            //initializee
            var parkingSlots = commandPrompt.Create("10");
            if (CommandChecker(command) == -1)
            {
                Console.WriteLine("unknown command, see help for options");
            }
            else if (CommandChecker(command) == 0)
            {
                parkingSlots = commandPrompt.Create(parameter);
            }
            
            if (commandPrompt.Created)
            {
                if (CommandChecker(command) == 10)
                {
                    return;
                }
                commandPrompt.CommandProcessor(CommandChecker(command), parameter, parkingSlots);
            }
            else
            {
                Console.WriteLine("You should create parking slot first!");
            }
            
        }
    }

    private static int CommandChecker(string command)
    {
        var availableCommands = new[]
        {
            "create_parking_lot", "park", "leave", "status", "type_of_vehicles",
            "registration_number_for_vehicle_with_odd_plate",
            "registration_number_for_vehicle_with_even_plate",
            "registration_number_for_vehicle_with_colour",
            "slot_number_for_vehicles_with_colour",
            "slot_number_for_registration_number",
            "exit"
        };

       return Array.IndexOf(availableCommands, command);
    }
}