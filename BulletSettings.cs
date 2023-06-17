using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletSettings : MonoBehaviour
{
    [SerializeField] private int bulletDamage = 20;
    private ZombieStats enemy = null;
    [SerializeField] private GameObject bloodPS = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided");

        if (collision.gameObject.tag == "enemy")
        {
            enemy = collision.gameObject.GetComponent<ZombieStats>();
            enemy.TakeDamage(bulletDamage);
            SpawnBlood(transform.position);
            Debug.Log("Enemy damage dealt");
            Destroy(gameObject);
        }
    }

    private void SpawnBlood(Vector3 position)
    {
        Instantiate(bloodPS, position, new Quaternion(0,0,0,0));
    }

}
