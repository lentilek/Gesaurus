using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClientsManager : MonoBehaviour
{
    public static ClientsManager Instance;

    [SerializeField] public Client client1, client2, client3;

    [SerializeField] private float minTime1, maxTime1, minTime2, maxTime2;

    [SerializeField] private Sprite[] portraitesAll;
    [HideInInspector] public List<Sprite> portraitesToChoose = new List<Sprite>();

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex != 2)
        {
            PreparePortraites();
            CreateClient();
        }
    }
    public void PreparePortraites()
    {
        foreach (var portrate in portraitesAll)
        {
            portraitesToChoose.Add(portrate);
        }
    }
    private IEnumerator WaitForClient()
    {
        if (GameManager.Instance.easyModeOn)
        {
            float time = Random.Range(minTime1, maxTime1);
            yield return new WaitForSeconds(time);
        }
        else
        {
            float time = Random.Range(minTime2, maxTime2);
            yield return new WaitForSeconds(time);
        }

        CreateClient();
    }
    public void CreateClient()
    {
        if (client1.isEmpty)
        {
            NewClient(client1);
        }
        else if (client2.isEmpty)
        {
            NewClient(client2);
        }
        else if (client3.isEmpty)
        {
            NewClient(client3);
        }

        if (GameManager.Instance.clientCounter > 0) StartCoroutine(WaitForClient());
    }
    private void NewClient(Client client)
    {
        int a = Random.Range(0, portraitesToChoose.Count);
        client.portraite.sprite = portraitesToChoose[a];
        portraitesToChoose.Remove(portraitesToChoose[a]);

        client.recipeIndex = Random.Range(0, Pot.Instance.recipes.Length);
        client.recipe = Pot.Instance.recipes[client.recipeIndex];

        client.descriptIndex = Random.Range(0, client.recipe.descriptions.Length);
        client.text.text = client.recipe.descriptions[client.descriptIndex];

        client.isEmpty = false;
        if (GameManager.Instance.easyModeOn) client.currentTime = client.maxTime1;
        else client.currentTime = client.maxTime2;

        client.gameObject.SetActive(true);
    }
    public void EmptyClients()
    {
        client1.isEmpty = true;
        client1.gameObject.SetActive(false);
        client2.isEmpty = true;
        client2.gameObject.SetActive(false);
        client3.isEmpty = true;
        client3.gameObject.SetActive(false);
    }
    public bool GoodRecipes()
    {
        if (client1.IsCorrect() || client2.IsCorrect() || client3.IsCorrect())
        {
            return true;
        }
        else { return false; }
    }
    public void StopClients()
    {
        StopAllCoroutines();
    }
}
