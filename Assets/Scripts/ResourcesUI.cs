using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResourcesUI : MonoBehaviour
{
    /// <summary>
    /// The UI template
    /// </summary>
    [SerializeField] private Transform resourceTemplate;
    private List<ResourceTypeSO> _resourceTypeList;
    private Dictionary<ResourceTypeSO, TextMeshProUGUI> _resourceGUIText;
    private void Awake()
    {

        _resourceGUIText = new Dictionary<ResourceTypeSO, TextMeshProUGUI>();
        _resourceTypeList = Resources.Load<ResourceTypeListSO>(typeof(ResourceTypeListSO).Name).list;
        resourceTemplate.gameObject.SetActive(false);
        float offsetAmount = 160f;
        var index = 0;

        foreach (var resourceType in _resourceTypeList)
        {
            var resourceTransform = Instantiate(resourceTemplate, transform);
            resourceTransform.gameObject.SetActive(true);
            resourceTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(-offsetAmount * index, 0);

            var image = resourceTransform.Find("image").GetComponent<Image>();
            image.sprite = resourceType.Image;

            var text = resourceTransform.Find("text").GetComponent<TextMeshProUGUI>();
            text.SetText("0");
            _resourceGUIText.Add(resourceType, text);

            index++;
        }
    }

    private void Start()
    {
        ResourceManager.Instance.onResourceAmountChanged += Instance_onResourceAmountChanged;
    }

    private void Instance_onResourceAmountChanged(object sender, ResourceTypeSO e)
    {
        _resourceGUIText[e].SetText(ResourceManager.Instance.GetResource(e).ToString());
      
    }


}
