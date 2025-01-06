using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveToTargetFixed : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] float speed = 1f;
    [Tooltip("Lifesan in seconds (safety net)")][SerializeField] float lifeSpan = 100f;
    float currentLifeSpan;


    // Start is called before the first frame update
    private void OnEnable()
    {
        currentLifeSpan = lifeSpan;
        transform.LookAt(target.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        // safety net destroy object shouild never trigger
        currentLifeSpan -= Time.deltaTime;
        if (currentLifeSpan <= 0)
        {
            Destroy(gameObject);
        }
        //move towartds target
        transform.Translate(speed * Time.deltaTime * Vector3.forward);
    }
    public void SetTarget(GameObject _target) => target = _target;
}
