using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class enemy : MonoBehaviour {
    public int health;
    public Animator spriteAnim;
    public Transform actionPoint;
    public bool inAttackMode;
    bool dead = false;
    NavMeshAgent agent;

    public audioGroupRandomizer audiorandom;

    public IEnumerator what() {
        yield return new WaitForSeconds(0.5f+Random.value);
        audiorandom.playAudio();

 }
    public void provoked(bool playsound=true) {
        inAttackMode = true;
        if(playsound)
        StartCoroutine(what());
        
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(follow());
    }
    IEnumerator follow() {
        
        yield return new WaitForSeconds(1);
        if (!dead && GameObject.FindGameObjectWithTag("Player")!=null)
        {

            Vector3 pos = GameObject.FindGameObjectWithTag("Player").transform.position - new Vector3(0,-1,0);

            agent.SetDestination(pos);
            StartCoroutine(follow());
        }
    }
    public void gethit(Vector3 position, Vector3 direction)
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 20);

        if (dead) return;
        int i = 0;
        while (i < hitColliders.Length)
        {
            if (hitColliders[i].tag == "enemy")
            {
                if (!hitColliders[i].GetComponent<enemy>().inAttackMode)
                    hitColliders[i].GetComponent<enemy>().provoked(false);
            }
            i++;
        }
        if (!spriteAnim.GetCurrentAnimatorStateInfo(0).IsName("hit"))
        {
            health -= 1;
            if (health > 0)
            {
                spriteAnim.SetTrigger("hit");
                GetComponent<Rigidbody>().AddForceAtPosition(direction * 200, position, ForceMode.Impulse);
            }
            else
            {
                agent.isStopped = true;
                spriteAnim.SetTrigger("die");
                dead = true;
                transform.parent.GetComponent<enemyCounter>().reduce();
                GetComponent<Rigidbody>().AddForceAtPosition((transform.up+direction/5) * 500, position, ForceMode.Impulse);
                GetComponent<CapsuleCollider>().height = 0.1f;
                GetComponent<CapsuleCollider>().radius = 0.2f;

            }

           
        }
    }
    
    bool scanIfPlayerInHitBox(float radius)
    {
        bool ret = false;
        Collider[] hitColliders = Physics.OverlapSphere(actionPoint.position, radius);
        int i = 0;
        while (i < hitColliders.Length)
        {
            if (hitColliders[i].tag == "Player")
            {
                ret = true;
                break;
            }
            i++;
        }
        if (spriteAnim.GetCurrentAnimatorStateInfo(0).IsName("hit")) ret = false;
        return ret;
    }
    IEnumerator playerPosCheck() {
        yield return new WaitForSeconds(1);
        if (inAttackMode && !dead)
        {
            if (scanIfPlayerInHitBox(2)) {
                if (!spriteAnim.GetCurrentAnimatorStateInfo(0).IsName("attack"))
                {
                    spriteAnim.SetTrigger("attack");
                    StartCoroutine(punch());
                }
            }
        }
        StartCoroutine(playerPosCheck());
    }
    IEnumerator punch() {
        yield return new WaitForSeconds(0.3f);
        if (scanIfPlayerInHitBox(1)) { GameObject.FindGameObjectWithTag("Player").GetComponent<attackCheck>().playerGetHit(); }
    }
	// Use this for initialization
	void Start () {
        StartCoroutine(playerPosCheck());
    }
	
	// Update is called once per frame
	void Update () {
        if (GetComponent<NavMeshAgent>().velocity.magnitude > 0.2f) {
            spriteAnim.SetFloat("speed", 1);
        }
        else
        {
            spriteAnim.SetFloat("speed", 0);
        }
	}
}
