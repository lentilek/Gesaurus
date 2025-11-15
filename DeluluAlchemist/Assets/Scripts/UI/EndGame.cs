using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public static EndGame Instance;

    [HideInInspector] public int happyClients, unhappyClients, ignoredClients;
    [SerializeField] private GameObject endGame;
    [SerializeField] private TextMeshProUGUI daysTXT, happyClientsTXT, unhappyClientsTXT, ignoredClientsTXT;

    private void Awake()
    {
        Instance = this;
        happyClients = 0;
        unhappyClients = 0;
        ignoredClients = 0;
    }
    private void Update()
    {
        if (GameManager.Instance.reputation <= -10)
        {
            FinishGame();
        }
    }
    public void FinishGame()
    {
        Time.timeScale = 0f;

        happyClients += EndDay.Instance.happyClients;
        unhappyClients += EndDay.Instance.unhappyClients;
        ignoredClients += EndDay.Instance.ignoredClients;

        daysTXT.text = $"Dzieñ: {GameManager.Instance.days}";
        happyClientsTXT.text = $"Zadowoleni klienci: {happyClients}";
        unhappyClientsTXT.text = $"Niezadowoleni klienci: {unhappyClients}";
        ignoredClientsTXT.text = $"Nieobs³u¿eni klienci: {ignoredClients}";

        endGame.SetActive(true);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
