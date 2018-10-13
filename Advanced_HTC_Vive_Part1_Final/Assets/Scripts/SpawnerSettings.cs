using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;


//public static class spawnerInfo
//{
//    public static int noOfRows, noOfColumns;
//    public static float spacing;
//}


[ExecuteInEditMode]
public class SpawnerSettings : MonoBehaviour
{
    public GameObject spawnerPlane;
    public int noOfRows = 1, noOfColumns = 1;
    public float spacing = 1;
    //public int noOfSpawnedObjects = 0;
    public bool spawnAtMultiplePlaces = false;
    public float spawnIntensity = 50;
    public float spawnInterval = 3;
    public float min_height = 0;
    public float max_height = 0;
    public GameObject[] gameObjects;
    //public ArrayList<GameObject> 

    float time=0;

    // Use this for initialization
    void Start()
    {
        if (Application.isEditor && !Application.isPlaying)
        {
            //Debug.Log("Hello");
        }

        //if (Application.isPlaying)
        if (Application.isPlaying)
        {
            //gameObjects = new GameObject[noOfSpawnedObjects];
            foreach (Transform child in transform)
            {
                GameObject.Destroy(child.gameObject);
            }

            if (gameObjects.Length > 0)
                //If no restriction on spawnining duplicates.
                if (spawnAtMultiplePlaces)
                {
                    for (int i = 0; i < noOfRows; i++)
                        for (int j = 0; j < noOfColumns; j++)
                        {
                            //Debug.Log("in spawner!");
                            Vector3 spawnPos = transform.position;
                            spawnPos.x += i * (spawnerPlane.GetComponent<Renderer>().bounds.size.x + spacing / 10.0f);
                            spawnPos.z += j * (spawnerPlane.GetComponent<Renderer>().bounds.size.z + spacing / 10.0f);
                            if (Random.Range(0.0f, 100.0f) < spawnIntensity)
                            {
                                int randGOindex = Random.Range(0, gameObjects.Length);
                                float y_variation = Random.Range(min_height, max_height);
                                spawnPos.y += y_variation;
                                spawnPos.y += gameObjects[randGOindex].GetComponent<Renderer>().bounds.size.y / 2;
                                GameObject spawnedGO = Instantiate(gameObjects[randGOindex], spawnPos, Quaternion.identity);
                                spawnedGO.transform.parent = transform;
                               // Debug.Log("Spawning!");
                            }
                        }
                }
                //If each is to be spawned only once.
                else
                {
                    List<Vector2> existingObjs = new List<Vector2>();

                    for (int g = 0; g < gameObjects.Length; g++)
                    {
                        Debug.Log("Obj: " + g);
                        float randIntensity = Random.Range(0.0f, 100.0f);
                        Debug.Log("SpawnIntensity: " + randIntensity);
                        if (randIntensity < spawnIntensity)
                        {
                            //Debug.Log("Entering.");
                            int randx = Random.Range(0, noOfRows);
                            int randz = Random.Range(0, noOfColumns);
                            Debug.Log("Location generated: " + randx + "," + randz);

                            //Check if spot is already occupied.
                            if (existingObjs.Contains(new Vector2(randx, randz)))
                            {
                                //If grid still has spots, check next available spot from current spot.
                                if (existingObjs.Count <= (noOfRows * noOfColumns))
                                {
                                    Debug.Log("Location not free!");
                                    //foreach (Vector2 item in existingObjs) { Debug.Log("Positions occupied: " + item.x + "," + item.y); }
                                    bool foundSpot = false;
                                    Debug.Log("Checking next available spot from current spot.");
                                    for (int i = randx + 1; i < noOfRows; i++)
                                        for (int j = 0; j < noOfColumns; j++)
                                        {
                                            if (i == randx && j <= randz)
                                                continue;
                                            if (!existingObjs.Contains(new Vector2(i, j)) && !foundSpot)
                                            {
                                                Vector3 spawnPos = transform.position;
                                                spawnPos.x += i * (spawnerPlane.GetComponent<Renderer>().bounds.size.x + spacing / 10.0f);
                                                spawnPos.z += j * (spawnerPlane.GetComponent<Renderer>().bounds.size.z + spacing / 10.0f);
                                                float y_variation = Random.Range(min_height, max_height);
                                                spawnPos.y += y_variation;
                                                spawnPos.y += gameObjects[g].GetComponent<Renderer>().bounds.size.y / 2;
                                                GameObject spawnedGO = Instantiate(gameObjects[g], spawnPos, Quaternion.identity);
                                                spawnedGO.transform.parent = transform;
                                                existingObjs.Add(new Vector2(i, j));
                                                foundSpot = true;
                                                Debug.Log("Found a spot");
                                            }
                                            else
                                            {
                                                Debug.Log("Occupied Position: " + i + "," + j);
                                            }
                                        }

                                    //Check for a spot from start to current spot.
                                    if (!foundSpot)
                                        Debug.Log("Didnt find a spot, trying from start.");
                                    if (!foundSpot)
                                        for (int i = 0; i <= randx; i++)
                                            for (int j = 0; j < noOfColumns; j++)
                                                if (!existingObjs.Contains(new Vector2(i, j)) && !foundSpot)
                                                {
                                                    Vector3 spawnPos = transform.position;
                                                    spawnPos.x += i * (spawnerPlane.GetComponent<Renderer>().bounds.size.x + spacing / 10.0f);
                                                    spawnPos.z += j * (spawnerPlane.GetComponent<Renderer>().bounds.size.z + spacing / 10.0f);
                                                    float y_variation = Random.Range(min_height, max_height);
                                                    spawnPos.y += y_variation;
                                                    spawnPos.y += gameObjects[g].GetComponent<Renderer>().bounds.size.y / 2;
                                                    GameObject spawnedGO = Instantiate(gameObjects[g], spawnPos, Quaternion.identity);
                                                    spawnedGO.transform.parent = transform;
                                                    existingObjs.Add(new Vector2(i, j));
                                                    foundSpot = true;
                                                    Debug.Log("Found a spot");
                                                }
                                                else
                                                {
                                                    Debug.Log("Occupied Position: " + i + "," + j);
                                                }
                                }
                            }
                            //Current spot was free.
                            else
                            {
                                Debug.Log("Location free!");
                                Vector3 spawnPos = transform.position;
                                spawnPos.x += randx * (spawnerPlane.GetComponent<Renderer>().bounds.size.x + spacing / 10.0f);
                                spawnPos.z += randz * (spawnerPlane.GetComponent<Renderer>().bounds.size.z + spacing / 10.0f);
                                float y_variation = Random.Range(min_height, max_height);
                                spawnPos.y += y_variation;
                                spawnPos.y += gameObjects[g].GetComponent<Renderer>().bounds.size.y / 2;
                                GameObject spawnedGO = Instantiate(gameObjects[g], spawnPos, Quaternion.identity);
                                spawnedGO.transform.parent = transform;
                                existingObjs.Add(new Vector2(randx, randz));

                            }
                        }


                    }

                }
            else
                Debug.Log("No gameobjects specified for spawner!");
        }
    }

