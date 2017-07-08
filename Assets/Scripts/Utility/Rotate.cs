using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {
    public Vector3 axis;
    [Space()]

    public bool randomSpeed;
    public AnimationCurve speedDistribution;
    [Range(-360, 360)]
    public float baseSpeed;
    [Space()]
    public bool randomStart;
	void Start () {
        if (randomSpeed)
            baseSpeed = speedDistribution.Evaluate(Random.value) * baseSpeed;
        if (randomStart)
            transform.Rotate(axis, Random.Range(0, 360));
	}
	
	void Update () {
        transform.Rotate(axis, baseSpeed * Time.deltaTime);
	}
}
