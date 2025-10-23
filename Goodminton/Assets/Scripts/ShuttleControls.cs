using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShuttleControls : MonoBehaviour
{
    TouchAction touchAction;

    Vector2 initTouchPos;
    Vector2 currTouchPos;

    private void OnEnable()
    {
        touchAction = new TouchAction();
        touchAction.Enable();

        touchAction.General.TouchPosition.started += Touch_started;
        touchAction.General.TouchPosition.performed += Touch_performed;
    }

    private void Touch_started(InputAction.CallbackContext ctx)
    {
        initTouchPos = ctx.ReadValue<Vector2>();
        Debug.Log($"Initial touch: {initTouchPos}");
    }

    private void Touch_performed(InputAction.CallbackContext ctx)
    {
        currTouchPos = ctx.ReadValue<Vector2>();
        Debug.Log($"Current touch: {currTouchPos}");

    }


    private void OnDisable()
    {
        touchAction.General.TouchPosition.started -= Touch_started;
        touchAction.General.TouchPosition.performed -= Touch_performed;

        touchAction.Disable();
    }
}
