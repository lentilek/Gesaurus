using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private int earnMagic;
    [HideInInspector] public int magicBalls;
    [HideInInspector] public int reputation, reputationGain, reputationLoose;

    public IngredientButton[] allIngredientButtons;

    private void Awake()
    {
        Instance = this;

        reputation = 0;
        magicBalls = 0;
    }

    public void EarnBalls()
    {
        magicBalls += earnMagic;
        reputation += reputationGain;
    }
    public void BadPotion()
    {
        magicBalls += earnMagic;
        reputation -= reputationLoose;
    }
    public void ClientLeft()
    {
        reputation -= reputationLoose;
    }
}
