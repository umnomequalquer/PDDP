using UnityEngine;
using System.Collections;

namespace PDDP {

    public class MenuUtil : MonoBehaviour {

        private const string PDDP = "PDDP";

        private const string COLLECTION = "Collection";
        private const string ACHIEVEMENT = "Achievement";
        private const string CHALLENGE = "Challenge";
        private const string TASK = "Task";
        private const string USER = "User";

        private const string COLLECTION_MENU = PDDP + "/" + COLLECTION;
        public const string ACHIEVEMENT_COLLECTION = COLLECTION_MENU + "/" + ACHIEVEMENT;
        public const string CHALLENGE_COLLECTION = COLLECTION_MENU + "/" + CHALLENGE;
        public const string COLLECTION_COLLECTION = COLLECTION_MENU + "/" + COLLECTION;
        public const string TASK_COLLECTION = COLLECTION_MENU + "/" + TASK;
        public const string USER_COLLECTION = COLLECTION_MENU + "/" + USER;


        private const string PROGRESS = "Progress";
        private const string RADIAL = "Radial";
        private const string LINEAR = "Linear";

        public const string PROGRESS_MENU = PDDP + "/" + PROGRESS;
        public const string LINEAR_ITEM = PROGRESS_MENU + "/" + LINEAR;
        public const string RADIAL_ITEM = PROGRESS_MENU + "/" + RADIAL;

    } // Class MenuUtil

} // Namespace pddp