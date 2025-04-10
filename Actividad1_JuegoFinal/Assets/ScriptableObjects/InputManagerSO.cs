using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "InputManager")]
public class InputManagerSO : ScriptableObject
{
    InputSystem_Actions controles;
    private void OnEnable()
    {
        controles = new InputSystem_Actions();
        controles.Player.Enable();
        controles.Player.Jump.started += Saltar;
        Debug.Log("Estoy Listo");
    }

    private void Saltar(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        
    }
}
