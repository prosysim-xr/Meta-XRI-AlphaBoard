using System.Collections;
using TMPro;
using UnityEngine;
namespace sks.utility.keyboard {
    public class AlphaBoard : MonoBehaviour {
        [SerializeField] string text;
        [SerializeField] TextMeshPro displayWord;

        //Unity Callbacks
        private void OnEnable() {
            text = "";
            displayWord.text = text;//Clear the text
        }
        public void HandleAlphabet(GameObject alphabet) {

            if (text.Length < 10) {
                text += alphabet.name;
            }
            displayWord.text = text;
        }
        public void HandleBackspace() {
            if (text.Length > 0) {
                text = text.Remove(text.Length - 1);
            }
            displayWord.text = text;
        }
        public void HandleClear() {
            text = "";
            displayWord.text = text;
        }
        public void HandleSpace() {
            text += " ";
            displayWord.text = text;
        }
        public void HandleEnter() {
            StartCoroutine(HandleEnterCoroutine());

        }
        IEnumerator HandleEnterCoroutine() {
            //Disable the alpha board
            yield return new WaitForSeconds(1f);
            this.gameObject.SetActive(false);

            //Fire an event to pass the text
            Events.InvokeOnTextEntered(text);
        }
    }

    public class Events {
        public delegate void TextEntered(string text);
        public static event TextEntered OnTextEntered;
        public static void InvokeOnTextEntered(string text) {
            OnTextEntered?.Invoke(text);
        }
    }

}