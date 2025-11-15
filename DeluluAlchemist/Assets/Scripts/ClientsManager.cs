using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientsManager : MonoBehaviour
{
    public static ClientsManager Instance;

    [SerializeField] private Client client1, client2, client3;

    [SerializeField] private float minTime, maxTime;

    [SerializeField] private Sprite[] portraites;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        CreateClient();
    }
    private IEnumerator WaitForClient()
    {
        yield return new WaitForSeconds(Random.Range(minTime,maxTime));

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
        client.portraite.sprite = portraites[Random.Range(0, portraites.Length)];
        client.recipe = Pot.Instance.recipes[Random.Range(0, Pot.Instance.recipes.Length)];
        client.text.text = client.recipe.descriptions[Random.Range(0, client.recipe.descriptions.Length)];
        client.isEmpty = false;
        client.currentTime = client.maxTime;

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
}
