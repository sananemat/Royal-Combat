using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody), typeof (BoxCollider))]
public class PlayerMovement : MonoBehaviour
{
    private PlayerAnimation player_Animation;

    [SerializeField]
    private FixedJoystick joystick;

    [SerializeField]
    private Rigidbody myBody;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    public float walk_Speed = 3f;

    public float z_Speed = 1.5f;

    public float rotation_Y = -90f;

    public float rotation_Speed = 15f;
    

    // Start is called before the first frame update
    void Awake()
    {
        myBody = GetComponent<Rigidbody>();
        player_Animation = GetComponentInChildren<PlayerAnimation>();

    }

    // Update is called once per frame
    void Update()
    {
        AnimatePlayerWalk();
    }

    void FixedUpdate()
    {
        myBody.velocity =
            new Vector3(joystick.Horizontal * -walk_Speed,
                myBody.velocity.y,
                joystick.Vertical * -walk_Speed);
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(myBody.velocity);
        }
    }

    //void DetectMovement()
    //{
    //    //myBody.velocity = new Vector3(
    //    //    Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) * (-walk_Speed),
    //    //    myBody.velocity.y,
    //    //      Input.GetAxisRaw(Axis.VERTICAL_AXIS) * (-z_Speed)
    //    //    );
    //}
    void AnimatePlayerWalk()
    {
        if (joystick.Horizontal != 0 || joystick.Horizontal != 0)
        {
            player_Animation.Walk(true);
        }
        else
        {
            player_Animation.Walk(false);
        }
    } //Function closing bracket
} // CLass closing bracket
