﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TES3Lib.Base;
using Utility;

namespace TES3Lib.Subrecords.PGRD
{
    public class PGRC : Subrecord
    {
        /// <summary>
        /// Edges
        /// Defines n points that are connected to m-th point from PGRP subrecord
        /// where ammount of n is defined in PGRP.Point.EdgeCount property of point
        /// and m is indice of point in PGRP.Point
        /// </summary>
        public int[] Edges { get; set; }

        public PGRC()
        {

        }

        public PGRC(byte[] rawData) : base(rawData)
        {
            var reader = new ByteReader();
            Edges = new int[base.Data.Length / sizeof(int)];


            for (int i = 0; i < Edges.GetLength(0); i++)
            {
                Edges[i] = reader.ReadBytes<int>(base.Data);
            }

        }

        public override byte[] SerializeSubrecord()
        {
            List<byte> data = new();

            for (int i = 0; i < Edges.GetLength(0); i++)
            {
                data.AddRange(ByteWriter.ToBytes(Edges[i], typeof(int)));
            }

            var serialized = Encoding.ASCII.GetBytes(this.GetType().Name)
               .Concat(BitConverter.GetBytes(data.Count))
               .Concat(data).ToArray();
            return serialized;
        }
    }
}
