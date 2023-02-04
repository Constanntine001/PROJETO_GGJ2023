using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class DayScript : MonoBehaviour
{

    public UnityEvent passDay;
    public UnityEvent endGame;
    public static int dayLimit = 3;
    public int dayCounter = 0;

    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    void passDayEvent() {
        if (dayCounter <= dayLimit) {
            dayCounter++;
        } else {
            endGame.Invoke();
        }
        passDay.Invoke();
    }
}
