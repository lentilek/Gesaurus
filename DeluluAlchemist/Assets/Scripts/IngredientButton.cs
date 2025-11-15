using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class IngredientButton : MonoBehaviour
{
    public Ingredient ingredient;

    [SerializeField] private GameObject active, inactive, replenishCounter;
    [SerializeField] private Image replenishFill;
    [SerializeField] private float replenishTime, currentTime;
    private int potButton;
    private bool replenishing;

    private void Awake()
    {
        replenishing = false;
        replenishCounter.SetActive(false); 
    }
    private void Update()
    {
        if (replenishing)
        {
            currentTime -= Time.deltaTime;
            GetCurrentFill();
        }
    }
    public void AddIngredient()
    {
        potButton = Pot.Instance.FindEmptySlot(this);
        if (potButton != 0) active.gameObject.SetActive(false);
    }
    public void UndoIngredient()
    {
        Pot.Instance.EmptySlot(potButton);
        potButton = 0;
        active.gameObject.SetActive(true);
    }
    public void UseIngredient()
    {
        inactive.gameObject.SetActive(true);
    }
    public void Replenish()
    {
        if (GameManager.Instance.magicBalls > 0)
        {
            replenishing = true;
            currentTime = replenishTime;
            inactive.gameObject.SetActive(false);
            GameManager.Instance.magicBalls--;
            GameManager.Instance.MagicCounter();
            replenishCounter.SetActive(true);
        }
    }
    private void GetCurrentFill()
    {
        float fill = currentTime / replenishTime;
        replenishFill.fillAmount = fill;

        if (replenishFill.fillAmount <= 0)
        {
            replenishCounter.SetActive(false);
            replenishing = false;
            active.gameObject.SetActive(true);
        }
    }
}
