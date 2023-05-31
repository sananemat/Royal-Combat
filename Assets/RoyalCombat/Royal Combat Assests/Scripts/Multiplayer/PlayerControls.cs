using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;

public class PlayerControls : MonoBehaviourPunCallbacks
    {
    private InputActionMap gameplayActionMap;
    private InputAction moveAction;

    public Vector2 MovementInput { get; private set; }

    private void Awake()
        {
        gameplayActionMap=new InputActionMap();
        moveAction=gameplayActionMap.AddAction("Move", binding: "<Gamepad>/leftStick");

        // Enable the action map
        gameplayActionMap.Enable();
        }

    private void OnEnable()
        {
        // Enable the action map
        gameplayActionMap.Enable();
        }

    private void OnDisable()
        {
        // Disable the action map
        gameplayActionMap.Disable();
        }

    private void Update()
        {
        // Update the movement input
        MovementInput=moveAction.ReadValue<Vector2>();
        }
    }
