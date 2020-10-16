namespace Hephaestus.Models
{
    public class DriveStatus
    {
        public DriveStatus(string name,
                           string available,
                           string total,
                           double percentageFull)
        {
            this.Name = name;
            this.Available = available;
            this.Total = total;
            this.PercentageFull = percentageFull;
        }

        public double PercentageFull { get; }
        public string Name { get; }
        public string Available { get; }
        public string Total { get; }
    }
}
