using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShuttleControls : MonoBehaviour
{
    TouchAction touchAction;

    Vector2 initTouchPos;
    Vector2 currTouchPos;

    LineRenderer line;

    private void OnEnable()
    {
        touchAction = new TouchAction();
        touchAction.Enable();

        touchAction.General.TouchPosition.started += Touch_started;
        touchAction.General.TouchPosition.performed += Touch_performed;
        touchAction.General.TouchPosition.canceled += TouchPosition_canceled;

    }

    private void TouchPosition_canceled(InputAction.CallbackContext ctx)
    {
        line.enabled = false;

        initTouchPos = Vector2.zero;
        currTouchPos = Vector2.zero;
    }

    private void Touch_started(InputAction.CallbackContext ctx)
    {
        initTouchPos = ctx.ReadValue<Vector2>();
        Debug.Log($"Initial touch: {initTouchPos}");
    }

    private void Touch_performed(InputAction.CallbackContext ctx)
    {
        currTouchPos = ctx.ReadValue<Vector2>();
        //Debug.Log($"Current touch: {currTouchPos}");

        line.enabled = true;        
    }


    private void OnDisable()
    {
        touchAction.General.TouchPosition.started -= Touch_started;
        touchAction.General.TouchPosition.performed -= Touch_performed;

        touchAction.Disable();
    }


    private void Start()
    {
        line = GetComponentInChildren<LineRenderer>();
        line.enabled = false;
    }

    private void Update()
    {
        Vector3 a = new(initTouchPos.x, initTouchPos.y, 10);
        Vector3 b = new(currTouchPos.x, currTouchPos.y, 10);

        Vector3 pos0 = Camera.main.ScreenToWorldPoint(a);
        Vector3 pos1 = Camera.main.ScreenToWorldPoint(b);

        line.SetPosition(0, pos0);
        line.SetPosition(1, pos1);
    }
}
