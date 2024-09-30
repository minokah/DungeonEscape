using UnityEngine;

public class MovementController : MonoBehaviour
{
    public CharacterController controller;
    public Transform camera;
    public BoxCollider feet;

    Animator animator;

    public float speed;
    
    //Used for smoothing turns
    public float SmoothTime = 0.3f;
    
    //A reference variable which will hold the target's velocity while turning
    private float velocity;

    void Start() {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // Idle
        if (h == 0f && v == 0f) {
            animator.SetBool("Idle", true);
        }
        else {
            animator.SetBool("Idle", false);
        }
        
        animator.SetFloat("MovementVertical", (float)((v + h) / 2));
        animator.SetFloat("Time", animator.GetFloat("Time") + Time.fixedDeltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && !animator.GetBool("Jumping")) {
            animator.SetBool("Jumping", true);
            controller.Move(new Vector3(0, 3, 0));
        }

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
        controller.Move(transform.rotation * dir * speed * Time.deltaTime);
    }

    public void SetLanded() {
        animator.SetBool("Jumping", false);
    }

    private void OnTriggerEnter(Collider other) {
        SetLanded();
    }
}
