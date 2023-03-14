using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class Reels : MonoBehaviour
{

    public float speed = 300;
    public float currentSpeed { get; set; }
    public int slices = 10;

    float startRotation = 15f;
    private Quaternion[] baserotations;
    public bool main = false;
    private void Awake()
    {
        if (!transform.parent.gameObject.name.Contains("(")) main = true;
    }
    void Start()
    {

        startRotation = 360 / slices;
        currentSpeed = 0;

        //declare all rotation slices for calculating when to stop
        baserotations = new Quaternion[slices];
        for (int i = 0; i < slices; i++)
        {
            baserotations[i] =
            Quaternion.Euler(new Vector3(mod(-
            i * (360f / slices), 360f), 0, 90f));
        }

        transform.GetChild(0).GetComponent<SymbolPlacer>().Hey();
    }

    // Update is called once per frame
    public bool stoped = true;
    void Update()
    {
        transform.Rotate(0f, currentSpeed * Time.deltaTime, 0f);
    }

    float rotplacedistance = 21.0f;
    float lastPlaced = 0.0f;
    public GameObject a;
    Transform b;
    private int count;
    public void TokenReset()
    {
        print(transform.parent.GetComponents<SymbolPool>());
        transform.parent.GetComponent<SymbolPool>().LoadPool();
        foreach (Transform i in transform)
        {
            if (i.GetComponent<SymbolPlacer>() != null)
            {
                i.GetComponent<SymbolPlacer>().loadRandomSprite(i);
            }
        }
    }
    public void Stop()
    {
        StartCoroutine(kk());
    }
    public int slowdownSteps = 20;
    public bool backwards = false;
    IEnumerator kk()
    {
        //The slowdown
        float s = currentSpeed;
        for (int i = 0; i < slowdownSteps; i++)
        {
            yield return new WaitForSeconds(0.1f);
            currentSpeed = s * (slowdownSteps - i) / slowdownSteps;
        }
        yield return new WaitForSeconds(0.1f);
        currentSpeed = 0;
        yield return new WaitForSeconds(0.1f);

        //Calculating where should it stop 
        float min = 361;
        float tmp;
        bool found = false;
        float piece = 360 / slices;
        int baseRotInd = 0;
        for (int i = 0; i < slices; i++)
        {
            if (!found)
            {
                tmp = signedAngle(transform.rotation,
                    baserotations[i]);

                if (!backwards)
                {
                    if (tmp >= 0 && tmp < piece)
                    {
                        baseRotInd = i;
                        if (clampstop)
                            min = tmp; found = true;
                    }
                }
                else
                {
                    if (tmp <= 0 && tmp > -piece)
                    {
                        if (clampstop) min = tmp;
                        baseRotInd = i;
                        found = true;


                    }
                }
            }
        }
        if (!clampstop)
        {
            transform.rotation = baserotations[baseRotInd];
        }
        else StartCoroutine(Clampstop(min));

    }
    public bool clampstop;
    [HideInInspector]
    public float clampspeed = 100;
    [HideInInspector]
    public float clampSteps = 77;
    IEnumerator Clampstop(float rotation)
    {
        int steps = 77;
        float stepLength = (rotation / steps);
        float stepTime = stepLength / clampspeed;
        for (int i = 0; i < steps; i++)
        {
            yield return new WaitForSeconds(stepTime);
            transform.Rotate(0, stepLength, 0);
        }
    }

    float signedAngle(Quaternion a, Quaternion b)
    {


        // define an axis, usually just up
        Vector3 axis = Vector3.right;


        // mock rotate the axis with each quaternion
        Vector3 vecA = a * axis;
        Vector3 vecB = b * axis;


        // now we need to compute the actual 2D rotation projections on the base plane
        float angleA = Mathf.Atan2(vecA.y, vecA.z) * Mathf.Rad2Deg;
        float angleB = Mathf.Atan2(vecB.y, vecB.z) * Mathf.Rad2Deg;


        // get the signed difference in these angles
        return Mathf.DeltaAngle(angleA, angleB);
    }
    float mod(float x, float m)
    {
        return (x % m + m) % m;
    }
}
