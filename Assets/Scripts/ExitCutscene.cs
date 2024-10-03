using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitCutscene : MonoBehaviour
{
    public GameObject player;
    CharacterController controller;

    Animator animator;

    public GameObject camera;
    public Transform startPosition;
    public Transform exitPosition;

    float time = 0;

    bool exiting = false;

    void Start() {
        controller = player.GetComponent<CharacterController>();
        animator = player.GetComponent<Animator>();    
    }

    public void Begin() {
        Global.Timer.running = false;
        Global.BlackBars.active = true;
        camera.SetActive(true);
        Global.PlayerMovement.canMove = false;
        Global.PlayerMovement.footstepAudio.Stop();
        Global.PlayerMovement.SetCamActive(false);
        Global.PlayerMovement.enabled = false;
        controller.enabled = false;
        controller.transform.position = startPosition.position;
        player.transform.rotation = Quaternion.Euler(0, 180, 0);
        controller.enabled = true;
        exiting = true;
        animator.SetBool("Idle", true);
        animator.SetFloat("MovementVertical", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (exiting) {
            // After black bars fade in, move guy towards the light (exit)!
            if (time > 3) {
                animator.SetBool("Idle", false);
                animator.SetFloat("MovementVertical", 1);

                Vector3 vector = exitPosition.position - controller.transform.position;
                vector.Normalize();
                controller.Move(vector * Time.deltaTime * 3);
                Global.PlayerMovement.footstepAudio.Play();
            }

            if (time > 5) {
                Global.BlackFade.toBlack = true;
            }

            if (time > 8)
            {
                Global.PlayerMovement.footstepAudio.Stop();
                Global.ScoreInput.Show();
                Cursor.lockState = CursorLockMode.None;
                Global.PauseMenu.gameObject.SetActive(false);
            }

            time += Time.deltaTime;
        }
    }
}
