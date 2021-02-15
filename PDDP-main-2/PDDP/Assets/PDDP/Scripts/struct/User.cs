using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PDDP {

    [System.Serializable]
    public struct User {
        [Header ("Account")]
        public int uuid;
        public Sprite picture;
        public string username;
        public string email;
        public string password;
        public string bio;
        [Header("Gameplay")]
        public int level;
        public List<Achievement> achievements;
        public List<Challenge> challenges;
        public List<Task> tasks;
    } // Struct User

} // Namespace PDDP