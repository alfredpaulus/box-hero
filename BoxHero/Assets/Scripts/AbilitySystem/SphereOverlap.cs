using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ConsequenceSphereOverlap", menuName = "Ability System/Consequence/SphereOverlap")]
public class SphereOverlap : Consequence
{
    public Stat Radius;
    public List<Consequence> Consequences;





    public override void Apply(GameObject user)
    {
        Vector3 center = user.transform.position;
        float radius = Radius.Value;

        Collider[] hitColliders = Physics.OverlapSphere(user.transform.position, Radius.Value);

        // Draw debug gizmo
        AbilityGizmoDrawer gizmoDrawer = user.GetComponent<AbilityGizmoDrawer>();
        if (gizmoDrawer != null)
        {
            gizmoDrawer.ShowSphere(center, radius, Color.red, 1f);
        }

        // Apply consequences to enemies hit
        foreach (var collider in hitColliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                foreach (var consequence in Consequences)
                {
                    consequence.Apply(collider.gameObject);
                }
            }
        }
    }
}