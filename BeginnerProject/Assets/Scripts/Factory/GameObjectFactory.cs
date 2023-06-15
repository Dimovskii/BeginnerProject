using UnityEngine;

namespace Factory
{
    public class GameObjectFactory
    {
        public GameObject Create(GameObject prefab)
        {
            return GameObject.Instantiate(prefab);
        }

        public GameObject CreateView(GameObject prefab, Transform parent)
        {
            var viewPrefab = GameObject.Instantiate(prefab);
            viewPrefab.transform.SetParent(parent);
            viewPrefab.GetComponent<RectTransform>().offsetMax = Vector2.zero;
            return viewPrefab;
        }
    }
}

