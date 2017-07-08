using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTrigger : MonoBehaviour {

    public KeyCode key;

    public UnityEngine.Events.UnityEvent OnKeyPressed;
    public UnityEngine.Events.UnityEvent OnKeyReleased;
	void Update () {
	    if(Input.GetKeyDown(key))
        {
            OnKeyPressed.Invoke();
        }
        if (Input.GetKeyUp(key))
        {
            OnKeyReleased.Invoke();
        }
    }
}
