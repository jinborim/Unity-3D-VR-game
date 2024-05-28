using System.Collections;
using UnityEngine;



    //Add this script to any object
    public class StaticCoroutine : MonoBehaviour {

        /// <summary>
        /// It can't be used in Awake method, It cause null referance exception.
        /// If you want to use it in Awake method, you have to adjust 'Script Execution Order'.
        /// </summary>

        private static StaticCoroutine instance;
        private void Awake () => instance = this;

        /* Can use the Coroutine in static method */
        public static void Start (IEnumerator routine) {
            instance.StartCoroutine (routine);
        }

        //Need MonoBehaviour target which has Coroutine method
        public static void Start (MonoBehaviour behaviour, string routineName) {
            behaviour.StartCoroutine (routineName);
        }

        public static void Start (MonoBehaviour behaviour, string routineName, object value) {
            behaviour.StartCoroutine (routineName, value);
        }
    }

