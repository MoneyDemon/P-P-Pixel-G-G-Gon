using UnityEngine;

public class Spiningsping : MonoBehaviour
{
   
    void Update()
    {
        transform.Rotate(0f, 0f, 100f * Time.deltaTime);
    }
}
