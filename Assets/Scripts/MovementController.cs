using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    public CharacterController controller;
    public Transform camera;
    public GameObject playerCamera;
    public AudioSource footstepAudio;

    Animator animator;

    public float speed;

    //Used for smoothing turns
    public float SmoothTime = 0.3f;

    // Movement and Camera locks
    public bool canMove = true;

    private float velocity;
    private bool grounded = true;
    private bool moving = false;
    private float jumpDelay = 0; // Jump delay to prevent spamming jump

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Allowed to move?
        if (!canMove)
        {
            animator.SetBool("Idle", true);
            animator.SetFloat("MovementVertical", 0);
            animator.SetBool("Jumping", false);
            footstepAudio.Stop();
            return;
        }

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // Moving?
        if (h == 0f && v == 0f) moving = false;
        else moving = true;

        animator.SetBool("Idle", !moving);
        animator.SetFloat("MovementVertical", (float)((v + h + 0.01) / 2)); // 0.01 to never be stuck in sliding position

        if (jumpDelay > 0.3f && grounded && Input.GetKeyDown(KeyCode.Space)) {
            grounded = false;
            animator.SetBool("Jumping", true);
            controller.Move(new Vector3(0, 3, 0));
        }

        if (!moving || !grounded) footstepAudio.Stop();
        else if (!footstepAudio.isPlaying) footstepAudio.Play();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // Rotate character in direction of camera if we've moving, otherwise allow freelook
        if (canMove && moving)
        {
            //We will normalize this direction vector to make sure players don't move faster on diagonals (ex. holding W and A)
            //This will ensure the vector is always length 1
            //https://www.khanacademy.org/computing/computer-programming/programming-natural-simulations/programming-vectors/a/vector-magnitude-normalization
            //https://docs.unity3d.com/ScriptReference/Vector3.Normalize.html
            Vector3 dir = new Vector3(h, 0, v).normalized;

            //Smoothes an angle over time
            //In our case our character's current rotation along y to the camera's y over SmoothTime
            //https://docs.unity3d.com/ScriptReference/Mathf.SmoothDampAngle.html
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, camera.eulerAngles.y, ref velocity, SmoothTime);

            //transform.rotation is a quaternion
            //https://docs.unity3d.com/ScriptReference/Transform-rotation.html
            //Quaternion.Euler returns a rotation (a quaternion) which is rotated x,y,z degrees around their respective axes
            //In our case this will rotate the character around the y-axis to match the smoothed forward direction of the camera
            //https://docs.unity3d.com/ScriptReference/Quaternion.Euler.html
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            //The Character Controller component makes movement very easy, simply tell it the direction you want to move!
            //Multiplying a quaternion with a vector results in a vector that is rotated by the given quaternion
            //In our case we are rotating our cartesian movement dir vector to match our character's rotation
            controller.Move(transform.rotation * dir * speed * Time.fixedDeltaTime);
        }

        jumpDelay += Time.fixedDeltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Ground"))
        {
            jumpDelay = 0;
            grounded = true;
            animator.SetBool("Jumping", false);
        }
    }

    public void Teleport(Vector3 position)
    {
        controller.enabled = false;
        controller.transform.position = position;
        controller.enabled = true;
    }

    public void SetCamActive(bool active)
    {
        playerCamera.SetActive(active);
    }
}
