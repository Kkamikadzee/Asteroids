namespace KMK.Model.Other
{
    public class Health
    {
        private int _currentHealth;

        public int CurrentHealth => _currentHealth;

        public Health(int currentHealth)
        {
            _currentHealth = currentHealth;
        }

        public void AddHealth(int value = 1)
        {
            _currentHealth += value;
        }

        public void SubHealth(int value = 1)
        {
            _currentHealth -= value;
        }
    }
}