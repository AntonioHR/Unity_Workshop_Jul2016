using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTouchTrigger : MonoBehaviour {
    public string TagToCheck;

    public UnityEngine.Events.UnityEvent OnTouch;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag(TagToCheck))
        {
            OnTouch.Invoke();
        }
    }
}
