using UnityEngine;

public class Trajectory : MonoBehaviour
{
    [SerializeField] int dotsNumber = 10;
    [SerializeField] GameObject dotsParent;
    [SerializeField] GameObject dotPrefab;
    [SerializeField] float dotSpacing = 0.1f;
    [SerializeField][Range(0.01f, 0.3f)] float dotMinScale = 0.1f;
    [SerializeField][Range(0.3f, 1f)] float dotMaxScale = 1f;

    Transform[] dotsList;

    Vector2 pos;
    float timeStamp;

    void Start()
    {
        if (dotsParent == null || dotPrefab == null)
        {
            Debug.LogError("Dots parent or dot prefab is not assigned.");
            return;
        }

        // Hide trajectory at the start
        Hide();

        // Prepare dots
        PrepareDots();
    }

    void PrepareDots()
    {
        dotsList = new Transform[dotsNumber];
        dotPrefab.transform.localScale = Vector3.one * dotMaxScale;

        float scale = dotMaxScale;
        float scaleFactor = scale / dotsNumber;

        for (int i = 0; i < dotsNumber; i++)
        {
            dotsList[i] = Instantiate(dotPrefab, dotsParent.transform).transform;
            dotsList[i].localScale = Vector3.one * scale;

            if (scale > dotMinScale)
                scale -= scaleFactor;
        }
    }

    public void UpdateDots(Vector3 ballPos, Vector2 forceApplied)
    {
        timeStamp = dotSpacing;
        for (int i = 0; i < dotsNumber; i++)
        {
            pos.x = (ballPos.x + forceApplied.x * timeStamp);
            pos.y = (ballPos.y + forceApplied.y * timeStamp) - (Physics2D.gravity.magnitude * timeStamp * timeStamp) / 2f;

            dotsList[i].position = pos;
            timeStamp += dotSpacing;
        }
    }

    public void Show()
    {
        Debug.Log("Showing trajectory.");
        dotsParent.SetActive(true);
    }

    public void Hide()
    {
        Debug.Log("Hiding trajectory.");
        dotsParent.SetActive(false);
    }
}
