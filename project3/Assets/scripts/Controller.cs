using UnityEngine;

public class Controller : MonoBehaviour
{
    private IControllable controllable;
    private Gameinput inputActions;
    internal int result;

    private void Awake()
    {
        inputActions = new Gameinput();
        inputActions.Enable();

        controllable = GetComponent<IControllable>();
    }

    private void OnEnable()
    {
        inputActions.gameplay.movement.performed += Movement_performed;
    }

    private void OnDisable()
    {
        inputActions.gameplay.movement.performed -= Movement_performed;
    }

    private void Movement_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (controllable != null)
        {
            controllable.Jump();
        }
    }
}