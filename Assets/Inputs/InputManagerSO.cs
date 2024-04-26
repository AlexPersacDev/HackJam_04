using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "InputManagerSO")]
public class InputManagerSO : ScriptableObject
{
    private Inputs inputs;

    private event Action<Vector2> OnMovePerformed;
    private event Action OnMoveCanceled;
    private void OnEnable()
    {
        inputs = new Inputs();
        inputs.Gameplay.Enable();

        inputs.Gameplay.Move.performed += Move_performed;

        inputs.Gameplay.Move.canceled += Move_canceled;
    }

    private void Move_performed(InputAction.CallbackContext obj)
    {
        OnMovePerformed?.Invoke(obj.ReadValue<Vector2>());
    }
    private void Move_canceled(InputAction.CallbackContext obj)
    {
        OnMoveCanceled?.Invoke();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
