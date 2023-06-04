// ----------------------------------------------------------------------
// -------------------- 3D Drop Bomb
// -------------------- David Dorrington, UoB, 2023
// ----------------------------------------------------------------------
using UnityEngine;

public class DD_Drop_Bomb : MonoBehaviour
{

    // Bombs
    public int in_bombs = 5;
    public int in_max_bombs = 5;
    public float fl_bomb_cooldown = 5;
    private float fl_next_bomb_time = 0;
    public float fl_push_force = 2;
    public GameObject go_bomb;

    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && Time.time > fl_next_bomb_time)
        {
            print("drop bomb");

            GameObject _go_bomb = Instantiate(go_bomb, transform.position + transform.TransformDirection(new Vector3(0, 0f, 1.5F)), transform.rotation);
            fl_next_bomb_time = Time.time + fl_bomb_cooldown;


            // Add Force
            _go_bomb.GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(0f, 0f, fl_push_force));

        }
    }       
}
