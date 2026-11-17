namespace UnitSkills.Features.Gameplay
{
    using UnitSkills.Features.Character;
    using UnitSkills.Features.Enemies;
    using UnitSkills.Features.Installer;
    using Unity.Cinemachine;
    using UnityEngine;

    /// <summary>
    /// Начинает и завершает один игровой забег
    /// </summary>
    public class GameSession : MonoBehaviour
    {
        [SerializeField] protected CinemachineCamera cinemachine;
        [SerializeField] protected CharacterFacade playerPrefab;
        [SerializeField] protected Transform playerSpawnPoint;
        [SerializeField] protected FacadeInstaller playerInstaller;

        private void Start()
        {
            CharacterFacade character = Instantiate(playerPrefab, playerSpawnPoint.position, Quaternion.identity);
            playerInstaller.Install(character);
            cinemachine.Follow = character.transform;
        }
    }
}
