using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndDay : MonoBehaviour
{
    public static EndDay Instance;

    [HideInInspector] public int happyClients, unhappyClients, ignoredClients;
    [SerializeField] private GameObject endDay;
    [SerializeField] private TextMeshProUGUI daysTXT, happyClientsTXT, unhappyClientsTXT, ignoredClientsTXT;

    private void Awake()
    {
        Instance = this;
        endDay.SetActive(false);
        happyClients = 0;
        unhappyClients = 0;
        ignoredClients = 0;
        Time.timeScale = 1.0f;
    }

    public void DayFinalize()
    {
        Time.timeScale = 0f;

        daysTXT.text = $"Dzieñ: {GameManager.Instance.days}";
        happyClientsTXT.text = $"Zadowoleni klienci: {happyClients}";
        unhappyClientsTXT.text = $"Niezadowoleni klienci: {unhappyClients}";
        ignoredClientsTXT.text = $"Nieobs³u¿eni klienci: {ignoredClients}";

        endDay.SetActive(true);
    }
    public void NewDay()
    {
        GameManager.Instance.days++;
        GameManager.Instance.dayCounter.text = $"Dzieñ: {GameManager.Instance.days}";

        ClientsManager.Instance.EmptyClients();
        GameManager.Instance.ClientNumberRandom();

        ClientsManager.Instance.CreateClient();

        endDay.SetActive(false);
        Time.timeScale = 1f;
    }
    public void FinishGame()
    {
        //
    }
}
