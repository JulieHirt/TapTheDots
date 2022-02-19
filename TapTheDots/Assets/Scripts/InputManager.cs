
using UnityEngine;
using UnityEngine.InputSystem; //tell it to use new input system

public class InputManager : MonoBehaviour
{
    public Scorekeeper scorekeeper;
    //for raycasting
    private Camera mainCamera;



   //uses raycasting
    private void DetectObject()
    {
        //shoots a ray from the camera to the position specified
        Ray ray = mainCamera.ScreenPointToRay(touchcontrols.Touch.TouchPosition.ReadValue<Vector2>());
        RaycastHit2D hits2D = Physics2D.GetRayIntersection(ray);
            if(hits2D.collider != null)
            {
                if (hits2D.collider.gameObject.tag == "greencircle")
                {
                Debug.Log("green");
                scorekeeper.IncreaseScore();
                }
                else if (hits2D.collider.gameObject.tag == "redcircle")
                {
                    scorekeeper.DecreaseScore();
                    Debug.Log("red");
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
