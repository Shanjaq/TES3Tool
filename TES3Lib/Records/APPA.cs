﻿using System.Diagnostics;
using TES3Lib.Base;
using TES3Lib.Subrecords.APPA;
using TES3Lib.Subrecords.Shared;

namespace TES3Lib.Records
{
    /// <summary>
    /// Alchemical apparatus Record
    /// </summary>
    [DebuggerDisplay("{NAME.EditorId}")]
    public class APPA : Record
    {
        /// <summary>
        /// EditorId
        /// </summary>
        public NAME NAME { get; set; }

        /// <summary>
        /// Model
        /// </summary>
        public MODL MODL { get; set; }

        /// <summary>
        /// Display name
        /// </summary>
        public FNAM FNAM { get; set; }

        /// <summary>
        /// Item properties
        /// </summary>
        public AADT AADT { get; set; }

        /// <summary>
        /// Icon
        /// </summary>
        public ITEX ITEX { get; set; }

        public SCRI SCRI { get; set; }

        public APPA()
        {
        }

        public APPA(byte[] rawData) : base(rawData)
        {
            BuildSubrecords();
        }
    }
}
