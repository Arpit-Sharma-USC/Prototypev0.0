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

    public GameObject[] gameObjects;
    //public ArrayList<GameObject> 

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
                if (spawnAtMultiplePlaces)
                {
                    for (int i = 0; i < noOfRows; i++)
                        for (int j = 0; j < noOfColumns; j++)
                        {
                            Debug.Log("in spawner!");
                            Vector3 spawnPos = transform.position;
                            spawnPos.x += i * (spawnerPlane.GetComponent<Renderer>().bounds.size.x + spacing / 10.0f);
                            spawnPos.z += j * (spawnerPlane.GetComponent<Renderer>().bounds.size.z + spacing / 10.0f);
                            if (Random.Range(0.0f, 100.0f) < spawnIntensity)
                            {
                                int randGOindex = Random.Range(0, gameObjects.Length);
                                spawnPos.y += gameObjects[randGOindex].GetComponent<Renderer>().bounds.size.y / 2;
                                Instantiate(gameObjects[randGOindex], spawnPos, Quaternion.identity);
                                Debug.Log("Spawning!");
                            }
                        }
                }
                else
                {

                }
            else
                Debug.Log("No gameobjects specified for spawner!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //spawnerInfo.noOfColumns = noOfColumns;
        //spawnerInfo.noOfRows = noOfRows;
        //spawnerInfo.spacing = spacing;

        //Editor Interface.
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
                    GameObject spawnedPlanes = Instantiate(spawnerPlane, spawnPos, Quaternion.identity);
                    spawnedPlanes.transform.parent = transform;

                }
        }
        //if (Application.isPlaying)
        if (!Application.isEditor && Application.isPlaying)
        {

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
   


