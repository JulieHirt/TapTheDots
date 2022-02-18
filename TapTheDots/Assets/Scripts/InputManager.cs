
using UnityEngine;
using UnityEngine.InputSystem; //tell it to use new input system

public class InputManager : MonoBehaviour
{
    private TouchControls touchcontrols;

    private void Awake()
    {
        touchcontrols = new TouchControls();
    }

    private void OnEnable()
    {
        touchcontrols.Enable();
    }

    private void OnDisable()
    {
        touchcontrols.Disable();
    }

    private void Start()
    {
        //subscribe to event when we press 
        touchcontrols.Touch.TouchPress.started += ctx => StartTouch(ctx); //ctx is context
        //touchcontrols.Actionmap.Action    .started or .cancelled
        touchcontrols.Touch.TouchPress.canceled += ctx => EndTouch(ctx); //ctx is context
    }

    private void StartTouch(InputAction.CallbackContext context) {
        Debug.Log("touch started" + touchcontrols.Touch.TouchPosition.ReadValue<Vector2>());
        }

    private void EndTouch(InputAction.CallbackContext context)
    {
        Debug.Log("touch ended");
    }

}
