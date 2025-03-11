using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Behaviour", menuName = "Ability System/Ability Behaviour")]
public class AbilityBehaviour : ScriptableObject
{
    public List<AbilityPhase> Phases;





    public void Trigger(GameObject user)
    {
        user.GetComponent<MonoBehaviour>().StartCoroutine(RunPhases(user));
    }

    private IEnumerator RunPhases(GameObject user)
    {
        foreach (var phase in Phases)
        {
            yield return phase.Execute(user);
        }
    }
}
