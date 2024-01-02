using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Click : MonoBehaviour
{
    [SerializeField] private GameObject scooter = null;
    [SerializeField] private GameObject selection = null;

    private Button button;

    public void Clicked()
    {
        button = gameObject.GetComponent<Button>();
        button.onClick.Invoke();
    }
    public void Move2Next_P()
    {
        Notification.text_num += 1; 
    }

    public void Move2Back_P()
    {
        Notification.text_num -= 1;
    }

    public void Selecct_Num()
    {
        int selected_num = int.Parse(gameObject.name.Split('_')[1]);
        scooter.GetComponent<ElectricScooter>().RouteChoice = true;
        scooter.GetComponent<ElectricScooter>().RouteSelection = selected_num;

        scooter.SetActive(true);
        Debug.Log("선택된 루트는" + selected_num); 
        gameObject.transform.parent.gameObject.SetActive(false);
        
    }

    public void Restart()
    {
        //scooter.SetActive(true);
        selection.SetActive(true);    
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
