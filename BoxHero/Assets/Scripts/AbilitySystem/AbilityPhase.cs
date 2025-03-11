using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Phase", menuName = "Ability System/Ability Phase")]
public class AbilityPhase : ScriptableObject
{
    public Stat Duration;
    public List<PhaseConsequence> PhaseConsequences = new List<PhaseConsequence>();





    // Convert _phaseConsequences list to dictionary with triggerTime as key
    public Dictionary<float, List<Consequence>> ConsequencesDict()
    {
        var dict = new Dictionary<float, List<Consequence>>();

        foreach (var phaseConsequence in PhaseConsequences)
        {
            dict[phaseConsequence.normalizedTime] = phaseConsequence.consequences;
        }

        return dict;
    }

    public IEnumerator Execute(GameObject user)
    {
        float timer = 0f;
        List<float> triggeredKeys = new List<float>();

        while (timer < Duration.Value)
        {
            timer += Time.deltaTime;
            float normalizedTime = timer / Duration.Value;
            
            foreach (var key in ConsequencesDict().Keys)
            {
                if (normalizedTime >= key && !triggeredKeys.Contains(key))
                {
                    triggeredKeys.Add(key);

                    foreach (var consequence in ConsequencesDict()[key])
                    {
                        consequence.Apply(user);
                    }
                }
            }

            yield return null;
        }
    }
}



[System.Serializable]
public class PhaseConsequence
{
    public float normalizedTime;
    public List<Consequence> consequences = new List<Consequence>();
}