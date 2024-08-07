using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class part_destory : MonoBehaviour
{
    // Start is called before the first frame update
    private ParticleSystem pt_ref;

    private void Start()
    {
        pt_ref = GetComponent<ParticleSystem>();
        Invoke("DestroyParticleSystem", pt_ref.main.duration);
    }

    void DestroyParticleSystem()
    {
        Destroy(pt_ref.gameObject);
    }
    
}
