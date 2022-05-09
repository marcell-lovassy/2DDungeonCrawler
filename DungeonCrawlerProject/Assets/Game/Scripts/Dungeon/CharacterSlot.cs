using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Game.Dungeon
{
    public class CharacterSlot : MonoBehaviour
    {

        [Header("Character")]
        [SerializeField]
        DungeonCharacter _character;

        [Header("Neighbours")]
        [SerializeField]
        CharacterSlot leftNeighbourSlot;

        [SerializeField]
        CharacterSlot rightNeighbourSlot;

        [SerializeField]
        [Range(1f, 3f)]
        float movementReactionSpeed = 1f;

        private float maxNeighbourDistance;
        private float minNeighbourDistance;

        private void Update()
        {
            if(rightNeighbourSlot != null)
            {
                if((rightNeighbourSlot.transform.position - transform.position).x > maxNeighbourDistance)
                {
                    FollowNeighbour();
                }

                if ((rightNeighbourSlot.transform.position - transform.position).x < minNeighbourDistance)
                {
                    StepBack();
                }
            }
        }

        internal void SetCharacter(DungeonCharacter character)
        {
            if (character == null) return;
            _character = Instantiate(character, this.transform);
            SetCharacterPosition();
        }

        private void SetCharacterPosition()
        {
            _character.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.transform.position.z);
        }

        public void SetDistances(float min, float max)
        {
            minNeighbourDistance = min;
            maxNeighbourDistance = max;
        }
        private void FollowNeighbour()
        {
            Vector2 followPosition = Vector2.Lerp(transform.position, rightNeighbourSlot.transform.position, Time.deltaTime * movementReactionSpeed);
            transform.position =  new Vector3(followPosition.x, followPosition.y, transform.position.z);
        }

        private void StepBack()
        {
            Vector3 stepBackDelta = transform.position - new Vector3(minNeighbourDistance, 0, 0);
            Vector2 stepBackPosition = Vector2.Lerp(transform.position, stepBackDelta, Time.deltaTime * movementReactionSpeed);
            transform.position = stepBackPosition;
        }

        
    }
}
