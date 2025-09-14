using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class particle : MonoBehaviour
{
    public ParticleSystem particle_;
    public GameObject chracter;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = chracter.GetComponent<Animator>();
        StartCoroutine(DelayedParticle());
    }


    IEnumerator DelayedParticle()
    {
        yield return new WaitForSeconds(1f);
        particle_.Play();
        chracter.SetActive(true);

        yield return new WaitForSeconds(2f);
        animator.SetBool("run", true);
        GameManager.instance.paradox = true;
    }

}
