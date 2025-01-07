using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMeregeDetector : MonoBehaviour
{
    [SerializeField] GameObject _gunFront;
    [SerializeField] GameObject _gunFrontVisual;

    [SerializeField] GameObject _gunBack;

    [SerializeField] GameObject _mergedGun;
    [SerializeField] GameObject _mergedGunVisual;

    AutoShoot shootFront;
    AutoShoot shootBack;
    private void Start()
    {
        _gunFront.TryGetComponent<AutoShoot>(out shootFront);
        _gunBack.TryGetComponent<AutoShoot>(out shootBack);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Gun"))
        {
            shootFront.enabled = false;
            shootBack.enabled = false;

            _gunFrontVisual.SetActive(false);
            _gunBack.SetActive(false);
            _mergedGun.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Gun")) 
        {
            _gunFrontVisual.SetActive(true);
            _gunBack.SetActive(true);
            _mergedGun.SetActive(false);

            shootFront.enabled = true;
            shootBack.enabled = true;
        }
    }
  
}
