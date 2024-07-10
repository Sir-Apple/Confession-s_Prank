using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnButton : MonoBehaviour, IPointerEnterHandler
{
    public GameObject prefabToSpawn;
    public RectTransform panelRectTransform;

    public float minX = 60f; // Adjust these values according to your desired range
    public float maxX = 800f;
    public float minY = 30f;
    public float maxY = 400f;

    void Start()
    {
        // Assign the RectTransform of your panel
        panelRectTransform = GetComponentInChildren<RectTransform>(); // Assumes the panel is a child of the object this script is attached to
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        SpawnPrefab();
    }

    public void SpawnPrefab()
    {
        if (prefabToSpawn != null && panelRectTransform != null)
        {
            // Get a random position within the specified range
            Vector2 randomPosition = new Vector2(
                Random.Range(minX, maxX),
                Random.Range(minY, maxY)
            );

            // Instantiate the prefab at the random position
            GameObject spawnedPrefab = Instantiate(prefabToSpawn, randomPosition, Quaternion.identity);

            // Parent the spawned prefab to the panel
            spawnedPrefab.transform.SetParent(panelRectTransform);

            // Copy the components and scripts from the original prefab to the spawned prefab
            CopyComponents(prefabToSpawn, spawnedPrefab);

            DestroyOnHover destroyOnHover = spawnedPrefab.AddComponent<DestroyOnHover>();
        }
        else
        {
            Debug.LogError("Prefab or Panel RectTransform not assigned.");
        }
    }

    void CopyComponents(GameObject source, GameObject target)
    {
        // Copy components from source to target
        foreach (var component in source.GetComponents<Component>())
        {
            // Exclude Transform and the script itself to avoid conflicts
            if (!(component is Transform) && !(component is SpawnButton))
            {
                UnityEditorInternal.ComponentUtility.CopyComponent(component);
                UnityEditorInternal.ComponentUtility.PasteComponentAsNew(target);
            }
        }
    }
}
