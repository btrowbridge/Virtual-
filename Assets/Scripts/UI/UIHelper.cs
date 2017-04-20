using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


namespace SmartHome.UI
{
    public static class UIHelper
    {

        public static void PopulateList(string listName, List<string> itemNames, GameObject prefab)
        {
            var currentList = GameObject.Find(listName);
            PopulateList( currentList,  itemNames,  prefab);
        }

        public static void PopulateList(GameObject currentList, List<string> itemNames, GameObject prefab)
        {
            var contentObject = currentList.GetComponentInChildren<VerticalLayoutGroup>();
            var content = contentObject.transform;
            for (int i = 0; i < content.childCount; i++)
            {
                GameObject.Destroy(content.GetChild(i).gameObject);
            }
            var toggleGroup = content.GetComponent<ToggleGroup>();
            foreach (string name in itemNames)
            {
                var instance = GameObject.Instantiate(prefab, content);
                instance.GetComponentInChildren<Text>().text = name;
                instance.GetComponentInChildren<Toggle>().group = toggleGroup;
            }

        }

        public static void PopulateList(string listName, List<string> itemNames)
        {
            var prefab = Resources.Load<GameObject>("ListComponent");
            PopulateList(listName, itemNames, prefab);

        }

        public static void PopulateList(GameObject list, List<string> itemNames)
        {
            var prefab = Resources.Load<GameObject>("ListComponent");
            PopulateList(list, itemNames, prefab);

        }

        public static List<string>GetSelectedNames(GameObject list)
        { 
            var currentList = list.GetComponentInChildren<VerticalLayoutGroup>();

            var toggles = currentList.GetComponentsInChildren<Toggle>().ToList().Where(tog => tog.IsActive());

            List<string> active = new List<string>();
            List<Toggle> activeToggles = new List<Toggle>(toggles);

            activeToggles.ForEach(
                tog => active.Add(tog.GetComponentInChildren<Text>().text));

            return active;
        }
    }
}