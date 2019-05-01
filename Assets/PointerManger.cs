using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerManger : MonoBehaviour
{
    public Transform canvas;//画布
    public LayerMask textureShouleBeChange;//要改变贴图的物体
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
            if (Input.GetAxis("Mouse X") == 0 && Input.GetAxis("Mouse Y") ==0)
            {
                timer += Time.deltaTime;
            }

            //调出按钮
            if (timer > xuanTingTime && instantiatedButton == null)
            {
                instantiatedButton = Instantiate(buttonToChange);//初始化按钮
                instantiatedButton.transform.SetParent(canvas.transform, false);//作为画布的子集

                instantiatedButton.GetComponent<ButtonToChange>().Init(hit.collider.gameObject);
            }

        }
        else{
            timer=0;
        }

    }
}
