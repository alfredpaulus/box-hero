using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float _health = 100f;




    public void TakeDamage(float damage)
    {
        _health -= damage;

        if (_health <= 0)
            Destroy(gameObject);

        Debug.Log($"{gameObject.name} received {damage} damage. Current enemy health: {_health}");
    }
}