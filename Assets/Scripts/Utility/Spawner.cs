using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject ObjectToSpawn;
    [Space]
    public Vector3 spawnDistance;
    public bool isSpawnDistanceLocal;

    public bool shouldShoot;
    public bool isDirectionLocal;
    public Vector3 shootingDirection;
    public float shootingSpeed = 1;
    
    public Vector3 TrueSpawnDistance { get { return isSpawnDistanceLocal? transform.TransformVector(spawnDistance) : spawnDistance; } }
    public Vector3 SpawnPosition { get { return transform.position + TrueSpawnDistance; } }

    public Vector3 TrueShootDirection { get { return (isDirectionLocal ? transform.TransformVector(spawnDistance) : spawnDistance).normalized; } }
    public Vector3 ShootingVector { get { return TrueShootDirection * shootingSpeed; } }

    public UnityEngine.Events.UnityEvent OnSpawn;

    public void Spawn()
    {
        var obj = GameObject.Instantiate(ObjectToSpawn, SpawnPosition, ObjectToSpawn.transform.rotation);

        if (shouldShoot)
        {
            var body = obj.GetComponent<Rigidbody>();
            Debug.Assert(body != null, "Prefab should have rigidbody to be shot");

            body.velocity = ShootingVector;
        }
        OnSpawn.Invoke();
    }
   

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(SpawnPosition, .3f);
        if (shouldShoot)
        {
            Gizmos.DrawLine(SpawnPosition, SpawnPosition + TrueShootDirection * shootingSpeed);
        }
    }
}
