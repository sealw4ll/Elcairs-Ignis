using UnityEngine;

public class Scaler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Vector3 getCurrentScale()
    {
        return transform.localScale;
    }

    public void setCurrentScale(Vector3 currentScale)
    {
        transform.localScale = currentScale;
    }
}
