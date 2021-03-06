﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace EFSamurai.Domain
{
    public class Samurai
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<Quote> QuotesCollection { get; set; }
        public HairStyle? HairStyle { get; set; }
        public SecretIdentity SecretIdentity { get; set; }
        public ICollection<SamuraiBattle> SamuraiBattle { get; set; }
    }
}
