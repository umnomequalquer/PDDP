using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace PDDP
{

    public class MChallenge : MonoBehaviour
    {

        public Image imageHolder;
        public GameObject answerObject;
        public MAccount account;
        public MCollection collection;
        public RectTransform answerHolder;

        public List<Challenge>list = new List<Challenge>();
        private List<GameObject>answerList = new List<GameObject>();

        public TextMeshProUGUI question;
        public Challenge chosedChallenge; 

        public void Load()
        {
            foreach (Challenge challenges in collection.challengeDB.challenges)
            {
                if (account.loggedUser.challenges.Count >= 1)
                {
                   
                    bool canAdd = false;
                    foreach (Challenge challenge in account.loggedUser.challenges)
                    {
                        //Debug.Log("Challenge: " + challenges.uuid + " Challenger User: " + challenge.uuid);
                        if (challenges.uuid == challenge.uuid)
                        {
                            canAdd = false;
                        } else
                        {
                            canAdd = true;
                        }

                    }

                    if (canAdd == true)
                    {
                        list.Add(challenges);
                    }
                }
                else
                {
                    list.Add(challenges);
                }
            }

            int ran = 0;
            if (list.Count >= 2)
            {
                ran = Random.Range(0, list.Count);
            }

            chosedChallenge = list[ran];

            imageHolder.sprite = chosedChallenge.icon;
            question.text = chosedChallenge.question;

            foreach (Answer answer in chosedChallenge.answers)
            {
            
                GameObject answerObj = Instantiate(answerObject);
                answerObj.transform.SetParent(answerHolder);
                answerObj.transform.GetComponent<MonoChallenge>().text.text = answer.text;
                answerObj.transform.GetComponent<MonoAnswer>().account = account;
                answerObj.transform.GetComponent<MonoAnswer>().mchallenge = this;
                answerObj.transform.GetComponent<MonoAnswer>().answer = answer;
                answerList.Add(answerObj);
            }
        }

        public void Unload()
        {
            imageHolder.sprite = null;

            foreach (GameObject answer in answerList)
            {
                Destroy(answer);
            }

            chosedChallenge = new Challenge();
            answerList.Clear();
            list.Clear();
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}