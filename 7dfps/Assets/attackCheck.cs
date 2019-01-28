using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class attackCheck : MonoBehaviour {
    public GameObject currentWeapon;
    public Transform actionPoint;
    public GameObject whiteout;
    public UnityEvent tauntEvent;
    public UnityEvent gethitEvent;
    public levelstart starter;
    public Text kuosi;
    public Text kaljaa;
    public GameObject cam;
    // Use this for initialization
    int health = 100;
    public drunkCam drunk;
    public void kalia() { drunk.kanni = drunk.kanni+1; addToHealth(15); }
    public void addToHealth(float value) {
        health += Mathf.RoundToInt(value);
        if (health > 100) health = 100;
    }
    public void playerGetHit() {
        health -= Mathf.RoundToInt(10 + 10* Random.value-drunk.kanni*2);
        if (health > 0)
            StartCoroutine(flash());
        else
        {
            whiteout.SetActive(true);
            cam.SetActive(true);
            gameObject.SetActive(false);
            starter.dead = true;
        }
    }
    void provoke()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position+ (transform.forward*8), 7);
        int i = 0;
        while (i < hitColliders.Length)
        {
            if (hitColliders[i].tag == "enemy")
            {
                if(!hitColliders[i].GetComponent<enemy>().inAttackMode)
                hitColliders[i].GetComponent<enemy>().provoked();
            }
            i++;
        }
    }
    IEnumerator flash() {
        whiteout.SetActive(true);
        yield return new WaitForSeconds(.2f);
        whiteout.SetActive(false);
    }

    IEnumerator taunt() {
        yield return new WaitForSeconds(0.5f);
        if (currentWeapon.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("fistbird"))
        {
            tauntEvent.Invoke();
            provoke();
        }

}
// Update is called once per frame
void Update () {
        kuosi.text = "kuosi: " + health.ToString();
        if(drunk.kanni==1) kaljaa.text = drunk.kanni.ToString() + " kalja";
        else kaljaa.text = drunk.kanni.ToString() + " kaljaa";
        if (Input.GetButtonDown("Fire1")) { currentWeapon.GetComponent<Animator>().SetTrigger("attack");
            Collider[] hitColliders = Physics.OverlapSphere(actionPoint.position, .5f);
            int i = 0;
            while (i < hitColliders.Length)
            {
                if(hitColliders[i].tag=="enemy")
                {
                    hitColliders[i].GetComponent<enemy>().gethit(transform.position,transform.forward);
                    break;
                }
                i++;
            }

        }

        if (Input.GetButtonDown("Fire2")) { currentWeapon.GetComponent<Animator>().SetTrigger("bird");
            StartCoroutine(taunt());
            provoke(); }
    }

}
