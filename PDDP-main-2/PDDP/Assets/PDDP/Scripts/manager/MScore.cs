using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace PDDP {

    [ExecuteInEditMode]
    public class MScore : MonoBehaviour {

        [Header ("UsAccounter")]
        public int completedAchievements;
        public int completedChallenges;
        public int completedTasks;

        [Header("System")]
        public int numberOfAchieviements;
        public int numberOfChallenges;
        public int numberOfTasks;

        [Header("Collections")]
        public MCollection collection;
        public MAccount account;

        [Header ("Home Score")]
        public GameObject hChart;
        public GameObject tChart;
        public GameObject sChartT;
        public GameObject sChartC;

        public void CalculateDataCollections () {
            numberOfAchieviements = collection.achievementDB.achievements.Count;
            numberOfChallenges = collection.challengeDB.challenges.Count;
            numberOfTasks = collection.taskDB.tasks.Count;

            completedAchievements = account.loggedUser.achievements.Count;
            completedChallenges = account.loggedUser.challenges.Count;
            completedTasks = account.loggedUser.tasks.Count;

            hChart.transform.GetComponent<ProgressBar> ().maximun = numberOfAchieviements + numberOfChallenges + numberOfTasks;
            hChart.transform.GetComponent<ProgressBar> ().current = completedAchievements + completedChallenges + completedTasks;

            sChartT.transform.GetComponent<ProgressBar> ().maximun = numberOfTasks;
            sChartT.transform.GetComponent<ProgressBar> ().current = completedTasks;
            sChartT.transform.Find ("Text").GetComponent<TextMeshProUGUI> ().text = completedTasks  + "/" + numberOfTasks;

            sChartC.transform.GetComponent<ProgressBar> ().maximun = numberOfChallenges;
            sChartC.transform.GetComponent<ProgressBar> ().current = completedChallenges;
            sChartC.transform.Find ("Text").GetComponent<TextMeshProUGUI> ().text = completedChallenges + "/" + numberOfChallenges;

            tChart.transform.GetComponent<ProgressBar> ().maximun = numberOfTasks;
            tChart.transform.GetComponent<ProgressBar> ().current = completedTasks;
            tChart.transform.Find ("Text").GetComponent<TextMeshProUGUI> ().text = completedTasks + "/" + numberOfTasks;

            //foreach (Achievement achievement in account.loggedUser.achievements) {
            //    foreach (Achievement achievementS in collection.achievementDB.achievements) {
            //        if (achievementS.uuid == achievement.uuid) {
            //            if (achievement.status == Status.Complete)
            //                completedAchievements++;
            //        }
            //    }
            //}

        } // CalculateDataCollections


        public void Update () {
            CalculateDataCollections ();
        } // Update

    } // Class MScore

} // Namespace PDDP