﻿using TES3Lib.Base;
using Utility;

namespace TES3Lib.Subrecords.Shared
{
    /// <summary>
    /// AI Travel Package
    /// </summary>
    public class AI_T : Subrecord, IAIPackage
    {
        public float DestinationX { get; set; }

        public float DestinationY { get; set; }

        public float DestinationZ { get; set; }

        public int Unknown { get; set; }

        public AI_T()
        {

        }

        public AI_T(byte[] rawData) : base(rawData)
        {
            var reader = new ByteReader();
            DestinationX = reader.ReadBytes<float>(Data);
            DestinationY = reader.ReadBytes<float>(Data);
            DestinationZ = reader.ReadBytes<float>(Data);
            Unknown = reader.ReadBytes<int>(Data);
        }
    }
}