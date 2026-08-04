namespace Game
{
    public class DestroyTouchDamage : TouchDamage
    {
        public override void Damage(HealthComponent target)
        {
            base.Damage(target);
            
            Destroy(gameObject);
        }
    }
}