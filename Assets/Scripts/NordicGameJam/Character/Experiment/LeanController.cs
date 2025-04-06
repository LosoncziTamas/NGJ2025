using System.Collections;
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

    private float forwardAmount;
    private float sideAmount;

    public Transform localTrans;

    //how fast the character goes
    public float playerSpeed;

    private float maxPlayerSpeed = 0.02f;
    private float maxSpeedGain = 0.0005f;

    private bool isDrunk = false;


    void Start()
    {
        isDrunk = true;

        localTrans = gameObject.GetComponent<Transform>();
        Cursor.lockState = CursorLockMode.Locked;
        //StartCoroutine(RandomiseMovement());
    }

    // Update is called once per frame
    void Update()
    {
        { 
            if (Input.GetKey(KeyCode.A))
            {
                //gameObject.transform.Rotate(0, 0, leanSpeed);

                if (sideAmount > -maxPlayerSpeed)
                {
                    sideAmount -= maxSpeedGain;
                    gameObject.transform.Rotate(0, 0, leanSpeed);
                }                   
            }
            if (Input.GetKey(KeyCode.D))
            {
                //gameObject.transform.Rotate(0, 0, -leanSpeed);

                if (sideAmount < maxPlayerSpeed)
                {
                    sideAmount += maxSpeedGain;
                    gameObject.transform.Rotate(0, 0, -leanSpeed);
                }
            }
            if (Input.GetKey(KeyCode.W))
            {
                //gameObject.transform.Rotate(leanSpeed, 0, 0);

                if (forwardAmount < maxPlayerSpeed)
                {
                    forwardAmount += maxSpeedGain;
                    gameObject.transform.Rotate(leanSpeed, 0, 0);
                }
            }
            if (Input.GetKey(KeyCode.S))
            {
                //gameObject.transform.Rotate(-leanSpeed, 0, 0);

                if (forwardAmount > -maxPlayerSpeed)
                {                  
                    forwardAmount -= maxSpeedGain;
                    gameObject.transform.Rotate(-leanSpeed, 0, 0);
                }
                    
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

        gameObject.GetComponent<Rigidbody>().velocity += new Vector3(transform.right.x * sideAmount, 0, transform.right.z * sideAmount);
        gameObject.GetComponent<Rigidbody>().velocity += new Vector3(transform.forward.x * forwardAmount, 0, transform.forward.z * forwardAmount);
      
    }

    IEnumerator RandomiseMovement()
    {
        //generate random x and z movement
        float zRandomTarget;
        float xRandomTarget;

        float timeSec;

        while(isDrunk == true)
        {
            timeSec = 1.5f;

            //select new z and x target speed
            zRandomTarget = Random.Range(-maxPlayerSpeed /2, maxPlayerSpeed /2);
            xRandomTarget = Random.Range(-maxPlayerSpeed / 2, maxPlayerSpeed / 2);

            Debug.Log(zRandomTarget);
            Debug.Log(xRandomTarget);

            if (sideAmount < maxPlayerSpeed && sideAmount > -maxPlayerSpeed)
            {
                sideAmount += (zRandomTarget - sideAmount) * timeSec - Time.deltaTime; 
            }

            if (forwardAmount < maxPlayerSpeed && forwardAmount > -maxPlayerSpeed)
            {
                forwardAmount += (xRandomTarget - sideAmount) * timeSec - Time.deltaTime;
            }
            
            yield return new WaitForSeconds(1.5f);
        }
    }

    private void MoveCamera()
    {
        xRotation -= PlayerMouseInput.y * Sensetivity;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.Rotate(0f, PlayerMouseInput.x * Sensetivity, 0f, Space.World);

        PlayerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0,0);
    }
}