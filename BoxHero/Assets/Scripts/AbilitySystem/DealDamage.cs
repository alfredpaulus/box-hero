using UnityEngine;

[CreateAssetMenu(fileName = "ConsequenceDealDamage", menuName = "Ability System/Consequence/DealDamage")]
public class DealDamage : Consequence
{
    public Stat DamageAmount;




    // Apply consequence (damage) to enemies hit
    public override void Apply(GameObject target)
    {
        if (target.TryGetComponent(out EnemyHealth health))
        {
            health.TakeDamage(DamageAmount.Value);
        }
    }
}