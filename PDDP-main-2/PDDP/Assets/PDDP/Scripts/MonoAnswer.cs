using UnityEngine;
using System.Collections;

namespace PDDP
{

    public class MonoAnswer : MonoBehaviour
    {
        public Answer answer;
        public MAccount account;
        public MChallenge mchallenge; 

        public void CheckAnswer()
        {
            if (answer.isCorrect)
            {
                account.loggedUser.challenges.Add(mchallenge.chosedChallenge);
                mchallenge.Unload();
                mchallenge.Load();
            }
            else
            {
                mchallenge.Unload();
                mchallenge.Load();
            }

        }
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
