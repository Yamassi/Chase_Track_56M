using UnityEngine.UI;

namespace Orion.System
{
    public static class ArrayExtensions
    {
        public static void SetActiveOneElement(this Image[] array, int index)
        {
            for (var i = 0; i < array.Length; i++)
            {
                array[i].gameObject.SetActive(i == index);
            }
        }

        public static void SetActiveLowerElements(this Image[] array, int index)
        {
            for (var i = 0; i < array.Length; i++)
            {
                array[i].gameObject.SetActive(i < index);
            }
        }
    }
}