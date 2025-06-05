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

    private List<int> rootsList = new List<int>();

    private Level level;

    private void Awake()
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
                int customerId = Random.Range(0, customerSOs.Length - 1);
                int rootId = Random.Range(0, customersRoots.Count - 1);
                if (customersList.Contains(customerId) || rootsList.Contains(rootId))
                {
                    spawnAmount++;
                    continue;
                }
                GameObject instance = Instantiate(customerPrefab, customersRoots[rootId]);
                Customer customer = instance.GetComponent<Customer>();
                Debug.Log(customerSOs[customerId].customerAnimation);
                customer.SetupCustomer(customerSOs[customerId].customerSprite, customerSOs[customerId].customerAnimation);
                customersList.Add(customerId);
                rootsList.Add(rootId);
            }
        }
    }

    private void ResourceLoader()
    {
        customerSOs = Resources.LoadAll("SO/CustomerSO", typeof(CustomersSO))
            .Cast<CustomersSO>()
            .ToArray();
        //Debug.Log(customerSOs.Length);
    }
}
