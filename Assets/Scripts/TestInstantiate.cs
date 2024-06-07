using UnityEngine;

public class TestInstantiate : MonoBehaviour
{
    public GameObject dotPrefab;
    public GameObject dotsParent;

    void Start()
    {
        if (dotPrefab == null || dotsParent == null)
        {
            Debug.LogError("Prefab or Parent is not assigned.");
            return;
        }

        GameObject dotInstance = Instantiate(dotPrefab, dotsParent.transform);
        dotInstance.transform.localScale = Vector3.one * 1f;
        Debug.Log($"Instantiated Dot Scale: {dotInstance.transform.localScale}");
    }
}
