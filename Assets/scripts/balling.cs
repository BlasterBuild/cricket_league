using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class balling : MonoBehaviour
{
    public GameObject shootPoint;
    public GameObject projectile;
    public GameObject plane;
    public ParticleSystem clickEffect;
    public float speed;
    private bool fl = true;

    void Start()
    {
        Debug.Log("Start");
        
    }
    private void FlagCheck(bool flag)
    {
        fl = flag;
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0)&&fl)
        {
            Debug.Log("entered");
            Click();
        }
    }
    
    void Click()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("pit"))
            {
                Debug.Log("entered in particle system");
                Instantiate(clickEffect, hit.point += new Vector3(0, 0.1f, 0), clickEffect.transform.rotation);
                Shoot(hit.point);
            }
        }
    }

    IEnumerator ball_pause()
    {
        fl = false;
        yield return new WaitForSeconds(3.5f);
        fl = true;
    }

    void Shoot(Vector3 targetLoc)
    {
        shootPoint.transform.LookAt(targetLoc);
        GameObject go = Instantiate(projectile, shootPoint.transform.position, shootPoint.transform.rotation);
        go.GetComponent<Rigidbody>().AddForce(shootPoint.transform.forward*speed,ForceMode.Impulse);
        StartCoroutine(ball_pause());
    }
    
}
