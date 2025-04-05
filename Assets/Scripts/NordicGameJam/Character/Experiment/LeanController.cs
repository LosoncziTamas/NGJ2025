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
    [SerializeField] private float Sensetivity;


    //how fast the character leans
    public float leanSpeed;

    //min max lean angle 
    private float AngleMax = 30f;
    private float AngleMin = -30f;

    public Transform localTrans;

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

        playerEulerAngles.x = (playerEulerAngles.x > 180 ? playerEulerAngles.x - 360 : playerEulerAngles.x);
        playerEulerAngles.x = Mathf.Clamp(playerEulerAngles.x, AngleMin, AngleMax);

        localTrans.localRotation = Quaternion.Euler(playerEulerAngles);
    }

    private void MovePlayer()
    {
        gameObject.transform.position += transform.forward * transform.localRotation.x / 20;
        //gameObject.transform.position += Vector2(transform.localRotation,);

        //gameObject.transform.localPosition += new Vector3(transform.localRotation.z /20, 0, transform.localRotation.x /20);
    }

    private void MoveCamera()
    {
        xRotation -= PlayerMouseInput.y * Sensetivity;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.Rotate(0f, PlayerMouseInput.x * Sensetivity, 0f, Space.World);

        PlayerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0,0);
    }
}