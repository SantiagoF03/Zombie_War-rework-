using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public  class Pool : MonoBehaviour
{
    public static List<GameObject> Pooling = new List<GameObject>();
    
    //  spawner //
    private static Spawner<GameObject> _spawner = new Spawner<GameObject>();

    public static GameObject RemovedGameObject(GameObject remove)
    {
        Pooling.Add(remove);
        remove.gameObject.SetActive(false);
        return remove;
    }

    public static void ZombieInstance(GameObject zombie, Vector3 transformPosition, quaternion identity, Transform parent)
    {
        bool isHaveZombieInPool = false;
        bool isInstanceZombie = false;
        if (!isHaveZombieInPool)
        {
            foreach (var zGameObject in Pooling)
            {
                Debug.Log("entre al foreach");
           
            
                if (zGameObject.tag  == zombie.tag)
                {
                    if (zGameObject.activeSelf == false)
                    {
                        isHaveZombieInPool = true;
                        zGameObject.SetActive(true);
                        zGameObject.transform.position = transformPosition;
                        zGameObject.transform.rotation = identity;
                        zGameObject.transform.SetParent(parent);
                        zGameObject.GetComponent<HealthController>().Revive();
                        isInstanceZombie = true;
                    }

                }
            }
            if (!isHaveZombieInPool)
            {
                GameObject zombies = _spawner.Create(zombie);
                zombies.transform.position = transformPosition;
                zombies.transform.rotation = identity;
                zombies.transform.SetParent(parent);
                zombies.GetComponent<HealthController>().Revive();
                isInstanceZombie = true;

            }
        }
    }
}
