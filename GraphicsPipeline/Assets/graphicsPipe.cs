using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class graphicsPipe : MonoBehaviour
{
    GameObject myLetter_GO;
    Modle myLetter;

    // Start is called before the first frame update
    void Start()
    {
        myLetter = new Modle();
        myLetter_GO = myLetter.CreateUnityGameObject();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
