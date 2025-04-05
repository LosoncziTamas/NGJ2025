using UnityEditor.Search;
using UnityEngine;

public class First_Person_Movement : MonoBehaviour
{
    private Vector3 Velocity;
    private Vector3 PlayerMovementInput;
    private Vector2 PlayerMouseInput;
    private bool Sneaking = false;
    private float xRotation;

    [Header("Components Needed")]
    [SerializeField] private Transform PlayerCamera;
    [SerializeField] private CharacterController Controller;
    [SerializeField] private Transform Player;
    [Space]
    [Header("Movement")]
    [SerializeField] private float Speed;
    [SerializeField] private float JumpForce;
    [SerializeField] private float Sensetivity;
    [SerializeField] private float Gravity = 9.81f;
    [Space]
    [Header("Sneaking")]
    [SerializeField] private bool Sneak = false;
    [SerializeField] private float SneakSpeed;


    //how fast the character leans
    public float leanSpeed;

    //maximum lean angle   
    private float AngleMax = 20f;
    private float AngleMin = -20f;

    public Transform localTrans;

    //minimum lean angle
    public float minAngle;

    //how fast the character goes
    public float characterSpeed;


    void Start()
    {
        localTrans = gameObject.GetComponent<Transform>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        { 
            if (Input.GetKey(KeyCode.A))
            {

                //Debug.Log(gameObject.transform.rotation.z);
                //transform character roation 
                gameObject.transform.Rotate(0, 0, leanSpeed);

            }

            if (Input.GetKey(KeyCode.D))
            {
                gameObject.transform.Rotate(0, 0, -leanSpeed);
            }
            if (Input.GetKey(KeyCode.W))
            {
                gameObject.transform.Rotate(leanSpeed, 0, 0);
            }

            if (Input.GetKey(KeyCode.S))
            {
                gameObject.transform.Rotate(-leanSpeed, 0, 0);
            }
        }
        LimitRot();
        //  PlayerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        PlayerMouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        MovePlayer();
        MoveCamera();
    }
    private void LimitRot()
    {
        Vector3 playerEulerAngles = localTrans.rotation.eulerAngles;

        playerEulerAngles.z = (playerEulerAngles.z > 180 ? playerEulerAngles.z - 360 : playerEulerAngles.z);
        playerEulerAngles.z = Mathf.Clamp(playerEulerAngles.z, AngleMin, AngleMax);

        localTrans.localRotation = Quaternion.Euler(playerEulerAngles);
    }

    private void MovePlayer()
    {
        Vector3 MoveVector = transform.TransformDirection(PlayerMovementInput);


        if (Controller.isGrounded)
        {
            Velocity.y = -1f;

            if (Input.GetKeyDown(KeyCode.Space) && Sneaking == false)
            {
                Velocity.y = JumpForce;
            }
        }
        else
        {
            Velocity.y += Gravity * -2f * Time.deltaTime;
        }
        if (Sneaking)
        {
            Controller.Move(MoveVector * SneakSpeed * Time.deltaTime);
        }
        else
        {
            Controller.Move(MoveVector * Speed * Time.deltaTime);
        }
        Controller.Move(Velocity * Time.deltaTime);

    }
    private void MoveCamera()
    {
        xRotation -= PlayerMouseInput.y * Sensetivity;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.Rotate(0f, PlayerMouseInput.x * Sensetivity, 0f);
        PlayerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}