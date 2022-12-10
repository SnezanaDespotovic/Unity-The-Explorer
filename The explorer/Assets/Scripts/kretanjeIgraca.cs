using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kretanjeIgraca : MonoBehaviour
{
    public float maxBrzina = 5.0f;
    bool pravacUdesno = true;
    Animator animator;

    public float maxSkok = 200.0f;
    bool naZemlji = true;
    public Transform zemljaTest;
    public LayerMask staJeTlo;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update(){

        if (Input.GetKeyDown(KeyCode.Space)){
            animator.SetBool("zemlja", false);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, maxSkok));
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        naZemlji = Physics2D.OverlapCircle( zemljaTest.position, 0.2f, staJeTlo);
        animator.SetBool("zemlja", naZemlji);

        float ubrzanje = Input.GetAxis("Horizontal");
        //Debug.Log(ubrzanje); opseg vrednosti je od -1 do 1
        GetComponent<Rigidbody2D>().velocity = new Vector2(maxBrzina * ubrzanje, GetComponent<Rigidbody2D>().velocity.y);
        animator.SetFloat("brzina", Mathf.Abs(ubrzanje) );

        if (pravacUdesno && ubrzanje<0){
            PromeniPravac();
        }
        if (!pravacUdesno && ubrzanje>0) {
            PromeniPravac();
        }

    }

    void PromeniPravac(){
        
        pravacUdesno = !pravacUdesno;
        Vector3 GOscale = transform.localScale;
        GOscale.x *= -1;
        transform.localScale = GOscale;
    }
}
