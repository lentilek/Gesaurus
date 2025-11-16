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
    public float maxTime1, maxTime2, currentTime, patienceNoPotion;
    [HideInInspector] public Recipe recipe;
    [HideInInspector] public bool isEmpty;
    [SerializeField] private Sprite giveNormal, hoverNormal, giveGood, hoverGood;
    [SerializeField] private Button giveButton;

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
        if (Pot.Instance.isTherePotion && recipe == Pot.Instance.currentRecipe)
        {
            GiveButton(false);
        }
        else
        {
            GiveButton(true);
        }
    }
    public void GivePotion()
    {
        if (Pot.Instance.isTherePotion && Pot.Instance.progressFill.fillAmount >= 1)
        {
            if (Pot.Instance.currentRecipe == recipe)
            {
                AudioManager.Instance.PlaySound("clientGood");
                GameManager.Instance.EarnBalls();
                EndDay.Instance.happyClients++;
            }
            else
            {
                AudioManager.Instance.PlaySound("clientBad");
                GameManager.Instance.BadPotion();
                EndDay.Instance.unhappyClients++;
            }
            ClientsManager.Instance.portraitesToChoose.Add(portraite.sprite);
            Pot.Instance.ing1.UseIngredient();
            Pot.Instance.ing2.UseIngredient();
            Pot.Instance.ing3.UseIngredient();
            Pot.Instance.EmptyPot();
            GameManager.Instance.clientCounter--;
            isEmpty = true;
            gameObject.SetActive(false);
        }
        else
        {
            AudioManager.Instance.PlaySound("clientNothing");
            currentTime -= patienceNoPotion;
        }
    }
    private void GetCurrentFill()
    {
        if (GameManager.Instance.easyModeOn)
        {
            float fill = currentTime / maxTime1;
            patienceFill.fillAmount = fill;
        }
        else
        {
            float fill = currentTime / maxTime2;
            patienceFill.fillAmount = fill;
        }

        if (patienceFill.fillAmount <= 0)
        {
            ClientsManager.Instance.portraitesToChoose.Add(portraite.sprite);
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
    public void GiveButton(bool normal)
    {
        SpriteState select = new SpriteState();
        if (normal)
        {
            select.highlightedSprite = hoverNormal;
            giveButton.gameObject.GetComponent<Image>().sprite = giveNormal;
            giveButton.gameObject.GetComponent<Button>().spriteState = select;
        }
        else
        {
            select.highlightedSprite = hoverGood;
            giveButton.gameObject.GetComponent<Image>().sprite = giveGood;
            giveButton.gameObject.GetComponent<Button>().spriteState = select;
        }
    }
}
