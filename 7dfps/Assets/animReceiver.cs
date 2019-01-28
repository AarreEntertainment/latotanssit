using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class animReceiver : MonoBehaviour {
    public UnityEvent beerEv;
    public UnityEvent ufoEv;
    public void beer() { beerEv.Invoke(); }
    public void ufo() { ufoEv.Invoke(); }
}
