using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] private PlayerSO playerOne, playerTwo;
    [SerializeField] private CinemachineVirtualCamera playerOneCam;
    [SerializeField] private CinemachineVirtualCamera playerTwoCam;
    [SerializeField] private GameManagerSO gM;
    [SerializeField] private Transform playerOneCarPos;
    [SerializeField] private Transform playerTwoCarPos;
    [SerializeField] private GameObject[] badCars;
    [SerializeField] private GameObject[] baseCars;
    [SerializeField] private GameObject[] midCars;
    [SerializeField] private GameObject duckCar;

    private List<GameObject> usedCars = new List<GameObject>();

    private List<Ranks> playerRank = new List<Ranks>();

    private void OnEnable ()
    {
        foreach (Ranks rank in gM.PlayerRanks)
        {
            AnalizePlayerRank(rank);
        }
    }

    private void OnDisable ()
    {
        
    }

    private void AnalizePlayerRank (Ranks currentRank)
    {
        bool aux = true; 
        if (currentRank == Ranks.Good)
        {
            Transform targetTranform = playerRank.Count == 0 ? playerOneCarPos : playerTwoCarPos;
            Instantiate(duckCar, targetTranform.position, Quaternion.identity);
            playerRank.Add(currentRank);
            SetCarVar(duckCar, playerRank.Count);
            usedCars.Add(duckCar);
            return;
        }

        if (currentRank == Ranks.Medium)
        {
            while (aux)
            {
                int index = Random.Range(0, midCars.Length);
                if (!usedCars.Contains(midCars[index]))
                {
                    Transform targetTranform = playerRank.Count == 0 ? playerOneCarPos : playerTwoCarPos;
                    Instantiate(midCars[index], targetTranform.position, Quaternion.identity);
                    playerRank.Add(currentRank);
                    SetCarVar(midCars[index], playerRank.Count);
                    usedCars.Add(midCars[index]);
                    aux = !aux;
                    return;
                }  //si el gO que he sacado no lo tiene el otro player salgo del while
            }
        }
        
        if (currentRank == Ranks.Base)
        {
            
            while (aux)
            {
                int index = Random.Range(0, baseCars.Length);
                if (!usedCars.Contains(baseCars[index]))
                {
                    Transform targetTranform = playerRank.Count == 0 ? playerOneCarPos : playerTwoCarPos;
                    Instantiate(baseCars[index], targetTranform.position, Quaternion.identity);
                    playerRank.Add(currentRank);
                    SetCarVar(baseCars[index], playerRank.Count);
                    usedCars.Add(baseCars[index]);
                    aux = !aux;
                    return;
                }  //si el gO que he sacado no lo tiene el otro player salgo del while
            }
            
        }
        while (aux)
        {
            int index = Random.Range(0, badCars.Length);
            if (!usedCars.Contains(badCars[index]))
            {
                Transform targetTranform = playerRank.Count == 0 ? playerOneCarPos : playerTwoCarPos;
                Instantiate(badCars[index], targetTranform.position, Quaternion.identity);
                playerRank.Add(currentRank);
                SetCarVar(badCars[index], playerRank.Count);
                usedCars.Add(badCars[index]);
                aux = !aux;
                return;
            }  //si el gO que he sacado no lo tiene el otro player salgo del while
        }
    }

    private void SetCarVar(GameObject currentcar, int playerIndex)
    {
        CarMain currentCarSc = currentcar.GetComponent<CarMain>();

        PlayerSO playerSo = playerIndex == 1 ? playerOne : playerTwo;
        currentCarSc.SetIDCar(playerSo);

        if (playerSo == playerOne)
        {
            playerOneCam.Follow = currentCarSc.transform;
            playerOneCam.LookAt = currentCarSc.transform;
        }
        else if (playerSo == playerTwo)
        {
            playerTwoCam.Follow = currentCarSc.transform;
            playerTwoCam.LookAt = currentCarSc.transform;
        }
    }
}
