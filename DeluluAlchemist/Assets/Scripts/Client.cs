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
            }
            else
            {
                GameManager.Instance.BadPotion();
            }
            Pot.Instance.ing1.UseIngredient();
            Pot.Instance.ing2.UseIngredient();
            Pot.Instance.ing3.UseIngredient();
            Pot.Instance.EmptyPot();
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
}
