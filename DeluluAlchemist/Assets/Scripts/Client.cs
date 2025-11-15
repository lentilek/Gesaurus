using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Client : MonoBehaviour
{
    public Image portraite;
    public TextMeshProUGUI text;
    [SerializeField] private Image patienceFill;
    public float maxTime, currentTime, patienceNoPotion;
    [HideInInspector] public Recipe recipe;
    [HideInInspector] public bool isEmpty;

    private void Awake()
    {
        isEmpty = true;
        gameObject.SetActive(false);
    }
    private void Update()
    {
        if (!isEmpty)
        {
            currentTime -= Time.deltaTime;
            GetCurrentFill();
        }
    }
    public void GivePotion()
    {
        if (Pot.Instance.isTherePotion && Pot.Instance.currentTime <= 0)
        {
            if (Pot.Instance.currentRecipe == recipe)
            {
                GameManager.Instance.EarnBalls();
                EndDay.Instance.happyClients++;
            }
            else
            {
                GameManager.Instance.BadPotion();
                EndDay.Instance.unhappyClients++;
            }
            Pot.Instance.ing1.UseIngredient();
            Pot.Instance.ing2.UseIngredient();
            Pot.Instance.ing3.UseIngredient();
            Pot.Instance.EmptyPot();
            EndDay.Instance.ignoredClients++;
            GameManager.Instance.clientCounter--;
            isEmpty = true;
            gameObject.SetActive(false);
        }
        else
        {
            currentTime -= patienceNoPotion;
        }
    }
    private void GetCurrentFill()
    {
        float fill = currentTime / maxTime;
        patienceFill.fillAmount = fill;

        if (patienceFill.fillAmount <= 0)
        {
            GameManager.Instance.ClientLeft();
            isEmpty = true;
            gameObject.SetActive(false);
        }
    }
    public bool IsCorrect()
    {
        if(recipe != null && recipe.ing.Contains(Pot.Instance.ing1.ingredient) 
            && recipe.ing.Contains(Pot.Instance.ing2.ingredient)
            && recipe.ing.Contains(Pot.Instance.ing3.ingredient))
        {
            return true;
        }
        return false;
    }
}
