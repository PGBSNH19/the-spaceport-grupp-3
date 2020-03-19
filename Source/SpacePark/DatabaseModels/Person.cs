namespace SpacePark
{
    public class Person : IPerson
    {
        public int PersonID { get; set; }
        public string Name { get; set; }
        public SpaceShip SpaceShip { get; set; }
    }
}
