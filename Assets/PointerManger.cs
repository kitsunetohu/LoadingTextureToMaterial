using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerManger : MonoBehaviour
{
    public Transform canvas;
    public LayerMask textureShouleBeChange;
    public GameObject buttonToChange;
    public float xuanTingTime = 0.3f;
    float timer;
    GameObject instantiatedButton;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 10000, textureShouleBeChange))
        {
            timer+=Time.deltaTime;
            //调出按钮
            if (timer > xuanTingTime&&instantiatedButton==null)
            {  // timer=0;//计时器复位
                instantiatedButton=Instantiate(buttonToChange);//初始化按钮
                instantiatedButton.transform.SetParent(canvas.transform,false);//作为画布的子集
                
                instantiatedButton.GetComponent<ButtonToChange>().Init(hit.collider.gameObject);

                
                //告诉按钮悬停了哪个物体
            }

        }
        
    }
}
