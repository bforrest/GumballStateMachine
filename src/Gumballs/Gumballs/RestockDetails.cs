namespace Gumballs
{
    public class RestockDetails
    {
        public RestockDetails(int howMany)
        {
            Quantity = howMany;
        }

        public int Quantity { get; private set; }
    }
}