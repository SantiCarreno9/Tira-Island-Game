
public class RangedEnemy : Enemy
{
    protected override void Update()
    {
        base.Update();

        if (isDead)
            return;

        if (IsInDetectionRange)
        {
            if (!hasAttacked)
            {
                Attack();
                hasAttacked = true;
            }
        }
        else StopAttacking();
    }
}
