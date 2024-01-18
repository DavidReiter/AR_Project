using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    public GameObject playField;
    [SerializeField]
    public GameObject tilePrefab;
    [SerializeField]
    public GameObject canvas;

    private const float boundX = 0.15f;
    private const float boundZ = 0.1f;

    private GameObject tile;
    private TileController tc;
    private CanvasController canvasController;

    private float tileTime = 2f;
    private float timeLeft;
    private bool timerOn = false;

    private int counter;

    // Start is called before the first frame update
    void Start()
    {
        if(tilePrefab != null && playField != null)
        {
            tile = Instantiate(tilePrefab);
            tile.transform.SetParent(playField.transform);
            tc = tile.GetComponent<TileController>();
        }

        // Set first random position
        ChangePosition();

        if(canvas != null)
        {
            canvasController = canvas.GetComponent<CanvasController>();
        }

        timeLeft = tileTime;
        counter = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if(tc != null && tc.isActive())
        {
            timerOn = true;
        }
        else
        {
            timerOn = false;
            timeLeft = tileTime;
        }
    }

    // fixed update for more realistic seconds in timer
    private void FixedUpdate()
    {
        CheckTimer();
    }

    private Vector3 GetRandomPosition(float minX, float maxX, float minZ, float maxZ)
    {
        float x = Random.Range(minX, maxX);
        float z = Random.Range(minZ, maxZ);
        return new Vector3(x, 0, z);
    }

    private void ChangePosition()
    {
        tile.transform.position = GetRandomPosition(-boundX, boundX, -boundZ, boundZ);
        tc.ResetActice();
    }

    private void CheckTimer()
    {
        if (timerOn)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                setTimer(timeLeft);
            }
            else
            {
                timerOn = false;
                timeLeft = tileTime;

                counter++;
                setCounter(counter);
                setTimer(timeLeft);

                ChangePosition();
            }
        }
    }

    private void setCounter(int count)
    {
        if(canvasController != null)
        {
            canvasController.SetCounter(count);
        }
    }

    private void setTimer(float time)
    {
        if (canvasController != null)
        {
            canvasController.SetTimer(time);
        }
    }
}
