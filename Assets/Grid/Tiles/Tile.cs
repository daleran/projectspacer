﻿using UnityEngine;
using System.Collections.Generic;

namespace ProjectSpacer
{

    public class Tile
    {

        public Info TileInfo = GV.defaultInfo;

        public State Active = State.IDLE;
        public State Enabled = State.ENABLED;
        public State DamageState = State.UNDAMAGED;

        public Direction direction = Direction.UP;
        public bool flipped = false;

        public CollisionLayer collisionLayer = CollisionLayer.ENTITY;


        public List<Stat> tileStats = new List<Stat>();
        public List<QuadData> tileQuads = new List<QuadData>();
        public List<GameObject> TileEffects = new List<GameObject>();

        public delegate void TileStateEvent(Tile tile, State newState);
        public delegate void TileStatEvent(Tile tile, Stat newStat);

        public Tile(Info info, Direction direct, bool flipUV, CollisionLayer colLayer, List<Stat> stats, List<QuadData> quads, List<GameObject> effects)
        {

            TileInfo = info;
            direction = direct;
            flipped = flipUV;
            collisionLayer = colLayer;
            tileStats = stats;
            tileQuads.AddRange(quads);
            TileEffects.AddRange(effects);

        }

        public void SetActive(bool state)
        {
            if (Enabled == State.ENABLED)
            {
                if (state == true)
                    Active = State.ACTIVE;
                else
                    Active = State.IDLE;
            }
                
        }

        public void SetEnable (bool state)
        {
            if (state == true)
            {
                Enabled = State.ENABLED;
            }
            else
            {
                Enabled = State.DISABLED;
                Active = State.IDLE;
            }
        }

        public void SetDamageState (State state)
        {
            switch (state)
            {
                case State.UNDAMAGED:
                    DamageState = State.UNDAMAGED;
                    break;
                case State.DAMAGED:
                    DamageState = State.DAMAGED;
                    break;
                case State.BROKEN:
                    DamageState = State.BROKEN;
                    Enabled = State.DISABLED;
                    Active = State.IDLE;
                    break;
                case State.DESTORYED:
                    DamageState = State.DESTORYED;
                    Enabled = State.DISABLED;
                    Active = State.IDLE;
                    break;
                default:
                    Debug.LogError("PS ERROR: " + state + " not a valid damage state.");
                    break;

            }
        }


        public void RotateTile(Direction dir)
        {

        }

        public void FlipTile()
        {

        }

    }
}
