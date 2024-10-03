using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script will setup all the globals for the scene if it is included in the scene.

public class GameSceneStartup : MonoBehaviour
{
    void Awake() {
        Time.timeScale = 1;
        Global.PlayerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementController>();
        Global.BlackFade = GameObject.FindGameObjectWithTag("UI_BlackFade").GetComponent<BlackFade>();
        Global.BlackBars = GameObject.FindGameObjectWithTag("UI_BlackBars").GetComponent<BlackBars>();
        Global.KeyArea = GameObject.FindGameObjectWithTag("UI_KeyArea").GetComponent<KeyArea>();
        Global.KeyPrompt = GameObject.FindGameObjectWithTag("UI_KeyPrompt").GetComponent<KeyPrompt>();
        Global.Timer = GameObject.FindGameObjectWithTag("UI_Timer").GetComponent<Timer>();
        Global.ExitCutscene = GameObject.FindGameObjectWithTag("ExitCutscene").GetComponent<ExitCutscene>();
        Global.ScoreInput = GameObject.FindGameObjectWithTag("UI_ScoreInput").GetComponent<ScoreInput>();
        Global.PauseMenu = GameObject.FindGameObjectWithTag("UI_PauseMenu").GetComponent<PauseMenu>();
    }
}
