using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
namespace sks.utility.keyboard {
    public class AddCharactersUtility : MonoBehaviour {
        [SerializeField] List<Transform> chars;
        // Start is called before the first frame update
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }

        [ContextMenu(nameof(AddCharacters))]
        public void AddCharacters() {
            if (chars != null) {
                foreach (var c in chars) {
                    c.GetChild(1).GetChild(0).GetChild(1).GetComponent<TextMeshPro>().text = c.name;
                }
            }
        }
    }
}
