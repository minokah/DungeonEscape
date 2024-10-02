using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Global
{
    public static MovementController PlayerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementController>();
    public static BlackFade BlackFade = GameObject.FindGameObjectWithTag("UI_BlackFade").GetComponent<BlackFade>();
    public static KeyArea KeyArea = GameObject.FindGameObjectWithTag("UI_KeyArea").GetComponent<KeyArea>();
}
