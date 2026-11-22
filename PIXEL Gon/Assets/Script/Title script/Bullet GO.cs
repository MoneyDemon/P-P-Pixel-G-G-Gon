using UnityEngine;

public class BulletGO : MonoBehaviour
{

    void Update()
    {
        transform.position += new Vector3(10f * Time.deltaTime, 0f, 0f);
    }
}
