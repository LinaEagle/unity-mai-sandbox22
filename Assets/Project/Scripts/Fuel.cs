namespace Project
{
    public class Fuel
    {
        // todo property
        public float curAmount;
        public float maxAmount;
        private float fullThresold = 1f;

        public Fuel(float maxFuelAmount)
        {
            maxAmount = maxFuelAmount;
            curAmount = maxFuelAmount;
        }

        public bool IsFull()
        {
            return (maxAmount - curAmount) < fullThresold;
        }
    }
}
