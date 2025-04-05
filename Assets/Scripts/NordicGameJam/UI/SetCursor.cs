using UnityEngine;

namespace NordicGameJam.UI
{
    public class SetCursor : MonoBehaviour
    {
        [SerializeField] private Sprite _cursorSprite;

        private void Awake()
        {
            Cursor.SetCursor(_cursorSprite.texture, Vector2.zero, CursorMode.ForceSoftware);
        }
    }
}