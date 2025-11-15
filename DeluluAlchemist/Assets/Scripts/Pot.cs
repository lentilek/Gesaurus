using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Pot : MonoBehaviour
{
    public static Pot Instance;

    public Recipe[] recipes;

    [HideInInspector]public IngredientButton ing1, ing2, ing3;

    public Image image1, image2, image3, potionColor, progressFill;
    [HideInInspector] public bool isTherePotion;
    [SerializeField] private Color regularPotion, weirdPotion;

    [SerializeField] private float potAnimMove, potAnimTime, progressTime;
    [HideInInspector] public float currentTime;

    [HideInInspector] public Recipe currentRecipe;
    private SpriteState select = new SpriteState();
    [SerializeField] private GameObject mixButton, inactiveMixButton, progressBar;
    private void Awake()
    {
        Instance = this;
        isTherePotion = false;
        potionColor.color = regularPotion;
        progressBar.SetActive(false);
    }
    private void Update()
    {
        if (isTherePotion)
        {
            currentTime -= Time.deltaTime;
            GetCurrentFill();
        }
        if (ing1 != null && ing2 != null && ing3 != null)
        {
            mixButton.SetActive(true);
            inactiveMixButton.SetActive(false);
            if (ClientsManager.Instance.GoodRecipes())
            {
                Character.Instance.Emotion(1);
            }
            else
            {
                Character.Instance.Emotion(-1);
            }
        }
        else
        {
            mixButton.SetActive(false);
            inactiveMixButton.SetActive(true);
            Character.Instance.Emotion(0);
        }
        if (ing1 != null)
        {
            image1.sprite = ing1.ingredient.pot;
            select.highlightedSprite = ing1.ingredient.potHover;
            image1.gameObject.GetComponent<Button>().spriteState = select;
            image1.gameObject.SetActive(true);
        }
        else
        {
            image1.gameObject.SetActive(false);
        }
        if (ing2 != null)
        {
            image2.sprite = ing2.ingredient.pot;
            select.highlightedSprite = ing2.ingredient.potHover;
            image2.gameObject.GetComponent<Button>().spriteState = select;
            image2.gameObject.SetActive(true);
        }
        else
        {
            image2.gameObject.SetActive(false);    
        }
        if (ing3 != null)
        {
            image3.sprite = ing3.ingredient.pot;
            select.highlightedSprite = ing3.ingredient.potHover;
            image3.gameObject.GetComponent<Button>().spriteState = select;
            image3.gameObject.SetActive(true);
        }
        else
        {
            image3.gameObject.SetActive(false);
        }
    }
    public int FindEmptySlot(IngredientButton ing)
    {
        if (ing1 == null)
        {
            ing1 = ing;
            return 1;
        }
        else if (ing2 == null)
        {
            ing2 = ing;
            return 2;
        }
        else if (ing3 == null)
        {
            ing3 = ing;
            return 3;
        }
        return 0;
    }
    public void EmptySlot(int index)
    {
        if (index == 1)
        {
            ing1 = null;
        }else if (index == 2)
        {
            ing2 = null;
        }else if(index == 3)
        {
            ing3 = null;
        }
    }
    public void UndoIng(int i)
    {
        if (!isTherePotion && ing1 != null && i == 1)
        {
            ing1.UndoIngredient();
        }
        else if (!isTherePotion && ing2 != null && i == 2)
        {
            ing2.UndoIngredient();
        }
        if (!isTherePotion && ing3 != null && i == 3)
        {
            ing3.UndoIngredient();
        }
    }
    public void StartMixing()
    {
        StartCoroutine(Mix());
    }
    private IEnumerator Mix()
    {
        if (ing1 != null && ing2 != null && ing3 != null)
        {
            AnimateUpDown(image1.gameObject, potAnimMove, potAnimTime);
            AnimateUpDown(image2.gameObject, potAnimMove, potAnimTime);
            AnimateUpDown(image3.gameObject, potAnimMove, potAnimTime);

            isTherePotion = true;
            bool goodPotion = false;

            currentTime = progressTime;
            progressBar.SetActive(true);
            yield return new WaitForSecondsRealtime(progressTime);
            foreach (var rec in recipes)
            {
                if (rec.ing.Contains(ing1.ingredient) && rec.ing.Contains(ing2.ingredient) 
                    && rec.ing.Contains(ing3.ingredient))
                {
                    currentRecipe = rec;
                    potionColor.color = rec.potionColor;
                    goodPotion = true;
                    break;
                }
            }
            if (goodPotion)
            {
                //
            }
            else
            {
                potionColor.color = weirdPotion;
            }
            progressBar.SetActive(false);
        }
    }
    private void AnimateUpDown(GameObject go, float move, float time)
    {
        go.transform.DOMoveY(go.transform.position.y + move, time);
    }
    public void TrashPotion()
    {
        if (isTherePotion)
        {
            ing1.UseIngredient();
            ing2.UseIngredient();
            ing3.UseIngredient();
            EmptyPot();
        }
    }
    public void EmptyPot()
    {
        EmptySlot(1);
        EmptySlot(2);
        EmptySlot(3);

        AnimateUpDown(image1.gameObject, -potAnimMove, 0);
        AnimateUpDown(image2.gameObject, -potAnimMove, 0);
        AnimateUpDown(image3.gameObject, -potAnimMove, 0);

        currentRecipe = null;
        potionColor.color = regularPotion;

        isTherePotion = false;
    }
    private void GetCurrentFill()
    {
        float fill = currentTime / progressTime;
        progressFill.fillAmount = fill;

    }
}
