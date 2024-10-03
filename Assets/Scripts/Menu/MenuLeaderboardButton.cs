using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MenuLeaderboardButton : MonoBehaviour
{
    public GameObject menuCam;
    public GameObject leaderboardCam;
    public Button leaderboardButton;
    public Button backButton;
    public GameObject menuPanel;
    public GameObject leaderboardPanel;
    public GameObject leaderboardContent;
    public GameObject entryTemplate;

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

        Dictionary<string, float> entries = Leaderboard.GetScores();

        int i = 0;
        foreach ((string s, float v) in entries)
        {
            AddEntry($"{s}: {v.ToString("#.##")}", i);
            i++;
        }

        if (entries.Count == 0)
        {
            AddEntry("No scores :(", 0);
        }

        leaderboardContent.GetComponent<RectTransform>().sizeDelta = new Vector2(0, i * 30);
    }

    private void AddEntry(string s, int i)
    {
        GameObject newEntry = Instantiate(entryTemplate, leaderboardContent.transform);
        newEntry.transform.Find("Text").GetComponent<TMP_Text>().text = s;
        RectTransform rect = newEntry.GetComponent<RectTransform>();
        rect.anchoredPosition = new Vector2(0, -i * 30);
        newEntry.SetActive(true);
    }
}
