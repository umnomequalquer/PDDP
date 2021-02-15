using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;

namespace PDDP {

    public class MAccount : MonoBehaviour {
        [Header ("Profile")]
        public SVGImage pPicture;
        public TextMeshProUGUI pUsername;
        public TextMeshProUGUI pBio;

        [Header ("Sign In")]
        public TextMeshProUGUI iEmail;
        public TextMeshProUGUI iPassword;

        [Header("Sign Up")]
        public TextMeshProUGUI uUsername;
        public TextMeshProUGUI uEmail;
        public TextMeshProUGUI uPassword;

        [Header ("Window")]
        public GameObject homeWindow;
        public GameObject signInWindow;
        public GameObject signUpWindow;

        [Header ("DB")]
        public UCollection userDB;

        [NonSerialized] public User loggedUser;

        public void SignIn () {
            if (iEmail.text.Length < 3 || iPassword.text.Length < 3)
                return;

            foreach (User user in userDB.users) {
                if (user.email == iEmail.text && user.password == iPassword.text) {
                    loggedUser = user;

                    signInWindow.SetActive (false);
                    homeWindow.SetActive (true);
                    break;
                }
            }

            Log ();

        } // SignIn

        public void SignUp () {
            if (uUsername.text.Length < 3 || uEmail.text.Length < 3 || uPassword.text.Length < 3)
                return;

            bool canCreate = false;
            foreach(User user in userDB.users) {
                if (user.email != uEmail.text)
                    canCreate = true;

                if (canCreate)
                    break;
            }

            if (!canCreate)
                return;

            User newUser = new User ();
            newUser.username = uUsername.text;
            newUser.email = uEmail.text;
            newUser.password = uPassword.text;
            userDB.users.Add (newUser);
            loggedUser = newUser;

            signUpWindow.SetActive(false);
            homeWindow.SetActive(true);

            Log ();

        } // SignUp

        public void Log () {
            pPicture.sprite = loggedUser.picture;
            pUsername.text = loggedUser.username;
            pBio.text = loggedUser.bio;
        } // LogOut

    } // Class MAccount

} // Namespace PDDP