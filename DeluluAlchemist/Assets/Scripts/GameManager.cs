using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Localization.Settings;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TextMeshProUGUI dayCounter, magicCounter, reputationCounter;

    [SerializeField] private int earnMagic, reputationGain, reputationLooseNoP, reputationLooseBadP, minClients, maxClients;
    public int easyDays;
    [HideInInspector] public int magicBalls, reputation, days, clientCounter;
    [HideInInspector] public bool easyModeOn;

    public IngredientButton[] allIngredientButtons;

    private void Awake()
    {
        Instance = this;
        easyModeOn = true;

        reputation = 0;
        magicBalls = 2;
        days = 1;
        ClientNumberRandom();

        dayCounter.text = $"{days}";
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
            if (magicBalls > 0) EndDay.Instance.DayFinalize();
            else EndGame.Instance.FinishGame();
        }
    }
    public void ClientNumberRandom()
    {
        clientCounter = Random.Range(minClients, maxClients);
    }
    public void EarnBalls()
    {
        magicBalls += earnMagic;
        if (Random.Range(0, 101) < 70) magicBalls++;
        reputation += reputationGain;

        MagicCounter();
        ReputationCounter();
    }
    public void BadPotion()
    {
        magicBalls += earnMagic;
        reputation -= reputationLooseBadP;

        MagicCounter();
        ReputationCounter();
    }
    public void ClientLeft()
    {
        EndDay.Instance.ignoredClients++;
        clientCounter--;
        reputation -= reputationLooseNoP;
        ReputationCounter();
    }
    public void MagicCounter()
    {
        magicCounter.text = magicBalls.ToString();
    }
    public void ReputationCounter()
    {
        if (reputation > 10) reputation = 10;
        reputationCounter.text = reputation.ToString();
    }
}
