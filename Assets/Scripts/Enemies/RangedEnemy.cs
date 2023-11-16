
public class RangedEnemy : Enemy
{
    protected override void Update()
    {
        base.Update();

        if (isDead)
            return;

        if (hitTaken)
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
