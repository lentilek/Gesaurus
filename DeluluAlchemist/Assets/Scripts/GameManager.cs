using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TextMeshProUGUI dayCounter, magicCounter, reputationCounter;

    [SerializeField] private int earnMagic, reputationGain, reputationLoose, minClients, maxClients;
    [HideInInspector] public int magicBalls, reputation, days, clientCounter;

    public IngredientButton[] allIngredientButtons;

    private void Awake()
    {
        Instance = this;

        reputation = 0;
        magicBalls = 2;
        days = 1;
        ClientNumberRandom();

        dayCounter.text = $"Dzieñ: {days}";
        MagicCounter();
        ReputationCounter();
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
        if(clientCounter <= 0)
        {
            EndDay.Instance.DayFinalize();
        }
    }
    public void ClientNumberRandom()
    {
        clientCounter = Random.Range(minClients, maxClients);
    }
    public void EarnBalls()
    {
        magicBalls += earnMagic;
        reputation += reputationGain;

        MagicCounter();
        ReputationCounter();
    }
    public void BadPotion()
    {
        magicBalls += earnMagic;
        reputation -= reputationLoose;

        MagicCounter();
        ReputationCounter();
    }
    public void ClientLeft()
    {
        reputation -= reputationLoose;
        ReputationCounter();
    }
    public void MagicCounter()
    {
        magicCounter.text = magicBalls.ToString();
    }
    public void ReputationCounter()
    {
        reputationCounter.text = reputation.ToString();
    }
}
