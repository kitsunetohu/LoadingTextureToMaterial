using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonToChange : MonoBehaviour
{
    GameObject objectBeChange;
    Button button;
    RectTransform recTrans;
    public Vector2 offset;//How much higher is button higher than object;


    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (objectBeChange != null)
        {
            freshenTransform();
        }

    }

    public void Init(GameObject go)
    {
        Destroy(this.gameObject, 3.0f);
        objectBeChange = go;
        button = GetComponent<Button>();
        button.onClick.AddListener(() => OpenFile.instance.OpenAndChangeTex(objectBeChange, this));
        recTrans = GetComponent<RectTransform>();
        freshenTransform();
    }

    void freshenTransform()
    {
        Vector3 tarPos = objectBeChange.transform.position;
        Vector2 pos = RectTransformUtility.WorldToScreenPoint(Camera.main,tarPos );
        Debug.Log(pos + offset);
        recTrans.position = pos + offset;
    }
}
