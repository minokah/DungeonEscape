using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroCutscene : MonoBehaviour
{
    float time = 0;
    public GameObject introCamera;

    // Start is called before the first frame update
    void Start()
    {
        introCamera.SetActive(true);
        Global.PlayerMovement.SetCamActive(false);
        Global.PlayerMovement.canMove = false;
        Global.BlackBars.active = true;
        Global.BlackFade.toBlack = true;
        Global.BlackFade.SetOpacity(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 1)
        {
            Global.BlackFade.toBlack = false;
        }

        if (time > 5)
        {
            introCamera.SetActive(false);
            Global.PlayerMovement.SetCamActive(true);
            Global.PlayerMovement.canMove = true;
            Global.Timer.running = true;
            Global.BlackBars.active = false;
            this.enabled = false;
        }

        time += Time.deltaTime;
    }
}
