using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class ExitDoor : DoorUnlock
{
    public override void Update()
    {
        if (active && Input.GetKeyDown(KeyCode.E)) {
            Global.ExitCutscene.Begin();
        }

        base.Update();
    }
}
