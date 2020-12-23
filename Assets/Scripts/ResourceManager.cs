using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance { get; private set; }

    private Dictionary<ResourceTypeSO, int> _resourceAmounts;
    private ResourceTypeListSO resourceTypeList;

    private void Awake()
    {
        Instance = this;
        _resourceAmounts = new Dictionary<ResourceTypeSO, int>();

        resourceTypeList = Resources.Load<ResourceTypeListSO>(typeof(ResourceTypeListSO).Name);

        // Iterate each predefined type and set value to zero on awake
        foreach (var resourceType in resourceTypeList.list)
        {
            _resourceAmounts.Add(resourceType, 0);
        }
    }

    public int GetResource(ResourceTypeSO resourceType)
    {
        return _resourceAmounts[resourceType];
    }

    public void AddResource(ResourceTypeSO resourceType, int amount)
    {
        _resourceAmounts[resourceType] += amount;
    }
}
