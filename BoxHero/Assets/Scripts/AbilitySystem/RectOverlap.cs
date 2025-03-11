using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "ConsequenceRectOverlap", menuName = "Ability System/Consequence/RectOverlap")]
public class RectOverlap : Consequence
{
    public Stat Width;
    public Stat Depth;
    public Stat Height;
    public List<Consequence> Consequences;





    public override void Apply(GameObject user)
    {

        Vector3 center = user.transform.position;
        float width = Width.Value;
        float height = Height.Value;
        float depth = Depth.Value;

        Collider[] hitColliders = Physics.OverlapBox(center, new Vector3(Width.Value, Height.Value, Depth.Value));

        List<GameObject> enemiesHit = new List<GameObject>();

        // Draw debug gizmo
        AbilityGizmoDrawer gizmoDrawer = user.GetComponent<AbilityGizmoDrawer>();
        if (gizmoDrawer != null)
        {
            gizmoDrawer.ShowBox(center, width, height, depth, Color.green, 1f);
        }

        // Apply consequences to enemies hit
        foreach (var collider in hitColliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                GameObject enemyHit = collider.gameObject;

                if (!enemiesHit.Contains(enemyHit))
                {
                    enemiesHit.Add(enemyHit);

                    foreach (var consequence in Consequences)
                    {
                        consequence.Apply(collider.gameObject);
                    }
                }
            }
        }
    }
}