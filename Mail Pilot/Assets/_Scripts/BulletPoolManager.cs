using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Bonus - make this class a Singleton!

[System.Serializable]
public class BulletPoolManager : MonoBehaviour
{
    public GameObject bullet;
    public int numBullets;
    //TODO: create a structure to contain a collection of bullets
    public Queue<GameObject> bullets = new Queue<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        // TODO: add a series of bullets to the Bullet Pool
        for (int i = 0; i < numBullets; i++)
        {
            GameObject bulletToPool = Instantiate(bullet);
            bulletToPool.transform.parent = GameObject.Find("Bullets").transform;
            bulletToPool.SetActive(false);
            bullets.Enqueue(bulletToPool);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //TODO: modify this function to return a bullet from the Pool
    public GameObject GetBullet()
    {
        GameObject poolToBullet = bullets.Dequeue();
        poolToBullet.SetActive(true);
        return poolToBullet;
    }

    //TODO: modify this function to reset/return a bullet back to the Pool 
    public void ResetBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        bullets.Enqueue(bullet);
    }
}
