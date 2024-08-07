using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class for_ball : MonoBehaviour
{
    public GameObject dist;
    public ParticleSystem re;
    public GameObject lb;
    public GameObject rb;
    private GameObject[] f_stump;
    private AudioSource audiosource;
    private Rigidbody ball_rg;
    private bool flag = true;
    public GameObject targetObject;
    private balling balling_refrence;
    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
        ball_rg = GetComponent<Rigidbody>();
        balling_refrence = targetObject.GetComponent<balling>();
    }

    void Update()
    {
        if (gameObject.transform.position.z < dist.transform.position.z )
        {
            
            Destroy(gameObject);
        }
        
    }
    IEnumerator scenereset()
    {
        flag = false;
        
        Debug.Log("courotine starteed");
        yield return new WaitForSeconds(3.0f);
        Debug.Log("after 3 seconds");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        flag = true;
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.CompareTag("pit") && !collision.collider.CompareTag("ground"))
        {
            
            ball_rg.useGravity = true;
            ball_rg.mass = 1000.0f;
            audiosource.Play();
            f_stump = GameObject.FindGameObjectsWithTag(collision.gameObject.tag);
            foreach(GameObject st in f_stump)
            {
                Rigidbody rigidbody = st.GetComponent<Rigidbody>();
                if(rigidbody == null)
                {
                    rigidbody = st.AddComponent<Rigidbody>();

                    rigidbody.mass = 1.0f;
                    rigidbody.useGravity = true;
                    
                }
                Rigidbody rg_lb = lb.GetComponent<Rigidbody>();
                Rigidbody rg_rb = rb.GetComponent<Rigidbody>();
                if(rg_lb == null)
                {
                    Rigidbody lb_rigidbody = lb.AddComponent<Rigidbody>();
                   
                    lb_rigidbody.mass = 1.0f;
                    lb_rigidbody.useGravity = true;

                    
                }
                if (rg_lb == null)
                {
                   
                    Rigidbody rb_rigidbody = rb.AddComponent<Rigidbody>();
                   

                    rb_rigidbody.mass = 1.0f;
                    rb_rigidbody.useGravity = true;
                }
            }
            StartCoroutine(scenereset());
        }
    }
}
