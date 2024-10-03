using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script will setup all the globals for the scene if it is included in the scene.

public class MenuSceneStartup : MonoBehaviour
{
    void Awake() {
        Time.timeScale = 1;
        Global.PlayerMovement = null;
        Global.BlackFade = null;
        Global.BlackBars = null;
        Global.KeyArea = null;
        Global.KeyPrompt = null;
        Global.Timer = null;
        Global.ExitCutscene = null;
        Global.ScoreInput = null;
        Global.PauseMenu = null;
    }
}
