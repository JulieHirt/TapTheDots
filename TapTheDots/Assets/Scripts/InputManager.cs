
using UnityEngine;
using UnityEngine.InputSystem; //tell it to use new input system

public class InputManager : MonoBehaviour
{
    //for raycasting
    private Camera mainCamera;



   //uses raycasting
    private void DetectObject()
    {
        //ScreenPointToRay shoots a ray from the camera to the position specified
        Ray ray = mainCamera.ScreenPointToRay(touchcontrols.Touch.TouchPosition.ReadValue<Vector2>());
        //this will only return the first thing it hits. You can also detect multiple things with RaycastAll
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            if(hit.collider != null)
            {
                Debug.Log("hit" + hit.collider.tag);
            }
        }
 
    }
    private TouchControls touchcontrols; //TouchControls is the name of the auto-generated C# file

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
        mainCamera = Camera.main;//for raycasting
        //subscribe to event when we press 
        touchcontrols.Touch.TouchPress.started += ctx => StartTouch(ctx); //ctx is context
        //touchcontrols.Actionmap.Action    .started or .cancelled
        touchcontrols.Touch.TouchPress.canceled += ctx => EndTouch(ctx); //ctx is context
    }

    private void StartTouch(InputAction.CallbackContext context) {
        Debug.Log("touch started" + touchcontrols.Touch.TouchPosition.ReadValue<Vector2>());

        DetectObject();//check if object was collided with
    }

    private void EndTouch(InputAction.CallbackContext context)
    {
        Debug.Log("touch ended");
    }

}
