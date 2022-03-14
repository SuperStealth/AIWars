namespace AIWars
{
    public interface IWarriorStats
    {

        public float Health { get; }
        public float Speed { get; }
        public float Radius { get; }
        public float Attack { get; }

        public void GetDamage(float damage);
    }
}