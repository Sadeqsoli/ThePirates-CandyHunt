using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionCharacter : MonoBehaviour
{
    #region Public Variables
    public GameObject pnlChar;
    public GameObject panelLogin;
    public GameObject pnlSelection;

    #endregion

    #region Private Variables
    [SerializeField] private CharacterRepo charRepo; 
    [SerializeField] private CharacterManager charManager; 
    #endregion

    #region Public Methods
    public void YesBtn()
    {
        panelLogin.SetActive(true);
        pnlSelection.SetActive(false);
        pnlChar.SetActive(false);
    }
    public void HitNo()
    {
        pnlSelection.SetActive(false);
    }

    public void SelectingChar1()
    {
        charRepo.Push(100);
        charManager.CharSelecting();
        pnlSelection.SetActive(true);
    }
    public void SelectingChar2()
    {
        charRepo.Push(200);
        charManager.CharSelecting();
        pnlSelection.SetActive(true);
    }
    public void SelectingChar3()
    {
        charRepo.Push(300);
        charManager.CharSelecting();
        pnlSelection.SetActive(true);
    }
    public void SelectingChar4()
    {
        charRepo.Push(400);
        charManager.CharSelecting();
        pnlSelection.SetActive(true);
    }
    public void SelectingChar5()
    {
        charRepo.Push(500);
        charManager.CharSelecting();
        pnlSelection.SetActive(true);
    }
    public void SelectingChar6()
    {
        charRepo.Push(600);
        charManager.CharSelecting();
        pnlSelection.SetActive(true);
    }
    public void SelectingChar7()
    {
        charRepo.Push(700);
        charManager.CharSelecting();
        pnlSelection.SetActive(true);
    }
    public void SelectingChar8()
    {
        charRepo.Push(800);
        charManager.CharSelecting();
        pnlSelection.SetActive(true);
    }
    public void SelectingChar9()
    {
        charRepo.Push(900);
        charManager.CharSelecting();
        pnlSelection.SetActive(true);
    }
    public void SelectingChar10()
    {
        charRepo.Push(1000);
        charManager.CharSelecting();
        pnlSelection.SetActive(true);
    }
    public void SelectingChar11()
    {
        charRepo.Push(1100);
        charManager.CharSelecting();
        pnlSelection.SetActive(true);
    }
    public void SelectingChar12()
    {
        charRepo.Push(1200);
        charManager.CharSelecting();
        pnlSelection.SetActive(true);
    }
    #endregion

    #region Private Methods

    void Start()
    {

    }//Starttttt






    void LateUpdate()
    {

    }//Updateeeee

    #endregion
}//EndClasssss
