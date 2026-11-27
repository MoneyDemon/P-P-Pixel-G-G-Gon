using UnityEngine;

public class WallHealth : MonoBehaviour
{
    public float _health;
    

   
    void Update()
    {
        if(_health <= 0)
        {
            Destroy(gameObject);
        }
    }

    
}
