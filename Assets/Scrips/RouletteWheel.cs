using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RouletteWheel : MonoBehaviour
{
    public Transform wheelTransform;
    public float spinSpeed = 500f;
    private bool isSpinning = false;
    public int payout;
    [System.Serializable]
    public class ObjectWithID
    {
        public GameObject gameObject;
        public int id;
    }

    public List<ObjectWithID> objectsToTag;
    public List<Material> Materials;
    public string newTag;
    void Start()
    {
        wheelTransform = GetComponent<Transform>();

        foreach (ObjectWithID obj in objectsToTag)
        {
            obj.gameObject.tag = newTag + obj.id.ToString();
            
            obj.gameObject.GetComponent<Renderer>().material = Materials[(int.Parse(obj.gameObject.tag) -1)];
            
        }
        

    }

    void Update()
    {
       if(Input.GetKeyUp(KeyCode.Space)) 
        {
            Spin();
        }
        print(payout);
    }
    public void Spin()
    {
        if (!isSpinning && Manager.currentBet != 0)
        {
            float randomRotation = Random.Range(720, 1080); // generate a random rotation value
            Manager.TotalMoney = Manager.TotalMoney - (Manager.currentBet /5);
            StartCoroutine(SpinWheel(randomRotation));
            Calculate();// start the spin coroutine
          
        }
    }

    public void Calculate()
    {
       
       // (int a, int b, int c, int d, int e) total = (Manager.D1.data, Manager.D2.data, Manager.D3.data, Manager.D4.data,Manager.D5.data);
        List<int> integers = new List<int> { Manager.D1.data, Manager.D2.data, Manager.D3.data, Manager.D4.data, Manager.D5.data };

        int mostFrequent = integers.GroupBy(i => i)
                                 .OrderByDescending(g => g.Count())
                                 .Select(g => g.Key)
                                 .FirstOrDefault(i => i != 0 && integers.Count(x => x == i) >= 3);
        int count = integers.Count(x => x == mostFrequent);
        print("it happened "+count + " most freq " + mostFrequent + " " + Manager.IPayout.ID);

        if(mostFrequent == Manager.APayout.ID+1 && count != 0)
        {
            if(mostFrequent == 3) { payout = Manager.APayout.row.c; }
            else if (mostFrequent == 4) { payout = Manager.APayout.row.d; }
            else if (mostFrequent == 5) { payout = Manager.APayout.row.e; }
        }
        if (mostFrequent == Manager.BPayout.ID + 1 && count != 0)
        {
            if (mostFrequent == 3) { payout = Manager.BPayout.row.c; }
            else if (mostFrequent == 4) { payout = Manager.BPayout.row.d; }
            else if (mostFrequent == 5) { payout = Manager.BPayout.row.e; }
        }

        if (mostFrequent == Manager.CPayout.ID + 1 && count != 0)
        {
            if (mostFrequent == 3) { payout = Manager.CPayout.row.c; }
            else if (mostFrequent == 4) { payout = Manager.CPayout.row.d; }
            else if (mostFrequent == 5) { payout = Manager.CPayout.row.e; }
        }
        if (mostFrequent == Manager.DPayout.ID + 1 && count != 0)
        {
            if (mostFrequent == 3) { payout = Manager.DPayout.row.c; }
            else if (mostFrequent == 4) { payout = Manager.DPayout.row.d; }
            else if (mostFrequent == 5) { payout = Manager.DPayout.row.e; }
        }
        if (mostFrequent == Manager.EPayout.ID + 1 && count != 0)
        {
            if (mostFrequent == 3) { payout = Manager.EPayout.row.c; }
            else if (mostFrequent == 4) { payout = Manager.EPayout.row.d; }
            else if (mostFrequent == 5) { payout = Manager.EPayout.row.e; }
        }
        if (mostFrequent == Manager.FPayout.ID + 1 && count != 0)
        {
            if (mostFrequent == 3) { payout = Manager.FPayout.row.c; }
            else if (mostFrequent == 4) { payout = Manager.FPayout.row.d; }
            else if (mostFrequent == 5) { payout = Manager.FPayout.row.e; }
        }
        if (mostFrequent == Manager.GPayout.ID + 1 && count != 0)
        {
            if (mostFrequent == 3) { payout = Manager.GPayout.row.c; }
            else if (mostFrequent == 4) { payout = Manager.GPayout.row.d; }
            else if (mostFrequent == 5) { payout = Manager.GPayout.row.e; }
        }
        if (mostFrequent == Manager.HPayout.ID + 1 && count != 0)
        {
            if (mostFrequent == 3) { payout = Manager.HPayout.row.c; }
            else if (mostFrequent == 4) { payout = Manager.HPayout.row.d; }
            else if (mostFrequent == 5) { payout = Manager.HPayout.row.e; }
        }
        if (mostFrequent == Manager.IPayout.ID + 1 && count != 0)
        {
            if (mostFrequent == 3) { payout = Manager.IPayout.row.c; }
            else if (mostFrequent == 4) { payout = Manager.IPayout.row.d; }
            else if (mostFrequent == 5) { payout = Manager.IPayout.row.e; }
        }
        if (mostFrequent == Manager.IPayout.ID + 1 && count != 0)
        {
            if (mostFrequent == 3) { payout = Manager.JPayout.row.c; }
            else if (mostFrequent == 4) { payout = Manager.JPayout.row.d; }
            else if (mostFrequent == 5) { payout = Manager.JPayout.row.e; }
        }

    }

    public void Payout()
    {
        Manager.TotalMoney = Manager.TotalMoney+ (payout * Manager.currentBet);
        payout = 0;
    }

    IEnumerator SpinWheel(float rotationAmount)
    {
        isSpinning = true;
        float spinTime = rotationAmount / spinSpeed; // calculate the time it takes to spin based on the speed and rotation amount
        float elapsedTime = 0f;
        while (elapsedTime < spinTime)
        {
            float spinAngle = Mathf.Lerp(0f, rotationAmount, elapsedTime / spinTime); // calculate the current angle of rotation
            wheelTransform.Rotate(new Vector3(0, 0, spinAngle)); // rotate the wheel by the current angle
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        isSpinning = false;

        // Snap the wheel to the nearest center point between two sides of a decagon
        Vector3 currentRotation = wheelTransform.eulerAngles;
        float snapRotation = Mathf.Round(currentRotation.z / 36f) * 36f; // get the snapped rotation to the nearest 36 degrees (360 / 10)
        int snapIndex = Mathf.RoundToInt(snapRotation / 36f); // calculate the index of the closest snap point based on the snapped rotation
        float snapAngle = snapIndex * 36f; // calculate the angle of the closest snap point based on the index
        float prevAngle = (snapIndex - 1) * 36f; // calculate the angle of the previous snap point based on the index
        float nextAngle = (snapIndex + 1) * 36f; // calculate the angle of the next snap point based on the index
        float deltaPrev = Mathf.Abs(currentRotation.z - prevAngle); // calculate the difference in angle between the current rotation and the previous snap point
        float deltaNext = Mathf.Abs(currentRotation.z - nextAngle); // calculate the difference in angle between the current rotation and the next snap point

        // If the current rotation is closer to the previous snap point than the next snap point, snap to the previous snap point. Otherwise, snap to the next snap point.
        if (deltaPrev < deltaNext)
        {
            snapRotation = prevAngle;
        }
        else
        {
            snapRotation = nextAngle;
        }

        wheelTransform.rotation = Quaternion.Euler(currentRotation.x, currentRotation.y, snapRotation);
    }
}
