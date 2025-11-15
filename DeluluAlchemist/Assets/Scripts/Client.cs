using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class Client : MonoBehaviour
{
    public Image portraite;
    public TextMeshProUGUI text;
    [SerializeField] private Image patienceFill;
    public float maxTime, currentTime;
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
            Time.timeScale = 1f;
            GetCurrentFill();
        }
    }
    public void GivePotion()
    {
        if (Pot.Instance.isTherePotion)
        {
            if (Pot.Instance.currentRecipe == recipe)
            {
                GameManager.Instance.EarnBalls();
                foreach (var ingredient in GameManager.Instance.allIngredientButtons)
                {
                    if (Pot.Instance.currentRecipe.ing.Contains(ingredient.ingredient))
                    {
                        ingredient.UseIngredient();
                    }
                }
                gameObject.SetActive(false);
                Pot.Instance.EmptyPot();
            }
            else
            {
                GameManager.Instance.BadPotion();
                foreach (var ingredient in GameManager.Instance.allIngredientButtons)
                {
                    if (Pot.Instance.currentRecipe.ing.Contains(ingredient.ingredient))
                    {
                        ingredient.UseIngredient();
                    }
                }
                gameObject.SetActive(false);
                Pot.Instance.EmptyPot();
            }
        }
        else
        {
            // no potion
        }
    }
    private void GetCurrentFill()
    {
        float fill = currentTime / maxTime;
        patienceFill.fillAmount = fill;
    }
}
