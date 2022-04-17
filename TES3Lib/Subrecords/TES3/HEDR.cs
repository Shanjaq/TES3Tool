﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TES3Lib.Base;
using Utility;

namespace TES3Lib.Subrecords.TES3
{
    public class HEDR : Subrecord
    {

        public float Version { get; set; }

        /// <summary>
        /// 1 - ESM ; 0 - ESP
        /// </summary>
        public int ESMFlag { get; set; }

        public string CompanyName { get; set; }

        public string Description { get; set; }

        public int NumRecords { get; set; }

        public HEDR()
        {
        }

        public HEDR(byte[] rawData) : base(rawData)
        {
            var reader = new ByteReader();
            Version = reader.ReadBytes<float>(base.Data);
            ESMFlag = reader.ReadBytes<int>(base.Data);
            CompanyName = reader.ReadBytes<string>(base.Data, 32);
            Description = reader.ReadBytes<string>(base.Data, 256);
            NumRecords = reader.ReadBytes<int>(base.Data);
        }

        public override byte[] SerializeSubrecord()
        {
            //being lazy here...
            byte[] nameBytes = new byte[32];
            byte[] descBytes = new byte[256];
            Encoding.ASCII.GetBytes(CompanyName).CopyTo(nameBytes, 0);
            Encoding.ASCII.GetBytes(Description).CopyTo(descBytes, 0);


            List<byte> data = new();
            data.AddRange(BitConverter.GetBytes(Version));
            data.AddRange(BitConverter.GetBytes(ESMFlag));
            data.AddRange(nameBytes);
            data.AddRange(descBytes);
            data.AddRange(BitConverter.GetBytes(NumRecords));

            var serialized = Encoding.ASCII.GetBytes(GetType().Name)
               .Concat(BitConverter.GetBytes(data.Count))
               .Concat(data).ToArray();
            return serialized;
        }
    }
}