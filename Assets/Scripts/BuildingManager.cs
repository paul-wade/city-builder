using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    [SerializeField] private BuildingTypeSO buildingType;

    private Camera _mainCamera;
    private BuildingTypeListSO _buildingTypeList;
    private BuildingTypeSO _buildingType;

    private void Awake()
    {
        _buildingTypeList = Resources.Load<BuildingTypeListSO>(typeof(BuildingTypeListSO).Name);
        _buildingType = _buildingTypeList.buildingTypeList[0];
    }

    // Start is called before the first frame update
    void Start()
    {
        _mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(_buildingType.prefab, GetMouseWorldPosition(), Quaternion.identity);
        }

        if (Input.GetKeyUp(KeyCode.T))
        {
            GetNextBuilding();
        }

    }

    private Vector3 GetMouseWorldPosition()
    {
        var mouseWorldPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0f;
        return mouseWorldPosition;
    }

    private void GetNextBuilding()
    {
        var currentIndex = _buildingTypeList.buildingTypeList.IndexOf(_buildingType);
        if (currentIndex + 1 < _buildingTypeList.buildingTypeList.Count)
        {
            _buildingType = _buildingTypeList.buildingTypeList[currentIndex + 1];
        }
        else
        {
            _buildingType = _buildingTypeList.buildingTypeList[0];
        }

    }
}