    // Update is called once per frame
    void Update()
    {
               
        if (Application.isEditor && !Application.isPlaying)
        {
            while (transform.childCount != 0)
            {
                DestroyImmediate(transform.GetChild(0).gameObject);
            }
            for (int i = 0; i < noOfRows; i++)
                for (int j = 0; j < noOfColumns; j++)
                {
                    Vector3 spawnPos = transform.position;
                    spawnPos.x += i * (spawnerPlane.GetComponent<Renderer>().bounds.size.x + spacing / 10.0f);
                    spawnPos.z += j * (spawnerPlane.GetComponent<Renderer>().bounds.size.z + spacing / 10.0f);
                    spawnPos.y += min_height;
                    GameObject spawnedPlanes = Instantiate(spawnerPlane, spawnPos, Quaternion.identity);
                    spawnedPlanes.transform.parent = transform;

                }

            if(max_height != 0)
                for (int i = 0; i < noOfRows; i++)
                    for (int j = 0; j < noOfColumns; j++)
                    {
                        Vector3 spawnPos = transform.position;
                        spawnPos.x += i * (spawnerPlane.GetComponent<Renderer>().bounds.size.x + spacing / 10.0f);
                        spawnPos.z += j * (spawnerPlane.GetComponent<Renderer>().bounds.size.z + spacing / 10.0f);
                        spawnPos.y += max_height;
                        GameObject spawnedPlanes = Instantiate(spawnerPlane, spawnPos, Quaternion.identity);
                        spawnedPlanes.transform.parent = transform;

                    }
        }

        if (Application.isPlaying)
        {
            time += Time.deltaTime;
            if(time >= spawnInterval)
            {
                time = 0;
                //Delete all existing objects.
                foreach (Transform child in transform)
                {
                    GameObject.Destroy(child.gameObject);
                }
                if (gameObjects.Length > 0)
                    if (spawnAtMultiplePlaces)
                    {
                        for (int i = 0; i < noOfRows; i++)
                            for (int j = 0; j < noOfColumns; j++)
                            {
                                Debug.Log("in spawner!");
                                Vector3 spawnPos = transform.position;
                                spawnPos.x += i * (spawnerPlane.GetComponent<Renderer>().bounds.size.x + spacing / 10.0f);
                                spawnPos.z += j * (spawnerPlane.GetComponent<Renderer>().bounds.size.z + spacing / 10.0f);
                                float y_variation = Random.Range(min_height, max_height);
                                spawnPos.y += y_variation;
                                if (Random.Range(0.0f, 100.0f) < spawnIntensity)
                                {
                                    int randGOindex = Random.Range(0, gameObjects.Length);
                                    spawnPos.y += gameObjects[randGOindex].GetComponent<Renderer>().bounds.size.y / 2;
                                    GameObject spawnedGO = Instantiate(gameObjects[randGOindex], spawnPos, Quaternion.identity);
                                    spawnedGO.transform.parent = transform;
                                    Debug.Log("Spawning!");
                                }
                            }
                    }
                    else
                    {
                        List<Vector2> existingObjs = new List<Vector2>();

                        for (int g = 0; g < gameObjects.Length; g++)
                        {
                            Debug.Log("Obj: " + g);
                            float randIntensity = Random.Range(0.0f, 100.0f);
                            Debug.Log("SpawnIntensity: " + randIntensity);
                            if (randIntensity < spawnIntensity)
                            {
                                //Debug.Log("Entering.");
                                int randx = Random.Range(0, noOfRows);
                                int randz = Random.Range(0, noOfColumns);
                                Debug.Log("Location generated: " + randx + "," + randz);

                                //Check if spot is already occupied.
                                if (existingObjs.Contains(new Vector2(randx, randz)))
                                {
                                    //If grid still has spots, check next available spot from current spot.
                                    if (existingObjs.Count <= (noOfRows * noOfColumns))
                                    {
                                        Debug.Log("Location not free!");
                                        //foreach (Vector2 item in existingObjs) { Debug.Log("Positions occupied: " + item.x + "," + item.y); }
                                        bool foundSpot = false;
                                        Debug.Log("Checking next available spot from current spot.");
                                        for (int i = randx + 1; i < noOfRows; i++)
                                            for (int j = 0; j < noOfColumns; j++)
                                            {
                                                if (i == randx && j <= randz)
                                                    continue;
                                                if (!existingObjs.Contains(new Vector2(i, j)) && !foundSpot)
                                                {
                                                    Vector3 spawnPos = transform.position;
                                                    spawnPos.x += i * (spawnerPlane.GetComponent<Renderer>().bounds.size.x + spacing / 10.0f);
                                                    spawnPos.z += j * (spawnerPlane.GetComponent<Renderer>().bounds.size.z + spacing / 10.0f);
                                                    float y_variation = Random.Range(min_height, max_height);
                                                    spawnPos.y += y_variation;
                                                    spawnPos.y += gameObjects[g].GetComponent<Renderer>().bounds.size.y / 2;
                                                    GameObject spawnedGO = Instantiate(gameObjects[g], spawnPos, Quaternion.identity);
                                                    spawnedGO.transform.parent = transform;
                                                    existingObjs.Add(new Vector2(i, j));
                                                    foundSpot = true;
                                                    Debug.Log("Found a spot");
                                                }
                                                else
                                                {
                                                    Debug.Log("Occupied Position: " + i + "," + j);
                                                }
                                            }
                                                
                                        //Check for a spot from start to current spot.
                                        if (!foundSpot)
                                            Debug.Log("Didnt find a spot, trying from start.");
                                        if (!foundSpot)
                                            for (int i = 0; i <= randx; i++)
                                                for (int j = 0; j < noOfColumns; j++)
                                                    if (!existingObjs.Contains(new Vector2(i, j)) && !foundSpot)
                                                    {
                                                        Vector3 spawnPos = transform.position;
                                                        spawnPos.x += i * (spawnerPlane.GetComponent<Renderer>().bounds.size.x + spacing / 10.0f);
                                                        spawnPos.z += j * (spawnerPlane.GetComponent<Renderer>().bounds.size.z + spacing / 10.0f);
                                                        float y_variation = Random.Range(min_height, max_height);
                                                        spawnPos.y += y_variation;
                                                        spawnPos.y += gameObjects[g].GetComponent<Renderer>().bounds.size.y / 2;
                                                        GameObject spawnedGO = Instantiate(gameObjects[g], spawnPos, Quaternion.identity);
                                                        spawnedGO.transform.parent = transform;
                                                        existingObjs.Add(new Vector2(i, j));
                                                        foundSpot = true;
                                                        Debug.Log("Found a spot");
                                                    }
                                                    else
                                                    {
                                                        Debug.Log("Occupied Position: " + i + "," + j);
                                                    }
                                    }
                                }
                                //Current spot was free.
                                else
                                {
                                    Debug.Log("Location free!");
                                    Vector3 spawnPos = transform.position;
                                    spawnPos.x += randx * (spawnerPlane.GetComponent<Renderer>().bounds.size.x + spacing / 10.0f);
                                    spawnPos.z += randz * (spawnerPlane.GetComponent<Renderer>().bounds.size.z + spacing / 10.0f);
                                    float y_variation = Random.Range(min_height, max_height);
                                    spawnPos.y += y_variation;
                                    spawnPos.y += gameObjects[g].GetComponent<Renderer>().bounds.size.y / 2;
                                    GameObject spawnedGO = Instantiate(gameObjects[g], spawnPos, Quaternion.identity);
                                    spawnedGO.transform.parent = transform;
                                    existingObjs.Add(new Vector2(randx, randz));

                                }
                            }


                        }

                    }

            }
        }
    }
}
//[CustomEditor(typeof(SpawnerSettings))]
//public class SpawnerSettingsEditor : Editor
//{
//    SpawnerSettings script;
//    void OnEnable()
//    {
//        script = (SpawnerSettings)target;
//    }
//    public override void OnInspectorGUI()
//    {
//        EditorGUI.indentLevel++;
//        if (script.spawnAtMultiplePlaces)
//        {
//            script.spawnIntensity = EditorGUILayout.Slider("Percentage chance of spawning at each location", script.spawnIntensity, 1, 100);
//        }

//    }

//}
   


