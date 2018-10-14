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
    /////Spawned Location Indicator Object/////
    public GameObject spawnerPlane;

    /////Type of Spawner/////
    public bool spawnAtMultiplePlaces = false;

    /////Spawn Area Setup/////
    public int noOfRows = 1, noOfColumns = 1;
    public float spacing = 1;
    public float minHeight = 0;
    public float maxHeight = 0;

    /////User Based Setup/////
    //User Area - space left for the user;
    //if 0, no space; if 1, 1 to 4 squares in the centre; 
    //every next number adds a layer of squares.
    public int userArea = 1;
    public bool alphabetsFaceUsersEye = true;
    public bool useCustomUserEyeLocation = false;
    public Vector3 userEyePoint;

    /////Spawn Dynamics Settings/////
    public float spawnIntensity = 100;
    public float spawnInterval = 3;
    public bool gravity = false;

    /////Spawned Objects/////
    public GameObject[] gameObjects;



    Vector3 centerPoint;
    //public ArrayList<GameObject> 

    float time = 0;

    // Use this for initialization
    void Start()
    {
        gameObjects = Resources.LoadAll<GameObject>("Prefabs For Spawning");

        //centerPoint.Set(0.6f,1.0869f,0.6f);
        //centerPoint.Set(-3f, 4f, -5f);
        if (useCustomUserEyeLocation)
            centerPoint = userEyePoint;
        else
            centerPoint.Set(0f, 4.2f, 0f);

        //GameObject spawnedPlanes = Instantiate(spawnerPlane, centerPoint, Quaternion.identity);
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
                                float y_variation = Random.Range(minHeight, maxHeight);
                                spawnPos.y += y_variation;
                                spawnPos.y += gameObjects[randGOindex].GetComponent<Renderer>().bounds.size.y / 2;
                                GameObject spawnedGO = Instantiate(gameObjects[randGOindex], spawnPos, Quaternion.identity);
                                spawnedGO.transform.parent = transform;
                                Rigidbody rb = spawnedGO.GetComponent<Rigidbody>();
                                if (rb)
                                    rb.useGravity = gravity;
                                // Debug.Log("Spawning!");
                            }
                        }
                }
                //If each object is to be spawned only once. Currently worked one.
                else
                {
                    List<Vector2> existingObjs = new List<Vector2>();
                    preFill(existingObjs);

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
                                                float y_variation = Random.Range(minHeight, maxHeight);
                                                spawnPos.y += y_variation;
                                                spawnPos.y += gameObjects[g].GetComponent<Renderer>().bounds.size.y / 2;
                                                GameObject spawnedGO = Instantiate(gameObjects[g], spawnPos, Quaternion.identity);
                                                spawnedGO.transform.parent = transform;

                                                if (alphabetsFaceUsersEye)
                                                {
                                                    spawnedGO.transform.LookAt(centerPoint);
                                                    //spawnedGO.transform.Rotate(Vector3.up, -90);                                                
                                                    //spawnedGO.transform.rotation.eulerAngles.Set(spawnedGO.transform.rotation.eulerAngles.x, spawnedGO.transform.rotation.eulerAngles.y+90,0);
                                                    //spawnedGO.transform.localEulerAngles = (new Vector3(spawnedGO.transform.localEulerAngles.x, spawnedGO.transform.localEulerAngles.y + 180, spawnedGO.transform.localEulerAngles.z));
                                                    spawnedGO.transform.Rotate(0, 180, 0, Space.Self);
                                                }
                                                
                                                Rigidbody rb = spawnedGO.GetComponent<Rigidbody>();
                                                if (rb)
                                                    rb.useGravity = gravity;
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
                                                    float y_variation = Random.Range(minHeight, maxHeight);
                                                    spawnPos.y += y_variation;
                                                    spawnPos.y += gameObjects[g].GetComponent<Renderer>().bounds.size.y / 2;
                                                    GameObject spawnedGO = Instantiate(gameObjects[g], spawnPos, Quaternion.identity);
                                                    spawnedGO.transform.parent = transform;

                                                    if (alphabetsFaceUsersEye)
                                                    {
                                                        spawnedGO.transform.LookAt(centerPoint);
                                                        //spawnedGO.transform.Rotate(Vector3.up, -90);
                                                        //spawnedGO.transform.rotation.eulerAngles.Set(spawnedGO.transform.rotation.eulerAngles.x, spawnedGO.transform.rotation.eulerAngles.y+90, 0);
                                                        //spawnedGO.transform.localEulerAngles = (new Vector3(spawnedGO.transform.localEulerAngles.x, spawnedGO.transform.localEulerAngles.y + 180, 0));
                                                        //spawnedGO.transform.localEulerAngles = (new Vector3(spawnedGO.transform.localEulerAngles.x, spawnedGO.transform.localEulerAngles.y + 180, spawnedGO.transform.localEulerAngles.z));
                                                        spawnedGO.transform.Rotate(0, 180, 0, Space.Self);
                                                    }
                                                    
                                                    Rigidbody rb = spawnedGO.GetComponent<Rigidbody>();
                                                    if (rb)
                                                        rb.useGravity = gravity;
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
                                float y_variation = Random.Range(minHeight, maxHeight);
                                spawnPos.y += y_variation;
                                spawnPos.y += gameObjects[g].GetComponent<Renderer>().bounds.size.y / 2;
                                GameObject spawnedGO = Instantiate(gameObjects[g], spawnPos, Quaternion.identity);
                                spawnedGO.transform.parent = transform;
                                if (alphabetsFaceUsersEye)
                                {
                                    spawnedGO.transform.LookAt(centerPoint);
                                    //spawnedGO.transform.Rotate(Vector3.up, -90);
                                    //spawnedGO.transform.rotation.eulerAngles.Set(spawnedGO.transform.rotation.eulerAngles.x, spawnedGO.transform.rotation.eulerAngles.y+90, 0);
                                    //spawnedGO.transform.localEulerAngles = (new Vector3(spawnedGO.transform.localEulerAngles.x, spawnedGO.transform.localEulerAngles.y + 180, 0));
                                    //spawnedGO.transform.localEulerAngles = (new Vector3(spawnedGO.transform.localEulerAngles.x, spawnedGO.transform.localEulerAngles.y + 180, spawnedGO.transform.localEulerAngles.z));
                                    //spawnedGO.transform.eulerAngles = (new Vector3(spawnedGO.transform.eulerAngles.x, spawnedGO.transform.eulerAngles.y + 180, spawnedGO.transform.localEulerAngles.z));
                                    spawnedGO.transform.Rotate(0, 180, 0, Space.Self);
                                }
                                
                                Rigidbody rb = spawnedGO.GetComponent<Rigidbody>();
                                if (rb)
                                    rb.useGravity = gravity;
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
        //For displaying in editor, no gameplay stuff in here.       
        if (Application.isEditor && !Application.isPlaying)
        {
            while (transform.childCount != 0)
            {
                DestroyImmediate(transform.GetChild(0).gameObject);
            }
            List<Vector2> nonSpawnedArea = new List<Vector2>();
            preFill(nonSpawnedArea);
            for (int i = 0; i < noOfRows; i++)
                for (int j = 0; j < noOfColumns; j++)
                {
                    if (!nonSpawnedArea.Contains(new Vector2(i, j)))
                    {
                        Vector3 spawnPos = transform.position;
                        spawnPos.x += i * (spawnerPlane.GetComponent<Renderer>().bounds.size.x + spacing / 10.0f);
                        spawnPos.z += j * (spawnerPlane.GetComponent<Renderer>().bounds.size.z + spacing / 10.0f);
                        spawnPos.y += minHeight;
                        GameObject spawnedPlanes = Instantiate(spawnerPlane, spawnPos, Quaternion.identity);
                        spawnedPlanes.transform.parent = transform;
                    }


                }

            if (maxHeight != 0)
                for (int i = 0; i < noOfRows; i++)
                    for (int j = 0; j < noOfColumns; j++)
                    {
                        if (!nonSpawnedArea.Contains(new Vector2(i, j)))
                        {
                            Vector3 spawnPos = transform.position;
                            spawnPos.x += i * (spawnerPlane.GetComponent<Renderer>().bounds.size.x + spacing / 10.0f);
                            spawnPos.z += j * (spawnerPlane.GetComponent<Renderer>().bounds.size.z + spacing / 10.0f);
                            spawnPos.y += maxHeight;
                            GameObject spawnedPlanes = Instantiate(spawnerPlane, spawnPos, Quaternion.identity);
                            spawnedPlanes.transform.parent = transform;
                        }

                    }
        }

        //Actual game code.
        if (Application.isPlaying)
        {
            time += Time.deltaTime;
            if (time >= spawnInterval)
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
                                Vector3 spawnPos = transform.position;
                                spawnPos.x += i * (spawnerPlane.GetComponent<Renderer>().bounds.size.x + spacing / 10.0f);
                                spawnPos.z += j * (spawnerPlane.GetComponent<Renderer>().bounds.size.z + spacing / 10.0f);
                                float y_variation = Random.Range(minHeight, maxHeight);
                                spawnPos.y += y_variation;
                                if (Random.Range(0.0f, 100.0f) < spawnIntensity)
                                {
                                    int randGOindex = Random.Range(0, gameObjects.Length);
                                    spawnPos.y += gameObjects[randGOindex].GetComponent<Renderer>().bounds.size.y / 2;
                                    GameObject spawnedGO = Instantiate(gameObjects[randGOindex], spawnPos, Quaternion.identity);
                                    spawnedGO.transform.parent = transform;
                                    Rigidbody rb = spawnedGO.GetComponent<Rigidbody>();
                                    if (rb)
                                        rb.useGravity = gravity;
                                }
                            }
                    }
                    else
                    {
                        List<Vector2> existingObjs = new List<Vector2>();
                        preFill(existingObjs);

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
                                                    float y_variation = Random.Range(minHeight, maxHeight);
                                                    spawnPos.y += y_variation;
                                                    spawnPos.y += gameObjects[g].GetComponent<Renderer>().bounds.size.y / 2;
                                                    GameObject spawnedGO = Instantiate(gameObjects[g], spawnPos, Quaternion.identity);
                                                    spawnedGO.transform.parent = transform;
                                                    spawnedGO.transform.LookAt(centerPoint);
                                                    spawnedGO.transform.Rotate(Vector3.up, 180);
                                                    Rigidbody rb = spawnedGO.GetComponent<Rigidbody>();
                                                    if (rb)
                                                        rb.useGravity = gravity;
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
                                                        float y_variation = Random.Range(minHeight, maxHeight);
                                                        spawnPos.y += y_variation;
                                                        spawnPos.y += gameObjects[g].GetComponent<Renderer>().bounds.size.y / 2;
                                                        GameObject spawnedGO = Instantiate(gameObjects[g], spawnPos, Quaternion.identity);
                                                        spawnedGO.transform.parent = transform;
                                                        spawnedGO.transform.LookAt(centerPoint);
                                                        spawnedGO.transform.Rotate(Vector3.up, 180);
                                                        Rigidbody rb = spawnedGO.GetComponent<Rigidbody>();
                                                        if (rb)
                                                            rb.useGravity = gravity;
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
                                    float y_variation = Random.Range(minHeight, maxHeight);
                                    spawnPos.y += y_variation;
                                    spawnPos.y += gameObjects[g].GetComponent<Renderer>().bounds.size.y / 2;
                                    GameObject spawnedGO = Instantiate(gameObjects[g], spawnPos, Quaternion.identity);
                                    spawnedGO.transform.parent = transform;
                                    spawnedGO.transform.LookAt(centerPoint);
                                    spawnedGO.transform.Rotate(Vector3.up, 180);
                                    Rigidbody rb = spawnedGO.GetComponent<Rigidbody>();
                                    if (rb)
                                        rb.useGravity = gravity;
                                    existingObjs.Add(new Vector2(randx, randz));

                                }
                            }


                        }

                    }

            }
        }
    }

    void preFill(List<Vector2> existingObjList)
    {
        if (userArea > 0)
        {
            //Debug.Log("Entered Prefill");
            //Use hashSet instead of lists to avoid duplicate entries.
            HashSet<int> rowNos = new HashSet<int>(), colNos = new HashSet<int>();
            if (noOfRows % 2 != 0)
                for (int i = 0; i < userArea; i++)
                {
                    rowNos.Add((noOfRows - 1) / 2 + i);
                    rowNos.Add((noOfRows - 1) / 2 - i);
                }
            else
                for (int i = 0; i < userArea; i++)
                {
                    rowNos.Add((noOfRows - 1) / 2 + 1 + i);
                    rowNos.Add((noOfRows - 1) / 2 - i);
                }
            //Debug.Log("rowNos count is: " + rowNos.Count);
            //foreach (int item in rowNos) { Debug.Log("Row positions generated in preFill: " + item); }

            if (noOfColumns % 2 != 0)
                for (int i = 0; i < userArea; i++)
                {
                    colNos.Add((noOfColumns - 1) / 2 + i);
                    colNos.Add((noOfColumns - 1) / 2 - i);
                }
            else
                for (int i = 0; i < userArea; i++)
                {
                    colNos.Add((noOfColumns - 1) / 2 + 1 + i);
                    colNos.Add((noOfColumns - 1) / 2 - i);
                }

            //Debug.Log("colNos count is: " + colNos.Count);
            //foreach (int item in colNos) { Debug.Log("Col positions generated in preFill: " + item); }

            foreach (int rowNo in rowNos)
                foreach (int colNo in colNos)
                    existingObjList.Add(new Vector2(rowNo, colNo));

            foreach (Vector2 item in existingObjList) { Debug.Log("Positions generated in preFill: " + item.x + "," + item.y); }
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



