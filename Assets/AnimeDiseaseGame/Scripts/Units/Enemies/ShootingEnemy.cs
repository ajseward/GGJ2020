namespace AnimeDiseaseGame
{
    public class ShootingEnemy : Enemy
    {
        public Weapon EquippedWeapon;

        public override void Attack()
        {
            EquippedWeapon.Fire();
        }
    }
}