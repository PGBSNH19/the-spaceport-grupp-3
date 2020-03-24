using System.ComponentModel.DataAnnotations.Schema;

namespace SpacePark
{
    public class SpaceShip
    {
        public int SpaceShipID { get; set; }

        public string Name { get; set; }

        public int ShipLength { get; set; }

        [NotMapped]
        public string Length { get; set; }
    }
}
