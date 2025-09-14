using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CCTV_manager : MonoBehaviour
{
    [Header("Button")]
    public Button[] cctv_Button;  
    
    [Header("cctv_Room")]
    public GameObject[] room;

    [Header("Text")]
    public TextMeshProUGUI textComponent;

    private int currentActiveRoom = -1;  // 현재 활성화된 방 인덱스

    private void Start()
    {
        for (int i = 0; i < cctv_Button.Length; i++)
        {
            int index = i;
            cctv_Button[i].onClick.AddListener(() => OnButtonClicked(index));
        }
        
        // 초기 상태 설정 (옵션)
        if (room.Length > 0)
        {
            OnButtonClicked(0);
        }
    }

    private void OnDestroy()
    {
        // 리스너 제거로 메모리 누수 방지
        for (int i = 0; i < cctv_Button.Length; i++)
        {
            int index = i;
            cctv_Button[i].onClick.RemoveListener(() => OnButtonClicked(index));
        }
    }

    private void OnButtonClicked(int index)
    {
        // 같은 방을 다시 클릭한 경우 무시
        if (currentActiveRoom == index)
            return;
            
        // 이전 방은 비활성화
        if (currentActiveRoom >= 0 && currentActiveRoom < room.Length)
        {
            room[currentActiveRoom].SetActive(false);
        }
        
        // 새 방만 활성화
        room[index].SetActive(true);
        currentActiveRoom = index;

        // 텍스트 변경 (문자열 캐싱 사용)
        textComponent.text = "Room_1_" + (index + 1);
    }
}