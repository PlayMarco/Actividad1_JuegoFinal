using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using System;

[CreateAssetMenu(menuName = "InputManager")]
public class InputManagerSO : ScriptableObject
{
    InputSystem_Actions controles;
    public event Action OnSalto;
    public event Action<Vector2> OnMover;
    private void OnEnable()
    {
        controles = new InputSystem_Actions();

        EnablePlayer();

        controles.Player.Jump.started += Saltar;
        controles.Player.Move.performed += Mover;
        controles.Player.Move.canceled += Mover;
    }

    private void Mover(InputAction.CallbackContext ctx)
    {
        OnMover?.Invoke(ctx.ReadValue<Vector2>());
    }

    private void Saltar(InputAction.CallbackContext ctx)
    {
        OnSalto?.Invoke();
    }

    public void EnablePlayer()
    {
        controles.UI.Disable();
        controles.Player.Enable();
    }

    public void EnableUI()
    {
        controles.Player.Disable();
        controles.UI.Enable();
    }
}
