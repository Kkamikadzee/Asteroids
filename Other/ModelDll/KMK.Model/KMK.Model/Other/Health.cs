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
        
        public void AddHealth()
        {
            _currentHealth++;
        }

        public void SubHealth()
        {
            _currentHealth--;
        }
    }
}