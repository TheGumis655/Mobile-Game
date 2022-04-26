using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Mob_Spawn_Area0Spawning_Enemies : MonoBehaviour
{

    public int Max_Enemies_In=1;
    
    public GameObject Mob_To_Spawn;
    public Rigidbody2D Area_To_Spawn_In;
    public float Time_Beetwen_Trying_To_Spawn=1;
    public float Speed=1;
    public float OffsetX = 1;
    public float OffsetY = 1;


    public List<GameObject> enemies;
    public List<Vector3> point_to_move_towards;

    Rigidbody2D Mob_RigidBody;

    void Start()
    {
        
        Mob_RigidBody = Mob_To_Spawn.GetComponent<Rigidbody2D>();
        StartCoroutine(Spawning());

        for (int a = 0; a < Max_Enemies_In; a++)
        {
           point_to_move_towards.Add(new Vector3(Random.Range(Area_To_Spawn_In.transform.position.x - OffsetX, Area_To_Spawn_In.transform.position.x + OffsetX),
            Random.Range(Area_To_Spawn_In.transform.position.y - OffsetX, Area_To_Spawn_In.transform.position.y + OffsetY)));
        }
    }

    void FixedUpdate()
    {
        for (int a = 0; a < enemies.Count; a++)
        {
            //Movement
            if (enemies[a] != null)
            {
                if (Vector3.Distance(enemies[a].transform.position, point_to_move_towards[a]) < 0.01f)
                {
                    RandomMovement(enemies[a], a);
                }
                else
                {
                    float step = Speed * Time.deltaTime;
                    enemies[a].GetComponent<Rigidbody2D>().transform.position = Vector3.MoveTowards(enemies[a].transform.position, point_to_move_towards[a], step);
                    enemies[a].GetComponent<Animator>().SetFloat("Horizontal", -(enemies[a].transform.position.x- point_to_move_towards[a].x));
                    enemies[a].GetComponent<Animator>().SetFloat("Vertical", -(enemies[a].transform.position.y - point_to_move_towards[a].y));
                    enemies[a].GetComponent<Animator>().SetFloat("Speed", Vector3.MoveTowards(enemies[a].transform.position, point_to_move_towards[a], step).sqrMagnitude);
                }
            }
        }
    }

    IEnumerator Spawning()
    {
        if (enemies.Count < Max_Enemies_In){enemies.Add(Instantiate(Spawn()));
        }
        for (int a = 0; a < enemies.Count; a++)
        {
            yield return new WaitForSeconds(Time_Beetwen_Trying_To_Spawn);
            if (enemies[a]==null)
            { 
                enemies[a] = Instantiate(Spawn());
            }
            
        }
        
        StartCoroutine(Spawning());
    }

    GameObject Spawn()
    {
        Mob_RigidBody.transform.position = new Vector2(
        Random.Range(Area_To_Spawn_In.transform.position.x-OffsetX, Area_To_Spawn_In.transform.position.x + OffsetX), 
        Random.Range(Area_To_Spawn_In.transform.position.y-OffsetY, Area_To_Spawn_In.transform.position.y + OffsetY));
        return Mob_To_Spawn;
    }

    void RandomMovement(GameObject Enemy,int numerator)
    {
        Vector3 tmp = point_to_move_towards[numerator];
        tmp.x = Random.Range(Area_To_Spawn_In.transform.position.x - OffsetX, Area_To_Spawn_In.transform.position.x + OffsetX);
        tmp.y = Random.Range(Area_To_Spawn_In.transform.position.y - OffsetY, Area_To_Spawn_In.transform.position.y + OffsetY);
        point_to_move_towards[numerator]=tmp;
    }
    
}
