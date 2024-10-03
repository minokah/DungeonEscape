using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreInput : MonoBehaviour
{
    public GameObject panel;
    public Button confirm;
    public TMP_InputField field;
    public TMP_Text error;

    // Start is called before the first frame update
    void Start()
    {
        confirm.onClick.AddListener(Click);
    }

    private void Click()
    {
        float time = Global.Timer.time;

        if (field.text.Length == 0 || field.text.Length > 3)
        {
            error.text = "Name must be between 1 and 3 characters";
            return;
        }

        float boardScore = Leaderboard.GetScore(field.text);

        if (boardScore > time)
        {
            error.text = $"${field.text} ({boardScore}) has a better time already :(";
            return;
        }

        if (Leaderboard.AddScore(field.text, time)) SceneManager.LoadScene("MenuScene");
        else
        {
            error.text = "Error while adding score!";
        }
    }

    public void Show()
    {
        panel.SetActive(true);
    }
}
