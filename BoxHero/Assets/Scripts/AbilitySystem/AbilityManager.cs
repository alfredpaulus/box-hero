using UnityEngine;
using UnityEngine.InputSystem;

public class AbilityManager : MonoBehaviour
{
    [SerializeField] private Ability[] _abilities;



    

    public void OnAbility1(InputAction.CallbackContext context)
    {
        if (context.performed)
            Ability1();
    }

    public void OnAbility2(InputAction.CallbackContext context)
    {
        if (context.performed)
            Ability2();
    }

    public void OnAbility3(InputAction.CallbackContext context)
    {
        if (context.performed)
            Ability3();
    }


    private void Ability1()
    {
        _abilities[0].Activate(gameObject);
        Debug.Log("Ability1 performed");
    }

    private void Ability2()
    {
        _abilities[1].Activate(gameObject);
        Debug.Log("Ability2 performed");
    }

    private void Ability3()
    {
        _abilities[2].Activate(gameObject);
        Debug.Log("Ability3 performed");
    }
}