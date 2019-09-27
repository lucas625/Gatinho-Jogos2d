using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBound : MonoBehaviour
{
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
   {
       if (other.GetComponent<Cat>() != null)
       {
           other.GetComponent<Cat>().ResetSpeed();
       }
   }
}
