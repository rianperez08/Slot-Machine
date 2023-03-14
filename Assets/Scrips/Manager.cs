using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Linq;
using UnityEngine;
using static RouletteWheel;
using UnityEngine.UI;
public class Manager : MonoBehaviour
{
    public static float TotalMoney;
    public Text MoneyText;
    public static (int id, int data) D1,D2,D3,D4,D5;
    public static float currentBet = 0;
    public Text BetText;
    public static (int ID, string name, (int a, int b, int c, int d, int e) row ) APayout;
    public static (int ID, string name, (int a, int b, int c, int d, int e) row) BPayout;
    public static (int ID, string name, (int a, int b, int c, int d, int e) row) CPayout;
    public static (int ID, string name, (int a, int b, int c, int d, int e) row) DPayout;
    public static (int ID, string name, (int a, int b, int c, int d, int e) row) EPayout;
    public static (int ID, string name, (int a, int b, int c, int d, int e) row) FPayout;
    public static (int ID, string name, (int a, int b, int c, int d, int e) row) GPayout;
    public static (int ID, string name, (int a, int b, int c, int d, int e) row) HPayout;
    public static (int ID, string name, (int a, int b, int c, int d, int e) row) IPayout;
    public static (int ID, string name, (int a, int b, int c, int d, int e) row) JPayout;
    void Start()
    {

        APayout = (0, "A", (0, 0, 1, 5, 10));
        BPayout = (1, "B", (0, 0, 2, 8, 25));
        CPayout = (2, "C", (0, 0, 3, 10, 50));
        DPayout = (3, "D", (0, 0, 4, 15, 75));
        EPayout = (4, "E", (0, 0, 5, 20, 100));
        FPayout = (5, "F", (0, 0, 10, 50, 250));
        GPayout = (6, "G", (0, 0, 20, 100, 500));
        HPayout = (7, "H", (0, 0, 50, 200, 1000));
        IPayout = (8, "I", (0, 0, 100, 500, 5000));
        JPayout = (9, "J", (0, 0, 250, 1000, 10000));
        TotalMoney = 1000;

        
    }

    // Update is called once per frame
    void Update()
    {
        MoneyText.text = TotalMoney.ToString();
        BetText.text = currentBet.ToString();
    }

    public void Bet1()
    {
        currentBet = 1;
    }

    public void Bet10()
    {
        currentBet = 10;
    }

    public void Bet50()
    {
        currentBet = 50;
    }

    public void Bet100()
    {
        currentBet = 100;
    }
    public void Catch(int ID, int Data)
    {
       if(ID == 0) { D1 = (ID, Data); }
       if (ID == 1) { D2 = (ID, Data); }
       if (ID == 2) { D3 = (ID, Data); }
       if (ID == 3) { D4 = (ID, Data); }
       if (ID == 4) { D5 = (ID, Data); }
    } 
}
