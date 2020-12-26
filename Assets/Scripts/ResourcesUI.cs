using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using TMPro;

public class ResourcesUI : MonoBehaviour
{
    /// <summary>
    /// The UI template
    /// </summary>
    [SerializeField]private Transform resourceTemplate;

    private void Awake()
    {
        float offsetAmount = 160f;
         
        var _resourceTypeList = Resources.Load<ResourceTypeListSO>(typeof(ResourceTypeListSO).Name).list;
        resourceTemplate.gameObject.SetActive(false);
       var index = 0;
        foreach (var resourceType in _resourceTypeList)
        {
            var resourceTransform = Instantiate(resourceTemplate,transform);
            resourceTransform.gameObject.SetActive(true);
            resourceTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,offsetAmount * index);
            
            var image = resourceTransform.Find("image").GetComponent<Image>();
            image.sprite = resourceType.Image;

           // var text = resourceTransform.Find("text").GetComponent<TextMeshProGUI>
            index++;
        }
    }
}
