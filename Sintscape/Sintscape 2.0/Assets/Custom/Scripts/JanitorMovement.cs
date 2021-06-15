using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class JanitorMovement : MonoBehaviour
{
    //Waypoints zijn Empty Gameobject met de tag "Waypoint" die je in Unity zelf kan plaatsen
    //GameArtist geef je de tag "Gameart" en de GameDeveloper geef je de tag "Gamedev"

    private NavMeshAgent janitor;
    public GameObject janitorEyes;

    GameObject gameArtist;
    GameObject gameDev;

    bool seenDev = false;
    bool seenArt = false;

    public GameObject[] waypoints;
    int ranWayPoint;

    public float Aggrotime = 5;

    RaycastHit hit;
    Ray ray;
    void Start()
    {
        gameArtist = GameObject.FindGameObjectWithTag("Gameart");
        gameDev = GameObject.FindGameObjectWithTag("Gamedev");

        janitor = this.GetComponent<NavMeshAgent>();
        waypoints = GameObject.FindGameObjectsWithTag("Waypoint");

        ranWayPoint = Random.Range(0, waypoints.Length);
        janitor.SetDestination(waypoints[ranWayPoint].transform.position);
    }

    void Update()
    {
        if (waypoints[ranWayPoint].transform.position.x == janitor.transform.position.x) 
            StartCoroutine(Arrived());

        ray = new Ray(janitorEyes.transform.position, janitorEyes.transform.forward);
        Debug.DrawRay(janitorEyes.transform.position, janitorEyes.transform.forward * 40);

        if (Physics.Raycast(ray, out hit, 40f))
        {
            if (hit.collider.CompareTag("Gamedev"))
            {
                seenDev = true;
                Aggrotime = 5;
            }
  
            if (hit.collider.CompareTag("Gameart"))
            {
                seenArt = true;
                Aggrotime = 5;
            }
                
        }

        if (seenDev == true)
        {
            janitor.SetDestination(gameDev.transform.position);

            if (Aggrotime > 0)
            {
                Aggrotime -= Time.deltaTime;
                janitor.speed = 7;
            }
            if (Aggrotime < 0)
            {
                seenDev = false;
                janitor.speed = 3.5f;
                janitor.SetDestination(waypoints[ranWayPoint].transform.position);
            }

        }

        if (seenArt == true)
        {
            janitor.SetDestination(gameArtist.transform.position);

            if (Aggrotime > 0)
            {
                Aggrotime -= Time.deltaTime;
                janitor.speed = 7;
            }
            if (Aggrotime < 0)
            {
                seenArt = false;
                janitor.speed = 3.5f;
                janitor.SetDestination(waypoints[ranWayPoint].transform.position);
            }

        }
    }

    IEnumerator Arrived()
    {
        ranWayPoint = Random.Range(0, waypoints.Length);
        yield return new WaitForSeconds(1);
        janitor.SetDestination(waypoints[ranWayPoint].transform.position);
    }
}
