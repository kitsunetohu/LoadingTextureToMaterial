using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonToChange : MonoBehaviour
{   
    GameObject objectBeChange;
    Button button;

    public float offset;//How much higher is button higher than object;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this,3.0f);
        button=GetComponent<Button>();
        button.onClick.AddListener(() => OpenFile.instance.OpenAndChangeTex(objectBeChange));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init(GameObject go){
        objectBeChange=go;
    }
}
