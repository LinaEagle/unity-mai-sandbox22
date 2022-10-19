using UnityEngine;

namespace Project
{
    public class Player : MonoBehaviour
    {
        private float health = 100;
        private Fuel _fuel;

        private void Awake()
        {
            _fuel = new Fuel(100);
            Debug.Log(_fuel.curAmount);

            var healthToDecrease = 2f;

            DecreaseHealth(healthToDecrease, 3, 35, 10);
        }

        public void DecreaseHealth(float modifier, params int[] values)
        {
            health = health - values[0];
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<Bonus>())
            {

            }
        }
    }
}
