using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CounterTrigger : MonoBehaviour {
    private int Counter = 0;

    public int Target = 5;
    public bool trigersMultipleTimes = false;
    bool done = false;
    public UnityEvent OnCounterReached;
    

    public void Add(int number)
    {
        Debug.Assert(number > 0, "Number must be greater than");
        Counter += number;
        if (Counter >= Target)
            CounterReached();
    }

    public void Subtract(int number)
    {
        Debug.Assert(number > 0, "Number must be greater than zero");
        Counter -= number;
    }

    public void AddOne()
    {
        Add(1);
    }
    public void SubractOne()
    {
        Subtract(1);
    }

    public void ResetCounter()
    {
        Counter = 0;
    }

    private void CounterReached()
    {
        if (done)
            return;
        done = true;
        Counter = 0;
        OnCounterReached.Invoke();
        if (trigersMultipleTimes)
        {
            ResetCounter();
            done = false;
        }
    }
}
