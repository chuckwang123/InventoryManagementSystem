using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace InventoryManagementSystem.Models
{
    [DataContract(Name = "Info", Namespace = "") ]
    public class APIInfo
    {
        [DataMember(Order = 1)]
        public string Controller { get; set; }
        [DataMember(Order = 2)]
        public string Version { get; set; }
        [DataMember(Order = 3)]
        public LinksDictionary<string,string> Links { get; set; } 
    }

    [Serializable]
    [CollectionDataContract(Name = "Links",KeyName = "Name",ValueName = "Link")]
    public class LinksDictionary<TKey, TValue> : Dictionary<TKey, TValue>
    {
        public LinksDictionary() { }
        public LinksDictionary(SerializationInfo s, StreamingContext c) : base(s, c) { } 
    }
}