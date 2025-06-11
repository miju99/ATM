# ATM
> (같은 프로젝트에서 씬으로 구분하는 바람에 프로젝트 이름을 수정하지 못했습니다.)

Unity 인벤토리 구현하기

## 영상
- MainUI <-> StatusUI / InventoryUI

![Main](https://github.com/user-attachments/assets/fec886da-b0ff-48c9-9fc0-b089bef47aad)

- 장착 및 해제

![Equip](https://github.com/user-attachments/assets/f44aee5b-368b-450b-a61a-b397656245f4)

- 스테이터스 반영

![Status](https://github.com/user-attachments/assets/c8335f98-7690-4123-8cd3-85fe5dbf4221)

## 설치 방법
`https://github.com/miju99/ATM.git`
> Unity 2022.3.17f1 이상에서 테스트됨

## 사용 방법
- 마우스 클릭

## 주요 기능
- UIMainMenu
  - 플레이어 아이디, 레벨, 자금 표시
  - 스테이터스, 인벤토리 화면으로 전환 버튼 제공
- UIStatus
  - 플레이어 공격력, 방어력, 체력, 치명타 수치 표시
  - 장착 아이템의 스탯 효과 반영
- UiInventory
  - 아이템 슬롯 표시 및 동적 생성 (11개 슬롯)
  - 인벤토리에 담긴 아이템 리스트 표시
  - 아이템 선택 시 장착 혹은 해제 가능
  - 장착 상태 표시 아이콘(Emotion) 활성화
- Item
  - ScriptableObject 기반 아이템 데이터 (공격력, 방어력, 체력, 치명타, 아이콘)
  - 인벤토리에 아이템 추가 및 제거
  - 장착 시 캐릭터 스탯에 아이템 수치 적용 및 해제
- Singletone
  - UI 각 화면(메인, 스테이터스, 인벤토리) 관리 및 전환
- Character
  - 플레이어 정보 및 아이템 인벤토리 관리
  - 장비 장착 및 해제 기능 내장

## 스크립트 구조
| 스크립트명                  | 역할                                |
| ---------------------- | --------------------------------- |
| `UIMainMenu`           | 메인 메뉴 UI 제어, 상태 및 인벤토리 버튼 연결      |
| `UIStatus`             | 플레이어 스탯 UI 표시 및 업데이트              |
| `UIInventory`          | 인벤토리 슬롯 생성 및 아이템 표시, 인벤토리 데이터와 연동 |
| `UISlot`               | 인벤토리 슬롯 UI 구성, 아이템 장착/해제 버튼 처리    |
| `UIManager`            | UI 화면 간 전환 및 싱글톤 관리               |
| `InventoryGameManager` | 플레이어 캐릭터 데이터 및 초기화, UI와 데이터 연결    |
| `Character`            | 플레이어 정보 및 인벤토리, 장착 상태 관리          |
| `Item`                 | 아이템 데이터 정의 (ScriptableObject)     |

## 기술 스택
  * 게임 엔진
    > Unity(Unity 2022.3.17f1)
  * 프로그래밍 언어
    > C#
