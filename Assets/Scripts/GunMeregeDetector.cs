using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMeregeDetector : MonoBehaviour
{
    [SerializeField] AutoShoot _gunFront;
    [SerializeField] AutoShoot _gunBack;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Gun"))
        {
            _gunBack.enabled = false;
            _gunFront.enabled = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Gun")) 
        {
            _gunFront.enabled = true;
            _gunBack.enabled = true;
        }
    }
  
}
