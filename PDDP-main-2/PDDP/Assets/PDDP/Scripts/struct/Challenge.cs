using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PDDP {

    [System.Serializable]
    public struct Challenge {
        public int uuid;
        public Sprite icon;
        public AudioClip clip;
        public string title;
        public string question;
        public Mode mode;
        public AnswerType answerType;
        public List<Answer> answers;
        public Status status;
    } // Struct Challenge

} // Namespace PDDP