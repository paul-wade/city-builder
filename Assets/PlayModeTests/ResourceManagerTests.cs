using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class ResourceManagerTests
    {


        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator ResourceMananger_Awake_ResourceAmounts_HaveCorrectValues()
        {
            // Arrange
            GameObject gameObject = new GameObject();
            gameObject.AddComponent<ResourceManager>();
            var resourceList = Resources.Load<ResourceTypeListSO>(typeof(ResourceTypeListSO).Name);
            yield return null;
            // Act
            //awake has been run.on init.
            var resourceManager = gameObject.GetComponent<ResourceManager>();

            // Assert
            Assert.IsNotNull(resourceManager);
            foreach (var resource in resourceList.list)
            {
                Assert.IsTrue(resourceManager.GetResource(resource) == 0);
            }

            yield return null;
        }

        [UnityTest]
        public IEnumerator ResourceMananger_Update_AddsResourceAmounts()
        {
            // Arrange
            GameObject gameObject = new GameObject();
            var resourceManager = gameObject.AddComponent<ResourceManager>();
            var buildingList = Resources.Load<BuildingTypeListSO>(typeof(BuildingTypeListSO).Name);
            var resourceList = Resources.Load<ResourceTypeListSO>(typeof(ResourceTypeListSO).Name);

            // Act
            foreach (var buildingType in buildingList.buildingTypeList)
            {
                var buildingInstance = GameObject.Instantiate(buildingType.prefab);

                var resourceType = buildingType.resourceGeneratorData.resourceType;
                yield return new WaitForSeconds(1);

                if (buildingType.resourceGeneratorData.timerMax >= 1)
                {
                    // Assert
                    Assert.IsTrue(ResourceManager.Instance.GetResource(resourceType) == buildingType.resourceGeneratorData.timerMax);
                }
                else
                {
                    // Assert
                    Assert.IsTrue(ResourceManager.Instance.GetResource(resourceType) == 1 / buildingType.resourceGeneratorData.timerMax);
                }
            }
             
            yield return null;
        }
    }
}
