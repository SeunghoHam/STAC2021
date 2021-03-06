using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public IEnumerator Shake(float duration, float magnitude)
   {
       Vector3 originPos = transform.localPosition;

       float elapsed = 0.0f;

       while(elapsed < duration)
       {
           float x = Random.Range(-110f, 110f) * magnitude;
           float y = Random.Range(-110f, 110f) * magnitude;

           transform.position= new Vector3(x,y, originPos.z);


        elapsed += Time.deltaTime;
        yield return null;
       }

       transform.localPosition= originPos;
   }
}
