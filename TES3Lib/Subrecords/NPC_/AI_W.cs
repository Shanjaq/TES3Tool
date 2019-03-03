﻿using TES3Lib.Base;
using Utility;

namespace TES3Lib.Subrecords.NPC_
{
    /// <summary>
    /// AI Wander Package
    /// </summary>
    public class AI_W : Subrecord
    {
        public short Distance { get; set; }

        public short Duration { get; set; }

        public byte TimeOfDay { get; set; }

        /// <summary>
        /// Idle 2-9 chances
        /// </summary>
        public byte[] Idle { get; set; }

        /// <summary>
        /// Default 1?
        /// </summary>
        public byte Unknown { get; set; }

        public AI_W()
        {

        }

        public AI_W(byte[] rawData) : base(rawData)
        {
            var reader = new ByteReader();
            Distance = reader.ReadBytes<short>(base.Data);
            Duration = reader.ReadBytes<short>(base.Data);
            TimeOfDay = reader.ReadBytes<byte>(base.Data);
            Idle = reader.ReadBytes<byte[]>(base.Data, 8);
            Unknown = reader.ReadBytes<byte>(base.Data);
        }
    }
}