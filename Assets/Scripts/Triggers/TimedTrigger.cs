using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedTrigger : MonoBehaviour {
    public bool TimerAtStart;
    public float timeToTrigger;

    bool isCounting;
    float countStart;

    public UnityEngine.Events.UnityEvent OnTimerUp;


    public float CurrentTimer { get { return (Time.time - countStart); } }

    public bool HasExceededTime { get { return CurrentTimer > timeToTrigger; } }

	void Start () {
        if (TimerAtStart)
            StartTimer();
	}

    public void StartTimer()
    {
        countStart = UnityEngine.Time.time;
        isCounting = true;
    }

    public void CancelTimer()
    {
        isCounting = false;
    }
	
	void Update () {
	    if(isCounting && HasExceededTime)
        {
            isCounting = false;
            OnTimerUp.Invoke();
        }	
	}
}
