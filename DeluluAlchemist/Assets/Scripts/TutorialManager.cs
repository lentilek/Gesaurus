using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private GameObject[] parts;
    private int part;
    [SerializeField] private GameObject moveView1, moveView2, ryba, pokrzywa, clientGive, trash;
    private void Awake()
    {
        foreach (var part in parts) { part.gameObject.SetActive(false); }
        part = 0;
        moveView1.SetActive(false);
        moveView2.SetActive(false);
        ryba.SetActive(false);
        clientGive.SetActive(false);
    }
    private void Start()
    {
        ClientsManager.Instance.PreparePortraites();
        parts[part].gameObject.SetActive(true);
    }
    private void Update()
    {
        if (part == 2 && Pot.Instance.ing1 != null && Pot.Instance.ing2 != null && Pot.Instance.ing3 != null)
        {
            Part2();
        }
        else if (part == 3 && Pot.Instance.isTherePotion && !Pot.Instance.progressBar.activeSelf)
        {
            trash.GetComponent<Button>().enabled = true;
        }
        else if (part == 5 && Pot.Instance.isTherePotion && !Pot.Instance.progressBar.activeSelf)
        {
            Part5();
        }
    }
    public void Part0()
    {
        AudioManager.Instance.PlaySound("click");

        SpawnClient();
        parts[part].gameObject.SetActive(false);
        part++;
        parts[part].gameObject.SetActive(true);
        moveView1.SetActive(true);
    }
    private void SpawnClient()
    {
        int a = Random.Range(0, ClientsManager.Instance.portraitesToChoose.Count);
        ClientsManager.Instance.client3.portraite.sprite = ClientsManager.Instance.portraitesToChoose[a];
        ClientsManager.Instance.client3.recipe = Pot.Instance.recipes[0];
        ClientsManager.Instance.client3.text.text = ClientsManager.Instance.client3.recipe.descriptions[2];
        ClientsManager.Instance.client3.isEmpty = false;
        ClientsManager.Instance.client3.currentTime = ClientsManager.Instance.client3.maxTime1;

        ClientsManager.Instance.client3.gameObject.SetActive(true);
    }
    public void Part1()
    {
        parts[part].gameObject.SetActive(false);
        part++;
        parts[part].gameObject.SetActive(true); 
        moveView1.SetActive(false);
    }
    private void Part2()
    {
        parts[part].gameObject.SetActive(false);
        part++;
        parts[part].gameObject.SetActive(true);
    }
    public void Part3()
    {
        parts[part].gameObject.SetActive(false);
        part++;
        parts[part].gameObject.SetActive(true);
        pokrzywa.SetActive(false);
    } 
    public void Part4()
    {
        AudioManager.Instance.PlaySound("click");

        parts[part].gameObject.SetActive(false);
        part++;
        parts[part].gameObject.SetActive(true);
        ryba.SetActive(true);
    }
    private void Part5()
    {
        parts[part].gameObject.SetActive(false);
        part++;
        parts[part].gameObject.SetActive(true);
        moveView2.SetActive(true);
        clientGive.SetActive(true);
    }
    public void Part6()
    {
        parts[part].gameObject.SetActive(false);
        part++;
        parts[part].gameObject.SetActive(true);
    }
    public void Part7()
    {
        AudioManager.Instance.PlaySound("click");

        parts[part].gameObject.SetActive(false);
        part++;
        parts[part].gameObject.SetActive(true);
    }
    public void Part8()
    {
        AudioManager.Instance.PlaySound("click");

        parts[part].gameObject.SetActive(false);
        part++;
        parts[part].gameObject.SetActive(true);
    }
    public void Part9()
    {
        AudioManager.Instance.PlaySound("click");

        parts[part].gameObject.SetActive(false);
        part++;
        parts[part].gameObject.SetActive(true);
    }
    public void Finish()
    {
        AudioManager.Instance.PlaySound("click");

        SceneManager.LoadScene(0);
    }
    public void Hover()
    {
        AudioManager.Instance.PlaySound("hover");
    }
}
