using System.Collections.Generic;
using UnityEngine;

public class AbilityGizmoDrawer : MonoBehaviour
{
    private List<GizmoData> _activeGizmos = new List<GizmoData>();





    private void OnDrawGizmos()
    {
        foreach (var gizmo in _activeGizmos)
        {
            Gizmos.color = gizmo.color;

            if (gizmo.isSphere)
            {
                Gizmos.DrawWireSphere(gizmo.center, gizmo.radius);
            }
            else
            {
                Gizmos.matrix = Matrix4x4.TRS(gizmo.center, Quaternion.identity, Vector3.one);
                Gizmos.DrawWireCube(Vector3.zero, new Vector3(gizmo.width, gizmo.height, gizmo.depth));
            }
        }
    }

    public void ShowSphere(Vector3 center, float radius, Color color, float duration)
    {
        StartCoroutine(DisplayGizmo(new GizmoData(center, radius, color), duration));
    }

    public void ShowBox(Vector3 center, float width, float height, float depth, Color color, float duration)
    {
        StartCoroutine(DisplayGizmo(new GizmoData(center, width, height, depth, color), duration));
    }

    private System.Collections.IEnumerator DisplayGizmo(GizmoData gizmo, float duration)
    {
        _activeGizmos.Add(gizmo);
        yield return new WaitForSeconds(duration);
        _activeGizmos.Remove(gizmo);
    }

    private class GizmoData
    {
        public Vector3 center;
        public bool isSphere;
        public float radius;
        public float width, height, depth;
        public Color color;

        public GizmoData(Vector3 center, float radius, Color color)
        {
            this.center = center;
            this.radius = radius;
            this.color = color;
            isSphere = true;
        }

        public GizmoData(Vector3 center, float width, float height, float depth, Color color)
        {
            this.center = center;
            this.width = width;
            this.height = height;
            this.depth = depth;
            this.color = color;
            isSphere = false;
        }
    }
}