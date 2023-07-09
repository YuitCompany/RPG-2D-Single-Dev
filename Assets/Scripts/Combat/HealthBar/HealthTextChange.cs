using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthTextChange : MonoBehaviour
{
    [SerializeField] float _alive_time;

    void Start()
    {
        StartCoroutine(MoveTopRoutine(_alive_time));
    }

    private IEnumerator MoveTopRoutine(float moveTime)
    {
        while (moveTime >= 0)
        {
            moveTime -= Time.deltaTime;
            this.transform.position += Vector3.up * Time.deltaTime;
            // While Load Time Code
            yield return null;
        }
        // After Load Time Code
        StartCoroutine(DestoyTextRoutine(moveTime));
    }
    private IEnumerator DestoyTextRoutine(float aliveTime)
    {
        yield return new WaitForSeconds(aliveTime);
        // After Delay Time Code

        Destroy(this.gameObject);
    }
}
