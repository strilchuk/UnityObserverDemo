using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineTest : MonoBehaviour
{
    public bool hasPowerup;
    // Start is called before the first frame update
    void Start()
    {
        hasPowerup = true;
        StartCoroutine(PowerupCountdownRoutine());
        StartCoroutine(StopAllCorout());
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    IEnumerator PowerupCountdownRoutine() {
        for (int i = 3; i > 0; i--)
        {
            print($"waiting for {i}...");
            yield return new WaitForSeconds(1);
        }
       
        for (;;)
        {
            print($"has powerup: {hasPowerup}");
            yield return new WaitForSeconds(7);
            hasPowerup = !hasPowerup; 
        }
    }
    
    IEnumerator StopAllCorout() {
        yield return new WaitForSeconds(30);
        StopAllCoroutines();
    }    
}
