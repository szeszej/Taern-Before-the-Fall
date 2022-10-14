using UnityEngine;
using UnityEngine.EventSystems;

public class CardZoom : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    private GameObject ZoomedCardField;

    public GameObject ZoomedCardPrefab;
    private GameObject ZoomedCard;

    public void OnPointerEnter(PointerEventData eventData)
    {
        ZoomedCard = Instantiate(ZoomedCardPrefab, transform.position, transform.rotation);
        ZoomedCard.GetComponent<DisplayCard>().displayCard = eventData.pointerEnter.GetComponent<DisplayCard>().displayCard;
        ZoomedCard.transform.SetParent(ZoomedCardField.transform);
        ZoomedCard.transform.localScale = new Vector3(2, 2, 2);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Destroy(ZoomedCard.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        ZoomedCardField = GameObject.Find("CardZoom");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
