//------ Compass Rotate

using UnityEngine;
using UnityEngine.UI;

public class Compass : MonoBehaviour
{
    public Image im_compass;
    private GameObject go_PC;

    void Start()
    {
        go_PC = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        im_compass.rectTransform.eulerAngles = new Vector3(0, 0, go_PC.transform.eulerAngles.y);
    }
}
