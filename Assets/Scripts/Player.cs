using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public BaseAbility[] abilities;

    private InputSystem_Actions inputs;
    private BaseAbility current;

    void Awake()
    {
        inputs = new InputSystem_Actions();
        current = abilities[0];
    }

    void OnEnable()
    {
        inputs.Abilities.Ability1.performed += SelectAbility1;
        inputs.Abilities.Ability2.performed += SelectAbility2;
        inputs.Abilities.Ability3.performed += SelectAbility3;
        inputs.Abilities.Ability4.performed += SelectAbility4;
        inputs.Abilities.Ability5.performed += SelectAbility5;
        inputs.Abilities.Cast.performed += OnCast;
        inputs.Enable();
    }

    void OnDisable()
    {
        inputs.Abilities.Ability1.performed -= SelectAbility1;
        inputs.Abilities.Ability2.performed -= SelectAbility2;
        inputs.Abilities.Ability3.performed -= SelectAbility3;
        inputs.Abilities.Ability4.performed -= SelectAbility4;
        inputs.Abilities.Ability5.performed -= SelectAbility5;
        inputs.Abilities.Cast.performed -= OnCast;
        inputs.Disable();
    }

    void SelectAbility1(InputAction.CallbackContext context) => Select(0);
    void SelectAbility2(InputAction.CallbackContext context) => Select(1);
    void SelectAbility3(InputAction.CallbackContext context) => Select(2);
    void SelectAbility4(InputAction.CallbackContext context) => Select(3);
    void SelectAbility5(InputAction.CallbackContext context) => Select(4);

    void Select(int index)
    {
        current = abilities[index];
        Debug.Log("Habilidad: " + current.GetType().Name);
    }

    void OnCast(InputAction.CallbackContext context)
    {
        current.Execute();
    }
}
