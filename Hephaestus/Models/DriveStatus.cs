namespace Hephaestus.Models
{
    public class DriveStatus
    {
        public DriveStatus(string name, string available)
        {
            this.Name = name;
            this.Available = available;
        }

        public string Name { get; }
        public string Available { get; }
    }
}
