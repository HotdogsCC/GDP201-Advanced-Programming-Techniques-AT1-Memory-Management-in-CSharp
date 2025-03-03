using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHandler : BaseMonoBehaviour
{
    [SerializeField] private float projectileSpeed;
    // Start is called before the first frame update
    
    private float lifeTime = 8;
    private float lifeTimer = 0;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * projectileSpeed);
        lifeTimer += Time.deltaTime;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        //If projectile hit the enemy return it to the pool
        if (other.CompareTag("Enemy"))
        {
            ObjectPool.Get().ReturnToPool(other.gameObject);
            Destroy(gameObject);
        }
    }

    
    public bool ShouldBeDestroyed()
    {
        return lifeTimer >= lifeTime; //Lets the turret know the bullet needs to be destroyed
    }
}
