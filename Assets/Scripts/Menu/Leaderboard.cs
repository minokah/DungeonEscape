using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    public GameObject menuCam;
    public GameObject leaderboardCam;
    public Button leaderboardButton;
    public Button backButton;
    public GameObject menuPanel;
    public GameObject leaderboardPanel;

    // Start is called before the first frame update
    void Start()
    {
        leaderboardButton.onClick.AddListener(GotoLeaderboard);
        backButton.onClick.AddListener(GotoMenu);
    }

    private void GotoMenu() {
        menuPanel.SetActive(true);
        leaderboardPanel.SetActive(false);
        menuCam.SetActive(true);
        leaderboardCam.SetActive(false);
    }

    private void GotoLeaderboard() {
        menuPanel.SetActive(false);
        leaderboardPanel.SetActive(true);
        menuCam.SetActive(false);
        leaderboardCam.SetActive(true);
    }
}
