// ----------------------------------------------------------------------
// -------------------- NPC Talkie
// -------------------- David Dorrington, 22
// ----------------------------------------------------------------------


using UnityEngine;
using UnityEngine.UI;

public class DD_NPC_Talker : MonoBehaviour
{
    // ----------------------------------------------------------------------
    public string[] st_message;
    public float fl_distance = 2;
    private GameObject go_PC;
    private GameObject go_message_panel;
    private Text txt_window;
    private int in_message_stage;
    public bool bl_release_object;
    public GameObject go_release_object;


    // ----------------------------------------------------------------------
    // Start is called before the first frame update
    void Start()
    {
        /// Set initial states and find objects -- The UI object atttached to Game Manager
        go_PC = GameObject.FindWithTag("Player");
        go_message_panel = GameObject.Find("GameManager").transform.Find("SmallMessagePanel").gameObject;
        txt_window = go_message_panel.transform.Find("SmallMessageText").GetComponent<Text>();

        if (bl_release_object && go_release_object) go_release_object.SetActive(false);

    }//-----

    // ----------------------------------------------------------------------
    // Update is called once per frame
    void FixedUpdate()
    {
        ShowMessage();
        DropObject();

    }//-----

    // ----------------------------------------------------------------------
    private void ShowMessage()
    {
        // Is PC in range?
        if (Vector3.Distance(go_PC.transform.position, transform.position) < fl_distance)
        {
            // Enable message panel
            if (!go_message_panel.activeInHierarchy) go_message_panel.SetActive(true);

            // Step through Message
            if (Input.GetKeyDown(KeyCode.E))
                if (st_message.Length > 1 && (in_message_stage < st_message.Length - 1))
                    in_message_stage++;

            // Update the UI text
            txt_window.text = st_message[in_message_stage];
        }
        else if (go_PC && Vector3.Distance(go_PC.transform.position, transform.position) < fl_distance + 1)
        {
            go_message_panel.SetActive(false);
        }
    }//-----

    // ----------------------------------------------------------------------
    private void DropObject()
    {
        if (bl_release_object && in_message_stage >= st_message.Length - 1)
        {
            go_release_object.SetActive(true);
            bl_release_object = false;
        }
    }//----


}//========