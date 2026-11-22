using UnityEngine;

public class LeaveParent : MonoBehaviour
{
    private void Start()
    {
        transform.SetParent(null);
    }
}
