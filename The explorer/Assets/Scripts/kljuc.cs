using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class kljuc : MonoBehaviour
{
    // Start is called before the first frame update
    private BrojacKljuceva brojacKljuceva;
    void Awake(){

        brojacKljuceva = GameObject.Find("brojKljuceva").GetComponent<BrojacKljuceva>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    
    
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag=="Player"){
            brojacKljuceva.brojac++;
            gameObject.SetActive(false);
        }
    }
}
