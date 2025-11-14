using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientButton : MonoBehaviour
{
    public Ingredient ingredient;

    [SerializeField] private GameObject active, inactive;
    private int potButton;

    public void AddIngredient()
    {
        potButton = Pot.Instance.FindEmptySlot(this);
        active.gameObject.SetActive(false);
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
        active.gameObject.SetActive(true);
        inactive.gameObject.SetActive(false);
        // use magic
    }
}
