using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GubljenjeZivota : MonoBehaviour
{
    private BrojacZivota brojacZivota;
    public Transform igrac;

    void Awake() {
        brojacZivota=GameObject.Find("brojZivota").GetComponent<BrojacZivota>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag=="Player"){
            Smrt();
        }
    }
    public void Smrt(){
        brojacZivota.brojZivota--;
        igrac.transform.position=new Vector3(-7.56f, -0.72f, -3.481193f);
        if (brojacZivota.brojZivota==0){
            SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
        }

    }
}
