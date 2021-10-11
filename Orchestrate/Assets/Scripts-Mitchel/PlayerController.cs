//
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//
//public class PlayerController : MonoBehaviour
//{
//
//    [Tooltip("This is the CharacterController component attached to the player character. You can just drag the character onto this.")]
//    public CharacterController controller;
//    [Tooltip("This is the speed of the player character, or how fast the character can walk.")]
//    public float speed;
//
//    [Tooltip("This is the camera that will be used for the third person view.")]
//    public Camera thirdPersonCam;
//
//    [Tooltip("This is the camera that will be used for the first person view.")]
//    public Camera firstPersonCam;
//
//    [Tooltip("This is the canvas that the crosshair is on.")]
//    public Canvas crosshairCanvas;
//
//    // This is the move direction of the player.
//    private Vector3 moveDirect;
//
//    // "isPaused" tracks if the game is paused or not, "canBeHit" tracks if the player can be hit, and "touchingQuicksand" tracks if the player is touching Quicksand.
//    // "touchingFrozenLake" tracks if the player is touching the frozen lake.
//    private bool isPaused = false, canBeHit = true;
//
//    public GameObject GameController;
//    private GameController gc;
//
//    private bool touchingSolid;
//
//    public Animator anim;
//
//    public Camera cam;
//
//    void Awake()
//    {
//        gc = GameController.GetComponent<GameController>();
//        crosshairCanvas.enabled = false;
//
//    }
//
//    void Start()
//    {
//        Cursor.lockState = CursorLockMode.Locked;
//
//        thirdPersonCam.enabled = true;
//
//        firstPersonCam.enabled = false;
//
//        speedVal = speed;
//
//    }
//
//    void Update()
//    {
//    
//
//
//        if (Input.GetButtonDown("Pause Keyboard") || Input.GetButtonDown("Pause Controller"))
//            isPaused = !isPaused;
//
//        if (!isPaused)
//
//        {
//
//            float c = 2f, v = 2f, x = 2f, z = 2f;
//
//            c = Input.GetAxis("Horizontal");
//
//            v = Input.GetAxis("Vertical");
//
//            x = Input.GetAxis("Horizontal Controller");
//
//            z = Input.GetAxis("Vertical Controller");
//
//            //Debug.Log(x + ", " + v + ", " + ", " + x + ", " + z);
//
//            transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0), Space.Self);
//
//            //Input.GetJoystickNames().Length > 0
//
//            if (x != 0 || z != 0)
//            {
//                moveDirect = transform.right * x + transform.forward * z;
//            }
//            else
//            {
//                moveDirect = transform.right * c + transform.forward * v;
//            }
//
//            // This makes sure the player never floats in the air and continuously falls to the ground (if they're not already touching the ground)
//
//            if (!touchingSolid)
//            {
//                controller.Move(Vector3.down * Time.deltaTime * 3);
//            }
//
//        }
//    }
//    void FixedUpdate() // Physics is calculated when fixedupdate runs, movement here is consistent between the editor and builds.
//    {
//        if (!isPaused)
//        {
//            if ((Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0) && (Input.GetAxisRaw("Horizontal Controller") == 0 && Input.GetAxisRaw("Vertical Controller") == 0))
//            {
//                anim.SetInteger("State", 0);
//            }
//            else if (canBeHit)
//            {
//                anim.SetInteger("State", 1);
//            }
//
//            controller.Move(moveDirect * speed * Time.fixedDeltaTime);
//        }
//    }
//
//    void OnCollisionEnter(Collision entered)
//    {
//        if (entered == null)
//        {
//
//        }
//
//        else if (entered.gameObject.tag == "Solid" || entered.gameObject.tag == "Terrain")
//        {
//            touchingSolid = true;
//        }
//        
//        else
//        {
//
//        }
//    }
//
//    void OnCollisionExit(Collision other)
//    {
//        if (other.gameObject.tag == "Solid" || other.gameObject.tag == "Terrain")
//        {
//            touchingSolid = false;
//        }
//    }
//
//    public void Snare()
//    {
//        StartCoroutine(Stun());
//        gc.SetHealth(-1);
//    }
//}