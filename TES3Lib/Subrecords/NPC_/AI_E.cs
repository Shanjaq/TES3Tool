﻿using TES3Lib.Base;
using Utility;

namespace TES3Lib.Subrecords.NPC_
{
    /// <summary>
    /// AI Escort Package
    /// </summary>
    public class AI_E : Subrecord
    {
        public float DestinationX { get; set; }

        public float DestinationY { get; set; }

        public float DestinationZ { get; set; }

        public short Duration { get; set; }

        public string CellDestination { get; set; }

        /// <summary>
        /// Unknown (0100?)
        /// </summary>
        public int Unknown { get; set; }

        public AI_E()
        {

        }

        public AI_E(byte[] rawData) : base(rawData)
        {
            var reader = new ByteReader();
            DestinationX = reader.ReadBytes<float>(base.Data);
            DestinationY = reader.ReadBytes<float>(base.Data);
            DestinationZ = reader.ReadBytes<float>(base.Data);
            CellDestination = reader.ReadBytes<string>(base.Data, 32);
            Unknown = reader.ReadBytes<int>(base.Data);
        }
    }
}