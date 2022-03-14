public class WarriorStats : IWarriorStats
{
    public WarriorStats(float Health, float Speed, float Radius, float Attack)
    {
        this.Health = Health;
        this.Speed = Speed;
        this.Radius = Radius;
        this.Attack = Attack;
    }

    public float Health { get; private set; }

    public float Speed { get; private set; }

    public float Radius { get; private set; }

    public float Attack { get; private set; }

    public void GetDamage(float damage)
    {
        Health -= damage;
    }
}
