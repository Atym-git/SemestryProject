using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CustomersSpawner : MonoBehaviour
{
    [SerializeField] private GameObject customerPrefab;
    [SerializeField] private Transform customersRootParent;
    private List<Transform> customersRoots = new List<Transform>();

    private CustomersSO[] customerSOs;

    private List<int> customersList = new List<int>();

    private Level level;

    private void Start()
    {
        ResourceLoader();
        for (int i = 0; i < customersRootParent.childCount; i++)
        {
            customersRoots.Add(customersRootParent.GetChild(i));
        }
    }

    public void SpawnCustomers(int currLevel, int spawnAmount)
    {
        if (currLevel % 2 == 0)
        {
            for (int i = 0; i < spawnAmount; i++)
            {
                int customerId = Random.Range(0, customersRoots.Count - 1);
                if (customersList.Contains(customerId))
                {
                    spawnAmount++;
                    continue;
                }
                GameObject customer = Instantiate(customerPrefab, customersRoots[customerId]);
                SpriteRenderer customerSr = customer.GetComponent<SpriteRenderer>();
                Debug.Log(customerSr);
                Debug.Log(customerSOs[customerId]);
                customerSr.sprite = customerSOs[customerId].customerSprite;
                customersList.Add(customerId);
            }
        }
    }

    private void ResourceLoader()
    {
        customerSOs = Resources.LoadAll("SO/CustomerSO", typeof(CustomersSO))
            .Cast<CustomersSO>()
            .ToArray();
        Debug.Log(customerSOs.Length);
    }
}
