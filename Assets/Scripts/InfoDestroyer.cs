using UnityEngine;

public class InfoDestroyer : MonoBehaviour
{

	public int lifeTime = 5;
	
    void Awake()
    {
		 Destroy (gameObject, lifeTime);
    }
}
