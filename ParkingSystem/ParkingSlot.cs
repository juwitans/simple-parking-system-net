namespace ParkingSystem;

public class ParkingSlot
{
    public int Slot { get; set; }
    public bool Occupied { get; set; } = false;
    public string Type { get; set; }
    public string Colour { get; set; }
    public string RegistrationNumber { get; set; }
    public DateTime CheckInTime { get; set; }
}