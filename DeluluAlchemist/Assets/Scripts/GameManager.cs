using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] TextMeshProUGUI dayCounter, magicCounter, reputationCounter;

    [SerializeField] private int earnMagic;
    [HideInInspector] public int magicBalls;
    [HideInInspector] public int reputation, reputationGain, reputationLoose;

    public IngredientButton[] allIngredientButtons;

    private void Awake()
    {
        Instance = this;

        reputation = 0;
        magicBalls = 0;

        dayCounter.text = "1";
        MagicCounter();
        ReputationCounter();
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
        reputationCounter.text = reputationCounter.ToString();
    }
}
