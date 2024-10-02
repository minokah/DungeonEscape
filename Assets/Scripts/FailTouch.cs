using UnityEngine;

public class FailTouch : MonoBehaviour
{
    bool touched = false;
    float time = 0;
    public GameObject camera;
    public GameObject respawn;
    public GameObject respawnwithkey;
    public string key;

    void Update()
    {
        if (touched)
        {
            if (time < 3f) Global.BlackFade.toBlack = true;
            else
            {
                // Respawn at key spot if grabbed, other
                if (Global.KeyArea.Grabbed(key)) Global.PlayerMovement.Teleport(respawnwithkey.transform.position);
                else Global.PlayerMovement.Teleport(respawn.transform.position);

                Global.BlackFade.toBlack = false;
                Global.PlayerMovement.canMove = true;
                Global.PlayerMovement.SetCamActive(true);
                camera.SetActive(false);
                touched = false;
            }
        }

        time += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            touched = true;
            time = 0;
            Global.PlayerMovement.canMove = false;
            Global.PlayerMovement.SetCamActive(false);
            camera.SetActive(true);
        }
    }
}
