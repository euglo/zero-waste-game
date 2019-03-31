using UnityEngine;
using System.Collections;


namespace TMPro.Examples
{
    
    public class TeleType : MonoBehaviour
    {


        //[Range(0, 100)]
        //public int RevealSpeed = 50;

        private string label01 = "Los Angeles  is  a  city  filled  with  waste.  You,  a  sustainability  enthusiast,  have  been  tasked  with  cleaning  up  LA. Your  job  is  to  pick  up  all  recyclable  materials,  destroying  any  garbage  along  the  way,  until  you  clean   your  way  up  to  UCLA. Remember:  #ZeroWasteBy2020!  Are  you  up  to  the  challenge?";
        private string label02 = "Los Angeles  is  a  city  filled  with  waste.  You,  a  sustainability  enthusiast,  have  been  tasked  with  cleaning  up  LA. Your  job  is  to  pick  up  all  recyclable  materials,  destroying  any  garbage  along  the  way,  until  you  clean   your  way  up  to  UCLA. Remember:  #ZeroWasteBy2020!  Are  you  up  to  the  challenge?";


        private TMP_Text m_textMeshPro;


        void Awake()
        {
            // Get Reference to TextMeshPro Component
            m_textMeshPro = GetComponent<TMP_Text>();
            m_textMeshPro.text = label01;
            m_textMeshPro.enableWordWrapping = true;
            m_textMeshPro.alignment = TextAlignmentOptions.Top;



            //if (GetComponentInParent(typeof(Canvas)) as Canvas == null)
            //{
            //    GameObject canvas = new GameObject("Canvas", typeof(Canvas));
            //    gameObject.transform.SetParent(canvas.transform);
            //    canvas.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;

            //    // Set RectTransform Size
            //    gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(500, 300);
            //    m_textMeshPro.fontSize = 48;
            //}


        }


        IEnumerator Start()
        {

            // Force and update of the mesh to get valid information.
            m_textMeshPro.ForceMeshUpdate();


            int totalVisibleCharacters = m_textMeshPro.textInfo.characterCount; // Get # of Visible Character in text object
            int counter = 0;
            int visibleCount = 0;

            while (true)
            {
                visibleCount = counter % (totalVisibleCharacters + 1);

                m_textMeshPro.maxVisibleCharacters = visibleCount; // How many characters should TextMeshPro display?

                // Once the last character has been revealed, wait 1.0 second and start over.
                if (visibleCount >= totalVisibleCharacters)
                {
                    yield return new WaitForSeconds(100000000000000000000000.0f);
                    m_textMeshPro.text = label02;
                }

                counter += 1;

                yield return new WaitForSeconds(0.05f);
            }

            //Debug.Log("Done revealing the text.");
        }

    }
}