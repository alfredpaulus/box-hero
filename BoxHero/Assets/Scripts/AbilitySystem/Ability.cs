using UnityEngine;

[CreateAssetMenu(fileName = "Ability", menuName = "Ability System/Ability")]
public class Ability : ScriptableObject
{
    public string Id;
    public AbilityBehaviour Behaviour;
    public float Cooldown;


    private float _lastUsedTime = 0;





    private void OnDisable()
    {
        Reset();
    }


    public void Activate(GameObject user)
    {
        bool canUse = Time.time >= _lastUsedTime + Cooldown;

        if (canUse)
        {
            _lastUsedTime = Time.time;
            Behaviour.Trigger(user);
        }
    }

    private void Reset()
    {
        _lastUsedTime = 0;
    }
}