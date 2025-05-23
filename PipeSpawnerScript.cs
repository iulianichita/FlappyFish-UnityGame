using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 3;
    private float timer = 0;
    public float heightOffset = 10;
    public LogicScript logic;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindWithTag("Logic").GetComponent<LogicScript>();

        if (logic.gameStarted){
            spawnPipe();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (logic.gameStarted){
            if (timer < spawnRate){
                timer += Time.deltaTime;
            } else {
                spawnPipe();
                timer = 0;
            }
        }
    }

    void spawnPipe() {

        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint)), transform.rotation);
    }
}
