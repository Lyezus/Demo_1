using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMeregeDetector : MonoBehaviour
{
    [SerializeField] GameObject _gunFront;
    [SerializeField] GameObject _gunFrontVisual;

    [SerializeField] GameObject _gunBack;
    [SerializeField] GameObject _gunBackVisual;

    [SerializeField] GameObject _mergedGun;


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
            shootFront.Shoot = false;
            shootBack.Shoot = false;

            _gunFrontVisual.SetActive(false);
            _gunBackVisual.SetActive(false);

            _mergedGun.SetActive(true);

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Gun")) 
        {
            _mergedGun.SetActive(false);

            _gunFrontVisual.SetActive(true);
            _gunBackVisual.SetActive(true);

            shootFront.Shoot = true;
            shootBack.Shoot = true;
        }
    }
  
}
