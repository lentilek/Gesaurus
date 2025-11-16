using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject credits;
    private void Awake()
    {
        credits.SetActive(false);
    }
    public void StartGame()
    {
        AudioManager.Instance.PlaySound("click");
        SceneManager.LoadScene(1);
    }
    public void Tutorial()
    {
        AudioManager.Instance.PlaySound("click");
        SceneManager.LoadScene(2);
    }
    public void OpenCredits()
    {
        AudioManager.Instance.PlaySound("click");
        credits.SetActive(true);
    }
    public void CloseCredits()
    {
        AudioManager.Instance.PlaySound("click");
        credits.SetActive(false);
    }
    public void Quit()
    {
        AudioManager.Instance.PlaySound("click");
        Application.Quit();
    }
    public void Hover()
    {
        AudioManager.Instance.PlaySound("hover");
    }
}
