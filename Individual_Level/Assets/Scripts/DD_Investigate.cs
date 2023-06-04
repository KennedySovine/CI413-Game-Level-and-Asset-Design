// ----------------------------------------------------------------------
// -------------------- 3D  Investugate Object
// -------------------- David Dorrington, UoB, 2023
// ----------------------------------------------------------------------
using UnityEngine;
using UnityEngine.UI;

public class DD_Investigate : MonoBehaviour
{
    // ----------------------------------------------------------------------
    public float fl_distance = 4;
    public Color col_highlight = Color.yellow;
    private Color col_original;
    private Transform tf_PC;
    private Renderer rn_attached;

    public GameObject go_message_panel;
    public  Text text_message;
    public string st_message1 = "Press e to Examine";
    public string st_message2 = "You discover ....";
    public string st_message3 = "Nothing to see";

    public bool bl_progress_event;
    public bool bl_release_object;
    public GameObject go_object_to_release;

    private bool bl_activated;

    // ----------------------------------------------------------------------
    // Use this for initialization
    void Start()
    {
        tf_PC = GameObject.FindWithTag("Player").transform;
        rn_attached = GetComponent<Renderer>();
        col_original = rn_attached.material.color;

        // Deactivate release oject
        if (bl_release_object) go_object_to_release.SetActive(false);

    }//-----

    // ----------------------------------------------------------------------
    // Update is called once per frame
    void Update()
    {
        // In trigger distance change colour of object
        if (Vector3.Distance(tf_PC.position, transform.position) < fl_distance)
            rn_attached.material.color = col_highlight;
        else
            rn_attached.material.color = col_original;

        // As we get closer the message appears
        if (Vector3.Distance(tf_PC.position, transform.position) < fl_distance / 2)
        {
            // Turn on Message Panel
            go_message_panel.SetActive(true);

            // only show inital message
            if (!bl_activated)
            {
                // First message
                text_message.text = st_message1;

                if (Input.GetKeyDown("e"))
                {   // Second message
                    text_message.text = st_message2;
                    bl_activated = true;

                    // Release object if set
                    if (bl_release_object) go_object_to_release.SetActive(true);
                   
                }
            }
        }
        else if (Vector3.Distance(tf_PC.position, transform.position) < fl_distance + 1)
        {
            go_message_panel.SetActive(false);
            text_message.text = st_message3;
        }

    }//-----


}//==========
